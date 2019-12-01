using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class MainForm : Form
    {
        private ProtocolForm _protocolForm;

        public MainForm()
        {
            InitializeComponent();
            
            _protocolForm = new ProtocolForm();
        }

        private void FootballButton_Click(object sender, EventArgs e)
        {
            Hide();
            _protocolForm.Show();
        }
    }
}
