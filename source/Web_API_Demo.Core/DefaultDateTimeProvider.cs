using System;

namespace Web_API_Demo.Core
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        public DateTime Today
        {
            get { return DateTime.Today; }
        }
    }
}
