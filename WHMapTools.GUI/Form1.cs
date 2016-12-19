using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHMapTool.UC;

namespace WHMapTools.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CreateMenuButtons();
        }

        private void CreateMenuButtons()
        {
            IEnumerable<Type> types;
            types = GetTypesWithInterface(Assembly.Load("WHMapTool.UC"));
            foreach (Type myType in types)
            {
                ToolStripMenuItem myItem = new ToolStripMenuItem();
                myItem.Text = myType.Name;
                myItem.Name = myType.Name + "TSMI";
                myItem.Click += new EventHandler(delegate (Object o, EventArgs a)
                {
                    TabPage myTb = new TabPage();
                    String name = String.Empty;
                    String text = String.Empty;

                    IMapDesigner myMapDesigner = (IMapDesigner)myType.GetConstructor(Type.EmptyTypes).Invoke(new object[] { });
                    myTb.Controls.Add(myMapDesigner);
                    name = "tb" + (tbMaps.TabPages.Count + 1);
                    text = "New Map " + (tbMaps.TabPages.Count + 1);
                    myTb.Name = name;
                    myTb.Text = text;
                    tbMaps.TabPages.Add(myTb);
                });

                this.NewMapTSMenuItem.DropDownItems.Add(myItem);

                //(IMapDesigner x) => (IMapDesigner)mytype.GetConstructor(null).Invoke(null);
            }

            //foreach (Type mytype in WHMapTool.UC.GetTypes().Where(mytype => mytype.GetInterfaces().Contains(typeof(IMapDesigner))))
            //{
            //    TabPage myTb = new TabPage();
            //    String name = String.Empty;
            //    String text = String.Empty;
                
            //    IMapDesigner myMapDesigner = (IMapDesigner)mytype.GetConstructor(null).Invoke(null);
            //    myTb.Controls.Add(myMapDesigner);
            //    name = "tb" + (tbMaps.TabPages.Count + 1);
            //    text = "New Map " + (tbMaps.TabPages.Count + 1);
            //    myTb.Name = name;
            //    myTb.Text = text;
            //    tbMaps.TabPages.Add(myTb);
            //}
        }

        private IEnumerable<Type> GetTypesWithInterface(Assembly asm)
        {
            var it = typeof(IMapDesigner);
            return asm.GetTypes().Where(p => p.IsSubclassOf(it)).ToList();
        }

        private void sampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage myTb = new TabPage();
            String name = String.Empty;
            String text = String.Empty;
            IMapDesigner myMapDesigner = new CivilizationMapDesigner();
            myTb.Controls.Add(myMapDesigner);
            name = "tb" + (tbMaps.TabPages.Count + 1);
            text = "New Map " + (tbMaps.TabPages.Count + 1);
            myTb.Name = name;
            myTb.Text = text;
            tbMaps.TabPages.Add(myTb);
        }
    }
}
