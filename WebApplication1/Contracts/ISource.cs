using System;
using System.Collections.Generic;

namespace WebApplication1.Contracts
{
    public interface ISource
    {
        string GetDataFromSource(string url);
    }
}
