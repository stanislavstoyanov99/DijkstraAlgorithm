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
            this.gPage1 = new System.Windows.Forms.TabPage();
            this.PictureBoxGraph = new DijkstraAlgorithm.App.Visualization.CPictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TapPageLogs = new System.Windows.Forms.TabPage();
            this.TabPageMatrix = new System.Windows.Forms.TabPage();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.gPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGraph)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.TabControl.SuspendLayout();
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
            this.buttonCloseTab.Location = new System.Drawing.Point(1062, 27);
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
            this.buttonAddTab.Location = new System.Drawing.Point(1276, 28);
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
            // gPage1
            // 
            this.gPage1.Controls.Add(this.tabControl1);
            this.gPage1.Controls.Add(this.PictureBoxGraph);
            this.gPage1.Location = new System.Drawing.Point(4, 25);
            this.gPage1.Name = "gPage1";
            this.gPage1.Padding = new System.Windows.Forms.Padding(3);
            this.gPage1.Size = new System.Drawing.Size(1413, 646);
            this.gPage1.TabIndex = 0;
            this.gPage1.Text = "New Tab";
            this.gPage1.UseVisualStyleBackColor = true;
            // 
            // PictureBoxGraph
            // 
            this.PictureBoxGraph.Location = new System.Drawing.Point(15, 15);
            this.PictureBoxGraph.Name = "PictureBoxGraph";
            this.PictureBoxGraph.Size = new System.Drawing.Size(645, 625);
            this.PictureBoxGraph.TabIndex = 0;
            this.PictureBoxGraph.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageMatrix);
            this.tabControl1.Controls.Add(this.TapPageLogs);
            this.tabControl1.Location = new System.Drawing.Point(703, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(645, 625);
            this.tabControl1.TabIndex = 1;
            // 
            // TapPageLogs
            // 
            this.TapPageLogs.Location = new System.Drawing.Point(4, 25);
            this.TapPageLogs.Name = "TapPageLogs";
            this.TapPageLogs.Padding = new System.Windows.Forms.Padding(3);
            this.TapPageLogs.Size = new System.Drawing.Size(637, 596);
            this.TapPageLogs.TabIndex = 1;
            this.TapPageLogs.Text = "Логове";
            this.TapPageLogs.UseVisualStyleBackColor = true;
            // 
            // TabPageMatrix
            // 
            this.TabPageMatrix.Location = new System.Drawing.Point(4, 25);
            this.TabPageMatrix.Name = "TabPageMatrix";
            this.TabPageMatrix.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMatrix.Size = new System.Drawing.Size(637, 596);
            this.TabPageMatrix.TabIndex = 0;
            this.TabPageMatrix.Text = "Образуваща се матрица";
            this.TabPageMatrix.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.gPage1);
            this.TabControl.Location = new System.Drawing.Point(35, 132);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1421, 675);
            this.TabControl.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 819);
            this.Controls.Add(this.TabControl);
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
            this.gPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGraph)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
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
        private TabPage gPage1;
        private TabControl tabControl1;
        private TabPage TabPageMatrix;
        private TabPage TapPageLogs;
        private Visualization.CPictureBox PictureBoxGraph;
        private TabControl TabControl;
    }
}

