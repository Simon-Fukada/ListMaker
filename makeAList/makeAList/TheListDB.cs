using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Drawing;

namespace makeAList
{
    public class TheListDB
    {
        const string path = "TheListDB.txt"; //stored in bin/debug
        //with this can put all methods that return statistics on the list here rather
        //than in the form 
        //And can instantiate many list objects.
        //AND no longer need to constructos with this, at least for the customer class 
        //in lab 2, not sure about this specific project yet
        private List<Items> list = new List<Items>();

        public List<Items> itemlist
        {
            get { return list; }
            set { list = value; }
        }

        public TheListDB()
        {
        } 


        public void addtolist(Items x)
        {
            list.Add(x);
        }

        public void removeFromList(int x)
        {
            list.RemoveAt(x);
        }

        public double total()
        {
            double total = 0;
            foreach (Items i in list)
            {
                total += i.Price;
            }
            return total;
        }

        public void saveList()
        {
            string line;
            
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Items c in list)
            {

                if (c.Titles != null)
                {
                    line = c.Titles + ",";
                }
                else
                {
                    line = c.Item + ",";
                    line += c.Price;
                }
                sw.WriteLine(line);
            }
            sw.Close();
        }

        public List<Items> loadList()
        {
            string line;
            string[] parts;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {

                line = sr.ReadLine();
                parts = line.Split(',');

                if (parts[1] == "")
                {
                    Items loadTitle = new Items(parts[0]);
                    list.Add(loadTitle);
                }
                else
                {
                    Items loadItem = new Items(parts[0], Convert.ToDouble(parts[1]));
                    list.Add(loadItem);
                }

            }
            sr.Close();
            return list;
        }

        public void DrawList(Graphics graphic)
        {
            Font font = new Font("Courier New", 12);

            float fontHeight = font.GetHeight();

            int startx = 10;
            int starty = 10;
            int offset = 40;

            graphic.DrawString("Provided by Simon's List Maker Version 1.0", new Font("Courier New", 18), new SolidBrush(Color.Black), startx, starty);

            foreach (Items c in list)
            {
                if (c.Titles != null)
                {
                    string sectionTitle = c.Titles.PadLeft(25);
                    graphic.DrawString(sectionTitle, font, new SolidBrush(Color.Black), startx, starty + offset);

                    offset = offset + (int)fontHeight + 5;
                }
                else
                {
                    string item = c.Item;
                    string price = c.Price.ToString("c").PadLeft(35 - c.Item.Length);
                    string itemLine = item + price;
                    graphic.DrawString(itemLine, font, new SolidBrush(Color.Black), startx, starty + offset);

                    offset = offset + (int)fontHeight + 5;
                }
                
            }

            offset = offset + (int)fontHeight + 10;
            double total = 0;
            foreach (Items i in list)
            {
                total += i.Price;
            }

            graphic.DrawString("Sum of Prices" + total.ToString("c").PadLeft(22), font, new SolidBrush(Color.Black), startx, starty + offset);

        }

    }
}
