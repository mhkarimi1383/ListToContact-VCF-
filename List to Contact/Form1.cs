using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace List_to_Contact
{
    public partial class Form1 : Form
    {
        string pathToSave = string.Empty;
        string VcfTemplate = File.OpenText($@"{Environment.CurrentDirectory}\VcfTemplate.txt").ReadToEnd();
        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        OpenFileDialog openFileDialog2 = new OpenFileDialog();
        OpenFileDialog openFileDialog3 = new OpenFileDialog();
        string numberList = string.Empty;

        public Form1()
        {
            InitializeComponent();
            AjustSize();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            AjustSize();
        }

        private void AjustSize()
        {
            listBox1.Width = Width / 3;
            listBox2.Width = Width / 3;
            listBox3.Width = Width / 3;
            button1.Width = Width / 3;
            button2.Width = Width / 3;
            button3.Width = Width / 3;
            panel1.Height = Height - 200;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Reset();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.Description = "Select Folder to Save Contact Files";
            DialogResult folderBrowserDialog1DialogResult = folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1DialogResult == DialogResult.OK)
            {
                pathToSave = folderBrowserDialog1.SelectedPath;
                folderBrowserDialog1.Dispose();
                folderBrowserDialog1.Reset();
                
            }
            else
            {
                MessageBox.Show(this, "You are not selected a path!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            folderBrowserDialog1.Reset();
        }

        //Open Number List
        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Title = "Select Number List File";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            DialogResult openFileDialog1DialogResult = openFileDialog1.ShowDialog();
            if (openFileDialog1DialogResult == DialogResult.OK)
            {
                listBox2.Items.Clear();
                StreamReader numbersListStreamReader = new StreamReader(openFileDialog1.FileName);
                string line;
                while ((line = numbersListStreamReader.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
                numberList = numbersListStreamReader.ReadToEnd();
                numbersListStreamReader.Close();
            }
            else
            {
                MessageBox.Show(this, "You are not selected a File!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.Reset();
            openFileDialog2.CheckFileExists = true;
            openFileDialog2.CheckPathExists = true;
            openFileDialog2.Title = "Select First Name List File";
            openFileDialog2.Filter = "txt files (*.txt)|*.txt";
            DialogResult openFileDialog2DialogResult = openFileDialog2.ShowDialog();
            if (openFileDialog2DialogResult == DialogResult.OK)
            {
                listBox2.Items.Clear();
                StreamReader firstNamesListStreamReader = new StreamReader(openFileDialog2.FileName);
                string line;
                while ((line = firstNamesListStreamReader.ReadLine()) != null)
                {
                    listBox2.Items.Add(line);
                }
                firstNamesListStreamReader.Close();
            }
            else
            {
                MessageBox.Show(this, "You are not selected a File!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog3.Reset();
            openFileDialog3.CheckFileExists = true;
            openFileDialog3.CheckPathExists = true;
            openFileDialog3.Title = "Select Last Name List File";
            openFileDialog3.Filter = "txt files (*.txt)|*.txt";
            DialogResult openFileDialog3DialogResult = openFileDialog3.ShowDialog();
            if (openFileDialog3DialogResult == DialogResult.OK)
            {
                listBox3.Items.Clear();
                StreamReader lastNamesListStreamReader = new StreamReader(openFileDialog3.FileName);
                string line;
                while ((line = lastNamesListStreamReader.ReadLine()) != null)
                {
                    listBox3.Items.Add(line);
                }
                lastNamesListStreamReader.Close();
            }
            else
            {
                MessageBox.Show(this, "You are not selected a File!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int counter=0;
            int countToFinish = listBox1.Items.Count;
            StreamWriter contactFileStreamWriter;
            while (counter < countToFinish)
            {
                contactFileStreamWriter = new StreamWriter($@"{pathToSave}\{counter}.vcf");

                if (listBox1.Items.Count == listBox2.Items.Count && listBox3.Items.Count == listBox2.Items.Count)
                {
                    contactFileStreamWriter.Write(VcfTemplate
                    .Replace("<Number>", listBox1.Items[counter].ToString())
                    .Replace("<FirstName>", listBox2.Items[counter].ToString())
                    .Replace("<LastName>", listBox3.Items[counter].ToString()));
                    contactFileStreamWriter.Flush();
                    contactFileStreamWriter.Close();
                    counter++;
                    continue;
                }
                else if (listBox1.Items.Count == listBox2.Items.Count)
                {
                    contactFileStreamWriter.Write(VcfTemplate
                    .Replace("<Number>", listBox1.Items[counter].ToString())
                    .Replace("<FirstName>", listBox2.Items[counter].ToString())
                    .Replace("<LastName>", string.Empty));
                    contactFileStreamWriter.Flush();
                    contactFileStreamWriter.Close();
                    counter++;
                    continue;
                }
                else if (listBox1.Items.Count != listBox2.Items.Count)
                {
                    contactFileStreamWriter.Write(VcfTemplate
                    .Replace("<Number>", listBox1.Items[counter].ToString())
                    .Replace("<FirstName>", listBox1.Items[counter].ToString())
                    .Replace("<LastName>", string.Empty));
                    contactFileStreamWriter.Flush();
                    contactFileStreamWriter.Close();
                    counter++;
                    continue;
                }
                
            }
        }
    }
}
