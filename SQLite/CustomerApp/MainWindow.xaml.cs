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

        // 顧客リスト
        List<Customer> _customers;

        public MainWindow() {
            InitializeComponent();
            ReadDatabase(); // 起動時にデータベースから情報を読み込み
        }

        // 画像選択ボタン
        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenFileDialog();
            dialog.Filter = "画像ファイル (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (dialog.ShowDialog() == true) {
                _selectedImagePath = dialog.FileName;

                // 選択した画像をImageコントロールに表示
                SelectedImage.Source = new BitmapImage(new Uri(_selectedImagePath));
            }
        }

        // 画像クリアボタン
        private void ClearImageButton_Click(object sender, RoutedEventArgs e) {
            // 画像をクリア、Imageをリセット
            _selectedImagePath = "";
            SelectedImage.Source = null; // 画像をクリア
        }

        // 保存ボタン
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImagePath = _selectedImagePath // 画像を保存
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブルが存在しかったら作成
                connection.Insert(customer); // データ挿入
            }

            ReadDatabase(); // ListViewを再読み込み
            // 入力欄を空にする
            ClearInputs();
        }

        // 情報をデータベースから読み込み
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブルを作成（存在しない時）
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

        // 更新ボタン
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

        // 顧客削除ボタン
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("消すもん選べ！");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブル作成（必要な場合）
                connection.Delete(item); // 顧客データを削除
            }

            ReadDatabase(); // ListViewを再読み込み

            // 入力欄を空にする
            ClearInputs();
        }

        // 検索テキスト変更時
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList; // 検索結果を表示
        }

        //入力欄を空にする
        private void ClearInputs() {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            _selectedImagePath = ""; // 画像リセット
            SelectedImage.Source = null; // 画像表示リセット
        }
    }
}
