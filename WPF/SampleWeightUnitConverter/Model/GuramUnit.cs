using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class GuramUnit : WeightUnit{
        private static List<GuramUnit> units = new List<GuramUnit>(){
            new GuramUnit{ Name = "mg",Coefficient = 1,},
            new GuramUnit{ Name = "g",Coefficient = 12,},
            new GuramUnit{ Name = "kg",Coefficient = 12,},
        };
        public static ICollection<GuramUnit> Units { get { return units; } }

        /// <summary>
        /// ポンド単位からグラム単位に変換
        /// </summary>
        /// <param name="unit">グラム単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>


        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) / 25.4 / this.Coefficient;
        }
    }
}
