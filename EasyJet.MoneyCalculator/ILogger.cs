using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace EasyJet.MoneyCalculator
{
    public interface ILogger
    {
        void Write(LogLevel logLevel, string message);
        void Write(LogLevel logLevel, Exception ex, string message);
    }
}
