using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentInformation_CSharp
{
    public class StudentInformationForm : Form
    {
        Label lblTitle, lblname, lblstudentid, lbldepartment, lblsemester;
        TextBox txtname, txtstudentid, txtdepartment, txtsemester;
        Label lbloutput;
        Button btnshowinfo, btnclear, btnexit, btnBirthDate;

        public StudentInformationForm()
        {
            Text = "Student Information";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(900, 560);
            Font = new Font("Segoe UI", 11);
            BackColor = Color.WhiteSmoke;

            lblTitle = new Label
            {
                Text = "STUDENT INFORMATION",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.Navy,
                AutoSize = true,
                Location = new Point(285, 25)
            };

            lblname = MakeLabel("Enter the student name", 60, 105);
            lblstudentid = MakeLabel("Enter the student ID", 60, 165);
            lbldepartment = MakeLabel("Enter the department", 60, 225);
            lblsemester = MakeLabel("Enter the semester", 60, 285);

            txtname = MakeTextBox("txtname", 400, 100);
            txtstudentid = MakeTextBox("txtstudentid", 400, 160);
            txtdepartment = MakeTextBox("txtdepartment", 400, 220);
            txtsemester = MakeTextBox("txtsemester", 400, 280);

            lbloutput = new Label
            {
                Name = "lbloutput",
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Location = new Point(60, 350),
                Size = new Size(780, 75),
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            btnshowinfo = MakeButton("Show Information", "btnshowinfo", 70, 455);
            btnclear = MakeButton("Clear", "btnclear", 335, 455);
            btnexit = MakeButton("Exit", "btnexit", 600, 455);

            btnshowinfo.Click += Btnshowinfo_Click;
            btnclear.Click += Btnclear_Click;
            btnexit.Click += (s, e) => Close();

            btnBirthDate = MakeButton("Birth Date String", "btnBirthDate", 335, 505);
            btnBirthDate.Width = 230;
            btnBirthDate.Click += (s, e) => new BirthDateForm().ShowDialog();

            Controls.AddRange(new Control[]
            {
                lblTitle, lblname, lblstudentid, lbldepartment, lblsemester,
                txtname, txtstudentid, txtdepartment, txtsemester,
                lbloutput, btnshowinfo, btnclear, btnexit, btnBirthDate
            });
        }

        Label MakeLabel(string text, int x, int y) => new Label
        {
            Text = text, AutoSize = true, Location = new Point(x, y)
        };

        TextBox MakeTextBox(string name, int x, int y) => new TextBox
        {
            Name = name, Location = new Point(x, y), Size = new Size(410, 32)
        };

        Button MakeButton(string text, string name, int x, int y) => new Button
        {
            Text = text, Name = name, Location = new Point(x, y),
            Size = new Size(200, 45)
        };

        void Btnshowinfo_Click(object? sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string id = txtstudentid.Text.Trim();
            string department = txtdepartment.Text.Trim();
            string semester = txtsemester.Text.Trim();

            lbloutput.Text =
                $"Name: {name}\r\nStudent ID: {id}\r\nDepartment: {department}\r\nSemester: {semester}";
        }

        void Btnclear_Click(object? sender, EventArgs e)
        {
            txtname.Clear();
            txtstudentid.Clear();
            txtdepartment.Clear();
            txtsemester.Clear();
            lbloutput.Text = "";
            txtname.Focus();
        }
    }
}
