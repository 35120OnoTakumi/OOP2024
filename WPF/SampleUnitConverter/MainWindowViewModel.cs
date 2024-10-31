using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel{
        private double metricValue,imperialValue;

        //▲ボタンで呼ばれるコマンド
        public ICommand ImperialUnitToMetric {  get; private set; }
        //▼ボタンで呼ばれるコマンド
        public ICommand MetricToImerialUnit { get; private set; }

        //上のComboBoxで選択されている値
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のComboBoxで選択されている値
        public ImperialUnit CurrentimperialUnit { get; set; }

        public double MetricValue {
            get { return metricValue; }
            set {
                metricValue = value;
                OnPropertyChanged();    //値が変更されたら通知
            }
        }

        public double ImperialValue {
            get { return imperialValue; }
            set {
                imperialValue = value;
                OnPropertyChanged();    //値が変更されたら通知
            }
        }

        //コンストラクタ
        public MainWindowViewModel() {
            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();
        }
    }
}
