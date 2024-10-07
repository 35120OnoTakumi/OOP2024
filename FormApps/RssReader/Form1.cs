using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Web.WebView2.Core;
using Windows.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Wpf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;


namespace RssReader {

    public partial class Form1 : Form {
        List<TitleData> xtitles;
        List<ItemSet> favorites = new List<ItemSet>();

        public Form1() {
            InitializeComponent();
            cbLoad();
            cbRssUrl.SelectedIndexChanged += lbRssUrl_SelectedIndexChanged;
            this.Controls.Add(cbRssUrl);
            List<ItemSet> favorites = new List<ItemSet>();
            cbRssUrl.SelectedIndex = -1; // 初期選択をクリア
                         
        }

        private void btGet_Click(object sender, EventArgs e) {
            if (cbRssUrl.SelectedItem is ItemSet selectedItem) {
                using (var wc = new WebClient()) {
                    try {
                        var rssStream = wc.OpenRead(selectedItem.ItemName);

                        // XmlReaderSettingsを使って外部DTDを無効にする設定を行う
                        XmlReaderSettings settings = new XmlReaderSettings {
                            DtdProcessing = DtdProcessing.Ignore, // DTDを無視する
                            XmlResolver = null // 外部エンティティの解決を無効化
                        };

                        using (XmlReader reader = XmlReader.Create(rssStream, settings)) {
                            var xdoc = XDocument.Load(reader);

                            xtitles = xdoc.Root.Descendants("item")
                                .Select(title => new TitleData {
                                    Title = title.Element("title")?.Value,
                                    Link = title.Element("link")?.Value,
                                }).ToList();

                            lbRssTitle.Items.Clear(); // 以前のアイテムをクリア
                            foreach (var title in xtitles) {
                                lbRssTitle.Items.Add(title.Title);
                            }
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"RSSフィードの取得中にエラーが発生しました: {ex.Message}");
                    }
                }
            } else if(cbRssUrl.Text != ""){
                using (var wc = new WebClient()) {
                    try {
                        var rssStream = wc.OpenRead(cbRssUrl.Text);

                        // XmlReaderSettingsを使って外部DTDを無効にする設定を行う
                        XmlReaderSettings settings = new XmlReaderSettings {
                            DtdProcessing = DtdProcessing.Ignore, // DTDを無視する
                            XmlResolver = null // 外部エンティティの解決を無効化
                        };

                        using (XmlReader reader = XmlReader.Create(rssStream, settings)) {
                            var xdoc = XDocument.Load(reader);

                            xtitles = xdoc.Root.Descendants("item")
                                .Select(title => new TitleData {
                                    Title = title.Element("title")?.Value,
                                    Link = title.Element("link")?.Value,
                                }).ToList();

                            lbRssTitle.Items.Clear(); // 以前のアイテムをクリア
                            foreach (var title in xtitles) {
                                lbRssTitle.Items.Add(title.Title);
                            }
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"RSSフィードの取得中にエラーが発生しました: {ex.Message}");
                    }
                }
            }
        }

        private async void webView21_Click(object sender, EventArgs e) {

            if (lbRssTitle.SelectedIndex >= 0) {
                Uri uri = new Uri(xtitles[lbRssTitle.SelectedIndex].Link);
                webView21.Source = uri;
            }

        }

        private void cbLoad() {
            List<ItemSet> src = new List<ItemSet>();
            src.Add(new ItemSet("主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"));/// 1つでItem１つ分となる
            src.Add(new ItemSet("国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml"));
            src.Add(new ItemSet("国際", "https://news.yahoo.co.jp/rss/topics/world.xml"));
            src.Add(new ItemSet("経済", "https://news.yahoo.co.jp/rss/topics/business.xml"));
            src.Add(new ItemSet("エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml"));
            src.Add(new ItemSet("スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"));
            src.Add(new ItemSet("IT", "https://news.yahoo.co.jp/rss/topics/it.xml"));
            src.Add(new ItemSet("科学", "https://news.yahoo.co.jp/rss/topics/science.xml"));
            src.Add(new ItemSet("地域", "https://news.yahoo.co.jp/rss/topics/local.xml"));

            cbRssUrl.DataSource = src;
            cbRssUrl.DisplayMember = "ItemValue";
            cbRssUrl.ValueMember = "ItemName";

            //cbRssUrl.Text = null;

            lbRssUrl_SelectedIndexChanged(null, null);
            //初期値
            cbRssUrl.SelectedIndex = -1;
        }


        private void lbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {

            // ユーザーが選択した場合のみ
            if (cbRssUrl.SelectedIndex >= 0) {
                var selectedItem = (ItemSet)cbRssUrl.SelectedItem;

            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btFavorite_Click(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex >= 0) {
                var selectedTitle = xtitles[lbRssTitle.SelectedIndex];

                // 重複を確認
                if (!cbRssUrl.Items.Cast<ItemSet>().Any(item => item.ItemName == selectedTitle.Link)) {
                    // 新しいリストを作成,既存のアイテムと新しいアイテムを追加
                    var newItems = cbRssUrl.Items.Cast<ItemSet>().ToList();

                    // お気に入りに追加する際の表示名を設定
                    var displayName = $"{selectedTitle.Title} (お気に入り)"; // タイトルを表示名に設定
                    //newItems.Add(new ItemSet(selectedTitle.Link, displayName));
                    newItems.Add(new ItemSet( displayName, selectedTitle.Link));

                    // DataSourceを再設定
                    cbRssUrl.DataSource = null; // まずはデータソースをクリア
                    cbRssUrl.DataSource = newItems; // 新しいリストをデータソースに設定

                    // 表示名の設定
                    cbRssUrl.DisplayMember = "ItemValue"; // 表示名としてItemValueを設定
                    cbRssUrl.ValueMember = "ItemName"; // 値名としてItemNameを設定

                    
                } else {
                    MessageBox.Show("このリンクは既にお気に入りに追加されています。");
                }
            } else {
                MessageBox.Show("お気に入りに追加するタイトルを選択してください。");
            }

        }

        private void ShowFavorites() {
            if (favorites.Count > 0) {
                StringBuilder favoriteList = new StringBuilder("お気に入りリスト:\n");
                foreach (var item in favorites) {
                    favoriteList.AppendLine($"{item.ItemValue} - {item.ItemName}");
                }
                MessageBox.Show(favoriteList.ToString(), "お気に入り一覧");
            } else {
               
            }
        }


        private void Form1_Load_1(object sender, EventArgs e) {
            ShowFavorites();
        }
    }

    //データ格納用クラス
    public class TitleData {
        public string Title { get; set; }
        public string Link { get; set; }
    }
    public class ItemSet {
        public String ItemName { get; set; }
        public String ItemValue { get; set; }

        // プロパティをコンストラクタでセット
        public ItemSet(String urstr, String name) {
            ItemName = name;
            ItemValue = urstr;
        }
    }

}