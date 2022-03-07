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
        List<Direcciones> direc = new List<Direcciones>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Guardar(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in direc)
            {
                writer.WriteLine(p.texto);
                writer.WriteLine(p.veces);
                writer.WriteLine(p.fecha);
            }
            writer.Close();

        }
        private void buttonbuscar_Click(object sender, EventArgs e)
        {
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

            int p = direc.FindIndex(t => t.texto == comboBox1.Text);
            if (p == -1)
            {
                Direcciones dire = new Direcciones();
                dire.fecha = DateTime.Now;
                dire.veces=1;
                dire.texto = uri;
                direc.Add(dire);            }
            else
            {
                direc[p].veces++;
                direc[p].fecha = DateTime.Now;
            }
            Guardar("H.txt");
            mostrar();
        }
        private void mostrar()
        {
            comboBox1.DataSource = null;
            comboBox1.Refresh();
            comboBox1.DisplayMember = "texto";
            comboBox1.DataSource = direc;
            comboBox1.Refresh();
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
        private void Leer(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Direcciones dire = new Direcciones();
                dire.texto = reader.ReadLine(); 
                dire.veces = Convert.ToInt32(reader.ReadLine());
                dire.fecha = Convert.ToDateTime(reader.ReadLine());
                direc.Add(dire);
            }

            reader.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Leer("H.txt");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void historialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            direc = direc.OrderBy(p => p.fecha).ToList();
            mostrar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            direc.RemoveAll(p => p.texto == t);

            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                direc = direc.OrderByDescending(p => p.veces).ToList();
                mostrar();
            }
        }

        private void ordenarPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            direc = direc.OrderBy(p => p.fecha).ToList();
            mostrar();
        }

        private void ordenarPorVecesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            direc = direc.OrderByDescending(p => p.veces).ToList();
            mostrar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
