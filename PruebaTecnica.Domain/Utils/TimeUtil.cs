namespace PruebaTecnica.Domain.Utils
{
    public static class TimeUtil
    {
        public static string GetDateInFormatYYYYmmddHHmm(DateTime dateTime)
            => dateTime.ToString("yyyy-MM-dd HH:mm");

        public static DateTime ObtenerFechaYHoraZonaHorariaBogota()
        {
            TimeZoneInfo zonaHorariaBogota = TimeZoneInfo.FindSystemTimeZoneById("America/Bogota");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zonaHorariaBogota);
        }
    }
}
