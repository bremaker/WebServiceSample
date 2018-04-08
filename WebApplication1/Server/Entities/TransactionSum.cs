using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Entities
{
   public class TransactionsSum
    {
        public decimal sum;
        public List<Transaction> list;

        public TransactionsSum()
        {
            sum = 0;
            list = new List<Transaction>();
        }
    }
}
