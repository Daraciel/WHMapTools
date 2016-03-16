using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHMapTools;
using WHMapTools.Factories;
using WHMapTools.Interfaces;

namespace WHMapTool.UC
{
    public partial class CivilizationMapDesigner : IMapDesigner
    {
        public CivilizationMapDesigner()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            InitializeParams inip = new InitializeParams();
            //inip.Parameters.Add(WHMapTools.Enums.AlgorithmParameters.DEBUG, true);
            inip.Parameters.Add(WHMapTools.Enums.AlgorithmParameters.LANDMASS, Int32.Parse(nudLandMass.Value.ToString()));
            inip.Parameters.Add(WHMapTools.Enums.AlgorithmParameters.TEMPERATURE, Int32.Parse(nudTemperature.Value.ToString()));
            inip.Parameters.Add(WHMapTools.Enums.AlgorithmParameters.CLIMATE, Int32.Parse(nudClimate.Value.ToString()));
            inip.Parameters.Add(WHMapTools.Enums.AlgorithmParameters.AGE, Int32.Parse(nudAge.Value.ToString()));
            Civilization1 factory = new Civilization1();
            factory.Initialize(inip);
            this.Map = factory.Create();
            this.pbMap.Image = this.Map.Show();
        }
    }
}
