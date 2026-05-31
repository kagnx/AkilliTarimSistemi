using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using AkilliTarimSistemi.Services;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLModel = AkilliTarimSistemi.ML.Models;

namespace AkilliTarimSistemi.UI
{
    public partial class TahminForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITarlaService _tarlaService;
        private List<ToprakAnalizi> _analizListesi = new();

        private PredictionEngine<GubreOnerisiData, MLModel.GubreOnerisiPrediction> _azotEngine;
        private PredictionEngine<GubreOnerisiData, MLModel.GubreOnerisiPrediction> _fosforEngine;
        private PredictionEngine<GubreOnerisiData, MLModel.GubreOnerisiPrediction> _potasyumEngine;
        private PredictionEngine<UrunTavsiyeData, MLModel.UrunTavsiyePrediction> _urunTavsiyeEngine;
        private PredictionEngine<GubreOnerisiData, MLModel.VerimTahminiPrediction> _verimTahminEngine;

        public TahminForm(IUnitOfWork unitOfWork, ITarlaService tarlaService)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _tarlaService = tarlaService;
            this.Load += (s, e) => { ModelleriHazirla(); VerileriYukle(); };
        }

        private void ModelleriHazirla()
        {
            try
            {
                var mlContext = new MLContext();
                var gubre = GubreOnerisiModelBuilder.LoadModels();
                _azotEngine = mlContext.Model.CreatePredictionEngine<GubreOnerisiData, MLModel.GubreOnerisiPrediction>(gubre.azot);
                _fosforEngine = mlContext.Model.CreatePredictionEngine<GubreOnerisiData, MLModel.GubreOnerisiPrediction>(gubre.fosfor);
                _potasyumEngine = mlContext.Model.CreatePredictionEngine<GubreOnerisiData, MLModel.GubreOnerisiPrediction>(gubre.potasyum);
                _urunTavsiyeEngine = mlContext.Model.CreatePredictionEngine<UrunTavsiyeData, MLModel.UrunTavsiyePrediction>(UrunTavsiyeModelBuilder.LoadModel());
                _verimTahminEngine = mlContext.Model.CreatePredictionEngine<GubreOnerisiData, MLModel.VerimTahminiPrediction>(VerimTahminiModelBuilder.LoadModel());
            }
            catch (Exception ex) { MessageBox.Show("Model yükleme hatası: " + ex.Message); }
        }

        private async void VerileriYukle()
        {
            _analizListesi = (await _unitOfWork.ToprakAnalizler.GetAllAsync()).ToList();
            cmbAnalizList.DataSource = _analizListesi.Select(a => new { Id = a.Id, Text = $"Analiz #{a.Id} - {a.Tarih.ToShortDateString()}" }).ToList();
            // ... (Diğer doldurma kodların aynı kalabilir)
        }

        private ToprakAnalizi? GetSeciliAnaliz() => _analizListesi.FirstOrDefault(a => a.Id == (int?)cmbAnalizList.SelectedValue);

        private async Task TahminKaydet(string tip, float val)
        {
            var analiz = GetSeciliAnaliz();
            if (analiz == null) return;
            // TahminGecmisi entity'ne göre burayı düzenle
            await _unitOfWork.CompleteAsync();
        }

        private void btnVerimTahmin_Click(object sender, EventArgs e)
        {
            var a = GetSeciliAnaliz();
            if (a == null || _verimTahminEngine == null) return;

            // MODELİN BEKLEDİĞİ TÜM ALANLAR BURAYA EKLENDİ
            var input = new GubreOnerisiData
            {
                pH = (float)a.pH,
                Azot_ppm = (float)a.Azot,
                Fosfor_ppm = (float)a.Fosfor,
                Potasyum_ppm = (float)a.Potasyum,
                OrganikMadde = (float)a.OrganikMadde,
                UrunTipi = Convert.ToSingle(cmbUrunVerim.SelectedValue),
                //GecmisVerim_kg = (float)a.Verim // ToprakAnalizi içinde bu alan varsa ekle
            };

            var sonuc = _verimTahminEngine.Predict(input).PredictedVerim;
            lblVerimSonuc.Text = $"{sonuc:F1} kg/Da";
        }
    }
}