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
            this.gpDebugParams.SuspendLayout();
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
            this.gbParameters.Controls.SetChildIndex(this.gpDebugParams, 0);
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
            this.chkDebug.Location = new System.Drawing.Point(6, 258);
            // 
            // gpDebugParams
            // 
            this.gpDebugParams.Controls.Add(this.nudChunkIterations);
            this.gpDebugParams.Controls.Add(this.lblChunkIterations);
            this.gpDebugParams.Controls.Add(this.nudSeed);
            this.gpDebugParams.Controls.Add(this.lblSeed);
            this.gpDebugParams.Location = new System.Drawing.Point(6, 281);
            this.gpDebugParams.Size = new System.Drawing.Size(188, 158);
            // 
            // lblLandMass
            // 
            this.lblLandMass.AutoSize = true;
            this.lblLandMass.Location = new System.Drawing.Point(6, 37);
            this.lblLandMass.Name = "lblLandMass";
            this.lblLandMass.Size = new System.Drawing.Size(133, 13);
            this.lblLandMass.TabIndex = 1;
            this.lblLandMass.Text = "Cantidad de masa de tierra";
            // 
            // nudLandMass
            // 
            this.nudLandMass.Location = new System.Drawing.Point(3, 53);
            this.nudLandMass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLandMass.Name = "nudLandMass";
            this.nudLandMass.Size = new System.Drawing.Size(188, 20);
            this.nudLandMass.TabIndex = 2;
            this.nudLandMass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTemperature
            // 
            this.nudTemperature.Location = new System.Drawing.Point(3, 92);
            this.nudTemperature.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTemperature.Name = "nudTemperature";
            this.nudTemperature.Size = new System.Drawing.Size(188, 20);
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
            this.lblTemperature.Location = new System.Drawing.Point(6, 76);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(67, 13);
            this.lblTemperature.TabIndex = 3;
            this.lblTemperature.Text = "Temperatura";
            // 
            // nudClimate
            // 
            this.nudClimate.Location = new System.Drawing.Point(3, 131);
            this.nudClimate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudClimate.Name = "nudClimate";
            this.nudClimate.Size = new System.Drawing.Size(188, 20);
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
            this.lblClimate.Location = new System.Drawing.Point(6, 115);
            this.lblClimate.Name = "lblClimate";
            this.lblClimate.Size = new System.Drawing.Size(87, 13);
            this.lblClimate.TabIndex = 5;
            this.lblClimate.Text = "Clima (Humedad)";
            // 
            // nudAge
            // 
            this.nudAge.Location = new System.Drawing.Point(3, 170);
            this.nudAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(188, 20);
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
            this.lblAge.Location = new System.Drawing.Point(6, 154);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 13);
            this.lblAge.TabIndex = 7;
            this.lblAge.Text = "Edad";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(6, 26);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(40, 13);
            this.lblSeed.TabIndex = 0;
            this.lblSeed.Text = "Semilla";
            // 
            // nudSeed
            // 
            this.nudSeed.Location = new System.Drawing.Point(6, 42);
            this.nudSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSeed.Name = "nudSeed";
            this.nudSeed.Size = new System.Drawing.Size(176, 20);
            this.nudSeed.TabIndex = 7;
            this.nudSeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudChunkIterations
            // 
            this.nudChunkIterations.Location = new System.Drawing.Point(6, 81);
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
            this.nudChunkIterations.Size = new System.Drawing.Size(176, 20);
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
            this.lblChunkIterations.Location = new System.Drawing.Point(6, 65);
            this.lblChunkIterations.Name = "lblChunkIterations";
            this.lblChunkIterations.Size = new System.Drawing.Size(159, 13);
            this.lblChunkIterations.TabIndex = 8;
            this.lblChunkIterations.Text = "Número de iteraciones de trozos";
            // 
            // CivilizationMapDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CivilizationMapDesigner";
            this.gbParameters.ResumeLayout(false);
            this.gbParameters.PerformLayout();
            this.gbMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.gpDebugParams.ResumeLayout(false);
            this.gpDebugParams.PerformLayout();
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
