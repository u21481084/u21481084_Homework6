using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework6_u21481084.Models
{
    public class StockStoreVM
    {
        public IEnumerable<product> Products { get; set; }
        public IEnumerable<stock> stonks { get; set; }
    }
}