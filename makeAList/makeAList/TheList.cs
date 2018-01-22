using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makeAList
{
    public abstract class TheList
    {
        private string title;
        private string item;
        private double price;

        public string Titles
        {
            get { return title; }
            set { title = value; }
        }
        public string Item
        {
            get { return item; }
            set { item = value; }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
            }
        }

        public TheList()// Default Construstor
        {

        }
        public TheList(string t)// Construstor for titles
        {
            Titles = t;
        }
        public TheList(string i,double p)// Construstor for items and optional price
        {
            Item = i;
            Price = p; 
        }
    }
}
