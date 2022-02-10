using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.FakeServices
{
    public class FakePosSystemService
    {
        public bool GetPayment(string cardNo, string name, string secKey, string date)
        {
            if(cardNo.Length == 16 && secKey.Length == 3)
            {
                return true;
            }
            return false;
        }
    }
}
