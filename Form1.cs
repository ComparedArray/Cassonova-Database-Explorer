using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Text;

using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Windows.Forms;
using System.Net.Http;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Directory_Randomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.LoadFromBrowser("Insert URL");

            // foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a")){ Debug.WriteLine(link.Attributes["href"].Value); }
           // string[] Links = new string[3015]; // The Total
            var ssa = 0;
            
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {

                //Debug.WriteLine(link.InnerText);
                if (link.InnerText.Contains(".jpg") || link.InnerText.Contains(".png") || link.InnerText.Contains(".gif") || link.InnerText.Contains(".jpeg"))
                {
                    treeView1.Nodes.Add(link.Attributes["href"].Value);
                   // Links[ssa] = link.InnerText;
                }
                    ssa++;
                Debug.WriteLine(link.Id.ToString());
                //if (link.Name) { }
                // Debug.WriteLine(link.);

            }
            Debug.WriteLine(ssa);
            Debug.WriteLine(treeView1.Nodes.Count);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            var isa = rand.Next(treeView1.Nodes.Count);
            var Node = treeView1.Nodes[isa].Text;
            webBrowser1.Navigate("Insert Url" + Node);
            label1.Text = "Current Selected Image: " + Node;
            be.ImageNumber = isa;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var isa = treeView1.Nodes.Count;
            var Node = treeView1.Nodes[be.ImageNumber+1].Text;
            webBrowser1.Navigate("(Insert URL)" + Node);
            be.ImageNumber = be.ImageNumber + 1;
            label1.Text = "Current Selected Image: " + be.ImageNumber;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var isa = treeView1.Nodes.Count;
            var Node = treeView1.Nodes[be.ImageNumber - 1].Text;
            webBrowser1.Navigate("(Insert URL)" + Node);
            be.ImageNumber = be.ImageNumber - 1;
            label1.Text = "Current Selected Image: " + be.ImageNumber;
        }
    }
    public class be
    {
        public static int ImageNumber;
    }
}
