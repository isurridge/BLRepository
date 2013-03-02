using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LearningTreatz.Core
{
    public class Attendee
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FamiliarName { get; set; }
        public string City { get; set; }
        public bool IsSpeaker { get; set; }
        public string EmailAddress { get; set; }
        public string Office { get; set; }    
        public Guid UserId { get; set; }
        public bool TSIsDone { get; set; }
        public bool EvaLIsDone { get; set; }
       
    }
}
