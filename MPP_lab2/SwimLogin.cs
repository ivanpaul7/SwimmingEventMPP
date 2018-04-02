using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client {
    public partial class SwimLogin : Form {
        SwimClientController ctrl;
        private SwimMainForm mainSwimForm;

        public SwimLogin(SwimClientController ctrl) {
            InitializeComponent();
            this.ctrl = ctrl;
            password.Text = "";
            password.PasswordChar = '*';
            //this.mainSwimForm = mainSwimForm;
        }

        private void Login_Click(object sender, EventArgs e) {
            String user = username.Text;
            String pass = password.Text;
            try {
                ctrl.login(user, pass);
                //MessageBox.Show("Login succeded");
                SwimMainForm swimWin = new SwimMainForm(ctrl);
                swimWin.Text = "Chat window for " + user;
                swimWin.Show();
                this.Hide();
            } catch (Exception ex) {
                MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
