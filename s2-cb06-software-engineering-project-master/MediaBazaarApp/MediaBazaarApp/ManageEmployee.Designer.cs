namespace MediaBazaarApp
{
    partial class ManageEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEmployee));
            this.lbEmployees = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFire = new System.Windows.Forms.Button();
            this.tbWage = new System.Windows.Forms.TextBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.btnChangePos = new System.Windows.Forms.Button();
            this.gbID = new System.Windows.Forms.GroupBox();
            this.gbPosition = new System.Windows.Forms.GroupBox();
            this.gbWage = new System.Windows.Forms.GroupBox();
            this.btnChangeWage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbID.SuspendLayout();
            this.gbPosition.SuspendLayout();
            this.gbWage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEmployees
            // 
            this.lbEmployees.FormattingEnabled = true;
            this.lbEmployees.ItemHeight = 17;
            this.lbEmployees.Location = new System.Drawing.Point(55, 89);
            this.lbEmployees.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbEmployees.Name = "lbEmployees";
            this.lbEmployees.Size = new System.Drawing.Size(660, 429);
            this.lbEmployees.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Promote, Fire and Change Employees Salary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee ID to Modify:";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(183, 35);
            this.tbID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(60, 28);
            this.tbID.TabIndex = 3;
            this.tbID.TextChanged += new System.EventHandler(this.TbID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "New Position:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "New Wage:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fire Employee?";
            // 
            // btnFire
            // 
            this.btnFire.BackColor = System.Drawing.Color.Salmon;
            this.btnFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFire.Location = new System.Drawing.Point(127, 41);
            this.btnFire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(132, 33);
            this.btnFire.TabIndex = 7;
            this.btnFire.Text = "Fired!";
            this.btnFire.UseVisualStyleBackColor = false;
            this.btnFire.Click += new System.EventHandler(this.BtnFire_Click);
            // 
            // tbWage
            // 
            this.tbWage.Location = new System.Drawing.Point(101, 40);
            this.tbWage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbWage.Name = "tbWage";
            this.tbWage.Size = new System.Drawing.Size(60, 28);
            this.tbWage.TabIndex = 8;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "Cashier",
            "Customer assistant",
            "Inventory manager"});
            this.cmbPosition.Location = new System.Drawing.Point(109, 32);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(148, 25);
            this.cmbPosition.TabIndex = 25;
            // 
            // btnChangePos
            // 
            this.btnChangePos.BackColor = System.Drawing.Color.GreenYellow;
            this.btnChangePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePos.Location = new System.Drawing.Point(67, 73);
            this.btnChangePos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangePos.Name = "btnChangePos";
            this.btnChangePos.Size = new System.Drawing.Size(191, 36);
            this.btnChangePos.TabIndex = 26;
            this.btnChangePos.Text = "Promote/Change Position";
            this.btnChangePos.UseVisualStyleBackColor = false;
            this.btnChangePos.Click += new System.EventHandler(this.Button1_Click);
            // 
            // gbID
            // 
            this.gbID.BackColor = System.Drawing.Color.Transparent;
            this.gbID.Controls.Add(this.label2);
            this.gbID.Controls.Add(this.tbID);
            this.gbID.Location = new System.Drawing.Point(787, 30);
            this.gbID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbID.Name = "gbID";
            this.gbID.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbID.Size = new System.Drawing.Size(267, 85);
            this.gbID.TabIndex = 27;
            this.gbID.TabStop = false;
            this.gbID.Text = "Employee ID";
            // 
            // gbPosition
            // 
            this.gbPosition.BackColor = System.Drawing.Color.Transparent;
            this.gbPosition.Controls.Add(this.label3);
            this.gbPosition.Controls.Add(this.cmbPosition);
            this.gbPosition.Controls.Add(this.btnChangePos);
            this.gbPosition.Location = new System.Drawing.Point(787, 132);
            this.gbPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPosition.Name = "gbPosition";
            this.gbPosition.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPosition.Size = new System.Drawing.Size(267, 131);
            this.gbPosition.TabIndex = 4;
            this.gbPosition.TabStop = false;
            this.gbPosition.Text = "Change Position";
            // 
            // gbWage
            // 
            this.gbWage.BackColor = System.Drawing.Color.Transparent;
            this.gbWage.Controls.Add(this.btnChangeWage);
            this.gbWage.Controls.Add(this.label4);
            this.gbWage.Controls.Add(this.tbWage);
            this.gbWage.Location = new System.Drawing.Point(787, 288);
            this.gbWage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbWage.Name = "gbWage";
            this.gbWage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbWage.Size = new System.Drawing.Size(267, 131);
            this.gbWage.TabIndex = 28;
            this.gbWage.TabStop = false;
            this.gbWage.Text = "Change Wages";
            // 
            // btnChangeWage
            // 
            this.btnChangeWage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChangeWage.BackgroundImage")));
            this.btnChangeWage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeWage.Location = new System.Drawing.Point(67, 74);
            this.btnChangeWage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangeWage.Name = "btnChangeWage";
            this.btnChangeWage.Size = new System.Drawing.Size(191, 36);
            this.btnChangeWage.TabIndex = 27;
            this.btnChangeWage.Text = "Change Wage";
            this.btnChangeWage.UseVisualStyleBackColor = true;
            this.btnChangeWage.Click += new System.EventHandler(this.BtnChangeWage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnFire);
            this.groupBox1.Location = new System.Drawing.Point(787, 426);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(267, 112);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fire Employee?";
            // 
            // ManageEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1088, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbWage);
            this.Controls.Add(this.gbPosition);
            this.Controls.Add(this.gbID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbEmployees);
            this.Font = new System.Drawing.Font("MV Boli", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManageEmployee";
            this.Text = "ManageEmployee";
            this.gbID.ResumeLayout(false);
            this.gbID.PerformLayout();
            this.gbPosition.ResumeLayout(false);
            this.gbPosition.PerformLayout();
            this.gbWage.ResumeLayout(false);
            this.gbWage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbEmployees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.TextBox tbWage;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Button btnChangePos;
        private System.Windows.Forms.GroupBox gbID;
        private System.Windows.Forms.GroupBox gbPosition;
        private System.Windows.Forms.GroupBox gbWage;
        private System.Windows.Forms.Button btnChangeWage;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}