using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningTreatz.Core;
using System.Data.Entity;

namespace LearningTreatz.Data.Configuration
{
    public class RestaurantEntities : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
