using System;
using System.Collections.Generic;

namespace WebApplication1.Contracts
{
    public interface IBasicRepo
    {
        bool StoreData(string data);

        string ReadData();
    }
}
