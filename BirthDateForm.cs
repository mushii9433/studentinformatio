using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentInformation_CSharp
{
    public class BirthDateForm : Form
    {
        Label dayOfWeekPromptLabel, monthPromptLabel, dayOfMonthPromptLabel, yearPromptLabel;
        TextBox dayOfWeekTextBox, monthTextBox, dayOfMonthTextBox, yearTextBox;
        Label dateOutputLabel;
        Button showDateButton, clearButton, exitButton;

        public BirthDateForm()
        {
            Text = "Birth Date String";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(700, 470);
            Font = new Font("Segoe UI", 11);
            BackColor = Color.WhiteSmoke;

            var title = new Label
            {
                Text = "BIRTH DATE STRING",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.Navy,
                AutoSize = true,
                Location = new Point(220, 25)
            };

            dayOfWeekPromptLabel = MakeLabel("Enter the day of the week", 45, 100);
            monthPromptLabel = MakeLabel("Enter the name of the month", 45, 150);
            dayOfMonthPromptLabel = MakeLabel("Enter the numeric day of the month", 45, 200);
            yearPromptLabel = MakeLabel("Enter the year", 45, 250);

            dayOfWeekTextBox = MakeTextBox("dayOfWeekTextBox", 430, 95);
            monthTextBox = MakeTextBox("monthTextBox", 430, 145);
            dayOfMonthTextBox = MakeTextBox("dayOfMonthTextBox", 430, 195);
            yearTextBox = MakeTextBox("yearTextBox", 430, 245);

            dateOutputLabel = new Label
            {
                Name = "dateOutputLabel",
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                Location = new Point(45, 305),
                Size = new Size(610, 55),
                BackColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };

            showDateButton = MakeButton("Show Date", "showDateButton", 55, 385);
            clearButton = MakeButton("Clear", "clearButton", 260, 385);
            exitButton = MakeButton("Exit", "exitButton", 465, 385);

            showDateButton.Click += ShowDateButton_Click;
            clearButton.Click += ClearButton_Click;
            exitButton.Click += (s, e) => Close();

            Controls.AddRange(new Control[]
            {
                title, dayOfWeekPromptLabel, monthPromptLabel,
                dayOfMonthPromptLabel, yearPromptLabel,
                dayOfWeekTextBox, monthTextBox, dayOfMonthTextBox, yearTextBox,
                dateOutputLabel, showDateButton, clearButton, exitButton
            });
        }

        Label MakeLabel(string text, int x, int y) => new Label
        {
            Text = text, AutoSize = true, Location = new Point(x, y)
        };

        TextBox MakeTextBox(string name, int x, int y) => new TextBox
        {
            Name = name, Location = new Point(x, y), Size = new Size(200, 30)
        };

        Button MakeButton(string text, string name, int x, int y) => new Button
        {
            Text = text, Name = name, Location = new Point(x, y),
            Size = new Size(170, 42)
        };

        void ShowDateButton_Click(object? sender, EventArgs e)
        {
            string day = dayOfWeekTextBox.Text.Trim();
            string month = monthTextBox.Text.Trim();
            string dayNumber = dayOfMonthTextBox.Text.Trim();
            string year = yearTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(day) ||
                string.IsNullOrWhiteSpace(month) ||
                string.IsNullOrWhiteSpace(dayNumber) ||
                string.IsNullOrWhiteSpace(year))
            {
                MessageBox.Show("Please enter all birth date information.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dateOutputLabel.Text = $"{day}, {month} {dayNumber}, {year}";
        }

        void ClearButton_Click(object? sender, EventArgs e)
        {
            dayOfWeekTextBox.Clear();
            monthTextBox.Clear();
            dayOfMonthTextBox.Clear();
            yearTextBox.Clear();
            dateOutputLabel.Text = "";
            dayOfWeekTextBox.Focus();
        }
    }
}
