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

namespace AIUB.Shop_Management.Default
{
    public partial class ProductInfo : Form
    {
        public ProductInfo()
        {
            InitializeComponent();
        }

        private void pURCHASEToolStripMenuItem_Click(object sender, EventArgs e)//Being Used
        {
            Purches p = new Purches();
            p.TopLevel = false;
            p.AutoScroll = true;
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();//Clear panelDisplay
            this.panelDisplay.Controls.Add(p);
            p.Show();
        }

        private void pRODUCTLISTSToolStripMenuItem_Click(object sender, EventArgs e)//Being Used
        {
            ProductList pl = new ProductList();
            pl.TopLevel = false;
            pl.AutoScroll = true;
            pl.FormBorderStyle = FormBorderStyle.None;
            pl.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(pl);
            pl.Show();
        }

        private void ProductInfo_Load(object sender, EventArgs e)
        {
            LoadSellsChart();
            LoadInventoryChart();
            LoadReportChart();
            LoadProductChart();
        }

        private void LoadSellsChart()
        {
            string query = "select ProductId ,sum(Qnty) from Sells_Details group by ProductId";
            SqlDataReader dr;
            dr = DBConnection.getReader(query);
            try
            {

                while (dr.Read())
                {
                    this.chrtTopSells.Series["Series1"].Points.AddXY(dr.GetString(0), dr.GetDouble(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadInventoryChart()
        {
            string query = "select Name ,sum(PurchaseQuentity) from Purchase,ProductList group by Name";
            SqlDataReader dr;
            dr = DBConnection.getReader(query);
            try
            {

                while (dr.Read())
                {
                    this.chartInv.Series["Series1"].Points.AddXY(dr.GetString(0), dr.GetDouble(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadReportChart()
        {
            string query = "select  SellsDate ,sum(NetAmount) from Sells group by SellsDate";
            SqlDataReader dr;
            dr = DBConnection.getReader(query);
            try
            {

                while (dr.Read())
                {
                    this.chartReport.Series["Series1"].Points.AddXY(dr.GetDateTime(0), dr.GetDecimal(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadProductChart()
        {
            DateTime dt = DateTime.Now;
            string dtString = dt.ToShortDateString();
            string query = "select SellsDate ,Name,sum(Amount) from Sells,Sells_Details where Sells.Invoice = Sells_Details.Invoice and SellsDate = '" + dtString + "' group by Name,SellsDate";
            SqlDataReader dr;
            dr = DBConnection.getReader(query);
            try
            {

                while (dr.Read())
                {
                    this.chartProduct.Series["Series1"].Points.AddXY(dr.GetDateTime(1), dr.GetDecimal(2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
