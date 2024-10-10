using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public abstract class ConverterBase {

        public abstract bool IsMyUnit(string name);

        //メートルとの比率 (この比率を掛けてメートルに変換)
        protected abstract double Ratio { get; }

        //距離の単位名(例 "メートル","フィート"など
        public abstract string UnitName { get; }

        //メートルからの変換
        public double FromMeter(double meter) {
            return meter / Ratio;
        }

        //メートルへの変換
        public double ToMeter(double feet) {
            return feet * Ratio;
        }
    }
}
