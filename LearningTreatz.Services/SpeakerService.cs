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
    public class SpeakerService
    {

        public IEnumerable<Speaker> Speakers(string name)
        {
            using (SpeakerRepository db = new SpeakerRepository())
            {
                return (from x in db.Speakers() where x.EmailAddress == name select x).ToList();
            }
        }




        public IEnumerable<Speaker> Speakers(int id, IPrincipal user, Guid userId, string emailAddress)
        {
           using (SpeakerRepository db = new SpeakerRepository())
            {
                return (from x in db.Speakers() where x.EmailAddress == emailAddress select x).ToList();
            }
        }












        public String[] emailLKup(string emailAddress)
        {
            using (SpeakerRepository db = new SpeakerRepository())
            {
                return (from x in db.Speakers() where x.EmailAddress == emailAddress select x.CoPresenters).ToArray();
            }
            
        }










        public IEnumerable<Speaker> Speakers()
        {
            using (SpeakerRepository db = new SpeakerRepository())
            {
                return db.Speakers().ToList();
            }
        }




        public Speaker SpeakerToEdit(int id, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            Speaker speaker;
            using (SpeakerRepository db = new SpeakerRepository())
            {
                speaker = (from x in db.Speakers() where x.Id == id select x).Single();
            }
            if (userId == speaker.UserId || user.IsInRole(Constants.Admin) || user.IsInRole(Constants.Speaker))
            {
                return speaker;
            }
            throw new ArgumentException("You do not have permission to edit this speaker.");
        }








        public void Create(Speaker speaker, IPrincipal user)
        {
            IsAuthenticated(user);
            if (user.IsInRole(Constants.Admin) || user.IsInRole(Constants.Speaker))
            {
                using (SpeakerRepository db = new SpeakerRepository())
                {
                    db.Create(speaker);
                }
            }
        }



        public void Update(Speaker speaker, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);

            if (user.IsInRole(Constants.Admin) || userId == speaker.UserId)
            {
                using (SpeakerRepository db = new SpeakerRepository())
                {
                    db.Update(speaker);
                }

            }
            else
            {
                throw new ArgumentException("You do not have permission to edit this review");
            }
        }



        public void Delete(Speaker speaker, IPrincipal user, Guid userId)
        {
            IsAuthenticated(user);
            if (userId == speaker.UserId || user.IsInRole(Constants.Admin))
            {
                using (SpeakerRepository db = new SpeakerRepository())
                {
                    db.Delete(speaker);
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
