namespace stade
{
    partial class ResaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ListeStade = new System.Windows.Forms.ComboBox();
            this.ListeZoneDuStade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AnnulerAction = new System.Windows.Forms.Button();
            this.ReserverAction = new System.Windows.Forms.Button();
            this.listeSiegeDelaZone1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listeSiegeDeLaZone2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Réservation Place";
            // 
            // ListeStade
            // 
            this.ListeStade.FormattingEnabled = true;
            this.ListeStade.Location = new System.Drawing.Point(337, 96);
            this.ListeStade.Name = "ListeStade";
            this.ListeStade.Size = new System.Drawing.Size(121, 21);
            this.ListeStade.TabIndex = 2;
            this.ListeStade.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ListeZoneDuStade
            // 
            this.ListeZoneDuStade.FormattingEnabled = true;
            this.ListeZoneDuStade.Location = new System.Drawing.Point(337, 133);
            this.ListeZoneDuStade.Name = "ListeZoneDuStade";
            this.ListeZoneDuStade.Size = new System.Drawing.Size(121, 21);
            this.ListeZoneDuStade.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "N° sièges";
            // 
            // AnnulerAction
            // 
            this.AnnulerAction.Location = new System.Drawing.Point(257, 301);
            this.AnnulerAction.Name = "AnnulerAction";
            this.AnnulerAction.Size = new System.Drawing.Size(75, 23);
            this.AnnulerAction.TabIndex = 7;
            this.AnnulerAction.Text = "Annuler";
            this.AnnulerAction.UseVisualStyleBackColor = true;
            // 
            // ReserverAction
            // 
            this.ReserverAction.Location = new System.Drawing.Point(407, 301);
            this.ReserverAction.Name = "ReserverAction";
            this.ReserverAction.Size = new System.Drawing.Size(75, 23);
            this.ReserverAction.TabIndex = 8;
            this.ReserverAction.Text = "Réserver";
            this.ReserverAction.UseVisualStyleBackColor = true;
            this.ReserverAction.Click += new System.EventHandler(this.ReserverAction_Click);
            // 
            // listeSiegeDelaZone1
            // 
            this.listeSiegeDelaZone1.FormattingEnabled = true;
            this.listeSiegeDelaZone1.Location = new System.Drawing.Point(356, 198);
            this.listeSiegeDelaZone1.Name = "listeSiegeDelaZone1";
            this.listeSiegeDelaZone1.Size = new System.Drawing.Size(49, 21);
            this.listeSiegeDelaZone1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "du";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "au";
            // 
            // listeSiegeDeLaZone2
            // 
            this.listeSiegeDeLaZone2.FormattingEnabled = true;
            this.listeSiegeDeLaZone2.Location = new System.Drawing.Point(436, 198);
            this.listeSiegeDeLaZone2.Name = "listeSiegeDeLaZone2";
            this.listeSiegeDeLaZone2.Size = new System.Drawing.Size(46, 21);
            this.listeSiegeDeLaZone2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Le";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(323, 240);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zone";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Evenement";
            // 
            // ResaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listeSiegeDeLaZone2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listeSiegeDelaZone1);
            this.Controls.Add(this.ReserverAction);
            this.Controls.Add(this.AnnulerAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ListeZoneDuStade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ListeStade);
            this.Controls.Add(this.label1);
            this.Name = "ResaForm";
            this.Text = "Réservation";
            this.Load += new System.EventHandler(this.ResaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ListeStade;
        private System.Windows.Forms.ComboBox ListeZoneDuStade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AnnulerAction;
        private System.Windows.Forms.Button ReserverAction;
        private System.Windows.Forms.ComboBox listeSiegeDelaZone1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox listeSiegeDeLaZone2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}