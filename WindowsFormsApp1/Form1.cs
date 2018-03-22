using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<string> NameCity = new List<string>
            {
                "Boston", "Amsterdam", "Barcelona"
            };
            List<City> cities = new List<City>();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-0V3DHJF\\SQL2017;Initial Catalog=Uppgift3;Integrated Security=True";

            foreach (var item in NameCity)
            {


                try
                {
                    conn.Open();

                    SqlCommand myQuery = new SqlCommand("SELECT * FROM " + item + ";", conn);

                    SqlDataReader myReader = myQuery.ExecuteReader();

                    List<Accomodation> accomodationsList = new List<Accomodation>();

                    int room_id;
                    int host_id;
                    string room_type;
                    int borough;
                    bool borough_new;
                    string neighborhood;
                    int reviews;
                    double overall_satisfaction;
                    int accommodates;
                    double bedrooms;
                    double price;
                    double latitude;
                    double longitude;
                    int minstay;
                    string last_modified;
                    bool minstay_new;




                    while (myReader.Read())
                    {
                        room_id = (int)myReader["room_id"];
                        host_id = (int)myReader["host_id"];
                        room_type = (string)myReader["room_type"];
                        neighborhood = myReader["neighborhood"].ToString();
                        reviews = (int)myReader["reviews"];
                        accommodates = (int)myReader["accommodates"];
                        last_modified = (string)myReader["last_modified"].ToString();
                        latitude = Convert.ToDouble(myReader["latitude"]);
                        //Konverterar tal 
                        overall_satisfaction = Convert.ToDouble(myReader["overall_satisfaction"]);
                        longitude = Convert.ToDouble(myReader["longitude"]);
                        bedrooms = Convert.ToDouble(myReader["bedrooms"]);
                        price = Convert.ToDouble(myReader["price"]);
                        minstay_new = int.TryParse(Convert.ToString(myReader["minstay"]), out minstay);
                        borough_new = int.TryParse(Convert.ToString(myReader["borough"]), out borough);

                        //Läggger till objekt
                        Accomodation accomodation = new Accomodation(room_id, host_id, room_type, borough, neighborhood,
                        reviews, overall_satisfaction, accommodates, bedrooms, price, minstay,
                        latitude, longitude, last_modified);

                        accomodationsList.Add(accomodation);


                    }
                    City city = new City(item, 0, 0, 0, accomodationsList);
                    cities.Add(city);

                }

                catch (Exception ex)

                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }

            }
            foreach (City c in cities)
            {
                switch (c.NameCity)
                {
                    case "Boston":
                        foreach (Accomodation ac in c.Accomodation.Where(y => y.Room_type == "Private room"))
                        {
                            chart1.Series["Boston"].Points.AddY(ac.Price);
                        };
                        break;
                    case "Amsterdam":
                        foreach (Accomodation ac in c.Accomodation.Where(y => y.Room_type == "Private room"))
                        {
                            chart2.Series["Amsterdam"].Points.AddY(ac.Price);
                        };
                        break;
                    case "Barcelona":
                        foreach (Accomodation ac in c.Accomodation.Where(y => y.Room_type == "Private room"))
                        {
                            chart3.Series["Barcelona"].Points.AddY(ac.Price);
                        };
                        break;
                    default:
                        break;
                }

                foreach (City d in cities)
                {
                    switch (d.NameCity)
                    {
                        case "Boston":
                            foreach (Accomodation ac in d.Accomodation.Where(y => y.Overall_satisfaction < 4.5 && y.Overall_satisfaction != 0))
                            {
                                chart4.Series["Boston"].Points.AddXY(ac.Price, ac.Overall_satisfaction);
                            };
                            break;
                        case "Amsterdam":
                            foreach (Accomodation ac in d.Accomodation.Where(y => y.Overall_satisfaction < 4.5 && y.Overall_satisfaction != 0))
                            {
                                chart5.Series["Amsterdam"].Points.AddXY(ac.Price, ac.Overall_satisfaction);
                            };
                            break;
                        case "Barcelona":
                            foreach (Accomodation ac in d.Accomodation.Where(y => y.Overall_satisfaction < 4.5 && y.Overall_satisfaction != 0))
                            {
                                chart6.Series["Barcelona"].Points.AddXY(ac.Price, ac.Overall_satisfaction);
                            };
                            break;
                        default:
                            break;
                    }

                }
               
            }
            // PLOT FÖR Boston
            chart1.Series["Boston"].ChartType = SeriesChartType.Column;
            chart1.Titles.Add("Price spread on Private Rooms in Boston");
            chart1.ChartAreas[0].AxisY.Title = ("price");

            // PLOT FÖR Amsterdam
            chart2.Series["Amsterdam"].ChartType = SeriesChartType.Column;
            chart2.Titles.Add("Price spread on Private Rooms in Amsterdam");
            chart2.ChartAreas[0].AxisY.Title = ("price");

            // PLOT FÖR Barcelona
            chart3.Series["Barcelona"].ChartType = SeriesChartType.Column;
            chart3.Titles.Add("Price spread on Private Rooms in Barcelona");
            chart3.ChartAreas[0].AxisY.Title = ("price");


            chart4.Series["Boston"].ChartType = SeriesChartType.Point;
            chart4.Titles.Add("Price spread on Overall satisfacton in Boston");
            chart4.ChartAreas[0].AxisX.Title = ("Price");
            chart4.ChartAreas[0].AxisY.Title = ("Overall satisfaktion");

            chart5.Series["Amsterdam"].ChartType = SeriesChartType.Point;
            chart5.Titles.Add("Price spread on Overall satisfacton in Barcelona");
            chart5.ChartAreas[0].AxisX.Title = ("Price");
            chart5.ChartAreas[0].AxisY.Title = ("Overall satisfaktion");

            chart6.Series["Barcelona"].ChartType = SeriesChartType.Point;
            chart6.Titles.Add("Price spread on Overall satisfacton in Amsterdam");
            chart6.ChartAreas[0].AxisX.Title = ("Price");
            chart6.ChartAreas[0].AxisY.Title = ("Overall satisfaktion");
        }

    }
}
