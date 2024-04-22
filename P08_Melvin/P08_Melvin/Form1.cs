using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P08_Melvin
{
    public partial class Form1 : Form
    {
        class TestScores
        {
            public string Name { get; set; }
            public int Earned_1 { get; set; }
            public int Earned_2 { get; set; }
            public int Earned_3 { get; set; }
            public int Possible_1 { get; set; }
            public int Possible_2 { get; set; }
            public int Possible_3 { get; set; }

            public TestScores(String name, int earned1, int earned2, int earned3, int possible1, int possible2, int possible3)
            {
                Name = name;
                Earned_1 = earned1;
                Earned_2 = earned2;
                Earned_3 = earned3;
                Possible_1 = possible1;
                Possible_2 = possible2;
                Possible_3 = possible3;
            }
        }

        // Dictionary 
        Dictionary<string, TestScores> scoresDictionary = new Dictionary<string, TestScores>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txt_Name.Text = "";
            txt_Earned1.Text = "";
            txt_Possible1.Text = "";
            txt_Earned2.Text = "";
            txt_Possible2.Text = "";
            txt_Earned3.Text = "";
            txt_Possible3.Text = "";
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text;
                if (!scoresDictionary.ContainsKey(name))
                {
                    //Adding Info
                    TestScores newTestScores;
                    int earned1 = int.Parse(txt_Earned1.Text);
                    int earned2 = int.Parse(txt_Earned2.Text);
                    int earned3 = int.Parse(txt_Earned3.Text);
                    int possible1 = int.Parse(txt_Possible1.Text);
                    int possible2 = int.Parse(txt_Possible2.Text);
                    int possible3 = int.Parse(txt_Possible3.Text);

                    //Dic
                    TestScores newTest = new TestScores(name, earned1, earned2, earned3, possible1, possible2, possible3);
                    scoresDictionary.Add(name, newTest);

                    ClearTextBoxes();
                }
                else
                {
                    //Error
                    MessageBox.Show("Error: TestScores Already Exists!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text;

                if (scoresDictionary.ContainsKey(name))
                {
                    //Show info
                    TestScores student = scoresDictionary[name];
                    txt_Earned1.Text = student.Earned_1.ToString();
                    txt_Possible1.Text = student.Possible_1.ToString();
                    txt_Earned2.Text = student.Earned_2.ToString();
                    txt_Possible2.Text = student.Possible_2.ToString();
                    txt_Earned3.Text = student.Earned_3.ToString();
                    txt_Possible3.Text = student.Possible_3.ToString();
                }
                else
                {
                    //error
                    MessageBox.Show("Error: TestScores Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    string name = txt_Name.Text;

                    if (scoresDictionary.ContainsKey(name))
                    {
                        TestScores updatedTestScores = scoresDictionary[name];

                        updatedTestScores.Earned_1 = int.Parse(txt_Earned1.Text);
                        updatedTestScores.Possible_1 = int.Parse(txt_Possible1.Text);
                        updatedTestScores.Earned_2 = int.Parse(txt_Earned2.Text);
                        updatedTestScores.Possible_2 = int.Parse(txt_Possible2.Text);
                        updatedTestScores.Earned_3 = int.Parse(txt_Earned3.Text);
                        updatedTestScores.Possible_3 = int.Parse(txt_Possible3.Text);

                        scoresDictionary[name] = updatedTestScores;
                    }
                    else
                    {
                        MessageBox.Show("Error: TestScores Not Found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = txt_Name.Text;

                //Removing name
                if (scoresDictionary.ContainsKey(name))
                {
                    scoresDictionary.Remove(name);
                }
                else
                {
                    //Error
                    MessageBox.Show("Error: TestScores Not Found!");
                }

                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}