namespace AkilliTarimSistemi.Core.Enums;

public enum ToprakTipi
{
    // Grid'in sıfır (0) değerinde patlamasını önleyen kurtarıcı satır:
    Belirtilmedi = 0,

    // ==========================================
    // 100+ KABA BÜNYELİ TOPRAKLAR (Hafif Topraklar)
    // ==========================================
    Kumlu = 101,
    TinliKumlu = 102,

    // ==========================================
    // 200+ ORTA BÜNYELİ TOPRAKLAR (Tarım İçin En İdeal/Dengeli Topraklar)
    // ==========================================
    KumluTinli = 201,
    Tinli = 202,
    Millitir = 203,
    MilliTinli = 204,

    // ==========================================
    // 300+ İNCE BÜNYELİ TOPRAKLAR (Ağır Topraklar)
    // ==========================================
    KilliTinli = 301,
    KumluKilliTinli = 302,
    MilliKilliTinli = 303,
    KumluKilli = 304,
    MilliKilli = 305,
    Killi = 306,

    // ==========================================
    // 400+ ÖZEL VE ORGANİK TOPRAKLAR
    // ==========================================
    OrganikTorf = 401,
    Kirecli = 402
}