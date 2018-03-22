using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace uppgift3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        

    private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            City boston = new City("boston", 300000, 1000, 200000000);
            boston = Program.FetchData(boston);

            List<double> xaxel = new List<double>();
            for (int x = 0; x < 30; x++)
            {
                xaxel.Add(0);
            }

            foreach (Accommodation element in boston.Accomodations)
            {
                if (element.Room_type == "Private room")
                {
                    for (int x = 0; x < 30; x++)
                    {
                        if (element.Price < x * 15)
                        {
                            xaxel[x]++;
                            break;
                        }
                    }
                }
                if (element.Overall_satisfaction < 4.5 && element.Overall_satisfaction != 0)
                {
                    this.chart1.Series["Series1"].Points.AddXY(element.Overall_satisfaction, element.Price);
                }
            }
            for (int x = 0; x < 30; x++)
            {
                this.chart2.Series["Series1"].Points.AddXY(x * 15, xaxel[x]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            City barcelona = new City("barcelona", 300000, 1000, 200000000);
            barcelona = Program.FetchData(barcelona);

            List<double> xaxel = new List<double>();
            for (int x = 0; x < 30; x++)
            {
                xaxel.Add(0);
            }

            foreach (Accommodation element in barcelona.Accomodations)
            {
                if (element.Room_type == "Private room")
                {
                    for (int x = 0; x < 30; x++)
                    {
                        if (element.Price < x * 15)
                        {
                            xaxel[x]++;
                            break;
                        }
                    }
                }
                if (element.Overall_satisfaction < 4.5 && element.Overall_satisfaction != 0)
                {
                    this.chart1.Series["Series1"].Points.AddXY(element.Overall_satisfaction, element.Price);
                }
            }
            for (int x = 0; x < 30; x++)
            {
                this.chart2.Series["Series1"].Points.AddXY(x * 15, xaxel[x]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Series1"].Points.Clear();
            this.chart2.Series["Series1"].Points.Clear();
            City amsterdam = new City("amsterdam", 300000, 1000, 200000000);
            amsterdam = Program.FetchData(amsterdam);

            List<double> xaxel = new List<double>();
            for(int x = 0; x < 30; x++)
                {
                    xaxel.Add(0);
                }


            foreach (Accommodation element in amsterdam.Accomodations)
            {
                if (element.Room_type == "Private room")
                {
                    for (int x = 0; x < 30; x++)
                    {
                        if (element.Price < x * 15)
                        {
                            xaxel[x]++;
                            break;
                        }
                    }
                }
                //this.chart2.Series["Series1"].Points.AddY(element.Price);
                if (element.Overall_satisfaction < 4.5 && element.Overall_satisfaction != 0)
                {
                    
                    double xx = element.Overall_satisfaction;
                    double yy = element.Price;
                    this.chart1.Series["Series1"].Points.AddXY(xx, yy);
                }
            }
            for (int x = 0; x < 30; x++)
            {
                this.chart2.Series["Series1"].Points.AddXY(x*15,xaxel[x]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
