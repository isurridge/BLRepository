using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LearningTreatz.Core
{
    public class Review
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The review cannot be blank")]
        public string Contents { get; set; }
        [Range(1, 5, ErrorMessage = "The rating must be between 1 and 5")]
        public int Rating { get; set; }
        public int RestaurantId { get; set; }
        public bool Approved { get; set; }
        public Guid UserId { get; set; }
    }
}
