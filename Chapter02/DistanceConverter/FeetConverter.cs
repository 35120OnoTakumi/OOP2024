using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    internal class FeetConverter {
        //private const double ratio = 0.3048;//定数
        public static readonly double ratio = 0.3048;
        //フィートからメートルを求める
        public static double MeterFeet(double feet) {
            return feet * 0.3048;
        }

        public static double FeetMeter(double meter) {
            return meter / 0.3048;
        }
    }
}
