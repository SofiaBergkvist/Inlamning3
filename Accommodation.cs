using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppgift3
{
    public class Accommodation
    {

        private int room_id;
        private int host_id;
        private string room_type;
        private string borough;
        private string neighborhood;
        private int reviews;
        private double overall_satisfaction;
        private int accommodates;
        private int bedrooms;
        private int price;
        private int minstay;
        private double latitude;
        private double longitude;
        private string last_modified;


        public Accommodation(int room_id, int host_id, string room_type, string borough,
            string neighborhood, int reviews, double overall_satisfaction, int accomodates,
            int bedrooms, int price, int minstay, double latitude, double longitude, string last_modified)
        {
            this.room_id = room_id;
            this.host_id = host_id;
            this.room_type = room_type;
            this.borough = borough;
            this.neighborhood = neighborhood;
            this.reviews = reviews;
            this.overall_satisfaction = overall_satisfaction;
            this.accommodates = accomodates;
            this.bedrooms = bedrooms;
            this.price = price;
            this.minstay = minstay;
            this.latitude = latitude;
            this.longitude = longitude;
            this.last_modified = last_modified;

        }

        public int Room_id { get => room_id; set => room_id = value; }
        public int Host_id { get => host_id; set => host_id = value; }
        public string Room_type { get => room_type; set => room_type = value; }
        public string Borough { get => borough; set => borough = value; }
        public string Neighborhood { get => neighborhood; set => neighborhood = value; }
        public int Reviews { get => reviews; set => reviews = value; }
        public double Overall_satisfaction { get => overall_satisfaction; set => overall_satisfaction = value; }
        public int Accomodates { get => accommodates; set => accommodates = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public int Price { get => price; set => price = value; }
        public int Minstay { get => minstay; set => minstay = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string Last_modified { get => last_modified; set => last_modified = value; }
    }
}
