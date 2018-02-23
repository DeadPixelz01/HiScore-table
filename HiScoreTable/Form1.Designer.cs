using System;
using System.IO;

namespace HiScoreTable
{
    partial class FrmHiScore
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupInput = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.vScrollScore = new System.Windows.Forms.VScrollBar();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            FrmHiScore.listHighScore = new System.Windows.Forms.ListBox();
            this.groupInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HI - SCORES!";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 195);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // groupInput
            // 
            this.groupInput.Controls.Add(this.btnAdd);
            this.groupInput.Controls.Add(this.vScrollScore);
            this.groupInput.Controls.Add(this.txtScore);
            this.groupInput.Controls.Add(this.label3);
            this.groupInput.Controls.Add(this.txtName);
            this.groupInput.Controls.Add(this.label2);
            this.groupInput.Location = new System.Drawing.Point(138, 29);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(200, 127);
            this.groupInput.TabIndex = 3;
            this.groupInput.TabStop = false;
            this.groupInput.Text = "Add a new high score";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(51, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // vScrollScore
            // 
            this.vScrollScore.Location = new System.Drawing.Point(139, 53);
            this.vScrollScore.Name = "vScrollScore";
            this.vScrollScore.Size = new System.Drawing.Size(14, 20);
            this.vScrollScore.TabIndex = 4;
            this.vScrollScore.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollScore_Scroll);
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(51, 53);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(74, 20);
            this.txtScore.TabIndex = 3;
            this.txtScore.TextChanged += new System.EventHandler(this.txtScore_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Score:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(51, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(102, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(263, 195);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // listBox1
            // 
            FrmHiScore.listHighScore.FormattingEnabled = true;
            FrmHiScore.listHighScore.Location = new System.Drawing.Point(12, 35);
            FrmHiScore.listHighScore.Name = "listHighScore";
            FrmHiScore.listHighScore.Size = new System.Drawing.Size(120, 121);
            FrmHiScore.listHighScore.TabIndex = 5;
            // 
            // FrmHiScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 228);
            this.Controls.Add(FrmHiScore.listHighScore);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupInput);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label1);
            this.Name = "FrmHiScore";
            this.Text = "Hi - Score Table";
            this.Load += new System.EventHandler(this.FrmHiScore_Load);
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public static System.Windows.Forms.ListBox listHighScore;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox groupInput;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.VScrollBar vScrollScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuit;
    }
}

