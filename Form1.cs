using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Döviz_Uygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

 

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var XmlDosya = new XmlDocument();
            XmlDosya.Load(bugun);

            string dolaralis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            label5.Text = dolaralis;

            string dolarsatis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            label6.Text = dolarsatis;

            string euroalis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            label7.Text = euroalis;

            string eurosatis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            label8.Text = eurosatis;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = label5.Text;
            textBox1.Text = textBox1.Text.ToString().Replace(".", ",");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = label6.Text;
            textBox1.Text = textBox1.Text.ToString().Replace(".", ",");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = label7.Text;
            textBox1.Text = textBox1.Text.ToString().Replace(".", ",");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = label8.Text;
            textBox1.Text = textBox1.Text.ToString().Replace(".", ",");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(textBox1.Text);
            miktar = Convert.ToDouble(textBox2.Text);
            tutar = kur * miktar;
            textBox3.Text = tutar.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(textBox1.Text);
            int miktar = Convert.ToInt32(textBox2.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            textBox3.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            textBox4.Text = kalan.ToString();
        }
    }
}
