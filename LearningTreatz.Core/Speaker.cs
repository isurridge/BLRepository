using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LearningTreatz.Core
{
    public class Speaker
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string SpeakerName { get; set; }
        public string EmailAddress { get; set; }
        public string Office { get; set; }
        public string JobTitle { get; set; }
        public string CoPresenters { get; set; }
        public string SessionTitle { get; set; }
        public string SessionNumber { get; set; }
        public string SessionDescription { get; set; }
        public Guid UserId { get; set; }
        public string CoPresEmailAddress { get; set; }
        public byte[] SpeakerPhoto { get; set; }
    }
}
