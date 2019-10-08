using System;
using System.Windows.Forms;

namespace KitkuAdminApp
{
    public partial class MainForm : Form
    {
        int menu;

        public MainForm()
        {
            InitializeComponent();
            //Console.WriteLine(userLogged);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Close();
            }
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DaftarTransaksi_Click(object sender, EventArgs e)
        {
            RemoveControl();
            menu = 1;
            UserControl1 = new DaftarTransaksi
            {
                Dock = DockStyle.Fill
            };
            //this.Controls.Add(userControl1);
            mainPanel.Controls.Add(UserControl1);
        }

        private void EditBarang_Click(object sender, EventArgs e)
        {
            RemoveControl();
            menu = 3;
            UserControl3 = new EditBarang
            {
                Dock = DockStyle.Fill
            };
            mainPanel.Controls.Add(UserControl3);
        }

        public string UserLogged
        {
            get; set;
        }
        public DaftarTransaksi UserControl1 { get; set; }
        public EditBarang UserControl3 { get; set; }

        public TambahBarang UserControl2 { get; set; }

        private void RemoveControl()
        {
            switch (menu)
            {
                case 1:                    
                    mainPanel.Controls.Remove(UserControl1); break;
                case 2:
                    mainPanel.Controls.Remove(UserControl2); break;
                case 3:
                    mainPanel.Controls.Remove(UserControl3); break;
                default:
                    break;
            };   
        }

        private void TambahBarang_Click(object sender, EventArgs e)
        {
            RemoveControl();
            menu = 2;
            UserControl2 = new TambahBarang
            {
                Dock = DockStyle.Fill
            };
            mainPanel.Controls.Add(UserControl2);
        }
    }
}
