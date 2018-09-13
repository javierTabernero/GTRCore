using System;
using System.Collections.Generic;
using System.Text;

namespace GTR.CrossCutting.Logging
{
    public interface ILogger
    {
        void Error(Exception exception);

        void Info(string message);
    }
}
