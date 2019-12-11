namespace OOP_TSU_Protocol
{
    partial class ManagementForm<T1, T2>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectTournamentLabel = new System.Windows.Forms.Label();
            this.TournamentInput = new System.Windows.Forms.ComboBox();
            this.SelectTournamentButton = new System.Windows.Forms.Button();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.NumberOfTeamsInput = new System.Windows.Forms.ComboBox();
            this.NumberOfTeamsLabel = new System.Windows.Forms.Label();
            this.NumberOfRowsLabel = new System.Windows.Forms.Label();
            this.NumberOfRowsInput = new System.Windows.Forms.ComboBox();
            this.CreateTournamentLabel = new System.Windows.Forms.Label();
            this.AddTeamsLabel = new System.Windows.Forms.Label();
            this.TeamInput = new System.Windows.Forms.ComboBox();
            this.TournamentTitleInput = new System.Windows.Forms.TextBox();
            this.TournamentTitleLabel = new System.Windows.Forms.Label();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.TeamOutput = new System.Windows.Forms.ListBox();
            this.ScheduleLabel = new System.Windows.Forms.Label();
            this.CurrentGameLabel = new System.Windows.Forms.Label();
            this.GameDateInput = new System.Windows.Forms.DateTimePicker();
            this.SaveDateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectTournamentLabel
            // 
            this.SelectTournamentLabel.AutoSize = true;
            this.SelectTournamentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectTournamentLabel.Location = new System.Drawing.Point(56, 336);
            this.SelectTournamentLabel.Name = "SelectTournamentLabel";
            this.SelectTournamentLabel.Size = new System.Drawing.Size(357, 46);
            this.SelectTournamentLabel.TabIndex = 6;
            this.SelectTournamentLabel.Text = "Select Tournament";
            // 
            // TournamentInput
            // 
            this.TournamentInput.FormattingEnabled = true;
            this.TournamentInput.Location = new System.Drawing.Point(64, 404);
            this.TournamentInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TournamentInput.Name = "TournamentInput";
            this.TournamentInput.Size = new System.Drawing.Size(349, 24);
            this.TournamentInput.TabIndex = 20;
            // 
            // SelectTournamentButton
            // 
            this.SelectTournamentButton.BackColor = System.Drawing.Color.Lavender;
            this.SelectTournamentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectTournamentButton.Location = new System.Drawing.Point(64, 433);
            this.SelectTournamentButton.Name = "SelectTournamentButton";
            this.SelectTournamentButton.Size = new System.Drawing.Size(84, 27);
            this.SelectTournamentButton.TabIndex = 21;
            this.SelectTournamentButton.Text = "Select";
            this.SelectTournamentButton.UseVisualStyleBackColor = false;
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.BackColor = System.Drawing.Color.Lavender;
            this.CreateTournamentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTournamentButton.Location = new System.Drawing.Point(475, 705);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(164, 48);
            this.CreateTournamentButton.TabIndex = 22;
            this.CreateTournamentButton.Text = "Create";
            this.CreateTournamentButton.UseVisualStyleBackColor = false;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // NumberOfTeamsInput
            // 
            this.NumberOfTeamsInput.FormattingEnabled = true;
            this.NumberOfTeamsInput.Items.AddRange(new object[] {
            "2",
            "4",
            "8"});
            this.NumberOfTeamsInput.Location = new System.Drawing.Point(475, 456);
            this.NumberOfTeamsInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NumberOfTeamsInput.Name = "NumberOfTeamsInput";
            this.NumberOfTeamsInput.Size = new System.Drawing.Size(164, 24);
            this.NumberOfTeamsInput.TabIndex = 23;
            this.NumberOfTeamsInput.SelectedIndexChanged += new System.EventHandler(this.NumberOfTeamsInput_SelectedIndexChanged);
            // 
            // NumberOfTeamsLabel
            // 
            this.NumberOfTeamsLabel.AutoSize = true;
            this.NumberOfTeamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOfTeamsLabel.Location = new System.Drawing.Point(469, 404);
            this.NumberOfTeamsLabel.Name = "NumberOfTeamsLabel";
            this.NumberOfTeamsLabel.Size = new System.Drawing.Size(239, 36);
            this.NumberOfTeamsLabel.TabIndex = 24;
            this.NumberOfTeamsLabel.Text = "Number of teams";
            // 
            // NumberOfRowsLabel
            // 
            this.NumberOfRowsLabel.AutoSize = true;
            this.NumberOfRowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOfRowsLabel.Location = new System.Drawing.Point(469, 527);
            this.NumberOfRowsLabel.Name = "NumberOfRowsLabel";
            this.NumberOfRowsLabel.Size = new System.Drawing.Size(225, 36);
            this.NumberOfRowsLabel.TabIndex = 26;
            this.NumberOfRowsLabel.Text = "Number of rows";
            // 
            // NumberOfRowsInput
            // 
            this.NumberOfRowsInput.FormattingEnabled = true;
            this.NumberOfRowsInput.Items.AddRange(new object[] {
            "1",
            "2"});
            this.NumberOfRowsInput.Location = new System.Drawing.Point(475, 579);
            this.NumberOfRowsInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NumberOfRowsInput.Name = "NumberOfRowsInput";
            this.NumberOfRowsInput.Size = new System.Drawing.Size(164, 24);
            this.NumberOfRowsInput.TabIndex = 25;
            this.NumberOfRowsInput.SelectedIndexChanged += new System.EventHandler(this.NumberOfRowsInput_SelectedIndexChanged);
            // 
            // CreateTournamentLabel
            // 
            this.CreateTournamentLabel.AutoSize = true;
            this.CreateTournamentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateTournamentLabel.Location = new System.Drawing.Point(467, 195);
            this.CreateTournamentLabel.Name = "CreateTournamentLabel";
            this.CreateTournamentLabel.Size = new System.Drawing.Size(364, 46);
            this.CreateTournamentLabel.TabIndex = 27;
            this.CreateTournamentLabel.Text = "Create Tournament";
            // 
            // AddTeamsLabel
            // 
            this.AddTeamsLabel.AutoSize = true;
            this.AddTeamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTeamsLabel.Location = new System.Drawing.Point(852, 289);
            this.AddTeamsLabel.Name = "AddTeamsLabel";
            this.AddTeamsLabel.Size = new System.Drawing.Size(156, 36);
            this.AddTeamsLabel.TabIndex = 29;
            this.AddTeamsLabel.Text = "Add teams";
            // 
            // TeamInput
            // 
            this.TeamInput.Enabled = false;
            this.TeamInput.FormattingEnabled = true;
            this.TeamInput.Location = new System.Drawing.Point(858, 341);
            this.TeamInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TeamInput.Name = "TeamInput";
            this.TeamInput.Size = new System.Drawing.Size(282, 24);
            this.TeamInput.TabIndex = 28;
            // 
            // TournamentTitleInput
            // 
            this.TournamentTitleInput.Location = new System.Drawing.Point(475, 339);
            this.TournamentTitleInput.Name = "TournamentTitleInput";
            this.TournamentTitleInput.Size = new System.Drawing.Size(282, 22);
            this.TournamentTitleInput.TabIndex = 31;
            // 
            // TournamentTitleLabel
            // 
            this.TournamentTitleLabel.AutoSize = true;
            this.TournamentTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TournamentTitleLabel.Location = new System.Drawing.Point(469, 289);
            this.TournamentTitleLabel.Name = "TournamentTitleLabel";
            this.TournamentTitleLabel.Size = new System.Drawing.Size(71, 36);
            this.TournamentTitleLabel.TabIndex = 32;
            this.TournamentTitleLabel.Text = "Title";
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.BackColor = System.Drawing.Color.Lavender;
            this.AddTeamButton.Enabled = false;
            this.AddTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTeamButton.Location = new System.Drawing.Point(858, 370);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(84, 27);
            this.AddTeamButton.TabIndex = 33;
            this.AddTeamButton.Text = "Add";
            this.AddTeamButton.UseVisualStyleBackColor = false;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // TeamOutput
            // 
            this.TeamOutput.BackColor = System.Drawing.Color.Lavender;
            this.TeamOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeamOutput.FormattingEnabled = true;
            this.TeamOutput.ItemHeight = 20;
            this.TeamOutput.Location = new System.Drawing.Point(858, 433);
            this.TeamOutput.Name = "TeamOutput";
            this.TeamOutput.Size = new System.Drawing.Size(282, 324);
            this.TeamOutput.TabIndex = 34;
            // 
            // ScheduleLabel
            // 
            this.ScheduleLabel.AutoSize = true;
            this.ScheduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScheduleLabel.Location = new System.Drawing.Point(1235, 289);
            this.ScheduleLabel.Name = "ScheduleLabel";
            this.ScheduleLabel.Size = new System.Drawing.Size(140, 36);
            this.ScheduleLabel.TabIndex = 35;
            this.ScheduleLabel.Text = "Schedule";
            // 
            // CurrentGameLabel
            // 
            this.CurrentGameLabel.AutoSize = true;
            this.CurrentGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentGameLabel.Location = new System.Drawing.Point(1237, 344);
            this.CurrentGameLabel.Name = "CurrentGameLabel";
            this.CurrentGameLabel.Size = new System.Drawing.Size(111, 20);
            this.CurrentGameLabel.TabIndex = 36;
            this.CurrentGameLabel.Text = "Current game";
            // 
            // GameDateInput
            // 
            this.GameDateInput.Enabled = false;
            this.GameDateInput.Location = new System.Drawing.Point(1241, 375);
            this.GameDateInput.Name = "GameDateInput";
            this.GameDateInput.Size = new System.Drawing.Size(200, 22);
            this.GameDateInput.TabIndex = 37;
            // 
            // SaveDateButton
            // 
            this.SaveDateButton.BackColor = System.Drawing.Color.Lavender;
            this.SaveDateButton.Enabled = false;
            this.SaveDateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveDateButton.Location = new System.Drawing.Point(1241, 413);
            this.SaveDateButton.Name = "SaveDateButton";
            this.SaveDateButton.Size = new System.Drawing.Size(84, 27);
            this.SaveDateButton.TabIndex = 38;
            this.SaveDateButton.Text = "Save";
            this.SaveDateButton.UseVisualStyleBackColor = false;
            this.SaveDateButton.Click += new System.EventHandler(this.SaveDateButton_Click);
            // 
            // ManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.SaveDateButton);
            this.Controls.Add(this.GameDateInput);
            this.Controls.Add(this.CurrentGameLabel);
            this.Controls.Add(this.ScheduleLabel);
            this.Controls.Add(this.TeamOutput);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.TournamentTitleLabel);
            this.Controls.Add(this.TournamentTitleInput);
            this.Controls.Add(this.AddTeamsLabel);
            this.Controls.Add(this.TeamInput);
            this.Controls.Add(this.CreateTournamentLabel);
            this.Controls.Add(this.NumberOfRowsLabel);
            this.Controls.Add(this.NumberOfRowsInput);
            this.Controls.Add(this.NumberOfTeamsLabel);
            this.Controls.Add(this.NumberOfTeamsInput);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.SelectTournamentButton);
            this.Controls.Add(this.TournamentInput);
            this.Controls.Add(this.SelectTournamentLabel);
            this.Name = "ManagementForm";
            this.Text = "ManagementForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectTournamentLabel;
        private System.Windows.Forms.ComboBox TournamentInput;
        private System.Windows.Forms.Button SelectTournamentButton;
        private System.Windows.Forms.Button CreateTournamentButton;
        private System.Windows.Forms.ComboBox NumberOfTeamsInput;
        private System.Windows.Forms.Label NumberOfTeamsLabel;
        private System.Windows.Forms.Label NumberOfRowsLabel;
        private System.Windows.Forms.ComboBox NumberOfRowsInput;
        private System.Windows.Forms.Label CreateTournamentLabel;
        private System.Windows.Forms.Label AddTeamsLabel;
        private System.Windows.Forms.ComboBox TeamInput;
        private System.Windows.Forms.TextBox TournamentTitleInput;
        private System.Windows.Forms.Label TournamentTitleLabel;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.ListBox TeamOutput;
        private System.Windows.Forms.Label ScheduleLabel;
        private System.Windows.Forms.Label CurrentGameLabel;
        private System.Windows.Forms.DateTimePicker GameDateInput;
        private System.Windows.Forms.Button SaveDateButton;
    }
}