using System.Windows.Forms;

namespace DijkstraAlgorithm.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.initialVertexId = new System.Windows.Forms.Label();
            this.textBoxInitial = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonCloseTab = new System.Windows.Forms.Button();
            this.buttonAddTab = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDijkstra = new System.Windows.Forms.RadioButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.gPage1 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialVertexId
            // 
            this.initialVertexId.AutoSize = true;
            this.initialVertexId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialVertexId.Location = new System.Drawing.Point(31, 38);
            this.initialVertexId.Name = "initialVertexId";
            this.initialVertexId.Size = new System.Drawing.Size(124, 20);
            this.initialVertexId.TabIndex = 0;
            this.initialVertexId.Text = "Initial Vertex Id:";
            // 
            // textBoxInitial
            // 
            this.textBoxInitial.Location = new System.Drawing.Point(165, 35);
            this.textBoxInitial.Name = "textBoxInitial";
            this.textBoxInitial.Size = new System.Drawing.Size(120, 22);
            this.textBoxInitial.TabIndex = 1;
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.Location = new System.Drawing.Point(337, 26);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(120, 40);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonCloseTab
            // 
            this.buttonCloseTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseTab.Location = new System.Drawing.Point(838, 25);
            this.buttonCloseTab.Name = "buttonCloseTab";
            this.buttonCloseTab.Size = new System.Drawing.Size(176, 41);
            this.buttonCloseTab.TabIndex = 2;
            this.buttonCloseTab.Text = "Close current tab";
            this.buttonCloseTab.UseVisualStyleBackColor = true;
            this.buttonCloseTab.Click += new System.EventHandler(this.buttonCloseTab_Click);
            // 
            // buttonAddTab
            // 
            this.buttonAddTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddTab.Location = new System.Drawing.Point(1029, 25);
            this.buttonAddTab.Name = "buttonAddTab";
            this.buttonAddTab.Size = new System.Drawing.Size(176, 40);
            this.buttonAddTab.TabIndex = 2;
            this.buttonAddTab.Text = "Add tab";
            this.buttonAddTab.UseVisualStyleBackColor = true;
            this.buttonAddTab.Click += new System.EventHandler(this.buttonAddTab_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose algorithm:";
            // 
            // rbDijkstra
            // 
            this.rbDijkstra.AutoSize = true;
            this.rbDijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDijkstra.Location = new System.Drawing.Point(198, 82);
            this.rbDijkstra.Name = "rbDijkstra";
            this.rbDijkstra.Size = new System.Drawing.Size(101, 24);
            this.rbDijkstra.TabIndex = 4;
            this.rbDijkstra.TabStop = true;
            this.rbDijkstra.Text = "Dijkstra\'s";
            this.rbDijkstra.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.gPage1);
            this.tabControl.Location = new System.Drawing.Point(35, 132);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1170, 618);
            this.tabControl.TabIndex = 3;
            // 
            // gPage1
            // 
            this.gPage1.Location = new System.Drawing.Point(4, 25);
            this.gPage1.Name = "gPage1";
            this.gPage1.Padding = new System.Windows.Forms.Padding(3);
            this.gPage1.Size = new System.Drawing.Size(1162, 589);
            this.gPage1.TabIndex = 0;
            this.gPage1.Text = "New Tab";
            this.gPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 762);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.rbDijkstra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddTab);
            this.Controls.Add(this.buttonCloseTab);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxInitial);
            this.Controls.Add(this.initialVertexId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dijkstra Algorithm App";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label initialVertexId;
        private System.Windows.Forms.TextBox textBoxInitial;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonCloseTab;
        private System.Windows.Forms.Button buttonAddTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDijkstra;
        private TabControl tabControl;
        private TabPage gPage1;
    }
}

