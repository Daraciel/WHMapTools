using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMapTools
{
    public class Civ1MapLayer
    {
        #region PROPERTIES

        public Byte[,] Values { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Civ1MapLayer(Tuple<int, int> s)
        {
            Values = new Byte[s.Item1, s.Item2];
            Initialize();
        }

        #endregion

        #region PUBLIC METHODS

        public void Initialize()
        {
            int dimH = Values.GetLength(0);
            int dimW = Values.GetLength(1);
            Parallel.For(0, dimH, y =>
            {
                Parallel.For(0, dimW, x =>
                {
                    Values[y, x] = 0;
                });
            });
        }

        #endregion
    }
}