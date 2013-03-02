using LearningTreatz.Core;
using LearningTreatz.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Services
{
    public class RestaurantService
    {


        public IEnumerable<string> RestaurantNames(string term)
        {
            using (RestaurantRepository db = new RestaurantRepository())
            {
                return (from x in db.Restaurants()
                        where x.Name.Contains(term) ||
                        x.Name == term
                        select x.Name).ToList();
            }
        }


        public IEnumerable<int> RestaurantIds(string name)
        {
            using (RestaurantRepository db = new RestaurantRepository())
            {
                return (from x in db.Restaurants()
                         where x.Name.Contains(name) ||
                         x.Name == name
                         select x.Id).ToList();               
            }
        }


        public IEnumerable<Restaurant> Restaurants(int cityId)
        {
            using (RestaurantRepository db = new RestaurantRepository())
            {
                return (from x in db.Restaurants() where x.CityId == cityId select x).ToList();
            }
        }


        public IEnumerable<Restaurant> Restaurant(int id)
        {
            using (RestaurantRepository db = new RestaurantRepository())
            {
                return (from x in db.Restaurants() where x.Id == id select x).ToList();
            }
        }


    }
}
