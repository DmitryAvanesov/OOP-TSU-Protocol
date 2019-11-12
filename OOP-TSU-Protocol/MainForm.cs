using System;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class MainForm : Form
    {
        private MinuteLabel _footballForm;

        public MainForm()
        {
            InitializeComponent();

            _footballForm = new MinuteLabel();
        }

        private void FootballButton_Click(object sender, EventArgs e)
        {
            Hide();
            _footballForm.Show();
        }
    }
}
