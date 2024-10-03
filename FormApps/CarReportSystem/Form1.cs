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

        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //Settings�C���X�^���X����
        Settings settings = Settings.getInstance();



        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        //�ǉ��{�^��
        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ���������...�������Ⴞ�߂�";
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

            dgvCarReport.ClearSelection();//�Z���N�V�������O��
            inputItemsAllClear();//���͍��ڂ����ׂăN���A

        }
        //���͍��ڂ����ׂăN���A
        private void inputItemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.�Ȃ�);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }

        //�o�^�҂̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^(�d���Ȃ�)
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        //�I������Ă��郁�[�J�[����񋓌^�ŕԂ�
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.�g���^;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.���Y;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.�z���_;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.�X�o��;
            if (rbImport.Checked)
                return CarReport.MakerGroup.�A����;
            if (rbOther.Checked)
                return CarReport.MakerGroup.���̑�;

            return CarReport.MakerGroup.���̑�;
        }
        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.�Ȃ�:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
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


        //�摜�}��
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        //�摜�폜
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false; //�摜��\�����Ȃ� 

            //���݂ɐF��ݒ�(�f�[�^�O���b�h�r���[)
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            if (File.Exists("settings.xml")) {

                //�ݒ�t�@�C�����t�V���A�����w�i�ݒ�
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
                MessageBox.Show("�n���V���W!�F���t�@�C����������Ȃ�!");
            }

        }

        //�ꗗ
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

        //�폜�{�^��
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection();//�Z���N�V�������O��
            //dgvCarReport.CurrentRow = null;

        }

        //�C���{�^��
        private void btModifyReport_Click(object sender, EventArgs e) {
            //���������R�[�h
            if ((dgvCarReport.Rows.Count == null)
               || (!dgvCarReport.CurrentRow.Selected)) return;
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ���������...�������Ⴞ�߂�";
                return;
            }

            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;


            dgvCarReport.Refresh();//�f�[�^�O���b�h�r���[�̍X�V

        }

        //�L�^�҃e�L�X�g�ҏW
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        //�Ԗ��e�L�X�g�ҏW
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
        //�ۑ��{�^��(�C�x���g�n���h��?)
        private void btReportSave_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }


        //�Z�[�u�t�@�C�������R�[�h
        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "�����݃G���[���g�`!";
                    throw;
                }
            }
        }


        //�ꗗ�̂Ƃ���̊J���{�^���C�x���g�n�C�h��
        private void btReportOpen_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }


        //�I�[�v���t�@�C�������R�[�h
        private void ReportOpenFile() {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
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
                    tslbMessage.Text = "�t�@�C���`�����Ⴄ�ɂ�`�܂�������!";
                    throw;
                }
                dgvCarReport.ClearSelection();//�Z���N�V�������O��
            }
        }


        //�N���A�{�^��
        private void btClear_Click(object sender, EventArgs e) {
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            inputItemsAllClear();//���͍��ڂ����ׂăN���A
            dgvCarReport.ClearSelection();//�Z���N�V�������O��

        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile();   //�t�@�C���J������         
        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();  //�t�@�C���ۑ�����
        }

        private void �I��ToolStripMenuItem_Click(object sender, EventArgs e) {
            //�I�����邩�m�F���đ��v�Ȃ�A�v���I��
            if (MessageBox.Show("�n���Ȃ�?���ʂ�?", "�y���A�X�J�����O���[",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();

            // Environment.Exit(0);//�A�v���I��

        }


        //�F��ݒ�
        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            //�_�C�A���O��\������
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //�ݒ�t�@�C���V���A����
            try {
                using (var writer = XmlWriter.Create("settings.xml")) {
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception) {
                MessageBox.Show("�n���V���W...");
            }
        }

        //���{���͂����Ƃ������O����
        private void ���̃A�v���ɂ���ToolStripMenuItem_Click(object sender, EventArgs e) {
            var fmversion = new fmVersion();
            fmversion.ShowDialog();//�_�C�A���O�o������
            
        }

    }
}