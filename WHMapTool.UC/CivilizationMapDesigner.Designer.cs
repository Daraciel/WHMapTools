namespace WHMapTool.UC
{
    partial class CivilizationMapDesigner
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
            this.lblLandMass = new System.Windows.Forms.Label();
            this.nudLandMass = new System.Windows.Forms.NumericUpDown();
            this.nudTemperature = new System.Windows.Forms.NumericUpDown();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.nudClimate = new System.Windows.Forms.NumericUpDown();
            this.lblClimate = new System.Windows.Forms.Label();
            this.nudAge = new System.Windows.Forms.NumericUpDown();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSeed = new System.Windows.Forms.Label();
            this.nudSeed = new System.Windows.Forms.NumericUpDown();
            this.nudChunkIterations = new System.Windows.Forms.NumericUpDown();
            this.lblChunkIterations = new System.Windows.Forms.Label();
            this.gbParameters.SuspendLayout();
            this.gbMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.gbDebugParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLandMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClimate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChunkIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // gbParameters
            // 
            this.gbParameters.Controls.Add(this.nudAge);
            this.gbParameters.Controls.Add(this.lblAge);
            this.gbParameters.Controls.Add(this.nudClimate);
            this.gbParameters.Controls.Add(this.lblClimate);
            this.gbParameters.Controls.Add(this.nudTemperature);
            this.gbParameters.Controls.Add(this.lblTemperature);
            this.gbParameters.Controls.Add(this.nudLandMass);
            this.gbParameters.Controls.Add(this.lblLandMass);
            this.gbParameters.Controls.SetChildIndex(this.gbDebugParams, 0);
            this.gbParameters.Controls.SetChildIndex(this.chkDebug, 0);
            this.gbParameters.Controls.SetChildIndex(this.btnGenerate, 0);
            this.gbParameters.Controls.SetChildIndex(this.lblLandMass, 0);
            this.gbParameters.Controls.SetChildIndex(this.nudLandMass, 0);
            this.gbParameters.Controls.SetChildIndex(this.lblTemperature, 0);
            this.gbParameters.Controls.SetChildIndex(this.nudTemperature, 0);
            this.gbParameters.Controls.SetChildIndex(this.lblClimate, 0);
            this.gbParameters.Controls.SetChildIndex(this.nudClimate, 0);
            this.gbParameters.Controls.SetChildIndex(this.lblAge, 0);
            this.gbParameters.Controls.SetChildIndex(this.nudAge, 0);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkDebug
            // 
            this.chkDebug.Location = new System.Drawing.Point(8, 318);
            this.chkDebug.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // gbDebugParams
            // 
            this.gbDebugParams.Controls.Add(this.nudChunkIterations);
            this.gbDebugParams.Controls.Add(this.lblChunkIterations);
            this.gbDebugParams.Controls.Add(this.nudSeed);
            this.gbDebugParams.Controls.Add(this.lblSeed);
            this.gbDebugParams.Location = new System.Drawing.Point(8, 346);
            this.gbDebugParams.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbDebugParams.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbDebugParams.Size = new System.Drawing.Size(251, 194);
            // 
            // lblLandMass
            // 
            this.lblLandMass.AutoSize = true;
            this.lblLandMass.Location = new System.Drawing.Point(8, 46);
            this.lblLandMass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLandMass.Name = "lblLandMass";
            this.lblLandMass.Size = new System.Drawing.Size(179, 17);
            this.lblLandMass.TabIndex = 1;
            this.lblLandMass.Text = "Cantidad de masa de tierra";
            // 
            // nudLandMass
            // 
            this.nudLandMass.Location = new System.Drawing.Point(4, 65);
            this.nudLandMass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudLandMass.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLandMass.Name = "nudLandMass";
            this.nudLandMass.Size = new System.Drawing.Size(251, 22);
            this.nudLandMass.TabIndex = 2;
            this.nudLandMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTemperature
            // 
            this.nudTemperature.Location = new System.Drawing.Point(4, 113);
            this.nudTemperature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudTemperature.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTemperature.Name = "nudTemperature";
            this.nudTemperature.Size = new System.Drawing.Size(251, 22);
            this.nudTemperature.TabIndex = 4;
            this.nudTemperature.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(8, 94);
            this.lblTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(90, 17);
            this.lblTemperature.TabIndex = 3;
            this.lblTemperature.Text = "Temperatura";
            // 
            // nudClimate
            // 
            this.nudClimate.Location = new System.Drawing.Point(4, 161);
            this.nudClimate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudClimate.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudClimate.Name = "nudClimate";
            this.nudClimate.Size = new System.Drawing.Size(251, 22);
            this.nudClimate.TabIndex = 6;
            this.nudClimate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblClimate
            // 
            this.lblClimate.AutoSize = true;
            this.lblClimate.Location = new System.Drawing.Point(8, 142);
            this.lblClimate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClimate.Name = "lblClimate";
            this.lblClimate.Size = new System.Drawing.Size(117, 17);
            this.lblClimate.TabIndex = 5;
            this.lblClimate.Text = "Clima (Humedad)";
            // 
            // nudAge
            // 
            this.nudAge.Location = new System.Drawing.Point(4, 209);
            this.nudAge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudAge.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(251, 22);
            this.nudAge.TabIndex = 8;
            this.nudAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(8, 190);
            this.lblAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(41, 17);
            this.lblAge.TabIndex = 7;
            this.lblAge.Text = "Edad";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(8, 32);
            this.lblSeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(53, 17);
            this.lblSeed.TabIndex = 0;
            this.lblSeed.Text = "Semilla";
            // 
            // nudSeed
            // 
            this.nudSeed.Location = new System.Drawing.Point(8, 52);
            this.nudSeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(235, 22);
            this.nudSeed.TabIndex = 7;
            this.nudSeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudChunkIterations
            // 
            this.nudChunkIterations.Location = new System.Drawing.Point(8, 100);
            this.nudChunkIterations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudChunkIterations.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudChunkIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudChunkIterations.Name = "nudChunkIterations";
            this.nudChunkIterations.Size = new System.Drawing.Size(235, 22);
            this.nudChunkIterations.TabIndex = 9;
            this.nudChunkIterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblChunkIterations
            // 
            this.lblChunkIterations.AutoSize = true;
            this.lblChunkIterations.Location = new System.Drawing.Point(8, 80);
            this.lblChunkIterations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChunkIterations.Name = "lblChunkIterations";
            this.lblChunkIterations.Size = new System.Drawing.Size(214, 17);
            this.lblChunkIterations.TabIndex = 8;
            this.lblChunkIterations.Text = "Número de iteraciones de trozos";
            // 
            // CivilizationMapDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "CivilizationMapDesigner";
            this.gbParameters.ResumeLayout(false);
            this.gbParameters.PerformLayout();
            this.gbMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.gbDebugParams.ResumeLayout(false);
            this.gbDebugParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLandMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClimate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChunkIterations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown nudClimate;
        private System.Windows.Forms.Label lblClimate;
        private System.Windows.Forms.NumericUpDown nudTemperature;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.NumericUpDown nudLandMass;
        private System.Windows.Forms.Label lblLandMass;
        private System.Windows.Forms.NumericUpDown nudSeed;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.NumericUpDown nudChunkIterations;
        private System.Windows.Forms.Label lblChunkIterations;
    }
}
