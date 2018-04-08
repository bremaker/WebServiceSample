using System;
using System.Collections.Generic;

namespace WebApplication.Contracts
{
    public interface ISource
    {
        string GetDataFromSource(string url);
    }
}
