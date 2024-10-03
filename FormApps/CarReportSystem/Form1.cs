using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //Settingsインスタンス生成
        Settings settings = Settings.getInstance();



        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        //追加ボタン
        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力...逃げちゃだめだ";
                return;
            }

            CarReport carReport = new CarReport {

                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };

            listCarReports.Add(carReport);

            setCbAuthor(cbAuthor.Text);

            dgvCarReport.ClearSelection();//セレクションを外す
            inputItemsAllClear();//入力項目をすべてクリア

        }
        //入力項目をすべてクリア
        private void inputItemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.なし);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }

        //登録者の履歴をコンボボックスへ登録(重複なし)
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //車名の履歴をコンボボックスへ登録(重複なし)
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.日産;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.スバル;
            if (rbImport.Checked)
                return CarReport.MakerGroup.輸入車;
            if (rbOther.Checked)
                return CarReport.MakerGroup.その他;

            return CarReport.MakerGroup.その他;
        }
        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.なし:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;

            }
        }

        private void rbAllClear() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbImport.Checked = false;
            rbOther.Checked = false;

        }


        //画像挿入
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        //画像削除
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false; //画像を表示しない 

            //交互に色を設定(データグリッドビュー)
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            if (File.Exists("settings.xml")) {

                //設定ファイルを逆シリアル化背景設定
                try {
                    using (XmlReader reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var settings = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormColor);
                        settings.MainFormColor = BackColor.ToArgb();

                    }
                }
                catch (Exception) {

                }
            } else {
                MessageBox.Show("馬鹿シンジ!色情報ファイル無いじゃない!");
            }

        }

        //一覧
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0)
               || (!dgvCarReport.CurrentRow.Selected)) return;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;

            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);

            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;

            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;

        }

        //削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection();//セレクションを外す
            //dgvCarReport.CurrentRow = null;

        }

        //修正ボタン
        private void btModifyReport_Click(object sender, EventArgs e) {
            //↓正しいコード
            if ((dgvCarReport.Rows.Count == null)
               || (!dgvCarReport.CurrentRow.Selected)) return;
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力...逃げちゃだめだ";
                return;
            }

            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;


            dgvCarReport.Refresh();//データグリッドビューの更新

        }

        //記録者テキスト編集
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        //車名テキスト編集
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
        //保存ボタン(イベントハンドラ?)
        private void btReportSave_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }


        //セーブファイル処理コード
        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "書込みエラー綾波～!";
                    throw;
                }
            }
        }


        //一覧のところの開くボタンイベントハイドラ
        private void btReportOpen_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }


        //オープンファイル処理コード
        private void ReportOpenFile() {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReport.DataSource = listCarReports;
                        foreach (var carReport in listCarReports) {
                            setCbAuthor(carReport.Author);
                            setCbCarName(carReport.CarName);
                        }
                    }
                }
                catch (Exception ex) {
                    tslbMessage.Text = "ファイル形式が違うにゃ～まぁいっか!";
                    throw;
                }
                dgvCarReport.ClearSelection();//セレクションを外す
            }
        }


        //クリアボタン
        private void btClear_Click(object sender, EventArgs e) {
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            inputItemsAllClear();//入力項目をすべてクリア
            dgvCarReport.ClearSelection();//セレクションを外す

        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile();   //ファイル開き処理         
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();  //ファイル保存処理
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            //終了するか確認して大丈夫ならアプリ終了
            if (MessageBox.Show("馬鹿なの?死ぬの?", "惣流アスカラングレー",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();

            // Environment.Exit(0);//アプリ終了

        }


        //色を設定
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            //ダイアログを表示する
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルシリアル化
            try {
                using (var writer = XmlWriter.Create("settings.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception) {
                MessageBox.Show("馬鹿シンジ...");
            }
        }

        //↓本当はちゃんとした名前つける
        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e) {
            var fmversion = new fmVersion();
            fmversion.ShowDialog();//ダイアログ出したい
            
        }

    }
}