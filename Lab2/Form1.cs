using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Guardar(string fileName, string texto)
        {
            //guadar en combo box temporalmente
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();
        }
        private void buttonbuscar_Click(object sender, EventArgs e)
        {
            // cambio al navegar 
            string uri = "";
            if (comboBox1.Text != null)
                uri = comboBox1.Text;
            else if (comboBox1.SelectedItem != null)
                uri = comboBox1.SelectedItem.ToString(); 

            if (!uri.Contains("."))
                uri = "https://www.google.com/search?q=" + uri;

            if (!uri.Contains("https://"))
                uri = "https://" + uri;

            webBrowser1.Navigate(new Uri(uri));

            int mismoD = 0;
            for (int i = 0; i<comboBox1.Items.Count; i++)
            {
                if (uri == comboBox1.Items[i].ToString())
                {
                    mismoD++;
                }
                if (mismoD==0)
                {
                    comboBox1.Items.Add(uri);
                    Guardar("H.txt", uri);
                }
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //comboBox1.Text = webBrowser1.Url.ToString();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void haciaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void haciaAdelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
 
        }
        private void leer(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                comboBox1.Items.Add(reader.ReadLine());
            }

            reader.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            leer("H.txt");
            //webBrowser1.GoHome();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
