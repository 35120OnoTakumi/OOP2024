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
        MyColor currentColor;//現在の色設定
        MyColor[] colorsTable;//色データ

        public MainWindow() {
            InitializeComponent();
            //αチャンネルの初期値設定(起動時直ちにストックボタンが押されたとき)
            currentColor.Color = Color.FromArgb(255, 0, 0, 0);
            colorSelectComboBox.DataContext = colorsTable = GetColorList();
        }
        //Sliderの値を入手色に変更
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            //currentColor.Name = colorsTable.Where(c => c.Color.Equals(currentColor.Color)).Select(x => x.Name).FirstOrDefault();
            
            int i;
            for(i = 0; i < colorsTable.Length; i++) {
                if (colorsTable[i].Color.Equals(currentColor.Color)) {
                    currentColor.Name = colorsTable[i].Name;
                    break;
                }
            }
            //if(i != colorsTable.Length) {
            //    colorSelectComboBox.SelectedIndex = i;
            //} else {

            //}
            colorSelectComboBox.SelectedIndex = i;
            colorArea.Background = new SolidColorBrush(currentColor.Color);
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
            bool exists = stockList.Items.Cast<MyColor>().Any(item => item.Color == currentColor.Color);

            //重複していなければstockListに追加
            if (!exists) {
                if (currentColor.Name != null && stockList.Items.Contains(currentColor.Name)) {
                    stockList.Items.Insert(0, currentColor.Name);
                }

            else {
                    stockList.Items.Insert(0, currentColor);
                }
                                                 
            } else {
                MessageBox.Show("既に登録済みやドアホ!");
            }
            

            /*参考コード
            if (stockList.Items.Contains((MyColor)currentColor)) {
                MessageBox.Show("既に登録済みです");

            } else {
                stockList.Items.Insert(0, currentColor);
            }
            Ctrl + K の次に Ctrl + / で指定範囲がコメント化される
            コメント化の解除も同じ
             */
        }
        //リストを選択したらLabelBackgroundのColor,Slider変更
        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            colorArea.Background = new SolidColorBrush(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
            setSliderValue(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);

        }



        //Comboboxで選択した色をLabelBackgroundのColorに反映,Sliderも値が動くようにしている
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
            var color = mycolor.Color;
            var name = mycolor.Name;
            colorArea.Background = new SolidColorBrush(mycolor.Color);
            setSliderValue(color);
            currentColor.Name =name;
            //下記のプログラムのほうが短くて綺麗
            //currentColor = (MyColor)((ComboBox)sender).SelectedItem;
            //setSliderValue(currentColor.Color);
            
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        //色を選択する
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e) {
            if (stockList.SelectedItem != null) {

                //stockList.Items.RemoveAt(stockList.SelectedItem[]);

            } else {
                MessageBox.Show("削除するんを選択せぇ！");
            }
        }

    }
}
