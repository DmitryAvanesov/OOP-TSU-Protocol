using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class FootballForm : Form
    {
        private readonly IList<FootballTeam> _teamsList =
            new List<FootballTeam>()
            {
                new FootballTeam("Liverpool F.C.", "Liverpool, England"),
                new FootballTeam("Manchester City F.C.", "Manchester, England")
            };

        private readonly IList<List<FootballPlayer>> _playersList =
            new List<List<FootballPlayer>>()
            {
                new List<FootballPlayer>()
                {
                    new FootballPlayer(11, "Mohamed Salah"),
                    new FootballPlayer(14, "Jordan Henderson")
                },

                new List<FootballPlayer>()
                {
                    new FootballPlayer(10, "Sergio Agüero"),
                    new FootballPlayer(11, "Oleksandr Zinchenko")
                }
            };

        private IList<FootballTeam> _teams;

        public FootballForm()
        {
            InitializeComponent();
            AddData();
        }

        private void AddData()
        {
            _teams = _teamsList;

            for (int i = 0; i < _teams.Count; i++)
            {
                _teams[i].AddPlayers(_playersList[i]);
            }
        }
    }
}
