using System.ComponentModel;
using System.Data;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Auther = cbAuther.Text,
                Maker = GetReadioButtonMaker(),

                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,

            };
            listCarReports.Add(carReport);
        }
        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetReadioButtonMaker() {
           if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
           }
           if(rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
           }
           if(rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
           }
           if(rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
           } 
           if(rbImport.Checked) {
                return CarReport.MakerGroup.輸入車;
           } else {
                return CarReport.MakerGroup.その他;
            }
            
        }
    }
}
