using System;

namespace Web_API_Demo.Core
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}