using System;
using System.Collections.Generic;

namespace WebApplication.Contracts
{
    public interface IBasicRepo
    {
        bool StoreData(string data);

        string ReadData();
    }
}
