using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
           
                string selectedTask = checkedListBox1.SelectedItem.ToString();
                string[] taskDetails = selectedTask.Split(new[] { "\n" }, StringSplitOptions.None);

                
                string taskName = taskDetails[0].Substring(taskDetails[0].IndexOf(":") + 2);
                string description = taskDetails[1].Substring(taskDetails[1].IndexOf(":") + 2);
                string importance = taskDetails[2].Substring(taskDetails[2].IndexOf(":") + 2);
                string date = taskDetails[3].Substring(taskDetails[3].IndexOf(":") + 2);

                textBox1.Text = taskName;
                textBox2.Text = description;
                comboBox1.SelectedItem = importance;
                dateTimePicker1.Value = DateTime.Parse(date);
            }
            else
            {
                MessageBox.Show("Please select a task to edit.");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string taskName = textBox1.Text;

            
            ProcessTask(taskName);
        }
        private void ProcessTask(string taskName)
        {
        
            Console.WriteLine("Task Name: " + taskName);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string description = textBox2.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {

            if (comboBox1.SelectedItem != null)
            {
             
                string selectedImportance = comboBox1.SelectedItem.ToString();

            
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string taskName = textBox1.Text;
            string description = textBox2.Text;
            string selectedImportance = comboBox1.SelectedItem?.ToString();
            string selectedDate = dateTimePicker1.Value.ToString();

            if (string.IsNullOrWhiteSpace(taskName) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(selectedImportance))
            {
                MessageBox.Show("Please provide all necessary information to add a task.");
                return;
            }

          
            string taskDetails = $"Task Name: {taskName}\nDescription: {description}\nImportance: {selectedImportance} \nTime : {selectedDate}";

            
            AddTaskWithProgressBar(taskDetails);

           
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void AddTaskWithProgressBar(string taskDetails)
        {
         
            checkedListBox1.Items.Add(taskDetails);

            
            int taskIndex = checkedListBox1.Items.Count - 1;

 
            ProgressBar progressBar = new ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 60;

            progressBar.ForeColor = Color.Green;

            int taskNameWidth = TextRenderer.MeasureText(taskDetails.Split('\n')[0], checkedListBox1.Font).Width;

         
            checkedListBox1.Controls.Add(progressBar);

            
            progressBar.Location = new Point(checkedListBox1.GetItemRectangle(taskIndex).X + taskNameWidth + 100,
                                              checkedListBox1.GetItemRectangle(taskIndex).Y + 3);
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
                string selectedTask = checkedListBox1.SelectedItem.ToString();
                MessageBox.Show(selectedTask);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
                int selectedIndex = checkedListBox1.SelectedIndex;

                // Remove the task
                checkedListBox1.Items.RemoveAt(selectedIndex);

                // Remove the associated progress bar
                if (checkedListBox1.Controls.Count > selectedIndex)
                {
                    checkedListBox1.Controls.RemoveAt(selectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
                
                string updatedTask = $"Task Name: {textBox1.Text}\nDescription: {textBox2.Text}\nImportance: {comboBox1.SelectedItem}\nTime : {dateTimePicker1.Value.ToString()}";

                checkedListBox1.Items[checkedListBox1.SelectedIndex] = updatedTask;

                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now; 
            }
            else
            {
                MessageBox.Show("Please select a task to edit.");
            }
        }
    }
}
