using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LearningTreatz.Core
{
    public class Event
    {
        public int Id { get; set; }  
        public string SpeakerName { get; set; }
        public string EmailAddress { get; set; }
        public string CoPresenters { get; set; }
        public string SessionTitle { get; set; }
        public string SessionNumber { get; set; }
        public string SessionDescription { get; set; }
        public DateTime SessionDate { get; set; }    
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventType { get; set; }      
        public int RoomMax { get; set; }
        public string WaitList { get; set; }
        public string RoomChairArrangments { get; set; }
        public string SpeakerAVRequirements { get; set; }
        public byte[] RoomChairArrImages { get; set; }
 
    }
}
