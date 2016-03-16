using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHMapTools.Interfaces;

namespace WHMapTool.UC
{
    public class IMapDesigner : UserControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.gbDebugParams = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbMap = new System.Windows.Forms.GroupBox();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.gbParameters.SuspendLayout();
            this.gbMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // gbParameters
            // 
            this.gbParameters.Controls.Add(this.chkDebug);
            this.gbParameters.Controls.Add(this.gbDebugParams);
            this.gbParameters.Controls.Add(this.btnGenerate);
            this.gbParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbParameters.Location = new System.Drawing.Point(0, 0);
            this.gbParameters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbParameters.Size = new System.Drawing.Size(267, 580);
            this.gbParameters.TabIndex = 0;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parametros";
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(8, 346);
            this.chkDebug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(72, 21);
            this.chkDebug.TabIndex = 3;
            this.chkDebug.Text = "Debug";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkDebug_CheckedChanged);
            // 
            // gbDebugParams
            // 
            this.gbDebugParams.Enabled = false;
            this.gbDebugParams.Location = new System.Drawing.Point(8, 374);
            this.gbDebugParams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDebugParams.Name = "gbDebugParams";
            this.gbDebugParams.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDebugParams.Size = new System.Drawing.Size(251, 166);
            this.gbDebugParams.TabIndex = 1;
            this.gbDebugParams.TabStop = false;
            this.gbDebugParams.Text = "Parametros de Debug";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Location = new System.Drawing.Point(4, 548);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(259, 28);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // gbMap
            // 
            this.gbMap.Controls.Add(this.pbMap);
            this.gbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMap.Location = new System.Drawing.Point(267, 0);
            this.gbMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMap.Name = "gbMap";
            this.gbMap.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMap.Size = new System.Drawing.Size(873, 580);
            this.gbMap.TabIndex = 1;
            this.gbMap.TabStop = false;
            this.gbMap.Text = "Mapa";
            // 
            // pbMap
            // 
            this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMap.Location = new System.Drawing.Point(4, 19);
            this.pbMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(865, 557);
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            // 
            // IMapDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMap);
            this.Controls.Add(this.gbParameters);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IMapDesigner";
            this.Size = new System.Drawing.Size(1140, 580);
            this.gbParameters.ResumeLayout(false);
            this.gbParameters.PerformLayout();
            this.gbMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected GroupBox gbParameters;
        protected Button btnGenerate;
        protected GroupBox gbMap;
        protected PictureBox pbMap;
        protected CheckBox chkDebug;
        protected GroupBox gbDebugParams;
        protected IMap _map;

        public IMap Map
        {
            set
            {
                _map = value;
            }
            get
            {
                return _map;
            }
        }

        public IMapDesigner()
        {
            InitializeComponent();
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            switch(chkDebug.Checked)
            {
                case true:
                    gbDebugParams.Enabled = true;
                    break;
                case false:
                    gbDebugParams.Enabled = false;
                    break;
            }
        }
    }
}
