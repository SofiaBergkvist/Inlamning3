using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppgift3
{
    public class City
    {
        private string name;
        private int inhabitants;
        private int avg_income;
        private int n_tourists_year;
        private int n_accommodations;
        private List<Accommodation> accommodations;


        public City(string name, int inhabitants, int avg_income, int n_tourists_year)
        {
            this.name = name;
            this.inhabitants = inhabitants;
            this.avg_income = avg_income;
            this.n_tourists_year = n_tourists_year;
            createAccommodation();
        }

        private void createAccommodation()
        {
            accommodations = new List<Accommodation>();
            n_accommodations = 0;
        }

        public void addAccommodation(Accommodation acco)
        {
            n_accommodations++;
            accommodations.Add(acco);
        }

        public string Name { get => name; set => name = value; }
        public int Inhabitants { get => inhabitants; set => inhabitants = value; }
        public int Avg_income { get => avg_income; set => avg_income = value; }
        public int N_tourists_year { get => n_tourists_year; set => n_tourists_year = value; }
        public int N_accomodations { get => n_accommodations; set => n_accommodations = value; }
        public List<Accommodation> Accomodations { get => accommodations; set => accommodations = value; }
    }
}
