using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace uppgift3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            City boston = new City("boston", 300000, 1000, 200000000);
            boston = FetchData(boston);

            City amsterdam = new City("amsterdam", 300000, 1000, 200000000);
            amsterdam = FetchData(amsterdam);

            City barcelona = new City("barcelona", 300000, 1000, 200000000);
            barcelona = FetchData(barcelona);
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Debug.WriteLine("HEJ");
        }

        public static City FetchData(City staden)
        {
            //Skapar ett objekt av klassen SqlConnection
            SqlConnection conn = new SqlConnection();

            //Sätter medlemsvariabeln ConnectionString till den connection string för den databas där AirBnB data finns
            conn.ConnectionString = "Data Source=DESKTOP-0V3DHJF\\SQL2017;Initial Catalog=Uppgift3;Integrated Security=True";

            try 
            {
                conn.Open(); //Öppnar länken mellan C# och SQL

                //Skapar en SQL query, declarerar även vad NULL värden ska sättas till 
                SqlCommand myQuery = new SqlCommand("SELECT room_id, host_id, room_type, ISNULL(borough, '') as borough, neighborhood, reviews, overall_satisfaction, accommodates, bedrooms, price, ISNULL(minstay, 0) as minstay, latitude, longitude, last_modified FROM " + staden.Name + ";", conn);

                //Startar inläsningen av data genom att anropa myQuery.ExecuteReader();
                SqlDataReader myReader = myQuery.ExecuteReader();

                //Sätter upp alla variabler som finns i klassen Accommondation och som ska hämtas från tabellen
                int room_id;
                int host_id;
                string room_type;
                string borough;
                string neighborhood;
                int reviews;
                double overall_satisfaction;
                int accommodates;
                int bedrooms;
                int price;
                int minstay;
                double latitude;
                double longitude;
                string last_modified;
                double temp; //Tempvariable som används för konvertering

                while (myReader.Read()) //Så länge det finns rader kvar att läsa skall while-loopen köras
                {
                    room_id = (int)myReader["room_id"];  //Alla värden från SQL servern är objektvärden. Med (*) tvingar vi C# att konvertera objekt till primitiv datatyp
                    host_id = (int)myReader["host_id"];
                    room_type = (string)myReader["room_type"];
                    borough = (string)myReader["borough"];
                    neighborhood = (string)myReader["neighborhood"];
                    reviews = (int)myReader["reviews"];
                    overall_satisfaction = (double)myReader["overall_satisfaction"];
                    accommodates = (int)myReader["accommodates"];
                    temp = (double)myReader["bedrooms"];
                    bedrooms = (int)Math.Round(temp);
                    temp = (double)myReader["price"];
                    price = (int)Math.Round(temp);
                    minstay = int.Parse((string)myReader["minstay"]);
                    latitude = (double)myReader["latitude"];
                    longitude = (double)myReader["longitude"];
                    last_modified = ((DateTime)myReader["last_modified"]).ToString();
                    Accommodation element = new Accommodation(room_id, host_id, room_type, borough, neighborhood, reviews, overall_satisfaction, accommodates, bedrooms, price, minstay, latitude, longitude, last_modified);
                    staden.addAccommodation(element);
                }

            }
            catch (Exception ex) //Här fångas eventuella fel upp
            {
                Debug.WriteLine(ex); //Ifall fel sker skriver vi ut felmeddelandet i konsollen
            }
            finally
            {
                conn.Close();
            }

            return staden;
        }
    }
}
