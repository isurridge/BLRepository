using LearningTreatz.Core;
using LearningTreatz.Data;
using LearningTreatz.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;






namespace LearningTreatz.Services
{
    public class EventService
    {

        public IEnumerable<Event> Events(string email)
        {
            using (EventRepository db = new EventRepository())
            {
                return (from x in db.Events() where x.EmailAddress == email select x).ToList();
            }
        }




        public IEnumerable<Event> Events(int id, IPrincipal user, Guid userId, string emailAddress)
        {
            using (EventRepository db = new EventRepository())
            {
                return (from x in db.Events() where x.EmailAddress == emailAddress select x).ToList();
            }
        }












        public String[] emailLKup(string emailAddress)
        {
            using (EventRepository db = new EventRepository())
            {
                return (from x in db.Events() where x.EmailAddress == emailAddress select x.EmailAddress).ToArray();
            }
            
        }










        public IEnumerable<Event> Events()
        {
            using (EventRepository db = new EventRepository())
            {
                return db.Events().ToList();
            }
        }




        public Event EventToEdit(int id, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            Event Event;
            using (EventRepository db = new EventRepository())
            {
                Event = (from x in db.Events() where x.Id == id select x).Single();
            }
            if ( user.IsInRole(Constants.Admin))
            {
                return Event;
            }
            throw new ArgumentException("You do not have permission to edit this speaker.");
        }








        public void Create(Event Event, IPrincipal user)
        {
            IsAuthenticated(user);
            if (user.IsInRole(Constants.Admin))
            {
                using (EventRepository db = new EventRepository())
                {
                    db.Create(Event);
                }
            }
        }



        public void Update(Event Event, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);

            if (user.IsInRole(Constants.Admin))
            {
                using (EventRepository db = new EventRepository())
                {
                    db.Update(Event);
                }

            }
            else
            {
                throw new ArgumentException("You do not have permission to edit this review");
            }
        }



        public void Delete(Event Event, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            if (user.IsInRole(Constants.Admin))
            {
                using (EventRepository db = new EventRepository())
                {
                    db.Delete(Event);
                }
            }
            else
            {
                throw new ArgumentException("You do not have permission to delete this speaker");
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
