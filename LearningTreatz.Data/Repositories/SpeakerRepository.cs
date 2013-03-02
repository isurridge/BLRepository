using LearningTreatz.Core;
using LearningTreatz.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Data.Repositories
{
    public class SpeakerRepository : IDisposable
    {
        private RestaurantEntities db = new RestaurantEntities();

        public IQueryable<Speaker> Speakers()
        {
            return from x in db.Speakers orderby x.SpeakerName select x;
        }


        public void Create(Speaker speaker)
        {
            db.Speakers.Add(speaker);
            db.SaveChanges();
        }

        public void Update(Speaker speaker)
        {
            db.Speakers.Attach(speaker);
            db.Entry<Speaker>(speaker).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Speaker speaker)
        {
            db.Speakers.Attach(speaker);
            db.Speakers.Remove(speaker);
            db.SaveChanges();
        }



        public void Dispose()
        {
            db.Dispose();
        }

    }
}
