using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class City
    {
        public City(string nameCity, int citizenCity, int tourist, double middleIncome, List<Accomodation> accomodation)
        {
            NameCity = nameCity;
            CitizenCity = citizenCity;
            Tourist = tourist;
            Accomodation = accomodation;
            MiddleIncome = middleIncome;

            AverageCost = accomodation.Average(a => a.Price);
            Countvalues = accomodation.Count();



        }

        public string NameCity { get; set; }
        public int CitizenCity { get; set; }
        public int Tourist { get; set; }
        public List<Accomodation> Accomodation { get; } = new List<Accomodation>();
        public int Accomotadioncount
        {
            get { return Accomodation.Count; } //Antalet övernattningar
        }
        public double MiddleIncome { get; set; }
        public double AverageCost { get; set; } //Meldelkostnad
        public int Countvalues { get; set; }
    }
}
