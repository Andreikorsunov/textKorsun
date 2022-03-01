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
using System.Collections;

namespace textKorsun
{
    public partial class Form1 : Form
    {
        OpenFileDialog OpenDig = new OpenFileDialog();
        SaveFileDialog SaveDig = new SaveFileDialog();
        MainMenu mainMenu;
        Label lbl_razd, lbl_razd2, lbl_sise;
        Panel panel;
        ComboBox cmb, cmb2;
        TextBox txb;
        RadioButton rb1, rb2, rb3;
        CheckBox chcbx, chcbx1;
        public ListBox lb1, lb2, lb3;
        GroupBox grpb, grpb2;
        RichTextBox rtb;
        Button start, otsing, vprav, vlev, vprav2, vlev2, sort1, 
            sort2, clear1, clear2, add, delete, exit, clear;

        public Form1()
        {
            this.Height = 650;
            this.Width = 800;
            this.Text = "Tekstiredaktor";
            this.BackgroundImage = Properties.Resources.background;

            panel = new Panel();
            panel.Location = new Point(25, 30);
            panel.Size = new Size(450, 520);
            panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(panel);

            grpb = new GroupBox();
            grpb.Location = new Point(20, 350);
            grpb.Size = new Size(255, 150);
            grpb.Text = "Otsing";
            panel.Controls.Add(grpb);

            grpb2 = new GroupBox();
            grpb2.Location = new Point(490, 440);
            grpb2.Size = new Size(255, 110);
            grpb2.Text = "Sõnade valik";
            this.Controls.Add(grpb2);

            lbl_razd = new Label();
            lbl_razd.Text = "Jaotis 1";
            lbl_razd.Location = new Point(25, 10);
            lbl_razd.Font = new System.Drawing.Font("Times New Roman", 10);
            panel.Controls.Add(lbl_razd);

            lbl_razd2 = new Label();
            lbl_razd2.Text = "Jaotis 2";
            lbl_razd2.Location = new Point(290, 10);
            lbl_razd2.Font = new System.Drawing.Font("Times New Roman", 10);
            panel.Controls.Add(lbl_razd2);

            cmb = new ComboBox();
            cmb.Location = new Point(25, 40);
            cmb.Size = new Size(145, 10);
            cmb.Items.Add("Tähestikuline (kasvavalt)");
            cmb.Items.Add("Tähestikuline (kahanevevalt)");
            cmb.Items.Add("Sõna pikkus (kasvavalt)");
            cmb.Items.Add("Sõna pikkus (kahanevalt)");
            cmb.SelectedIndexChanged += Sort;
            panel.Controls.Add(cmb);

            cmb2 = new ComboBox();
            cmb2.Location = new Point(290, 40);
            cmb2.Size = new Size(145, 10);
            cmb2.Items.Add("Tähestikuline (kasvavalt)");
            cmb2.Items.Add("Tähestikuline (kahanevevalt)");
            cmb2.Items.Add("Sõna pikkus (kasvavalt)");
            cmb2.Items.Add("Sõna pikkus (kahanevalt)");
            cmb2.SelectedIndexChanged += Sort2;
            panel.Controls.Add(cmb2);

            lb1 = new ListBox();
            lb1.Location = new System.Drawing.Point(25, 70);
            lb1.Size = new System.Drawing.Size(145, 200);
            lb1.SelectionMode = SelectionMode.MultiExtended;
            panel.Controls.Add(lb1);

            lb2 = new ListBox();
            lb2.Location = new System.Drawing.Point(290, 70);
            lb2.Size = new System.Drawing.Size(145, 200);
            lb2.SelectionMode = SelectionMode.MultiExtended;
            panel.Controls.Add(lb2);

            rtb = new RichTextBox();
            rtb.Location = new System.Drawing.Point(490, 30);
            rtb.Size = new System.Drawing.Size(255, 400);
            this.Controls.Add(rtb);

            vprav = new Button();
            vprav.Location = new System.Drawing.Point(185, 75);
            vprav.Size = new System.Drawing.Size(90, 30);
            vprav.Text = ">";
            vprav.Click += VPerenos_Vpravo;
            panel.Controls.Add(vprav);

            vlev = new Button();
            vlev.Location = new System.Drawing.Point(185, 115);
            vlev.Size = new System.Drawing.Size(90, 30);
            vlev.Text = "<";
            vlev.Click += VPerenos_Vlevo;
            panel.Controls.Add(vlev);

            vprav2 = new Button();
            vprav2.Location = new System.Drawing.Point(185, 155);
            vprav2.Size = new System.Drawing.Size(90, 30);
            vprav2.Text = ">>";
            vprav2.Click += SPerenos_Vpravo;
            panel.Controls.Add(vprav2);

            vlev2 = new Button();
            vlev2.Location = new System.Drawing.Point(185, 195);
            vlev2.Size = new System.Drawing.Size(90, 30);
            vlev2.Text = "<<";
            vlev2.Click += SPerenos_Vlevo;
            panel.Controls.Add(vlev2);

            sort1 = new Button();
            sort1.Location = new System.Drawing.Point(50, 275);
            sort1.Size = new System.Drawing.Size(90, 30);
            sort1.Text = "Sorterida";
            panel.Controls.Add(sort1);

            sort2 = new Button();
            sort2.Location = new System.Drawing.Point(315, 275);
            sort2.Size = new System.Drawing.Size(90, 30);
            sort2.Text = "Sorterida";
            panel.Controls.Add(sort2);

            clear1 = new Button();
            clear1.Location = new System.Drawing.Point(50, 315);
            clear1.Size = new System.Drawing.Size(90, 30);
            clear1.Text = "Puhasta";
            clear1.Click += Clear1_Click;
            panel.Controls.Add(clear1);

            clear2 = new Button();
            clear2.Location = new System.Drawing.Point(315, 315);
            clear2.Size = new System.Drawing.Size(90, 30);
            clear2.Text = "Puhasta";
            clear2.Click += Clear2_Click;
            panel.Controls.Add(clear2);

            add = new Button();
            add.Location = new System.Drawing.Point(185, 275);
            add.Size = new System.Drawing.Size(90, 30);
            add.Text = "Lisada";
            add.Click += Add;
            panel.Controls.Add(add);

            delete = new Button();
            delete.Location = new System.Drawing.Point(185, 315);
            delete.Size = new System.Drawing.Size(90, 30);
            delete.Text = "Kustutada";
            delete.Click += Kustu;
            panel.Controls.Add(delete);

            lbl_sise = new Label();
            lbl_sise.Text = "Sisesta otsingusõna";
            lbl_sise.Size = new System.Drawing.Size(120, 20);
            lbl_sise.Location = new Point(5, 20);
            lbl_sise.Font = new System.Drawing.Font("Times New Roman", 10);
            grpb.Controls.Add(lbl_sise);

            txb = new TextBox();
            txb.Size = new System.Drawing.Size(140, 20);
            txb.Location = new Point(5, 40);
            grpb.Controls.Add(txb);

            lb3 = new ListBox();
            lb3.Location = new System.Drawing.Point(5, 70);
            lb3.Size = new System.Drawing.Size(140, 80);
            lb3.SelectionMode = SelectionMode.MultiExtended;
            grpb.Controls.Add(lb3);

            chcbx = new CheckBox();
            chcbx.Height = 30;
            chcbx.Width = 90;
            chcbx.Location = new Point(160, 20);
            chcbx.Text = "Peatükk 1";
            grpb.Controls.Add(chcbx);

            chcbx1 = new CheckBox();
            chcbx1.Height = 30;
            chcbx1.Width = 90;
            chcbx1.Location = new Point(160, 55);
            chcbx1.Text = "Peatükk 2";
            grpb.Controls.Add(chcbx1);

            otsing = new Button();
            otsing.Location = new System.Drawing.Point(155, 85);
            otsing.Size = new System.Drawing.Size(90, 55);
            otsing.Text = "Otsing";
            otsing.Click += Otsi;
            grpb.Controls.Add(otsing);

            clear = new Button();
            clear.Location = new System.Drawing.Point(290, 395);
            clear.Size = new System.Drawing.Size(140, 55);
            clear.Text = "Lähtesta";
            clear.Click += Restart_Click;
            panel.Controls.Add(clear);

            exit = new Button();
            exit.Location = new System.Drawing.Point(290, 455);
            exit.Size = new System.Drawing.Size(140, 55);
            exit.Text = "Välja";
            exit.BackColor = Color.Red;
            exit.Click += Exit_Click;
            panel.Controls.Add(exit);

            start = new Button();
            start.Location = new System.Drawing.Point(145, 25);
            start.Size = new System.Drawing.Size(90, 75);
            start.Text = "Alusta";
            start.BackColor = Color.Green;
            start.Click += Alusta;
            grpb2.Controls.Add(start);

            rb1 = new RadioButton();
            rb1.Height = 30;
            rb1.Width = 80;
            rb1.Location = new Point(15, 15);
            rb1.Text = "Kõik";
            grpb2.Controls.Add(rb1);

            rb2 = new RadioButton();
            rb2.Height = 30;
            rb2.Width = 80;
            rb2.Location = new Point(15, 45);
            rb2.Text = "Sisaldatud numbrit";
            grpb2.Controls.Add(rb2);

            rb3 = new RadioButton();
            rb3.Height = 30;
            rb3.Width = 80;
            rb3.Location = new Point(15, 75);
            rb3.Text = "Sisaldatud e-mailit";
            grpb2.Controls.Add(rb3);

            mainMenu = new MainMenu();  
            MenuItem File = mainMenu.MenuItems.Add("&File");  
            File.MenuItems.Add(new MenuItem("&Ava", new EventHandler(this.Ava), Shortcut.CtrlO));  
            File.MenuItems.Add(new MenuItem("&Salvesta", new EventHandler(this.Salvesta), Shortcut.CtrlS));  
            File.MenuItems.Add(new MenuItem("&Välja", new EventHandler(this.Exit_Click), Shortcut.CtrlX));  
            this.Menu = mainMenu;  
            MenuItem File2 = mainMenu.MenuItems.Add("&?");  
            File2.MenuItems.Add(new MenuItem("&Info", new EventHandler(this.Info_Click)));  
            this.Menu = mainMenu; 
        }
        private void Kustu(object sender, EventArgs e)
        {
            for (int i = lb1.Items.Count - 1; i >= 0; i--)
            {
                if (lb1.GetSelected(i)) lb1.Items.RemoveAt(i);
            }
        }
        private void Sort(object sender, EventArgs e)
        {
            if (cmb.SelectedIndex == 0)
            {
                List<String> list = new List<String>();
                foreach (var item in lb1.Items)
                    list.Add(item.ToString());

                list.Sort();
                lb1.Items.Clear();
                foreach (var item in list)
                    lb1.Items.Add(item);
            }
            else if (cmb.SelectedIndex == 1)
            {
                List<String> list = new List<String>();
                foreach (var item in lb1.Items)
                    list.Add(item.ToString());

                list.Sort();
                list.Reverse();
                lb1.Items.Clear();
                foreach (var item in list)
                    lb1.Items.Add(item);
            }
            else if (cmb.SelectedIndex == 2)
            {
                lb1.Sorted = false;
                List<String> list = new List<string>();
                foreach (var item in lb1.Items)
                    list.Add(item.ToString());

                lb1.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    lb1.Items.Add(item);
            }
            else if (cmb.SelectedIndex == 3)
            {
                lb1.Sorted = false;
                List<String> list = new List<string>();
                foreach (var item in lb1.Items)
                    list.Add(item.ToString());

                lb1.Items.Clear();
                var sortResult = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult)
                    lb1.Items.Add(item);
            }
        }
        private void Sort2(object sender, EventArgs e)
        {
            if (cmb2.SelectedIndex == 0)
            {
                List<String> list = new List<String>();
                foreach (var item in lb2.Items)
                    list.Add(item.ToString());

                list.Sort();
                lb2.Items.Clear();
                foreach (var item in list)
                    lb2.Items.Add(item);
            }
            else if (cmb2.SelectedIndex == 1)
            {
                List<String> list = new List<String>();
                foreach (var item in lb2.Items)
                    list.Add(item.ToString());

                list.Sort();
                list.Reverse();
                lb2.Items.Clear();
                foreach (var item in list)
                    lb2.Items.Add(item);
            }
            else if (cmb2.SelectedIndex == 2)
            {
                lb2.Sorted = false;
                List<String> list = new List<string>();
                foreach (var item in lb2.Items)
                    list.Add(item.ToString());

                lb2.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    lb2.Items.Add(item);
            }
            else if (cmb2.SelectedIndex == 3)
            {
                lb2.Sorted = false;
                List<String> list = new List<string>();
                foreach (var item in lb2.Items)
                    list.Add(item.ToString());

                lb2.Items.Clear();
                var sortResult = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult)
                    lb2.Items.Add(item);
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Add(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }
        private void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Teave rakenduse ja arendaja kohta");
        }
        private void Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void Clear1_Click(object sender, EventArgs e)
        {
            lb1.Items.Clear();
        }
        private void Clear2_Click(object sender, EventArgs e)
        {
            lb2.Items.Clear();
        }
        private void VPerenos_Vlevo(object sender, EventArgs e)
        {
            while (lb2.SelectedItems.Count > 0)
            {
                string item = (string)lb2.SelectedItems[0];
                lb1.Items.Add(item);
                lb2.Items.Remove(item);
            }
        }
        private void VPerenos_Vpravo(object sender, EventArgs e)
        {
            while (lb1.SelectedItems.Count > 0)
            {
                string item = (string)lb1.SelectedItems[0];
                lb2.Items.Add(item);
                lb1.Items.Remove(item);
            }
        }
        private void SPerenos_Vlevo(object sender, EventArgs e)
        {
            lb1.Items.AddRange(lb2.Items);
            lb2.Items.Clear();
        }
        private void SPerenos_Vpravo(object sender, EventArgs e)
        {
            lb2.Items.AddRange(lb1.Items);
            lb1.Items.Clear();
        }
        private void Ava(object sender, EventArgs e)
        {
            if (OpenDig.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDig.FileName, Encoding.Default);
                rtb.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDig.Dispose();
        }
        private void Salvesta(object sender, EventArgs e)
        {
            if (SaveDig.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDig.FileName);
                for (int i = 0; i < lb2.Items.Count; i++)
                {
                    Writer.WriteLine((string)lb2.Items[i]);
                }
                Writer.Close();
            }
            SaveDig.Dispose();
        }
        private void Otsi(object sender, EventArgs e)
        {
            lb3.Items.Clear();

            string Find = txb.Text;
            if (chcbx.Checked)
            {
                foreach (string String in lb1.Items)
                {
                    if (String.Contains(Find)) lb3.Items.Add(String);
                }
            }
            if (chcbx1.Checked)
            {
                foreach (string String in lb2.Items)
                {
                    if (String.Contains(Find)) lb3.Items.Add(String);
                }
            }
        }
        private void Alusta(object sender, EventArgs e)
        {
            lb1.Items.Clear();
            lb2.Items.Clear();

            lb1.BeginUpdate();

            string[] Strings = rtb.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in Strings)
            {
                string Str = s.Trim();

                if (Str == String.Empty) continue;
                if (rb1.Checked) lb1.Items.Add(Str);
                if (rb2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) lb1.Items.Add(Str);
                }
                if (rb3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) lb1.Items.Add(Str);
                }
                lb1.EndUpdate();
            }
        }
    }
}