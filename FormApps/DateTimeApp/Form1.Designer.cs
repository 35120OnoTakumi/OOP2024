namespace DateTimeApp {
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
            label1 = new Label();
            dtpDate = new DateTimePicker();
            btDateCount = new Button();
            tbDisp = new TextBox();
            nudDay = new NumericUpDown();
            btPrevious = new Button();
            btDayafter = new Button();
            dateTimePicker1 = new DateTimePicker();
            btAge = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(41, 45);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(169, 45);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 39);
            dtpDate.TabIndex = 1;
            // 
            // btDateCount
            // 
            btDateCount.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDateCount.Location = new Point(258, 154);
            btDateCount.Name = "btDateCount";
            btDateCount.Size = new Size(200, 52);
            btDateCount.TabIndex = 2;
            btDateCount.Text = "今日までの日数";
            btDateCount.UseVisualStyleBackColor = true;
            btDateCount.Click += btDateCount_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(41, 338);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(467, 39);
            tbDisp.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(41, 163);
            nudDay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 43);
            nudDay.TabIndex = 4;
            // 
            // btPrevious
            // 
            btPrevious.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btPrevious.Location = new Point(181, 233);
            btPrevious.Name = "btPrevious";
            btPrevious.Size = new Size(155, 49);
            btPrevious.TabIndex = 5;
            btPrevious.Text = "日前";
            btPrevious.UseVisualStyleBackColor = true;
            btPrevious.Click += btPrevious_Click;
            // 
            // btDayafter
            // 
            btDayafter.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayafter.Location = new Point(353, 233);
            btDayafter.Name = "btDayafter";
            btDayafter.Size = new Size(155, 49);
            btDayafter.TabIndex = 5;
            btDayafter.Text = "日後";
            btDayafter.UseVisualStyleBackColor = true;
            btDayafter.Click += btDayafter_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dateTimePicker1.Location = new Point(353, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 39);
            dateTimePicker1.TabIndex = 1;
            // 
            // btAge
            // 
            btAge.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btAge.Location = new Point(537, 233);
            btAge.Name = "btAge";
            btAge.Size = new Size(155, 49);
            btAge.TabIndex = 5;
            btAge.Text = "年齢";
            btAge.UseVisualStyleBackColor = true;
            btAge.Click += btAge_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btAge);
            Controls.Add(btDayafter);
            Controls.Add(btPrevious);
            Controls.Add(nudDay);
            Controls.Add(tbDisp);
            Controls.Add(dateTimePicker1);
            Controls.Add(btDateCount);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDate;
        private Button btDateCount;
        private TextBox tbDisp;
        private NumericUpDown nudDay;
        private Button btPrevious;
        private Button btDayafter;
        private DateTimePicker dateTimePicker1;
        private Button btAge;
    }
}
