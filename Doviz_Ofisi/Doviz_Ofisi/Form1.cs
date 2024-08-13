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

namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtKursatis .Text);                              
            miktar= Convert.ToDouble(txtMiktarSatis .Text);
            tutar = kur * miktar;
            txtTutarSatis .Text =tutar.ToString ();                                 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";                  
            var xmldosya = new XmlDocument();                                    
            xmldosya.Load(bugun);                                   

            
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;                   
            lbldolaralis.Text = dolaralis;


            
            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsatis.Text = dolarsatis;


            
            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleuroalis.Text = euroalis;

            
            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleurosatis.Text = eurosatis;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            txtkuralis.Text = lbldolaralis.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            txtKursatis.Text = lbldolarsatis.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            txtkuralis.Text = lbleuroalis .Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            txtKursatis.Text = lbleurosatis.Text;
        }

        private void txtKur_TextChanged(object sender, EventArgs e)             

        {
            txtKursatis.Text = txtKursatis.Text.Replace("." , ",");                         
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtkuralis.Text);                              
            miktar = Convert.ToDouble(txtMiktarAlis.Text);
            tutar = kur * miktar;
            txtTutarAlis.Text = tutar.ToString("F2");
        }

        private void btnSatis2_Click(object sender, EventArgs e)
        {
            
            double kur;
            double miktar;
            double tutar;

            
            kur = Convert.ToDouble(txtKursatis.Text);
            miktar = Convert.ToDouble(txtMiktarSatis.Text);

            
            tutar = kur * miktar; 

            
            txtTutarSatis.Text = tutar.ToString("F2"); 
        }

        private void btnSatis1_Click(object sender, EventArgs e)
        {
           
            double kur;
            double tutar;
            int miktar;
            double kalan;

            
            kur = Convert.ToDouble(txtKursatis.Text);
            tutar = Convert.ToDouble(txtTutarSatis.Text);

            
            miktar = (int)(tutar / kur); 
            kalan = tutar % kur;        

            
            txtMiktarSatis.Text = miktar.ToString();
            txtKalanSatis.Text = kalan.ToString("F2");
        }

        private void txtkuralis_TextChanged(object sender, EventArgs e)
        {
            txtkuralis.Text = txtkuralis.Text.Replace(".", ",");
        }

        private void ClearTextBoxes()
        {
            txtkuralis.Clear();
            txtKursatis.Clear();
            txtMiktarAlis.Clear();
            txtMiktarSatis.Clear();
            txtTutarAlis.Clear();
            txtTutarSatis.Clear();
            txtKalanSatis.Clear();
        }
    }   

}
