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
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonCloseTab = new System.Windows.Forms.Button();
            this.buttonAddTab = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDijkstra = new System.Windows.Forms.RadioButton();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.gPage = new System.Windows.Forms.TabPage();
            this.PictureBoxGraph = new DijkstraAlgorithm.App.Visualization.CPictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TapPageMatrix = new System.Windows.Forms.TabPage();
            this.pageNameTextbox = new System.Windows.Forms.TextBox();
            this.pageNamelabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.gPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGraph)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(337, 26);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(120, 40);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Next step";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
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
            this.buttonCloseTab.Click += new System.EventHandler(this.ButtonCloseTab_Click);
            // 
            // buttonAddTab
            // 
            this.buttonAddTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddTab.Location = new System.Drawing.Point(1272, 28);
            this.buttonAddTab.Name = "buttonAddTab";
            this.buttonAddTab.Size = new System.Drawing.Size(176, 40);
            this.buttonAddTab.TabIndex = 2;
            this.buttonAddTab.Text = "Add tab";
            this.buttonAddTab.UseVisualStyleBackColor = true;
            this.buttonAddTab.Click += new System.EventHandler(this.ButtonAddTab_Click);
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
            this.rbDijkstra.Location = new System.Drawing.Point(197, 80);
            this.rbDijkstra.Name = "rbDijkstra";
            this.rbDijkstra.Size = new System.Drawing.Size(101, 24);
            this.rbDijkstra.TabIndex = 4;
            this.rbDijkstra.TabStop = true;
            this.rbDijkstra.Text = "Dijkstra\'s";
            this.rbDijkstra.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.gPage);
            this.TabControl.Location = new System.Drawing.Point(35, 149);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1417, 658);
            this.TabControl.TabIndex = 1;
            // 
            // gPage
            // 
            this.gPage.Controls.Add(this.PictureBoxGraph);
            this.gPage.Controls.Add(this.tabControl1);
            this.gPage.Location = new System.Drawing.Point(4, 25);
            this.gPage.Name = "gPage";
            this.gPage.Padding = new System.Windows.Forms.Padding(3);
            this.gPage.Size = new System.Drawing.Size(1409, 629);
            this.gPage.TabIndex = 0;
            this.gPage.Text = "Примерен граф";
            this.gPage.UseVisualStyleBackColor = true;
            // 
            // PictureBoxGraph
            // 
            this.PictureBoxGraph.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxGraph.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxGraph.BackgroundImage")));
            this.PictureBoxGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxGraph.Location = new System.Drawing.Point(16, 24);
            this.PictureBoxGraph.Name = "PictureBoxGraph";
            this.PictureBoxGraph.Size = new System.Drawing.Size(685, 584);
            this.PictureBoxGraph.TabIndex = 1;
            this.PictureBoxGraph.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TapPageMatrix);
            this.tabControl1.Location = new System.Drawing.Point(735, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(651, 588);
            this.tabControl1.TabIndex = 0;
            // 
            // TapPageMatrix
            // 
            this.TapPageMatrix.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TapPageMatrix.BackgroundImage")));
            this.TapPageMatrix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TapPageMatrix.Location = new System.Drawing.Point(4, 25);
            this.TapPageMatrix.Name = "TapPageMatrix";
            this.TapPageMatrix.Padding = new System.Windows.Forms.Padding(3);
            this.TapPageMatrix.Size = new System.Drawing.Size(643, 559);
            this.TapPageMatrix.TabIndex = 0;
            this.TapPageMatrix.Text = "Образуваща се матрица";
            this.TapPageMatrix.UseVisualStyleBackColor = true;
            // 
            // pageNameTextbox
            // 
            this.pageNameTextbox.Location = new System.Drawing.Point(840, 35);
            this.pageNameTextbox.MaxLength = 15;
            this.pageNameTextbox.Name = "pageNameTextbox";
            this.pageNameTextbox.Size = new System.Drawing.Size(129, 22);
            this.pageNameTextbox.TabIndex = 1;
            // 
            // pageNamelabel
            // 
            this.pageNamelabel.AutoSize = true;
            this.pageNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageNamelabel.Location = new System.Drawing.Point(670, 38);
            this.pageNamelabel.Name = "pageNamelabel";
            this.pageNamelabel.Size = new System.Drawing.Size(156, 20);
            this.pageNamelabel.TabIndex = 6;
            this.pageNamelabel.Text = "Име на страница:";
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(1062, 82);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(176, 40);
            this.loadButton.TabIndex = 7;
            this.loadButton.Text = "Load graph";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1272, 82);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(176, 40);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save graph";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1491, 819);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.pageNamelabel);
            this.Controls.Add(this.pageNameTextbox);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.rbDijkstra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddTab);
            this.Controls.Add(this.buttonCloseTab);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxInitial);
            this.Controls.Add(this.initialVertexId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dijkstra Algorithm App";
            this.TabControl.ResumeLayout(false);
            this.gPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGraph)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label initialVertexId;
        private System.Windows.Forms.TextBox textBoxInitial;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonCloseTab;
        private System.Windows.Forms.Button buttonAddTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDijkstra;
        private TabPage gPage;
        private TabControl tabControl1;
        private TabPage TapPageMatrix;
        private Visualization.CPictureBox PictureBoxGraph;
        private TabControl TabControl;
        private TextBox pageNameTextbox;
        private Label pageNamelabel;
        private Button loadButton;
        private Button saveButton;
    }
}

