using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningTreatz.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
    }
}
