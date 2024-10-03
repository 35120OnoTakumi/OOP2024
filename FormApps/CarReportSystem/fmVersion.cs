using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        private void btVersionOk_Click(object sender, EventArgs e) {
            this.Close();//このformアプリのみ終了
        }

        private void fmVersion_Load(object sender, EventArgs e) {
            var asm = Assembly.GetExecutingAssembly();
            var ver = asm.GetName().Version;
            
            /*lbVersion.Text = "Ver" + " " +
                         (ver.Major + "." + ver.Minor + "." + ver.Build + "." + ver.Revision).
                         ToString();
            label2.Text = "Ver" + " " + ver.Major.ToString()
                        + "." + ver.Minor.ToString()
                        + "." + ver.Build.ToString()
                        + "." + ver.Revision.ToString();*/
        }

    }
}
