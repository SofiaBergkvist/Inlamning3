using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppgift3
{
    class Country
    {

        private string name;
        private int inhabitants;
        private int bnp_capita;
        private List<City> cities;

        public Country(string name, int inhabitants, int bnp_capita)
        {
            this.name = name;
            this.inhabitants = inhabitants;
            this.bnp_capita = bnp_capita;
            createList();
        }

        private void createList()
        {
            cities = new List<City>();
        }


        public string Name { get => name; set => name = value; }
        public int Inhabitants { get => inhabitants; set => inhabitants = value; }
        public int Bnp_capita { get => bnp_capita; set => bnp_capita = value; }
        internal List<City> Cities { get => cities; set => cities = value; }
    }
}
