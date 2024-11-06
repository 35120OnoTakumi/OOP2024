using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //ヤード単位を表現するクラス
    public class ImperialUnit : DistanceUnit {
        private static List<ImperialUnit> units = new List<ImperialUnit>(){
            new ImperialUnit{ Name = "in",Coefficient = 1,},
            new ImperialUnit{ Name = "ft",Coefficient = 12,},
            new ImperialUnit{ Name = "yd",Coefficient = 12 * 3,},
            new ImperialUnit{ Name = "ml",Coefficient = 12 * 3 * 1760,},
        };
        public static ICollection<ImperialUnit> Units { get { return units; } }

        /// <summary>
        /// メートル単位からヤード単位に変換
        /// </summary>
        /// <param name="unit">メートル単位</param>
        /// <param name="value">値</param>
        /// <returns></returns>


        public double FromMetricUnit(MetricUnit unit,double value) {
            return (value * unit.Coefficient) / 25.4/ this.Coefficient;
        }
    }
}
