using CustomerApp.Objects;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CustomerApp {
    public partial class MainWindow : Window {
        List<Customer> _customers;
        private byte[] _imageData;

        public MainWindow() {
            InitializeComponent();
        }

        // 保存
        private void ResistButton_Click(object sender, RoutedEventArgs e) {
            if (NameTextBox.Text == "") {
                MessageBox.Show("名前を入力");
                return;
            }

            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImageData = _imageData,
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }


            ReadDatabase();
            ClearText();
            _imageData = null;
            CustomerImage.Source = null;
        }

        // 更新
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = (Customer)CustomerListView.SelectedItem;
            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択");
                return;
            }

            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            if (_imageData != null) {
                selectedCustomer.ImageData = _imageData;
            } else {
                selectedCustomer.ImageData = null;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);
            }

            ReadDatabase();
            ClearText();
        }

        // クリア
        private void ClearText() {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            SearchTextBox.Clear();
        }

        // データベースの読み込み
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();
                CustomerListView.ItemsSource = _customers;
            }
        }

        // 検索
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        // 削除
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する顧客を選択");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);
                ReadDatabase();
            }

            ClearText();
        }

        // 画像選択
        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog {
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true) {
                _imageData = File.ReadAllBytes(openFileDialog.FileName);
                CustomerImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        // 画像クリア
        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            CustomerImage.Source = null;
            _imageData = null;
        }

        // リスト選択
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = (Customer)CustomerListView.SelectedItem;
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;
                CustomerImage.Source = selectedCustomer.Image;
            } else {
                CustomerImage.Source = null;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ReadDatabase();
        }
    }
}