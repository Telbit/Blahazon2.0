using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    interface IOrderRepository
    {
        public bool IsPayed();

        public string CheckStatus();


    }
}
