using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolStrip_Kontrolu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        byte i;
        WebBrowser webBrowser1 = new WebBrowser();

        private void geriToolStripMenuItem__Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void ileriToolStripMenuItem__Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void aramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoSearch();
        }

        private void durToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i++;

            if(!(txtadres.Text.StartsWith("https://")))
                txtadres.Text = txtadres.Text.Insert(0, "https://");
            webBrowser1.Navigate(txtadres.Text);
            Cursor.Current = Cursors.Default;
            ToolStripMenuItem yenimenu = new ToolStripMenuItem(string.Format(txtadres.Text, i));
            tbsayfalar.DropDownItems.Add(yenimenu);
            
        }

        private void webBrowser2_Navigating(object sender,WebBrowserNavigatingEventArgs e)
         { 
            StatusLabel1.Visible = true;
            ProgressBar1.Visible = true;
            StatusLabel1.Text = txtadres.Text + "Sayfası Yükleme Başladı";
            ProgressBar1.Value = 0;
            timer1.Start();




        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StatusLabel1.Text = txtadres.Text + "Sayfası Yükleniyor";

            if (ProgressBar1.Value==100)
            {
                ProgressBar1.Value = 0;
            }
            else
            
                ProgressBar1.Value = ProgressBar1.Value + 10;
            
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtadres.Text = e.Url.ToString();
            timer1.Stop();
            StatusLabel1.Text = txtadres.Text + "Sayfa Yüklendi";
            ProgressBar1.Value=0;
            ProgressBar1.Visible=false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressBar1.Visible =false;
            ProgressBar1.Value = 100;
            StatusLabel1.Visible=false;
        }

        private void tbsayfalar_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            webBrowser2.Navigate(e.ClickedItem.Text);
        }
    }
}
