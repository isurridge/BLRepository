using LearningTreatz.Core;
using LearningTreatz.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Services
{
    public class CityService
    {

        public IEnumerable<City> Cities()
        {
            using (CityRepository db = new CityRepository())
            {
                return db.Cities().ToList();
            }
        }

    }
}
