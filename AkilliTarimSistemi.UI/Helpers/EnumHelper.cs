using System;
using System.Collections.Generic;
using System.Linq;
using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.UI.Helpers;

public static class EnumHelper
{
    public static List<KeyValuePair<int, string>> GetUrunTipiList()
    {
        return Enum.GetValues(typeof(UrunTipi))
            .Cast<UrunTipi>()
            .Select(e => new KeyValuePair<int, string>((int)e, e.ToString()))
            .ToList();
    }
}