using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Median_Problem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Random randGen = new Random();
        void Populate_Data()
        {
            string path = Application.StartupPath + "/median.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < 100; i++)
                {
                    int randNum = randGen.Next(1, 100);
                    writer.WriteLine(randNum);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "/median.txt";
            List<int> data = new List<int>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    data.Add(Convert.ToInt32(reader.ReadLine()));
                }
            }

            data.Sort();
            TxtDisplay.Text += "The total of the values is: " + data.Count + Environment.NewLine;

            foreach (var value in data) // Display the list of data once its sorted
                TxtDisplay.Text += Convert.ToString(value) + Environment.NewLine;

            double median;
            if (data.Count % 2 == 0) // then its even
            {
                median = ((data.Count / 2) + (data.Count + 2) / 2) / 2;
                TxtDisplay.Text += "Median for this data is: " + median + Environment.NewLine;
            }
            else if(data.Count % 2 != 0) // then its odd
            {
                median = (data.Count + 1) / 2;
                TxtDisplay.Text += "Median for this data is: " + median + Environment.NewLine;
            }
        }

    }
}
