using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.UnitOfWork;
using ClosedXML.Excel;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace AkilliTarimSistemi.UI
{
    public partial class RaporlamaForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public RaporlamaForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyNeonTheme(this);

            cmbRaporTipi.Items.Add("Toprak Analiz Raporu");
            cmbRaporTipi.Items.Add("Yaprak Analiz Raporu");
            cmbRaporTipi.Items.Add("Su Analiz Raporu");
            cmbRaporTipi.Items.Add("Tum Tarlalar Raporu");
            cmbRaporTipi.SelectedIndex = 0;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        public RaporlamaForm(IUnitOfWork unitOfWork) : this()
        {
            _unitOfWork = unitOfWork;
        }

        private async void btnExcelOlustur_Click(object sender, EventArgs e)
        {
            if (_unitOfWork == null)
            {
                MessageBox.Show("Veritabani baglantisi bulunamadi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sfd = new SaveFileDialog
            {
                Filter = "Excel Dosyasi|*.xlsx",
                Title = "Excel Rapor Kaydet",
                FileName = $"Rapor_{cmbRaporTipi.SelectedItem}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var dt = await RaporVerisiHazirlaAsync();
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Secili kategoride kayitli veri bulunamadi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ExcelOlustur(dt, sfd.FileName);
                    MessageBox.Show(
                        $"Excel raporu basariyla olusturuldu!\n\nDosya: {sfd.FileName}\nKayit Sayisi: {dt.Rows.Count}",
                        "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var onay = MessageBox.Show("Excel dosyasini acmak ister misiniz?", "Dosya Ac", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Excel olusturulurken hata olustu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnPdfOlustur_Click(object sender, EventArgs e)
        {
            if (_unitOfWork == null)
            {
                MessageBox.Show("Veritabani baglantisi bulunamadi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sfd = new SaveFileDialog
            {
                Filter = "PDF Dosyasi|*.pdf",
                Title = "PDF Rapor Kaydet",
                FileName = $"Rapor_{cmbRaporTipi.SelectedItem}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var dt = await RaporVerisiHazirlaAsync();
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Secili kategoride kayitli veri bulunamadi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string raporBasligi = cmbRaporTipi.SelectedItem?.ToString() ?? "Rapor";
                    PdfOlustur(dt, sfd.FileName, raporBasligi, true);
                    MessageBox.Show(
                        $"PDF raporu basariyla olusturuldu!\n\nDosya: {sfd.FileName}\nKayit Sayisi: {dt.Rows.Count}",
                        "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var onay = MessageBox.Show("PDF dosyasini acmak ister misiniz?", "Dosya Ac", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"PDF olusturulurken hata olustu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== VERI HAZIRLAMA ====================

        private async System.Threading.Tasks.Task<DataTable?> RaporVerisiHazirlaAsync()
        {
            string secilenRapor = cmbRaporTipi.SelectedItem?.ToString() ?? "";

            return secilenRapor switch
            {
                "Toprak Analiz Raporu" => await ToprakAnalizVerileriniGetirAsync(),
                "Yaprak Analiz Raporu" => await YaprakAnalizVerileriniGetirAsync(),
                "Su Analiz Raporu" => await SuAnalizVerileriniGetirAsync(),
                "Tum Tarlalar Raporu" => await TarlaVerileriniGetirAsync(),
                _ => null
            };
        }

        private async System.Threading.Tasks.Task<DataTable> ToprakAnalizVerileriniGetirAsync()
        {
            var dt = new DataTable("ToprakAnalizler");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tarih", typeof(string));
            dt.Columns.Add("Urun Tipi", typeof(string));
            dt.Columns.Add("Toprak Tipi", typeof(string));
            dt.Columns.Add("pH", typeof(double));
            dt.Columns.Add("Azot (ppm)", typeof(double));
            dt.Columns.Add("Fosfor (ppm)", typeof(double));
            dt.Columns.Add("Potasyum (ppm)", typeof(double));
            dt.Columns.Add("Organik Madde (%)", typeof(double));
            dt.Columns.Add("Tuzluluk", typeof(double));
            dt.Columns.Add("Tarla", typeof(string));

            var veriler = await _unitOfWork.ToprakAnalizler.GetAllAsync();
            foreach (var v in veriler.OrderByDescending(x => x.Tarih))
            {
                dt.Rows.Add(v.Id, v.Tarih.ToString("dd.MM.yyyy"), v.UrunTipi.ToString(), v.ToprakTipi.ToString(),
                    v.pH, v.Azot, v.Fosfor, v.Potasyum, v.OrganikMadde, v.Tuzluluk, v.Tarla?.TarlaAdi ?? "-");
            }
            return dt;
        }

        private async System.Threading.Tasks.Task<DataTable> YaprakAnalizVerileriniGetirAsync()
        {
            var dt = new DataTable("YaprakAnalizler");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tarih", typeof(string));
            dt.Columns.Add("Urun Tipi", typeof(string));
            dt.Columns.Add("Azot N (%)", typeof(double));
            dt.Columns.Add("Fosfor P (%)", typeof(double));
            dt.Columns.Add("Potasyum K (%)", typeof(double));
            dt.Columns.Add("Demir (ppm)", typeof(double));
            dt.Columns.Add("Cinko (ppm)", typeof(double));
            dt.Columns.Add("Mangan (ppm)", typeof(double));
            dt.Columns.Add("Bakir (ppm)", typeof(double));
            dt.Columns.Add("Eksiklik", typeof(string));
            dt.Columns.Add("Tarla", typeof(string));

            var veriler = await _unitOfWork.YaprakAnalizler.GetAllAsync();
            foreach (var v in veriler.OrderByDescending(x => x.Tarih))
            {
                dt.Rows.Add(v.Id, v.Tarih.ToString("dd.MM.yyyy"), v.UrunTipi.ToString(),
                    v.AzotYaprak, v.FosforYaprak, v.PotasyumYaprak, v.Demir, v.Cinko, v.Mangan, v.Bakir,
                    v.GozlenenEksiklik?.ToString() ?? "-", v.Tarla?.TarlaAdi ?? "-");
            }
            return dt;
        }

        private async System.Threading.Tasks.Task<DataTable> SuAnalizVerileriniGetirAsync()
        {
            var dt = new DataTable("SuAnalizler");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Analiz Tarihi", typeof(string));
            dt.Columns.Add("Kaynak", typeof(string));
            dt.Columns.Add("pH", typeof(double));
            dt.Columns.Add("EC (dS/m)", typeof(double));
            dt.Columns.Add("Sicaklik (C)", typeof(double));
            dt.Columns.Add("Bulaniklik (NTU)", typeof(double));
            dt.Columns.Add("Nitrat (mg/L)", typeof(double));
            dt.Columns.Add("Nitrit (mg/L)", typeof(double));
            dt.Columns.Add("Sodyum (mg/L)", typeof(double));
            dt.Columns.Add("Klor (mg/L)", typeof(double));
            dt.Columns.Add("Kalite Skoru", typeof(int));
            dt.Columns.Add("Sulamaya Uygun", typeof(string));

            var veriler = await _unitOfWork.SuAnalizleri.GetAllAsync();
            foreach (var v in veriler.OrderByDescending(x => x.AnalizTarihi))
            {
                dt.Rows.Add(v.Id, v.AnalizTarihi.ToString("dd.MM.yyyy"), v.Kaynak ?? "-",
                    v.pH, v.EC, v.Sicaklik, v.Bulaniklik, v.Nitrat, v.Nitrit, v.Sodyum, v.Klor,
                    v.SuKalitesiSkoru, v.SulamayaUygun ? "Evet" : "Hayir");
            }
            return dt;
        }

        private async System.Threading.Tasks.Task<DataTable> TarlaVerileriniGetirAsync()
        {
            var dt = new DataTable("Tarlalar");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tarla Adi", typeof(string));
            dt.Columns.Add("Alan (da)", typeof(double));
            dt.Columns.Add("Konum", typeof(string));
            dt.Columns.Add("Toprak Tipi", typeof(string));
            dt.Columns.Add("Olusturma Tarihi", typeof(string));

            var veriler = await _unitOfWork.Tarlalar.GetAllAsync();
            foreach (var v in veriler.OrderByDescending(x => x.OlusturmaTarihi))
            {
                dt.Rows.Add(v.Id, v.TarlaAdi, v.AlanDekar, v.Konum,
                    v.ToprakTipi.ToString(), v.OlusturmaTarihi.ToString("dd.MM.yyyy HH:mm"));
            }
            return dt;
        }

        // ==================== EXCEL OLUSTURMA ====================

        private static void ExcelOlustur(DataTable dt, string dosyaYolu)
        {
            using var workbook = new XLWorkbook();
            {
                var worksheet = workbook.Worksheets.Add(dt.TableName);

                for (int col = 0; col < dt.Columns.Count; col++)
                    worksheet.Cell(1, col + 1).Value = dt.Columns[col].ColumnName;

                for (int row = 0; row < dt.Rows.Count; row++)
                    for (int col = 0; col < dt.Columns.Count; col++)
                        worksheet.Cell(row + 2, col + 1).Value = dt.Rows[row][col]?.ToString() ?? "-";

                int sonSatir = dt.Rows.Count + 1;

                var headerRange = worksheet.Range(1, 1, 1, dt.Columns.Count);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Font.FontColor = XLColor.White;
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(0, 100, 0);
                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                if (sonSatir >= 2)
                {
                    var dataRange = worksheet.Range(2, 1, sonSatir, dt.Columns.Count);
                    dataRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                    for (int i = 2; i <= sonSatir; i++)
                    {
                        if (i % 2 == 0)
                            worksheet.Range(i, 1, i, dt.Columns.Count).Style.Fill.BackgroundColor = XLColor.FromArgb(240, 248, 240);
                    }
                }

                worksheet.Range(1, 1, 1, dt.Columns.Count).InsertRowsAbove(3);
                worksheet.Range(1, 1, 1, dt.Columns.Count).Merge();
                worksheet.Cell(1, 1).Value = $"AKILLI TARIM SISTEMI - {dt.TableName}";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                worksheet.Cell(1, 1).Style.Font.FontColor = XLColor.DarkGreen;
                worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                worksheet.Range(2, 1, 2, dt.Columns.Count).Merge();
                worksheet.Cell(2, 1).Value = $"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm} | Toplam Kayit: {dt.Rows.Count}";
                worksheet.Cell(2, 1).Style.Font.FontSize = 10;
                worksheet.Cell(2, 1).Style.Font.FontColor = XLColor.Gray;
                worksheet.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(dosyaYolu);
            }
        }

        // ==================== PDF OLUSTURMA ====================

        private static void PdfOlustur(DataTable dt, string dosyaYolu, string raporBasligi, bool includeHeader)
        {
            using var writer = new PdfWriter(dosyaYolu);
            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf, PageSize.A4.Rotate());
            {
                PdfFont font;
                PdfFont boldFont;
                try
                {
                    string fontPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    if (File.Exists(fontPath))
                    {
                        font = PdfFontFactory.CreateFont(fontPath);
                        PdfFont pdfFont = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                        boldFont = pdfFont;
                    }
                    else
                    {
                        font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                        boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    }
                }
                catch
                {
                    font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                }

                document.Add(new Paragraph()
                    .Add(new Text("AKILLI TARIM SISTEMI").SetFont(boldFont).SetFontSize(18))
                    .SetTextAlignment(TextAlignment.CENTER));

                document.Add(new Paragraph(raporBasligi)
                    .SetFont(font).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER));

                document.Add(new Paragraph($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm} | Toplam Kayit: {dt.Rows.Count}")
                    .SetFont(font).SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));

                var table = new Table(UnitValue.CreatePercentArray(dt.Columns.Count)).UseAllAvailableWidth();

                foreach (DataColumn column in dt.Columns)
                {
                    table.AddHeaderCell(new Cell()
                        .Add(new Paragraph()
                            .Add(new Text(column.ColumnName).SetFont(boldFont).SetFontSize(8))
                            .SetTextAlignment(TextAlignment.CENTER))
                        .SetPadding(4));
                }

                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        table.AddCell(new Cell()
                            .Add(new Paragraph(item?.ToString() ?? "-")
                                .SetFont(font).SetFontSize(7)
                                .SetTextAlignment(TextAlignment.CENTER))
                            .SetPadding(3));
                    }
                }

                document.Add(table);

                document.Add(new Paragraph($"\n\nBu rapor Akilii Tarim Sistemi tarafindan otomatik olarak olusturulmustur.")
                    .SetFont(font).SetFontSize(8)
                    .SetTextAlignment(TextAlignment.CENTER));
            }
        }
    }
}
