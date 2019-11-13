using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class MainForm : Form
    {
        private FootballForm _footballForm;

        public MainForm()
        {
            InitializeComponent();
            
            _footballForm = new FootballForm();
        }

        private void FootballButton_Click(object sender, EventArgs e)
        {
            Hide();
            _footballForm.Show();
        }
    }
}
