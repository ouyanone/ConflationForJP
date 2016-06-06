using System;
using System.Collections.Generic;
using System.Threading;

namespace ConflationForJP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        delegate void SetTextCallback(string text);

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorkerForC = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerForBAC = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDataFeeder = new System.ComponentModel.BackgroundWorker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CitiGroup C:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BankOfAmerica BAC:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(172, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stock Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Latest Price";
            // 
            // backgroundWorkerForC
            // 
            this.backgroundWorkerForC.WorkerReportsProgress = true;
            this.backgroundWorkerForC.WorkerSupportsCancellation = true;
            this.backgroundWorkerForC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerForC_DoWork);
            this.backgroundWorkerForC.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerForC_ProgressChanged);
            this.backgroundWorkerForC.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerForC_RunWorkerCompleted);
            // 
            // backgroundWorkerForBAC
            // 
            this.backgroundWorkerForBAC.WorkerReportsProgress = true;
            this.backgroundWorkerForBAC.WorkerSupportsCancellation = true;
            this.backgroundWorkerForBAC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerForBAC_DoWork);
            this.backgroundWorkerForBAC.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerForBAC_ProgressChanged);
            // 
            // backgroundWorkerDataFeeder
            // 
            this.backgroundWorkerDataFeeder.WorkerReportsProgress = true;
            this.backgroundWorkerDataFeeder.WorkerSupportsCancellation = true;
            this.backgroundWorkerDataFeeder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDataFeeder_DoWork);
            this.backgroundWorkerDataFeeder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDataFeeder_ProgressChanged);
            this.backgroundWorkerDataFeeder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDataFeeder_RunWorkerCompleted);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(50, 164);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(499, 329);
            this.listBox1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stock real time Updating Queue";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 524);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Stock Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForC;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForBAC;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDataFeeder;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
    }
}

