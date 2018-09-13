namespace GTR.CrossCutting.DateTime
{
    public static class DateTimeFormat
    {
        private const string DiaMesAnyo = "dd/MM/yyyy";
        private const string MesDiaAnyo = "M/d/yyyy";

        public static string GetShortDatePatternForDatetimepicker(System.Globalization.CultureInfo ci)
        {
            string shortDatePattern = ci.DateTimeFormat.ShortDatePattern;

            if (shortDatePattern == DiaMesAnyo)
            {
                return "dd/mm/yyyy";
            }
            else if (shortDatePattern == MesDiaAnyo)
            {
                return "mm/dd/yyyy";
            }

            return "dd/mm/yyyy";
        }

        public static string GetShortDatePatternForDataGrid(System.Globalization.CultureInfo ci)
        {
            string shortDatePattern = ci.DateTimeFormat.ShortDatePattern;

            if (shortDatePattern == DiaMesAnyo)
            {
                return "d/m/Y";
            }
            else if (shortDatePattern == MesDiaAnyo)
            {
                return "m/d/Y";
            }

            return "d/m/Y";
        }
    }
}
