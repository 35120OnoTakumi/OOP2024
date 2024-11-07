using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class PoundUnit :WeightUnit{
        private static List<PoundUnit> units = new List<PoundUnit>(){
            new PoundUnit{ Name = "oz",Coefficient = 1,},
            new PoundUnit{ Name = "lb",Coefficient = 16,},
            new PoundUnit{ Name = "gr",Coefficient = 70 * 3,},
        };
        public static ICollection<PoundUnit> Units { get { return units; } }

        /// <summary>
        /// メートル単位からヤード単位に変換
        /// </summary>
        /// <param name="unit">メートル単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>


        public double FromGuramUnit(GuramUnit unit, double value) {
            return (value * unit.Coefficient) / 25.4 / this.Coefficient;
        }
    }
}
