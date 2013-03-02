using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningTreatz.Core;
using LearningTreatz.Data.Configuration;

namespace LearningTreatz.Data.Repositories
{
    public class CityRepository : IDisposable
    {
        private RestaurantEntities db = new RestaurantEntities();

        public IQueryable<City> Cities()
        {
            return from x in db.Cities orderby x.Name select x;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
