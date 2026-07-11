using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkilliTarimSistemi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Soyad = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuKaynaklari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Konum = table.Column<string>(type: "TEXT", nullable: false),
                    KaynakTipi = table.Column<string>(type: "TEXT", nullable: false),
                    AktifMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    SonGuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKaynaklari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarlalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarlaAdi = table.Column<string>(type: "TEXT", nullable: false),
                    AlanDekar = table.Column<double>(type: "REAL", nullable: false),
                    Konum = table.Column<string>(type: "TEXT", nullable: false),
                    ToprakTipi = table.Column<int>(type: "INTEGER", nullable: false),
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrtalamaYagis = table.Column<double>(type: "REAL", nullable: true),
                    OrtalamaSicaklik = table.Column<double>(type: "REAL", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarlalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarlalar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GubreOnerileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarlaId = table.Column<int>(type: "INTEGER", nullable: false),
                    OneriTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HedefUrun = table.Column<int>(type: "INTEGER", nullable: false),
                    OnerilenAzot = table.Column<double>(type: "REAL", nullable: false),
                    OnerilenFosfor = table.Column<double>(type: "REAL", nullable: false),
                    OnerilenPotasyum = table.Column<double>(type: "REAL", nullable: false),
                    OnerilenGubreCesidi = table.Column<string>(type: "TEXT", nullable: true),
                    UygulamaZamani = table.Column<string>(type: "TEXT", nullable: true),
                    UygulandiMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GubreOnerileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GubreOnerileri_Tarlalar_TarlaId",
                        column: x => x.TarlaId,
                        principalTable: "Tarlalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorVerileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarlaId = table.Column<int>(type: "INTEGER", nullable: false),
                    OkumaZamani = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sicaklik = table.Column<double>(type: "REAL", nullable: false),
                    Nem = table.Column<double>(type: "REAL", nullable: false),
                    ToprakNemi = table.Column<double>(type: "REAL", nullable: false),
                    IsikSiddeti = table.Column<double>(type: "REAL", nullable: false),
                    pH = table.Column<double>(type: "REAL", nullable: true),
                    Co2 = table.Column<double>(type: "REAL", nullable: true),
                    SulamaDurumu = table.Column<int>(type: "INTEGER", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorVerileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorVerileri_Tarlalar_TarlaId",
                        column: x => x.TarlaId,
                        principalTable: "Tarlalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuAnalizler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnalizTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SuKaynagiId = table.Column<int>(type: "INTEGER", nullable: false),
                    TarlaId = table.Column<int>(type: "INTEGER", nullable: true),
                    UrunTipi = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Kaynak = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    pH = table.Column<double>(type: "REAL", nullable: false),
                    EC = table.Column<double>(type: "REAL", nullable: false),
                    Sicaklik = table.Column<double>(type: "REAL", nullable: false),
                    Bulaniklik = table.Column<double>(type: "REAL", nullable: false),
                    Sertlik = table.Column<double>(type: "REAL", nullable: false),
                    Klor = table.Column<double>(type: "REAL", nullable: false),
                    Sulfat = table.Column<double>(type: "REAL", nullable: false),
                    Bikarbonat = table.Column<double>(type: "REAL", nullable: false),
                    Karbonat = table.Column<double>(type: "REAL", nullable: false),
                    Nitrat = table.Column<double>(type: "REAL", nullable: false),
                    Nitrit = table.Column<double>(type: "REAL", nullable: false),
                    Kalsiyum = table.Column<double>(type: "REAL", nullable: false),
                    Magnezyum = table.Column<double>(type: "REAL", nullable: false),
                    Sodyum = table.Column<double>(type: "REAL", nullable: false),
                    Potasyum = table.Column<double>(type: "REAL", nullable: false),
                    Arsenik = table.Column<double>(type: "REAL", nullable: false),
                    Kadmiyum = table.Column<double>(type: "REAL", nullable: false),
                    Kursun = table.Column<double>(type: "REAL", nullable: false),
                    Civa = table.Column<double>(type: "REAL", nullable: false),
                    Krom = table.Column<double>(type: "REAL", nullable: false),
                    Nikel = table.Column<double>(type: "REAL", nullable: false),
                    SAR = table.Column<double>(type: "REAL", nullable: false),
                    RSC = table.Column<double>(type: "REAL", nullable: false),
                    SSP = table.Column<double>(type: "REAL", nullable: false),
                    TuzlulukSinifi = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    AlkaliniteSinifi = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    KoliformBakteri = table.Column<int>(type: "INTEGER", nullable: false),
                    EscherichiaColi = table.Column<int>(type: "INTEGER", nullable: false),
                    SuKalitesiSkoru = table.Column<int>(type: "INTEGER", nullable: false),
                    SulamayaUygun = table.Column<bool>(type: "INTEGER", nullable: false),
                    OneriMetni = table.Column<string>(type: "TEXT", nullable: true),
                    OnerilenTedavi = table.Column<string>(type: "TEXT", nullable: true),
                    AnaliziYapanKullaniciId = table.Column<int>(type: "INTEGER", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AktifMi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuAnalizler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuAnalizler_SuKaynaklari_SuKaynagiId",
                        column: x => x.SuKaynagiId,
                        principalTable: "SuKaynaklari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuAnalizler_Tarlalar_TarlaId",
                        column: x => x.TarlaId,
                        principalTable: "Tarlalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ToprakAnalizleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UrunTipi = table.Column<int>(type: "INTEGER", nullable: false),
                    ToprakTipi = table.Column<int>(type: "INTEGER", nullable: false),
                    TarlaId = table.Column<int>(type: "INTEGER", nullable: true),
                    pH = table.Column<double>(type: "REAL", nullable: false),
                    Azot = table.Column<double>(type: "REAL", nullable: false),
                    Fosfor = table.Column<double>(type: "REAL", nullable: false),
                    Potasyum = table.Column<double>(type: "REAL", nullable: false),
                    Kalsiyum = table.Column<double>(type: "REAL", nullable: false),
                    Magnezyum = table.Column<double>(type: "REAL", nullable: false),
                    OrganikMadde = table.Column<double>(type: "REAL", nullable: false),
                    Tuzluluk = table.Column<double>(type: "REAL", nullable: false),
                    Notlar = table.Column<string>(type: "TEXT", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToprakAnalizleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToprakAnalizleri_Tarlalar_TarlaId",
                        column: x => x.TarlaId,
                        principalTable: "Tarlalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UrunTavsiyeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarlaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TavsiyeTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TavsiyeEdilenUrun = table.Column<int>(type: "INTEGER", nullable: false),
                    GuvenSkoru = table.Column<double>(type: "REAL", nullable: false),
                    Gerekce = table.Column<string>(type: "TEXT", nullable: true),
                    UygulandiMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunTavsiyeleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunTavsiyeleri_Tarlalar_TarlaId",
                        column: x => x.TarlaId,
                        principalTable: "Tarlalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerimTahminleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarlaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Azot = table.Column<double>(type: "REAL", nullable: false),
                    Fosfor = table.Column<double>(type: "REAL", nullable: false),
                    Potasyum = table.Column<double>(type: "REAL", nullable: false),
                    PH = table.Column<double>(type: "REAL", nullable: false),
                    OrganikMadde = table.Column<double>(type: "REAL", nullable: false),
                    Tuzluluk = table.Column<double>(type: "REAL", nullable: false),
                    Yagis_mm = table.Column<double>(type: "REAL", nullable: false),
                    Sicaklik_Ort = table.Column<double>(type: "REAL", nullable: false),
                    SulamaYapildiMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    Gubreleme_TamMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    TahminTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UrunTipi = table.Column<int>(type: "INTEGER", nullable: false),
                    TahminiVerim = table.Column<double>(type: "REAL", nullable: false),
                    AltLimit = table.Column<double>(type: "REAL", nullable: false),
                    UstLimit = table.Column<double>(type: "REAL", nullable: false),
                    GuvenSkoru = table.Column<double>(type: "REAL", nullable: false),
                    KullanilanModel = table.Column<string>(type: "TEXT", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerimTahminleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerimTahminleri_Tarlalar_TarlaId",
                        column: x => x.TarlaId,
                        principalTable: "Tarlalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YaprakAnalizleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarlaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UrunTipi = table.Column<int>(type: "INTEGER", nullable: false),
                    AzotYaprak = table.Column<double>(type: "REAL", nullable: false),
                    FosforYaprak = table.Column<double>(type: "REAL", nullable: false),
                    PotasyumYaprak = table.Column<double>(type: "REAL", nullable: false),
                    Demir = table.Column<double>(type: "REAL", nullable: false),
                    Cinko = table.Column<double>(type: "REAL", nullable: false),
                    Mangan = table.Column<double>(type: "REAL", nullable: false),
                    Bakir = table.Column<double>(type: "REAL", nullable: false),
                    GozlenenEksiklik = table.Column<int>(type: "INTEGER", nullable: true),
                    GorselNot = table.Column<string>(type: "TEXT", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YaprakAnalizleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YaprakAnalizleri_Tarlalar_TarlaId",
                        column: x => x.TarlaId,
                        principalTable: "Tarlalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GubreOnerileri_TarlaId",
                table: "GubreOnerileri",
                column: "TarlaId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorVerileri_TarlaId",
                table: "SensorVerileri",
                column: "TarlaId");

            migrationBuilder.CreateIndex(
                name: "IX_SuAnalizler_SuKaynagiId",
                table: "SuAnalizler",
                column: "SuKaynagiId");

            migrationBuilder.CreateIndex(
                name: "IX_SuAnalizler_TarlaId",
                table: "SuAnalizler",
                column: "TarlaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarlalar_KullaniciId",
                table: "Tarlalar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_ToprakAnalizleri_TarlaId",
                table: "ToprakAnalizleri",
                column: "TarlaId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunTavsiyeleri_TarlaId",
                table: "UrunTavsiyeleri",
                column: "TarlaId");

            migrationBuilder.CreateIndex(
                name: "IX_VerimTahminleri_TarlaId",
                table: "VerimTahminleri",
                column: "TarlaId");

            migrationBuilder.CreateIndex(
                name: "IX_YaprakAnalizleri_TarlaId",
                table: "YaprakAnalizleri",
                column: "TarlaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GubreOnerileri");

            migrationBuilder.DropTable(
                name: "SensorVerileri");

            migrationBuilder.DropTable(
                name: "SuAnalizler");

            migrationBuilder.DropTable(
                name: "ToprakAnalizleri");

            migrationBuilder.DropTable(
                name: "UrunTavsiyeleri");

            migrationBuilder.DropTable(
                name: "VerimTahminleri");

            migrationBuilder.DropTable(
                name: "YaprakAnalizleri");

            migrationBuilder.DropTable(
                name: "SuKaynaklari");

            migrationBuilder.DropTable(
                name: "Tarlalar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
