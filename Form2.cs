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
using System.Text.RegularExpressions;

namespace textKorsun
{
    public partial class Form2 : Form
    {
        GroupBox groupbox;
        TextBox txb1;
        Label lb1;
        RadioButton rbt, rbt2;
        Button lisa, otmena;
        public Form2()
        {
            groupbox = new GroupBox();
            groupbox.Location = new Point(10, 10);
            groupbox.Size = new Size(260, 90);
            groupbox.Text = "Lisa";
            this.Controls.Add(groupbox);

            lisa = new Button();
            lisa.Location = new System.Drawing.Point(10, 210);
            lisa.Size = new System.Drawing.Size(110, 40);
            lisa.Text = "Lisa";
            lisa.Click += Lisada;
            this.Controls.Add(lisa);

            otmena = new Button();
            otmena.Location = new System.Drawing.Point(160, 210);
            otmena.Size = new System.Drawing.Size(110, 40);
            otmena.Text = "Välja";
            otmena.Click += Otmena;
            this.Controls.Add(otmena);

            lb1 = new Label();
            lb1.Text = "Sisesta teksti";
            lb1.Location = new Point(10, 155);
            lb1.Font = new System.Drawing.Font("Times New Roman", 10);
            this.Controls.Add(lb1);

            txb1 = new TextBox();
            txb1.Size = new System.Drawing.Size(260, 90);
            txb1.Location = new Point(10, 180);
            this.Controls.Add(txb1);

            rbt = new RadioButton();
            rbt.Height = 30;
            rbt.Width = 100;
            rbt.Location = new Point(10, 15);
            rbt.Text = "Peatükk 1";
            groupbox.Controls.Add(rbt);

            rbt2 = new RadioButton();
            rbt2.Height = 30;
            rbt2.Width = 100;
            rbt2.Location = new Point(10, 45);
            rbt2.Text = "Peatükk 2";
            groupbox.Controls.Add(rbt2);
        }
        private void Lisada(object sender, EventArgs e)
        {
            Form1 Main = this.Owner as Form1;
            if (txb1.Text != "")
            {
                if (this.rbt.Checked == true)
                Main.lb1.Items.Add(this.txb1.Text);
                else Main.lb2.Items.Add(this.txb1.Text);

                this.Close();
            }
        }
        private void Otmena(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}