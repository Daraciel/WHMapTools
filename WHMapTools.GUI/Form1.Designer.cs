namespace WHMapTools.GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMaps = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.NewMapTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.civilizationMapDesigner1 = new WHMapTool.UC.CivilizationMapDesigner();
            this.mainMenu.SuspendLayout();
            this.tbMaps.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1371, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMapTSMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // tbMaps
            // 
            this.tbMaps.Controls.Add(this.tabPage1);
            this.tbMaps.Controls.Add(this.tabPage2);
            this.tbMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaps.Location = new System.Drawing.Point(0, 28);
            this.tbMaps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMaps.Name = "tbMaps";
            this.tbMaps.SelectedIndex = 0;
            this.tbMaps.Size = new System.Drawing.Size(1371, 674);
            this.tbMaps.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.civilizationMapDesigner1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1363, 645);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1363, 645);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // NewMapTSMenuItem
            // 
            this.NewMapTSMenuItem.Name = "NewMapTSMenuItem";
            this.NewMapTSMenuItem.Size = new System.Drawing.Size(181, 26);
            this.NewMapTSMenuItem.Text = "Nuevo Mapa";
            // 
            // civilizationMapDesigner1
            // 
            this.civilizationMapDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.civilizationMapDesigner1.Location = new System.Drawing.Point(4, 4);
            this.civilizationMapDesigner1.Map = null;
            this.civilizationMapDesigner1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.civilizationMapDesigner1.Name = "civilizationMapDesigner1";
            this.civilizationMapDesigner1.Size = new System.Drawing.Size(1355, 637);
            this.civilizationMapDesigner1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 702);
            this.Controls.Add(this.tbMaps);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tbMaps.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.TabControl tbMaps;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WHMapTool.UC.CivilizationMapDesigner civilizationMapDesigner1;
        private System.Windows.Forms.ToolStripMenuItem NewMapTSMenuItem;
    }
}

