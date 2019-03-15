﻿using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();

                // show students

                lbl_Students.Text = "Students";
                pnl_Students.Show();

                

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                //add columns and allign
                listViewStudents.Columns.Add("Student number");
                listViewStudents.Columns[0].Width = 100;
                listViewStudents.Columns.Add("First Name");
                listViewStudents.Columns[1].Width = 125;
                listViewStudents.Columns.Add("Last Name");
                listViewStudents.Columns[2].Width = 125;

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Number.ToString());
                    li.SubItems.Add(s.FirstName);
                    li.SubItems.Add(s.LastName);
                    listViewStudents.Items.Add(li);
                }

            }
            else if (panelName == "Teachers")
            {
                //hiding the dashboard
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();

                //show teachers
                lbl_Students.Text = "Teachers";
                pnl_Students.Show();

                // fill the Teachers listview within the Teachers panel with a list of lecturers
                SomerenLogic.Lecturers_Service lecService = new SomerenLogic.Lecturers_Service();
                List<Teacher> lecturersList = lecService.GetLecturers();

                // clear the listview before filling it again
                listViewStudents.Clear();

                //Adding columns
                listViewStudents.View = View.Details;
                listViewStudents.Columns.Add("Teacher Number");
                listViewStudents.Columns[0].Width = 100;
                listViewStudents.Columns.Add("Name");
                listViewStudents.Columns[1].Width = 125;

                foreach (SomerenModel.Teacher s in lecturersList)
                {
                    ListViewItem li = new ListViewItem(s.Number.ToString());
                    li.SubItems.Add(s.Name.ToString());
                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                

                //show rooms
                pnl_Students.Show();
                lbl_Students.Text = "Rooms     ";


                //filling the roomList a list of rooms
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                //clearing listView
                listViewStudents.Clear();

                //add columns and allign
                listViewStudents.Columns.Add("Room Number");
                listViewStudents.Columns[0].Width = 100;
                listViewStudents.Columns.Add("Type");
                listViewStudents.Columns[1].Width = 125;
                listViewStudents.Columns.Add("Capacity");
                listViewStudents.Columns[2].Width = 125;

                foreach (SomerenModel.Room s in roomList)
                {

                    ListViewItem li = new ListViewItem(s.Number.ToString());
                    if (s.Type == true)
                    {
                        li.SubItems.Add("teacher");
                    }
                    else
                    {
                        li.SubItems.Add("student");
                    }
                    
                    li.SubItems.Add(s.Capacity.ToString());
                    listViewStudents.Items.Add(li);

                    //li.SubItems.Add(s.Type.ToString());
                    //saved for potential later use
                }

            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }
    }
}
