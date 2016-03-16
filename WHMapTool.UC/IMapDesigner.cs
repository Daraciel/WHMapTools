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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbMap = new System.Windows.Forms.GroupBox();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.gpDebugParams = new System.Windows.Forms.GroupBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.gbParameters.SuspendLayout();
            this.gbMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // gbParameters
            // 
            this.gbParameters.Controls.Add(this.chkDebug);
            this.gbParameters.Controls.Add(this.gpDebugParams);
            this.gbParameters.Controls.Add(this.btnGenerate);
            this.gbParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbParameters.Location = new System.Drawing.Point(0, 0);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(200, 471);
            this.gbParameters.TabIndex = 0;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parametros";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerate.Location = new System.Drawing.Point(3, 445);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(194, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generar";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // gbMap
            // 
            this.gbMap.Controls.Add(this.pbMap);
            this.gbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMap.Location = new System.Drawing.Point(200, 0);
            this.gbMap.Name = "gbMap";
            this.gbMap.Size = new System.Drawing.Size(655, 471);
            this.gbMap.TabIndex = 1;
            this.gbMap.TabStop = false;
            this.gbMap.Text = "Mapa";
            // 
            // pbMap
            // 
            this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMap.Location = new System.Drawing.Point(3, 16);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(649, 452);
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            // 
            // gpDebugParams
            // 
            this.gpDebugParams.Enabled = false;
            this.gpDebugParams.Location = new System.Drawing.Point(6, 304);
            this.gpDebugParams.Name = "gpDebugParams";
            this.gpDebugParams.Size = new System.Drawing.Size(188, 135);
            this.gpDebugParams.TabIndex = 1;
            this.gpDebugParams.TabStop = false;
            this.gpDebugParams.Text = "Parametros de Debug";
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(6, 281);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(58, 17);
            this.chkDebug.TabIndex = 3;
            this.chkDebug.Text = "Debug";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkDebug_CheckedChanged);
            // 
            // IMapDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMap);
            this.Controls.Add(this.gbParameters);
            this.Name = "IMapDesigner";
            this.Size = new System.Drawing.Size(855, 471);
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
        protected GroupBox gpDebugParams;
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
                    gbParameters.Enabled = true;
                    break;
                case false:
                    gbParameters.Enabled = false;
                    break;
            }
        }
    }
}
