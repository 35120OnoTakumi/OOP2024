using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor currentColror;//現在の色設定

        public MainWindow() {
            InitializeComponent();
            //αチャンネルの初期値設定(起動時直ちにストックボタンが押されたとき)
            currentColror.Color = Color.FromArgb(255, 0, 0, 0);
            colorSelectComboBox.DataContext = GetColorList();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColror.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(currentColror.Color);
        }
        //currentColror.Color = Color.FromRgb((byte)rSlider.Value,(byte)gSlider.Value,(byte)bSlider.Value);
        /* var rvalue = (int) rSlider.Value;
         var gvalue = (int) gSlider.Value;
         var bvalue = (int) bSlider.Value;

         //rValue.Text = rvalue.ToString();
        // gValue.Text = gvalue.ToString(); 
        // bValue.Text = bvalue.ToString();*/



        private void stockButton_Click(object sender, RoutedEventArgs e) {

            //重複しているか確認
            bool exists = stockList.Items.Cast<MyColor>().Any(item => item.Color == currentColror.Color);

            //重複していなければstockListに追加
            if (!exists) {
                stockList.Items.Insert(0, currentColror);
            }

        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            colorArea.Background = new SolidColorBrush(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
            rSlider.Value = ((MyColor)stockList.Items[stockList.SelectedIndex]).Color.R;
            gSlider.Value = ((MyColor)stockList.Items[stockList.SelectedIndex]).Color.G;
            bSlider.Value = ((MyColor)stockList.Items[stockList.SelectedIndex]).Color.B;
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { 
            
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
            var color = mycolor.Color;
            var name = mycolor.Name;
        }
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }
    }
}
