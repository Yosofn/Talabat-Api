using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DAL.Entities
{
    public  class CustomerBasket
    {
        public string Id { get; set; }  

        public List<BasketItem> BasketItems { get; set; }=new List<BasketItem>();


    }
}
