namespace Radiation
{
    public enum LocaleControls { Description, RadiationName, RadiationLevels };
    public enum LocaleExceptControls { Internet, General };

    static class Locale
    {
        // EN locale.
        private static string en_desc = "This is an unofficial app of Vilnius radiation.The app and the Facebook group are " +
                "run by enthusiasts, so take the data with a pinch of salt." + "\n" +
                "App & Facebook group are not in any way " +
                "related to authorities of Radiation Protection Centre(RPC), Environmental Protection Agency(EPA) " +
                "or any other agency/organization. " + "\n" +
                "You can find Facebook group, where radiation data is being posted daily, here: " + "\n" +
                "fb.com/VilniausRadiacinisFonas/ or simply - Vilniaus Radiacinis Fonas." + "\n" +
                "Background photos are from: fb.com/gintaras.sphotography/ (Gintaras.S photography).";

        private static string en_today = "Today's Radiation:";

        private static string en_levels = "Radiation levels:" + "\n" +
                        "N/A - Data is not available." + "\n" +
                        "0 - 0.1 µSv/h - Very low." + "\n" +
                        "0.1 - 0.2 µSv/h - Low." + "\n" +
                        "0.2 - 0.3 µSv/h - Medium." + "\n" +
                        "0.3 µSv/h & more - Exceeds the norm.";

        private static string en_exception1 = "Could not get radiation data." + "\n" + 
                                              "Check your internet connection!";

        private static string en_exception2 = "Could not get radiation data, because: " + "\n";

        private static string en_alertName = "Error";

        // LT locale
        private static string lt_desc = "Vilniaus radiacija - tai neoficiali Vilniaus miesto radiacijos programėlė, " +
            "skirta patogiau pasiekti radiacijos informaciją." + "\n" +
            "Aplikacija ir FB grupė yra palaikoma entuziastų, todėl kartais informacija gali būti netiksli." + "\n" +
            "Aplikacija ir FB grupė nėra susijusi su " + 
            "Radiacinės saugos centru(RSC), Aplinkos apsaugos agentūra(AAA) ar " + "\n" + 
            "kokia kita nors įstaiga/organizacija." + "\n" +
            "Jūs galite rasti FB grupę čia: " + "\n" + 
            "fb.com/VilniausRadiacinisFonas/ arba Vilniaus radiacinis fonas." + "\n" +
            "Fono nuotraukos yra iš: " + "\n" + 
            "fb.com/gintaras.sphotography/ (Gintaras.S photography).";

        private static string lt_today = "Šiandienos Radiacija:";

        private static string lt_levels = "Radiacijos lygiai:" + "\n" +
                        "N/A - Informacija nepasiekiama." + "\n" +
                        "0 - 0.1 µSv/h - Labai žema." + "\n" +
                        "0.1 - 0.2 µSv/h - Žema." + "\n" +
                        "0.2 - 0.3 µSv/h - Vidutinė." + "\n" +
                        "0.3 µSv/h ir daugiau - Viršija norma.";

        private static string lt_exception1 = "Nebuvo gauti radiacijos duomenys." + "\n" +
                                      "Patikrinkite interneto ryšį!";

        private static string lt_exception2 = "Nebuvo gauti radiacijos duomenys, nes: " + "\n";

        private static string lt_alertName = "Klaida";

        // Properties.

            // Application Locale.
        public static string CurrentLocale { private get; set; }

            // Locale of main controls.
        public static string[] MainLocale
        {
            get
            {
                if (CurrentLocale.IndexOf("lt_") == 0)
                    return new string[] { lt_desc, lt_today, lt_levels };

                return new string[] { en_desc, en_today, en_levels };
            }
        }

        public static string[] ExceptionLocale
        {
            get
            {
                if (CurrentLocale.IndexOf("lt_") == 0)
                    return new string[] { lt_exception1, lt_exception2 };

                return new string[] { en_exception1, en_exception2 };
            }
        }

        public static string AlertTitle
        {
            get
            {
                if (CurrentLocale.IndexOf("lt_") == 0)
                    return lt_alertName;
                else
                    return en_alertName;
            }
        }


    }
}