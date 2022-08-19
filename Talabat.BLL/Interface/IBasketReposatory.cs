using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Interface
{
    public interface IBasketReposatory
    {
        Task<CustomerBasket> GetCustomerBasket(string basketid);
        Task<CustomerBasket> UpdateCustomerBasket(CustomerBasket customerBasket);
        Task<bool> DeleteCustomerBasket(string basketid);
            
    }
}
