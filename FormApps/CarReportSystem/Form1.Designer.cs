namespace CarReportSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lbDay = new Label();
            ddp = new DateTimePicker();
            lbRecord = new Label();
            cbAuther = new ComboBox();
            lbMaker = new Label();
            lbCarname = new Label();
            lbOpen = new Label();
            cbCar = new ComboBox();
            tbReport = new TextBox();
            label6 = new Label();
            pbPicture = new PictureBox();
            btDeleteReport = new Button();
            btPicDelete = new Button();
            btAddReport = new Button();
            btReportSave = new Button();
            dataGridView1 = new DataGridView();
            btReportOpen = new Button();
            button6 = new Button();
            btPicOpen = new Button();
            btModifyReport = new Button();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            gpmaker = new GroupBox();
            rbAther = new RadioButton();
            rbInport = new RadioButton();
            rbSubaru = new RadioButton();
            rbNissan = new RadioButton();
            rbToyota = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            gpmaker.SuspendLayout();
            SuspendLayout();
            // 
            // lbDay
            // 
            lbDay.AutoSize = true;
            lbDay.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbDay.Location = new Point(26, 26);
            lbDay.Name = "lbDay";
            lbDay.Size = new Size(54, 25);
            lbDay.TabIndex = 0;
            lbDay.Text = "日付:";
            // 
            // ddp
            // 
            ddp.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            ddp.Location = new Point(95, 18);
            ddp.Name = "ddp";
            ddp.Size = new Size(200, 33);
            ddp.TabIndex = 1;
            // 
            // lbRecord
            // 
            lbRecord.AutoSize = true;
            lbRecord.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbRecord.Location = new Point(11, 70);
            lbRecord.Name = "lbRecord";
            lbRecord.Size = new Size(69, 25);
            lbRecord.TabIndex = 0;
            lbRecord.Text = "記録者";
            // 
            // cbAuther
            // 
            cbAuther.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuther.FormattingEnabled = true;
            cbAuther.Location = new Point(95, 72);
            cbAuther.Name = "cbAuther";
            cbAuther.Size = new Size(200, 33);
            cbAuther.TabIndex = 2;
            // 
            // lbMaker
            // 
            lbMaker.AutoSize = true;
            lbMaker.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbMaker.Location = new Point(11, 124);
            lbMaker.Name = "lbMaker";
            lbMaker.Size = new Size(63, 25);
            lbMaker.TabIndex = 0;
            lbMaker.Text = "メーカー";
            // 
            // lbCarname
            // 
            lbCarname.AutoSize = true;
            lbCarname.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbCarname.Location = new Point(11, 171);
            lbCarname.Name = "lbCarname";
            lbCarname.Size = new Size(50, 25);
            lbCarname.TabIndex = 0;
            lbCarname.Text = "車名";
            // 
            // lbOpen
            // 
            lbOpen.AutoSize = true;
            lbOpen.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbOpen.Location = new Point(24, 412);
            lbOpen.Name = "lbOpen";
            lbOpen.Size = new Size(50, 25);
            lbOpen.TabIndex = 0;
            lbOpen.Text = "一覧";
            // 
            // cbCar
            // 
            cbCar.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCar.FormattingEnabled = true;
            cbCar.Location = new Point(95, 163);
            cbCar.Name = "cbCar";
            cbCar.Size = new Size(200, 33);
            cbCar.TabIndex = 2;
            // 
            // tbReport
            // 
            tbReport.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbReport.Location = new Point(95, 213);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(342, 161);
            tbReport.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(522, 24);
            label6.Name = "label6";
            label6.Size = new Size(50, 25);
            label6.TabIndex = 5;
            label6.Text = "画像";
            // 
            // pbPicture
            // 
            pbPicture.BackColor = SystemColors.ActiveCaption;
            pbPicture.Location = new Point(522, 70);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(316, 196);
            pbPicture.TabIndex = 6;
            pbPicture.TabStop = false;
            // 
            // btDeleteReport
            // 
            btDeleteReport.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDeleteReport.Location = new Point(756, 294);
            btDeleteReport.Name = "btDeleteReport";
            btDeleteReport.Size = new Size(82, 46);
            btDeleteReport.TabIndex = 7;
            btDeleteReport.Text = "削除";
            btDeleteReport.UseVisualStyleBackColor = true;
            // 
            // btPicDelete
            // 
            btPicDelete.Location = new Point(763, 41);
            btPicDelete.Name = "btPicDelete";
            btPicDelete.Size = new Size(75, 23);
            btPicDelete.TabIndex = 7;
            btPicDelete.Text = "削除";
            btPicDelete.UseVisualStyleBackColor = true;
            // 
            // btAddReport
            // 
            btAddReport.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btAddReport.Location = new Point(522, 294);
            btAddReport.Name = "btAddReport";
            btAddReport.Size = new Size(91, 46);
            btAddReport.TabIndex = 7;
            btAddReport.Text = "追加";
            btAddReport.UseVisualStyleBackColor = true;
            // 
            // btReportSave
            // 
            btReportSave.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btReportSave.Location = new Point(5, 521);
            btReportSave.Name = "btReportSave";
            btReportSave.Size = new Size(75, 39);
            btReportSave.TabIndex = 7;
            btReportSave.Text = "保存";
            btReportSave.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(93, 389);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(739, 171);
            dataGridView1.TabIndex = 8;
            // 
            // btReportOpen
            // 
            btReportOpen.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btReportOpen.Location = new Point(5, 453);
            btReportOpen.Name = "btReportOpen";
            btReportOpen.Size = new Size(75, 42);
            btReportOpen.TabIndex = 7;
            btReportOpen.Text = "開く...";
            btReportOpen.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            button6.Location = new Point(-116, 484);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 7;
            button6.Text = "開く...";
            button6.UseVisualStyleBackColor = true;
            // 
            // btPicOpen
            // 
            btPicOpen.Location = new Point(645, 41);
            btPicOpen.Name = "btPicOpen";
            btPicOpen.Size = new Size(75, 23);
            btPicOpen.TabIndex = 7;
            btPicOpen.Text = "開く...";
            btPicOpen.UseVisualStyleBackColor = true;
            // 
            // btModifyReport
            // 
            btModifyReport.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btModifyReport.Location = new Point(640, 294);
            btModifyReport.Name = "btModifyReport";
            btModifyReport.Size = new Size(80, 46);
            btModifyReport.TabIndex = 7;
            btModifyReport.Text = "修正";
            btModifyReport.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(87, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(398, 31);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(215, 12);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(61, 19);
            radioButton4.TabIndex = 0;
            radioButton4.TabStop = true;
            radioButton4.Text = "輸入車";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(145, 12);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(54, 19);
            radioButton3.TabIndex = 0;
            radioButton3.TabStop = true;
            radioButton3.Text = "スバル";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(81, 12);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(49, 19);
            radioButton2.TabIndex = 0;
            radioButton2.TabStop = true;
            radioButton2.Text = "日産";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(14, 12);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(50, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "トヨタ";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // gpmaker
            // 
            gpmaker.Controls.Add(rbAther);
            gpmaker.Controls.Add(rbInport);
            gpmaker.Controls.Add(rbSubaru);
            gpmaker.Controls.Add(rbNissan);
            gpmaker.Controls.Add(rbToyota);
            gpmaker.Location = new Point(93, 125);
            gpmaker.Name = "gpmaker";
            gpmaker.Size = new Size(398, 31);
            gpmaker.TabIndex = 9;
            gpmaker.TabStop = false;
            // 
            // rbAther
            // 
            rbAther.AutoSize = true;
            rbAther.Location = new Point(299, 12);
            rbAther.Name = "rbAther";
            rbAther.Size = new Size(56, 19);
            rbAther.TabIndex = 0;
            rbAther.TabStop = true;
            rbAther.Text = "その他";
            rbAther.UseVisualStyleBackColor = true;
            // 
            // rbInport
            // 
            rbInport.AutoSize = true;
            rbInport.Location = new Point(215, 12);
            rbInport.Name = "rbInport";
            rbInport.Size = new Size(61, 19);
            rbInport.TabIndex = 0;
            rbInport.TabStop = true;
            rbInport.Text = "輸入車";
            rbInport.UseVisualStyleBackColor = true;
            // 
            // rbSubaru
            // 
            rbSubaru.AutoSize = true;
            rbSubaru.Location = new Point(145, 12);
            rbSubaru.Name = "rbSubaru";
            rbSubaru.Size = new Size(54, 19);
            rbSubaru.TabIndex = 0;
            rbSubaru.TabStop = true;
            rbSubaru.Text = "スバル";
            rbSubaru.UseVisualStyleBackColor = true;
            rbSubaru.CheckedChanged += radioButton6_CheckedChanged;
            // 
            // rbNissan
            // 
            rbNissan.AutoSize = true;
            rbNissan.Location = new Point(81, 12);
            rbNissan.Name = "rbNissan";
            rbNissan.Size = new Size(49, 19);
            rbNissan.TabIndex = 0;
            rbNissan.TabStop = true;
            rbNissan.Text = "日産";
            rbNissan.UseVisualStyleBackColor = true;
            // 
            // rbToyota
            // 
            rbToyota.AutoSize = true;
            rbToyota.Location = new Point(14, 12);
            rbToyota.Name = "rbToyota";
            rbToyota.Size = new Size(50, 19);
            rbToyota.TabIndex = 0;
            rbToyota.TabStop = true;
            rbToyota.Text = "トヨタ";
            rbToyota.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 602);
            Controls.Add(gpmaker);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(btPicOpen);
            Controls.Add(btPicDelete);
            Controls.Add(btReportOpen);
            Controls.Add(btModifyReport);
            Controls.Add(btAddReport);
            Controls.Add(button6);
            Controls.Add(btReportSave);
            Controls.Add(btDeleteReport);
            Controls.Add(pbPicture);
            Controls.Add(label6);
            Controls.Add(tbReport);
            Controls.Add(cbCar);
            Controls.Add(cbAuther);
            Controls.Add(ddp);
            Controls.Add(lbOpen);
            Controls.Add(lbCarname);
            Controls.Add(lbMaker);
            Controls.Add(lbRecord);
            Controls.Add(lbDay);
            Name = "Form1";
            Text = "試乗レポート管理システム";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gpmaker.ResumeLayout(false);
            gpmaker.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbDay;
        private DateTimePicker ddp;
        private Label lbRecord;
        private ComboBox cbAuther;
        private Label lbMaker;
        private Label lbCarname;
        private Label lbOpen;
        private ComboBox cbCar;
        private TextBox tbReport;
        private Label label6;
        private PictureBox pbPicture;
        private Button btDeleteReport;
        private Button btPicDelete;
        private Button btAddReport;
        private Button btReportSave;
        private DataGridView dataGridView1;
        private Button btReportOpen;
        private Button button6;
        private Button btPicOpen;
        private Button btModifyReport;
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox gpmaker;
        private RadioButton rbInport;
        private RadioButton rbSubaru;
        private RadioButton rbNissan;
        private RadioButton rbToyota;
        private RadioButton rbAther;
    }
}
