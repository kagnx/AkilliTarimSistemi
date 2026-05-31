using AkilliTarimSistemi.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace AkilliTarimSistemi.UI.Helpers;

public static class UrunHelper
{
    public static List<KeyValuePair<int, string>> GetUrunListesi()
    {
        return Enum.GetValues(typeof(UrunTipi))
            .Cast<UrunTipi>()
            .Select(u => new KeyValuePair<int, string>((int)u, u.ToString()))
            .ToList();
    }

    public static void UrunComboBoxDoldur(ComboBox comboBox)
    {
        var urunler = GetUrunListesi();
        comboBox.DataSource = null;
        comboBox.DataSource = urunler;
        comboBox.DisplayMember = "Value";
        comboBox.ValueMember = "Key";
        // Seçimi güvenli yap (BeginInvoke ile)
        comboBox.BeginInvoke(new Action(() =>
        {
            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }));
    }
}