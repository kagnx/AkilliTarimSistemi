namespace AkilliTarimSistemi.Core.Constants
{
    public static class Sabitler
    {
        // Toprak ideal değer aralıkları
        public const double IdealpHMin = 6.0;
        public const double IdealpHMax = 7.5;
        public const double IdealAzotMin = 20;    // ppm
        public const double IdealAzotMax = 50;
        public const double IdealFosforMin = 15;
        public const double IdealFosforMax = 40;
        public const double IdealPotasyumMin = 150;
        public const double IdealPotasyumMax = 300;

        // Gübre katsayıları (kg/da başına)
        public const double AzotGubreKatsayisi = 0.8;
        public const double FosforGubreKatsayisi = 0.6;
        public const double PotasyumGubreKatsayisi = 0.7;

        // Sulama
        public const int SulamaEsikToprakNemi = 30;  // %
        public const int SulamaSuresiVarsayilan = 60; // saniye
    }
}