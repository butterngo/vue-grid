namespace WebApi.Common.Helpers
{
    using System;

    public static class DateTimeHelper
    {
        public static int ToUnixTimeSeconds(this DateTime dateTime)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(dateTime)).TotalSeconds;

            return unixTimestamp;
        }
    }
}
