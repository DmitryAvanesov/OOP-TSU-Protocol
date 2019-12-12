using System;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FootballButton_Click(object sender, EventArgs e)
        {
            Hide();

            var managementForm = new ManagementForm<FootballTeam, FootballPlayer>(this);
            managementForm.Show();
        }

        private void BasketballButton_Click(object sender, EventArgs e)
        {
            Hide();

            var managementForm = new ManagementForm<BasketballTeam, BasketballPlayer>(this);
            managementForm.Show();
        }
    }
}
