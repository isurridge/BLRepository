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
    public class AttendeeService
    {

        public IEnumerable<Attendee> Attendees(string email)
        {
            using (AttendeeRepository db = new AttendeeRepository())
            {
                return (from x in db.Attendees() where x.EmailAddress == email select x).ToList();
            }
        }




        public IEnumerable<Attendee> Attendees(int id, IPrincipal user, Guid userId, string emailAddress)
        {
            using (AttendeeRepository db = new AttendeeRepository())
            {
                return (from x in db.Attendees() where x.EmailAddress == emailAddress select x).ToList();
            }
        }












        public String[] emailLKup(string emailAddress)
        {
            using (AttendeeRepository db = new AttendeeRepository())
            {
                return (from x in db.Attendees() where x.EmailAddress == emailAddress select x.LastName).ToArray();
            }
            
        }










        public IEnumerable<Attendee> Attendees()
        {
            using (AttendeeRepository db = new AttendeeRepository())
            {
                return db.Attendees().ToList();
            }
        }




        public Attendee AttendeeToEdit(int id, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            Attendee attendee;
            using (AttendeeRepository db = new AttendeeRepository())
            {
                attendee = (from x in db.Attendees() where x.Id == id select x).Single();
            }
            if ( user.IsInRole(Constants.Admin))
            {
                return attendee;
            }
            throw new ArgumentException("You do not have permission to edit this speaker.");
        }








        public void Create(Attendee attendee, IPrincipal user)
        {
            IsAuthenticated(user);
            if (user.IsInRole(Constants.Admin))
            {
                using (AttendeeRepository db = new AttendeeRepository())
                {
                    db.Create(attendee);
                }
            }
        }



        public void Update(Attendee attendee, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);

            if (user.IsInRole(Constants.Admin))
            {
                using (AttendeeRepository db = new AttendeeRepository())
                {
                    db.Update(attendee);
                }

            }
            else
            {
                throw new ArgumentException("You do not have permission to edit this review");
            }
        }



        public void Delete(Attendee attendee, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            if (user.IsInRole(Constants.Admin))
            {
                using (AttendeeRepository db = new AttendeeRepository())
                {
                    db.Delete(attendee);
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
