using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningTreatz.Data;
using LearningTreatz.Core;
using System.Security.Principal;
using LearningTreatz.Data.Repositories;

namespace LearningTreatz.Services
{
    public class ReviewService
    {

        public IEnumerable<Review> Reviews(int id, IPrincipal user, Guid userId)
        {
            using (ReviewRepository db = new ReviewRepository())
            {
                if (user.Identity.IsAuthenticated && user.IsInRole(Constants.Admin))
                {
                    return (from x in db.Reviews() where x.RestaurantId == id select x).ToList();
                }
                else
                {
                    return (from x in db.Reviews() where x.RestaurantId == id && (x.Approved || x.UserId == userId) select x).ToList();
                }
            }
        }




        public Review ReviewToEdit(int id, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            Review review;
            using (ReviewRepository db = new ReviewRepository())
            {
                review = (from x in db.Reviews() where x.Id == id select x).Single();
            }
            if (userId == review.UserId)
            {
                return review;
            }
            throw new ArgumentException("You do not have permission to edit this review");
        }



        public void Create(Review review, IPrincipal user)
        {
            IsAuthenticated(user);
            review.Approved = (user.IsInRole(Constants.Admin) || user.IsInRole(Constants.Instructor));
            using (ReviewRepository db = new ReviewRepository())
            {
                db.Create(review);
            }
        }



        public void Update(Review review, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            if (userId == review.UserId)
            {
                review.Approved = (user.IsInRole(Constants.Admin) || user.IsInRole(Constants.Instructor));
                using (ReviewRepository db = new ReviewRepository())
                {
                    db.Update(review);
                }
            }
            else 
            {
                throw new ArgumentException("You do not have permission to edit this review");
            }
        }



        public void Delete(Review review, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            if (userId == review.UserId || user.IsInRole(Constants.Admin))
            {
                using (ReviewRepository db = new ReviewRepository())
                {
                    db.Delete(review);
                }
            }
            else
            {
                throw new ArgumentException("You do not have permission to delete this review");
            }
        }


        public void ApproveToggle(int reviewId, IPrincipal user)
        {
            IsAuthenticated(user);
            if (user.IsInRole(Constants.Admin))
            {
                using (ReviewRepository db = new ReviewRepository())
                {
                    Review review = (from x in db.Reviews() where x.Id == reviewId select x).Single();
                    review.Approved = !review.Approved;
                    db.Update(review);
                }
            }
            else
            {
                throw new ArgumentException("You do not have permission to set approval");
            }
        }




        private void IsAuthenticated(IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
            {
                throw new ArgumentException("Only logged in users can add reviews");
            }
        }



    }
}
