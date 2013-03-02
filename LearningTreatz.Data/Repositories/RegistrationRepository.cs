using LearningTreatz.Core;
using LearningTreatz.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Data.Repositories
{
    public class RegistrationRepository : IDisposable
    {
        private RestaurantEntities db = new RestaurantEntities();

        public IQueryable<Registration> Registrations()
        {
            return from x in db.Registrations orderby x.EmailAddress select x;
        }


        public void Create(Registration registration)
        {
            db.Registrations.Add(registration);
            db.SaveChanges();
        }

        public void Update(Registration registration)
        {
            db.Registrations.Attach(registration);
            db.Entry<Registration>(registration).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Registration registration)
        {
            db.Registrations.Attach(registration);
            db.Registrations.Remove(registration);
            db.SaveChanges();
        }



        public void Dispose()
        {
            db.Dispose();
        }

    }
}
