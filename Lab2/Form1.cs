using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonbuscar_Click(object sender, EventArgs e)
        {
            string nombre = "";
            string nombre2 = "";
            comboBox1.Text =nombre;
            webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
            for (int x = 1; x < nombre.Length; x++)
            {

                //si la posición anterior a la letra es un espacio en blanco
                //convertirla a mayúscula
                //sino solo copiarla
                if (nombre[x - 1] == ' ')
                {
                    if (char.IsLetter(nombre[x]) || char.IsWhiteSpace(nombre[x]))
                        nombre2 += char.ToUpper(nombre[x]);
                }
                else
                  if (char.IsLetter(nombre[x]) || char.IsWhiteSpace(nombre[x]))
                    nombre2 += nombre[x];

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

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }
    }
}
