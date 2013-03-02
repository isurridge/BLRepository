using LearningTreatz.Core;
using LearningTreatz.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Data.Repositories
{
    public class ReviewRepository : IDisposable
    {
        private RestaurantEntities db = new RestaurantEntities();

        public IQueryable<Review> Reviews()
        {
            return from x in db.Reviews orderby x.Id select x;
        }


        public void Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }

        public void Update(Review review)
        {
            db.Reviews.Attach(review);
            db.Entry<Review>(review).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Review review)
        {
            db.Reviews.Attach(review);
            db.Reviews.Remove(review);
            db.SaveChanges();
        }



        public void Dispose()
        {
            db.Dispose();
        }

    }
}
