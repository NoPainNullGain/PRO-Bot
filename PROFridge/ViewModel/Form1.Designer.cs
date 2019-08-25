namespace PROFridge
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtbx_currentHealth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_pokemonID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbx_fightState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbx_xPos = new System.Windows.Forms.TextBox();
            this.txtbx_yPos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbx_pokeDollar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbx_enemyCurrentHealth = new System.Windows.Forms.TextBox();
            this.lbl_abilityPP = new System.Windows.Forms.Label();
            this.txtbx_abilityPP1 = new System.Windows.Forms.TextBox();
            this.txtbx_abilityPP2 = new System.Windows.Forms.TextBox();
            this.txtbx_abilityPP3 = new System.Windows.Forms.TextBox();
            this.txtbx_abilityPP4 = new System.Windows.Forms.TextBox();
            this.label111 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbx_status = new System.Windows.Forms.TextBox();
            this.chkbx_UseFishRod = new System.Windows.Forms.CheckBox();
            this.txtbx_currentPP1 = new System.Windows.Forms.TextBox();
            this.chkbx_farmSpecifPoke = new System.Windows.Forms.CheckBox();
            this.txtbx_farmSpcifPoke = new System.Windows.Forms.TextBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbx_currentHealth
            // 
            this.txtbx_currentHealth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "CurrentHealth", true));
            this.txtbx_currentHealth.Location = new System.Drawing.Point(92, 78);
            this.txtbx_currentHealth.Name = "txtbx_currentHealth";
            this.txtbx_currentHealth.ReadOnly = true;
            this.txtbx_currentHealth.Size = new System.Drawing.Size(23, 20);
            this.txtbx_currentHealth.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "My Health";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pokemon ID";
            // 
            // txtbx_pokemonID
            // 
            this.txtbx_pokemonID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "EncounterPokeIndex", true));
            this.txtbx_pokemonID.Location = new System.Drawing.Point(481, 94);
            this.txtbx_pokemonID.Name = "txtbx_pokemonID";
            this.txtbx_pokemonID.ReadOnly = true;
            this.txtbx_pokemonID.Size = new System.Drawing.Size(82, 20);
            this.txtbx_pokemonID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fight State";
            // 
            // txtbx_fightState
            // 
            this.txtbx_fightState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "IsFight", true));
            this.txtbx_fightState.Location = new System.Drawing.Point(481, 122);
            this.txtbx_fightState.Name = "txtbx_fightState";
            this.txtbx_fightState.ReadOnly = true;
            this.txtbx_fightState.Size = new System.Drawing.Size(82, 20);
            this.txtbx_fightState.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Coord Position";
            // 
            // txtbx_xPos
            // 
            this.txtbx_xPos.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "XPos", true));
            this.txtbx_xPos.Location = new System.Drawing.Point(243, 390);
            this.txtbx_xPos.Name = "txtbx_xPos";
            this.txtbx_xPos.ReadOnly = true;
            this.txtbx_xPos.Size = new System.Drawing.Size(42, 20);
            this.txtbx_xPos.TabIndex = 10;
            // 
            // txtbx_yPos
            // 
            this.txtbx_yPos.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "YPos", true));
            this.txtbx_yPos.Location = new System.Drawing.Point(305, 390);
            this.txtbx_yPos.Name = "txtbx_yPos";
            this.txtbx_yPos.ReadOnly = true;
            this.txtbx_yPos.Size = new System.Drawing.Size(41, 20);
            this.txtbx_yPos.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Poke $";
            // 
            // txtbx_pokeDollar
            // 
            this.txtbx_pokeDollar.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "PokeDollars", true));
            this.txtbx_pokeDollar.Location = new System.Drawing.Point(52, 392);
            this.txtbx_pokeDollar.Name = "txtbx_pokeDollar";
            this.txtbx_pokeDollar.ReadOnly = true;
            this.txtbx_pokeDollar.Size = new System.Drawing.Size(82, 20);
            this.txtbx_pokeDollar.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Enemy Health";
            // 
            // txtbx_enemyCurrentHealth
            // 
            this.txtbx_enemyCurrentHealth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "EnemyCurrentHealth", true));
            this.txtbx_enemyCurrentHealth.Location = new System.Drawing.Point(91, 108);
            this.txtbx_enemyCurrentHealth.Name = "txtbx_enemyCurrentHealth";
            this.txtbx_enemyCurrentHealth.ReadOnly = true;
            this.txtbx_enemyCurrentHealth.Size = new System.Drawing.Size(24, 20);
            this.txtbx_enemyCurrentHealth.TabIndex = 16;
            // 
            // lbl_abilityPP
            // 
            this.lbl_abilityPP.AutoSize = true;
            this.lbl_abilityPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_abilityPP.Location = new System.Drawing.Point(19, 165);
            this.lbl_abilityPP.Name = "lbl_abilityPP";
            this.lbl_abilityPP.Size = new System.Drawing.Size(61, 13);
            this.lbl_abilityPP.TabIndex = 18;
            this.lbl_abilityPP.Text = "Ability PP";
            // 
            // txtbx_abilityPP1
            // 
            this.txtbx_abilityPP1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "AbilityPP1", true));
            this.txtbx_abilityPP1.Location = new System.Drawing.Point(51, 183);
            this.txtbx_abilityPP1.Name = "txtbx_abilityPP1";
            this.txtbx_abilityPP1.Size = new System.Drawing.Size(24, 20);
            this.txtbx_abilityPP1.TabIndex = 19;
            // 
            // txtbx_abilityPP2
            // 
            this.txtbx_abilityPP2.Location = new System.Drawing.Point(51, 209);
            this.txtbx_abilityPP2.Name = "txtbx_abilityPP2";
            this.txtbx_abilityPP2.Size = new System.Drawing.Size(24, 20);
            this.txtbx_abilityPP2.TabIndex = 20;
            // 
            // txtbx_abilityPP3
            // 
            this.txtbx_abilityPP3.Location = new System.Drawing.Point(51, 235);
            this.txtbx_abilityPP3.Name = "txtbx_abilityPP3";
            this.txtbx_abilityPP3.Size = new System.Drawing.Size(24, 20);
            this.txtbx_abilityPP3.TabIndex = 21;
            // 
            // txtbx_abilityPP4
            // 
            this.txtbx_abilityPP4.Location = new System.Drawing.Point(50, 261);
            this.txtbx_abilityPP4.Name = "txtbx_abilityPP4";
            this.txtbx_abilityPP4.Size = new System.Drawing.Size(24, 20);
            this.txtbx_abilityPP4.TabIndex = 22;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(13, 186);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(34, 13);
            this.label111.TabIndex = 23;
            this.label111.Text = "PP#1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "PP#2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "PP#3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "PP#4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(181, 31);
            this.label12.TabIndex = 27;
            this.label12.Text = "FRIDGE BOT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(278, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Game Status";
            // 
            // txtbx_status
            // 
            this.txtbx_status.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "Status", true));
            this.txtbx_status.Location = new System.Drawing.Point(211, 25);
            this.txtbx_status.Name = "txtbx_status";
            this.txtbx_status.ReadOnly = true;
            this.txtbx_status.Size = new System.Drawing.Size(202, 20);
            this.txtbx_status.TabIndex = 28;
            // 
            // chkbx_UseFishRod
            // 
            this.chkbx_UseFishRod.AutoSize = true;
            this.chkbx_UseFishRod.Location = new System.Drawing.Point(447, 214);
            this.chkbx_UseFishRod.Name = "chkbx_UseFishRod";
            this.chkbx_UseFishRod.Size = new System.Drawing.Size(101, 17);
            this.chkbx_UseFishRod.TabIndex = 30;
            this.chkbx_UseFishRod.Text = "Use FishingRod";
            this.chkbx_UseFishRod.UseVisualStyleBackColor = true;
            // 
            // txtbx_currentPP1
            // 
            this.txtbx_currentPP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbx_currentPP1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "AbilityPP1", true));
            this.txtbx_currentPP1.Location = new System.Drawing.Point(93, 183);
            this.txtbx_currentPP1.Name = "txtbx_currentPP1";
            this.txtbx_currentPP1.ReadOnly = true;
            this.txtbx_currentPP1.Size = new System.Drawing.Size(24, 20);
            this.txtbx_currentPP1.TabIndex = 32;
            // 
            // chkbx_farmSpecifPoke
            // 
            this.chkbx_farmSpecifPoke.AutoSize = true;
            this.chkbx_farmSpecifPoke.Location = new System.Drawing.Point(447, 241);
            this.chkbx_farmSpecifPoke.Name = "chkbx_farmSpecifPoke";
            this.chkbx_farmSpecifPoke.Size = new System.Drawing.Size(118, 17);
            this.chkbx_farmSpecifPoke.TabIndex = 33;
            this.chkbx_farmSpecifPoke.Text = "Farm Specific Poke";
            this.chkbx_farmSpecifPoke.UseVisualStyleBackColor = true;
            // 
            // txtbx_farmSpcifPoke
            // 
            this.txtbx_farmSpcifPoke.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.form1BindingSource, "FarmSpecifPokeID", true));
            this.txtbx_farmSpcifPoke.Location = new System.Drawing.Point(447, 264);
            this.txtbx_farmSpcifPoke.Name = "txtbx_farmSpcifPoke";
            this.txtbx_farmSpcifPoke.Size = new System.Drawing.Size(118, 20);
            this.txtbx_farmSpcifPoke.TabIndex = 34;
            this.txtbx_farmSpcifPoke.TextChanged += new System.EventHandler(this.txtbx_farmSpcifPoke_TextChanged);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(PROFridge.Form1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(439, 374);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 17);
            this.label14.TabIndex = 35;
            this.label14.Text = "F6 TO STOP";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(439, 349);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 17);
            this.label15.TabIndex = 36;
            this.label15.Text = "F5 TO START";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 425);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtbx_farmSpcifPoke);
            this.Controls.Add(this.chkbx_farmSpecifPoke);
            this.Controls.Add(this.txtbx_currentPP1);
            this.Controls.Add(this.chkbx_UseFishRod);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtbx_status);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label111);
            this.Controls.Add(this.txtbx_abilityPP4);
            this.Controls.Add(this.txtbx_abilityPP3);
            this.Controls.Add(this.txtbx_abilityPP2);
            this.Controls.Add(this.txtbx_abilityPP1);
            this.Controls.Add(this.lbl_abilityPP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtbx_enemyCurrentHealth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtbx_pokeDollar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbx_yPos);
            this.Controls.Add(this.txtbx_xPos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbx_fightState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbx_pokemonID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_currentHealth);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_currentHealth;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_pokemonID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_fightState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbx_xPos;
        private System.Windows.Forms.TextBox txtbx_yPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbx_pokeDollar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbx_enemyCurrentHealth;
        private System.Windows.Forms.Label lbl_abilityPP;
        private System.Windows.Forms.TextBox txtbx_abilityPP1;
        private System.Windows.Forms.TextBox txtbx_abilityPP2;
        private System.Windows.Forms.TextBox txtbx_abilityPP3;
        private System.Windows.Forms.TextBox txtbx_abilityPP4;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtbx_status;
        private System.Windows.Forms.CheckBox chkbx_UseFishRod;
        private System.Windows.Forms.TextBox txtbx_currentPP1;
        private System.Windows.Forms.CheckBox chkbx_farmSpecifPoke;
        private System.Windows.Forms.TextBox txtbx_farmSpcifPoke;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

