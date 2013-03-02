using LearningTreatz.Core;
using LearningTreatz.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Data.Repositories
{
    public class EventRepository : IDisposable
    {
        private RestaurantEntities db = new RestaurantEntities();

        public IQueryable<Event> Events()
        {
            return from x in db.Events orderby x.SessionDate select x;
        }


        public void Create(Event Event)
        {
            db.Events.Add(Event);
            db.SaveChanges();
        }

        public void Update(Event Event)
        {
            db.Events.Attach(Event);
            db.Entry<Event>(Event).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Event Event)
        {
            db.Events.Attach(Event);
            db.Events.Remove(Event);
            db.SaveChanges();
        }



        public void Dispose()
        {
            db.Dispose();
        }

    }
}
