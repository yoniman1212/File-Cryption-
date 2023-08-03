using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace file_encrypt
{
    public partial class Form1 : Form
    {
        byte[] abc;
        byte[,] table;



        // Define some colors and fonts
        private Color primaryColor = Color.FromArgb(0, 123, 255);
        private Color secondaryColor = Color.FromArgb(255, 255, 255);
        private Font labelFont = new Font("Arial", 12, FontStyle.Bold);
        private Font buttonFont = new Font("Arial", 10, FontStyle.Regular);

        public Form1()
        {
            InitializeComponent();

            // Apply styles to the controls
            // simple substitution cipher algorithm

            tbPath.BorderStyle = BorderStyle.None;
            tbPath.BackColor = secondaryColor;
            tbPath.Font = labelFont;

            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.BackColor = secondaryColor;
            tbPassword.Font = labelFont;

            btBrowse.BackColor = primaryColor;
            btBrowse.Font = buttonFont;
            btBrowse.ForeColor = secondaryColor;
            btBrowse.FlatStyle = FlatStyle.Flat;
            btBrowse.Cursor = Cursors.Hand;



            btStart.FlatStyle = FlatStyle.Flat;
            btStart.BackColor = primaryColor;
            btStart.ForeColor = secondaryColor;
            btStart.Font = buttonFont;
            btStart.Cursor = Cursors.Hand;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Multiselect = false;
            if (od.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = od.FileName;
            }
        }

        private void rdEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdEncrypt.Checked)
            {
                rdDecrypt.Checked = false;
            }
        }

        private void rdDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDecrypt.Checked)
            {
                rdEncrypt.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdEncrypt.Checked = true;
            abc = new byte[256];
            for (int i = 0; i < 256; i++)
                abc[i] = Convert.ToByte(i);
            table = new byte[256, 256];
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    table[i, j] = abc[(i + j) % 256];
                }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbPath.Text))
            {
                MessageBox.Show("File does not exist.");
                return;
            }
            if (String.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Password empty. Please enter your password.");
                return;
            }

            try
            {
                byte[] fileContent = File.ReadAllBytes(tbPath.Text);
                byte[] passwordTmp = Encoding.ASCII.GetBytes(tbPassword.Text);
                byte[] Keys = new byte[fileContent.Length];

                for (int i = 0; i < fileContent.Length; i++)
                    Keys[i] = passwordTmp[i % passwordTmp.Length];

                //Encrypt or decrypt
                byte[] result = new byte[fileContent.Length];
                if (rdEncrypt.Checked)
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = Keys[i];
                        int valueIndex = -1, keyIndex = -1;
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == value)
                            {
                                valueIndex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        result[i] = table[keyIndex, valueIndex];
                    }
                }
                else
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = Keys[i];
                        int valueIndex = -1, keyIndex = -1;

                        for (int j = 0; j < 256; j++)
                            if (abc[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (table[keyIndex, j] == value)
                            {
                                valueIndex = j;
                                break;
                            }
                        result[i] = abc[valueIndex];
                    }
                }

                //Save result to new file with the same extension
                String fileExt = Path.GetExtension(tbPath.Text);
                SaveFileDialog sd = new SaveFileDialog();
                
                sd.Filter = "Files (*" + fileExt + ") | *" + fileExt;
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sd.FileName, result);
                }
                FileStream fileStream = File.OpenWrite(tbPath.Text);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File not found: " + ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading/writing file: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
    }