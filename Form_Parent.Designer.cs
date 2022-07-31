
namespace MinerGunBuilderCalculator
{
    partial class Form_Parent
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newShipToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importShipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newShipToolStripMenuItem,
            this.aToolStripMenuItem,
            this.windowwToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newShipToolStripMenuItem
            // 
            this.newShipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newShipToolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.importShipMenuItem});
            this.newShipToolStripMenuItem.Name = "newShipToolStripMenuItem";
            this.newShipToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.newShipToolStripMenuItem.Text = "Ship";
            // 
            // newShipToolStripMenuItem1
            // 
            this.newShipToolStripMenuItem1.Name = "newShipToolStripMenuItem1";
            this.newShipToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.newShipToolStripMenuItem1.Text = "New Ship";
            this.newShipToolStripMenuItem1.Click += new System.EventHandler(this.NewShipToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadShipToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveShipToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsShipToolStripMenuItem_Click);

            this.importShipMenuItem.Name = "importShipMenuItem";
            this.importShipMenuItem.Size = new System.Drawing.Size(124, 22);
            this.importShipMenuItem.Text = "Import Ship";
            this.importShipMenuItem.Click += new System.EventHandler(this.ImportShipMenuItem_Click);


            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemWindowToolStripMenuItem});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aToolStripMenuItem.Text = "View";
            // 
            // itemWindowToolStripMenuItem
            // 
            this.itemWindowToolStripMenuItem.Name = "itemWindowToolStripMenuItem";
            this.itemWindowToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.itemWindowToolStripMenuItem.Text = "Item window";
            this.itemWindowToolStripMenuItem.Click += new System.EventHandler(this.NewItemWindowToolStripMenuItem_Click);
            // 
            // windowwToolStripMenuItem
            // 
            this.windowwToolStripMenuItem.Name = "windowwToolStripMenuItem";
            this.windowwToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowwToolStripMenuItem.Text = "Window";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Form_Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Parent";
            this.Text = "Miner Gun Builder Calculator.";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Parent_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newShipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newShipToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importShipMenuItem;
    }
}
