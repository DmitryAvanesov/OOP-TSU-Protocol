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

            var protocolForm = new ProtocolForm<FootballTeam, FootballPlayer>();
            protocolForm.Show();
        }
    }
}
