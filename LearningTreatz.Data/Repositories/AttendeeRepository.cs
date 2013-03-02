using LearningTreatz.Core;
using LearningTreatz.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Data.Repositories
{
    public class AttendeeRepository : IDisposable
    {
        private RestaurantEntities db = new RestaurantEntities();

        public IQueryable<Attendee> Attendees()
        {
            return from x in db.Attendees orderby x.LastName select x;
        }


        public void Create(Attendee attendee)
        {
            db.Attendees.Add(attendee);
            db.SaveChanges();
        }

        public void Update(Attendee attendee)
        {
            db.Attendees.Attach(attendee);
            db.Entry<Attendee>(attendee).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Attendee attendee)
        {
            db.Attendees.Attach(attendee);
            db.Attendees.Remove(attendee);
            db.SaveChanges();
        }



        public void Dispose()
        {
            db.Dispose();
        }

    }
}
