using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace makeAList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Form level data
        TheListDB itemlist = new TheListDB();
        //List<TheList> thelist = new List<TheList>();
        //List<Items> itemlist = new List<Items>();
        // to save by writing to file it won't be possible to maintain the order by looping through these lists
        //therefore have to try to loop through listbox and put items into a NEW LIST to then write to file
        //Or actually now that I have everything in itemlist this should just work


        public void btnAddSectionTitle_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtSectionTitle,"Section Title"))
            {
                string title = txtSectionTitle.Text;
                Items NewTitle = new Items(title);
                itemlist.addtolist(NewTitle);
                lstItems.Items.Add(NewTitle.Titles.PadLeft(25));
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtSectionItems, "Section Item") && Validator.IsNonNegativeDouble(txtAddPrice,"Price"))
            {
                string item = txtSectionItems.Text;
                double price = Convert.ToDouble(txtAddPrice.Text);
                Items listItem = new Items(item, price);
                itemlist.addtolist(listItem);
                lstItems.Items.Add(listItem.Item + listItem.Price.ToString("c").PadLeft(35 - listItem.Item.Length));
                lblSumOfPrices.Text = itemlist.total().ToString("c");
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            int x = (lstItems.SelectedIndex);
            itemlist.removeFromList(x);
            lstItems.Items.RemoveAt(lstItems.SelectedIndex);
            lblSumOfPrices.Text = itemlist.total().ToString("c");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            itemlist.saveList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Items> list = itemlist.loadList();

            foreach(Items c in list)
            {
                if (c.Titles != null)
                {
                    lstItems.Items.Add(c.Titles.PadLeft(25));
                }
                else if (c.Item != null)
                {
                    lstItems.Items.Add(c.Item + c.Price.ToString("c").PadLeft(35 - c.Item.Length));
                }
            }

            lblSumOfPrices.Text = itemlist.total().ToString("c");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            printDocument.PrintPage += PrintDocument_PrintPage;

            DialogResult result = printDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            itemlist.DrawList(graphic);


        }


    }
}
