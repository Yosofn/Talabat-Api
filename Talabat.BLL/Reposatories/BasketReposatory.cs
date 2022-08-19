using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.BLL.Interface;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Reposatories
{
    public class BasketReposatory : IBasketReposatory
    {   private readonly IDatabase _database;
        public BasketReposatory(IConnectionMultiplexer redis)
        {
            _database =redis.GetDatabase();
        }

        public async Task<bool> DeleteCustomerBasket(string basketid)
        {
            return await _database.KeyDeleteAsync(basketid);
        }

        public async Task<CustomerBasket> GetCustomerBasket(string basketid)
        {
         var basket = await _database.StringGetAsync(basketid);
            return basket.IsNullOrEmpty ? null :JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateCustomerBasket(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize( basket), TimeSpan.FromDays(30));
            if (!created) return null;

            return await GetCustomerBasket(basket.Id);

        }
    }
}
