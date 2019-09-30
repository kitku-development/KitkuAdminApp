using System.Windows.Forms;

namespace KitkuAdminApp
{
    public partial class LoadingDialog : Form
    {
        public LoadingDialog()
        {
            InitializeComponent();
        }

        public void dismiss()
        {
            this.Close();
        }
    }
}
