using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Accomodation
    {
        public Accomodation(int room_id, int host_id, string room_type, int borough, string neighborhood,
              int reviews, double overall_satisfaction, int accommodates, double bedrooms, double price, int minstay,
              double latitude, double longitude, string last_modified)
        {
            Room_id = room_id;
            Host_id = host_id;
            Room_type = room_type;
            Borough = borough;
            Neighborhood = neighborhood;
            Reviews = reviews;
            Overall_satisfaction = overall_satisfaction;
            Accommodates = accommodates;
            Bedrooms = bedrooms;
            Price = price;
            Minstay = minstay;
            Latitude = latitude;
            Longitude = longitude;
            Last_modified = last_modified;
        }

        public int Room_id { get; set; }
        public int Host_id { get; set; }
        public string Room_type { get; set; }
        public int Borough { get; set; }
        public string Neighborhood { get; set; }
        public int Reviews { get; set; }
        public double Overall_satisfaction { get; set; }
        public int Accommodates { get; set; }
        public double Bedrooms { get; set; }
        public double Price { get; set; }
        public int Minstay { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Last_modified { get; set; }
    }
}
