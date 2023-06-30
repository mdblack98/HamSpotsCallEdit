namespace HamSpotsCallEdit
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openEdgeToolStripMenuItem = new ToolStripMenuItem();
            openChromeToolStripMenuItem = new ToolStripMenuItem();
            openBraveToolStripMenuItem = new ToolStripMenuItem();
            deleteAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            Call = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(165, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openEdgeToolStripMenuItem, openChromeToolStripMenuItem, openBraveToolStripMenuItem, deleteAllToolStripMenuItem, toolStripMenuItem1, toolStripMenuItem2 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openEdgeToolStripMenuItem
            // 
            openEdgeToolStripMenuItem.Name = "openEdgeToolStripMenuItem";
            openEdgeToolStripMenuItem.Size = new Size(180, 22);
            openEdgeToolStripMenuItem.Text = "Open Edge Data";
            openEdgeToolStripMenuItem.Click += openEdgeToolStripMenuItem_Click;
            // 
            // openChromeToolStripMenuItem
            // 
            openChromeToolStripMenuItem.Name = "openChromeToolStripMenuItem";
            openChromeToolStripMenuItem.Size = new Size(180, 22);
            openChromeToolStripMenuItem.Text = "Open Chrome Data";
            openChromeToolStripMenuItem.Click += openChromeToolStripMenuItem_Click;
            // 
            // openBraveToolStripMenuItem
            // 
            openBraveToolStripMenuItem.Name = "openBraveToolStripMenuItem";
            openBraveToolStripMenuItem.Size = new Size(180, 22);
            openBraveToolStripMenuItem.Text = "Open Brave Dat";
            openBraveToolStripMenuItem.Click += openBraveToolStripMenuItem_Click;
            // 
            // deleteAllToolStripMenuItem
            // 
            deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            deleteAllToolStripMenuItem.Size = new Size(180, 22);
            deleteAllToolStripMenuItem.Text = "Delete all listed";
            deleteAllToolStripMenuItem.Click += deleteAllToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "Quit";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(180, 22);
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Call });
            dataGridView1.Location = new Point(0, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(165, 197);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // Call
            // 
            Call.HeaderText = "Column1";
            Call.Name = "Call";
            Call.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(165, 224);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "HamSpotsCallEdit 20230629";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private ToolStripMenuItem deleteAllToolStripMenuItem;
        private DataGridViewTextBoxColumn Call;
        private ToolStripMenuItem toolStripMenuItem1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem openBraveToolStripMenuItem;
        private ToolStripMenuItem openChromeToolStripMenuItem;
        private ToolStripMenuItem openEdgeToolStripMenuItem;
    }
}