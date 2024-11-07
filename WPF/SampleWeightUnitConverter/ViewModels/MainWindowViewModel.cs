using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWeightUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double guramValue, poundValue;

        //▲ボタンで呼ばれるコマンド
        public ICommand PoundUnitToGuram { get; private set; }
        //▼ボタンで呼ばれるコマンド
        public ICommand GuramToPoundUnit { get; private set; }

        //上のComboBoxで選択されている値
        public GuramUnit CurrentGuramUnit { get; set; }
        //下のComboBoxで選択されている値
        public PoundUnit CurrentPoundUnit { get; set; }

        public double GuramValue {
            get { return guramValue; }
            set {
                guramValue = value;
                OnPropertyChanged();    //値が変更されたら通知
            }
        }

        public double PoundValue {
            get { return poundValue; }
            set {
                poundValue = value;
                OnPropertyChanged();    //値が変更されたら通知
            }
        }

        //コンストラクタ
        public MainWindowViewModel() {
            CurrentGuramUnit = GuramUnit.Units.First();
            CurrentPoundUnit = PoundUnit.Units.First();

            GuramToPoundUnit = new DelegateCommand(() =>
            PoundValue = CurrentPoundUnit.FromGuramUnit(CurrentGuramUnit, GuramValue));

            PoundUnitToGuram = new DelegateCommand(() =>
            GuramValue = CurrentGuramUnit.FromPoundUnit(CurrentPoundUnit, PoundValue));
        }
    }
}
