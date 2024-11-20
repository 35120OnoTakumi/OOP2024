using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using SQLite;
using System.Linq;
using System.Collections.Generic;
using CustomerApp.Objects;
using System.Windows.Controls;
using System;

namespace CustomerApp {
    public partial class MainWindow : Window {
        // 画像を保持
        string _selectedImagePath = "";

        // リスト
        List<Customer> _customers;

        public MainWindow() {
            InitializeComponent();
            ReadDatabase(); // 起動時にDBの情報を読み込み
        }

        // 画像選択
        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenFileDialog();
            dialog.Filter = "画像ファイル (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (dialog.ShowDialog() == true) {
                _selectedImagePath = dialog.FileName;

                // 選んだ画像をImageコントロールに表示
                SelectedImage.Source = new BitmapImage(new Uri(_selectedImagePath));
            }
        }

        // 画像クリア
        private void ClearImageButton_Click(object sender, RoutedEventArgs e) {
            // 画像クリア、Imageリセット
            _selectedImagePath = "";
            SelectedImage.Source = null; // 画像をクリア
        }

        // 保存
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImagePath = _selectedImagePath // 画像を保存
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブルが存在したら作成
                connection.Insert(customer); // データ挿入
            }

            ReadDatabase(); // ListViewを再読み込み
            // 入力欄を空にする
            ClearInputs();
        }

        // 情報をDBから読み込み
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // 存在しなかったらテーブル作成
                _customers = connection.Table<Customer>().ToList(); // 情報をリストに取得

                CustomerListView.ItemsSource = _customers; // ListViewにデータバインド
            }
        }

        // リストビュー選択変更
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item != null) {
                NameTextBox.Text = item.Name;
                PhoneTextBox.Text = item.Phone;
                AddressTextBox.Text = item.Address;

                // テーブルに関連付けた画像表示
                if (!string.IsNullOrEmpty(item.ImagePath)) {
                    SelectedImage.Source = new BitmapImage(new Uri(item.ImagePath));
                } else {
                    SelectedImage.Source = null; // 画像が無い場合表示せず
                }
            }
        }

        // 更新
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("更新するもん選らばんかい!");
                return;
            }

            // 情報を更新
            item.Name = NameTextBox.Text;
            item.Phone = PhoneTextBox.Text;
            item.Address = AddressTextBox.Text;
            item.ImagePath = _selectedImagePath; // 新しい画像を保存

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブル作成（必要な場合）
                connection.Update(item); // データを更新
            }

            ReadDatabase(); // ListViewを再読み込み

            // 入力欄を空にする
            ClearInputs();
        }

        // 削除
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("消すもん選べ！");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブル作成（必要な場合）
                connection.Delete(item); // データ削除
            }

            ReadDatabase(); // ListViewを再読み込み

            // 入力欄を空にする
            ClearInputs();
        }

        // 変更時の検索
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList; // 検索結果表示
        }

        // 入力欄を空にする
        private void ClearInputs() {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            _selectedImagePath = ""; // 画像リセット
            SelectedImage.Source = null; // 画像表示リセット
        }

        // ウィンドウ全体
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            // クリックされた場所が入力場所でなければクリア
            if (!(e.OriginalSource is TextBox || e.OriginalSource is Image)) {
                ClearInputs();
            }
        }
    }
}
