namespace Labolatorium_3_8.Services
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }

}
