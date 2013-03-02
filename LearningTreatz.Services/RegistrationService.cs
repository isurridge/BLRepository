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
    public class RegistrationService
    {

        public IEnumerable<Registration> Registrations(string name)
        {
            using (RegistrationRepository db = new RegistrationRepository())
            {
                return (from x in db.Registrations() where x.EmailAddress == name select x).ToList();
            }
        }




        public IEnumerable<Registration> Registrations(int id, IPrincipal user, Guid userId, string emailAddress)
        {
            using (RegistrationRepository db = new RegistrationRepository())
            {
                return (from x in db.Registrations() where x.EmailAddress == emailAddress select x).ToList();
            }
        }













        public IEnumerable<Registration> Registrations()
        {
            using (RegistrationRepository db = new RegistrationRepository())
            {
                return db.Registrations().ToList();
            }
        }




        public Registration RegistrationToEdit(int id, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            Registration registration;
            using (RegistrationRepository db = new RegistrationRepository())
            {
                registration = (from x in db.Registrations() where x.Id == id select x).FirstOrDefault();
            }
            if (registration != null)
            {
                if (userId == registration.UserId || user.IsInRole(Constants.Admin))
                {
                    return registration;
                }
            }
            return null;
        }

        public Registration RegistrationToEdit(string email, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            Registration registration;
            using (RegistrationRepository db = new RegistrationRepository())
            {
                registration = (from x in db.Registrations() where x.EmailAddress == email select x).FirstOrDefault();
            }

            if (registration != null)
            {
                if (userId == registration.UserId || user.IsInRole(Constants.Admin))
                {
                    return registration;
                }
            }
            return null;
        }






        public void Create(Registration registration, IPrincipal user)
        {
            IsAuthenticated(user);
            
            
                using (RegistrationRepository db = new RegistrationRepository())
                {
                    db.Create(registration);
                }
            
        }



        public void Update(Registration registration, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);

            if (user.IsInRole(Constants.Admin) || userId == registration.UserId)
            {
                using (RegistrationRepository db = new RegistrationRepository())
                {
                    db.Update(registration);
                }

            }
            else
            {
                throw new ArgumentException("You do not have permission to edit this review");
            }
        }



        public void Delete(Registration registration, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            if (userId == registration.UserId || user.IsInRole(Constants.Admin))
            {
                using (RegistrationRepository db = new RegistrationRepository())
                {
                    db.Delete(registration);
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
