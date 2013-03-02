using LearningTreatz.Core;
using LearningTreatz.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Data.Repositories
{
    public class RestaurantRepository : IDisposable
    {

        private RestaurantEntities db = new RestaurantEntities();

        public IQueryable<Restaurant> Restaurants()
        {
            return from x in db.Restaurants orderby x.Name select x;
        }




        public void Dispose()
        {
            db.Dispose();
        }
    }
}
