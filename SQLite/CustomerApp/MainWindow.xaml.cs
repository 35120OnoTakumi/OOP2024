using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using SQLite;
using CustomerApp.Objects;
using System.Windows.Media;

namespace CustomerApp {
    public partial class MainWindow : Window {
        // 画像データ保持
        private byte[] _selectedImageData = null;

        // リスト
        private List<Customer> _customers;

        public MainWindow() {
            InitializeComponent();
            ReadDatabase(); // 起動時にDB読込み
        }

        // 画像選択
        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenFileDialog();
            dialog.Filter = "画像ファイル (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (dialog.ShowDialog() == true) {
                string selectedImagePath = dialog.FileName;

                // 画像をバイト配列に変換
                _selectedImageData = File.ReadAllBytes(selectedImagePath);

                // 選んだ画像をImageコントロールに表示
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(selectedImagePath);
                bitmapImage.EndInit();
                SelectedImage.Source = bitmapImage;
            }
        }

        // 画像クリア
        private void ClearImageButton_Click(object sender, RoutedEventArgs e) {
            _selectedImageData = null; // 画像データリセット
            SelectedImage.Source = null; // 画像表示リセット
        }

        // 保存
        private void RegistButton_Click(object sender, RoutedEventArgs e) {
            // 入力チェック
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(PhoneTextBox.Text) || string.IsNullOrWhiteSpace(AddressTextBox.Text)) {
                MessageBox.Show("名前、電話番号、住所のどれかが未入力。全て入力せんかい。",
                    "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // 処理中止
            }

            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = _selectedImageData // byte配列保存
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブルが存在したら作成
                connection.Insert(customer); // DBに挿入
            }

            ReadDatabase(); // ListViewを再読み込み
            ClearInputs(); // 入力欄を空にする
        }

        // DBから読込み
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブル作成（必要な場合）
                _customers = connection.Table<Customer>().ToList(); // リストに取得

                CustomerListView.ItemsSource = _customers; // ListViewにデータバインド
            }
        }

        // 選択変更時
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item != null) {
                NameTextBox.Text = item.Name;
                PhoneTextBox.Text = item.Phone;
                AddressTextBox.Text = item.Address;

                // 画像データがあったら、画像として表示
                if (item.Picture != null && item.Picture.Length > 0) {
                    var imageStream = new MemoryStream(item.Picture);
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = imageStream;
                    bitmap.EndInit();
                    SelectedImage.Source = bitmap;
                } else {
                    SelectedImage.Source = null; // 画像が無い場合表示せず
                }
            }
        }

        // 更新
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(PhoneTextBox.Text) || string.IsNullOrWhiteSpace(AddressTextBox.Text)) {
                MessageBox.Show("名前、電話番号、住所のいずれかが未入力です。全て入力してください。",
                "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // 処理中止
            }

            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("更新するデータを選択してください。");
                return;
            }

            // 画像が未選択の場合、既存の画像を保持
            if (_selectedImageData == null) {
                _selectedImageData = item.Picture; // 画像が変更されない場合は元の画像データを保持
            }

            // 更新
            item.Name = NameTextBox.Text;
            item.Phone = PhoneTextBox.Text;
            item.Address = AddressTextBox.Text;
            item.Picture = _selectedImageData; // 新しい画像データを保存

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブル作成（必要な場合）
                connection.Update(item); // 更新
            }

            ReadDatabase(); // ListViewを再読み込み
            ClearInputs(); // 入力欄を空にする
        }

        // 削除
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除するデータを選択してください。");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>(); // テーブル作成（必要な場合）
                connection.Delete(item); // 削除
            }

            ReadDatabase(); // ListViewを再読み込み
            ClearInputs(); // 入力欄を空にする
        }

        // 検索
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList; // 検索結果表示
        }

        // 入力欄を空にする
        private void ClearInputs() {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            _selectedImageData = null; // 画像データをリセット
            SelectedImage.Source = null; // 画像表示リセット
            CustomerListView.SelectedItem = null; // 選択解除
        }

        // ウィンドウ全体でクリックした場合、入力欄をクリア
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (!(e.OriginalSource is TextBox || e.OriginalSource is System.Windows.Controls.Image)) {
                ClearInputs();
            }
        }
    }
}
