using System.Windows.Forms;

namespace TCC.View
{
    public partial class Notificacao : Form
    {
        private const int WM_NCLBUTTONDWN = 0xA1;

        public Notificacao(int dias)
        {
            InitializeComponent();

            this.MouseClick += new MouseEventHandler(fecharNotificacao);
            label1.MouseClick += new MouseEventHandler(fecharNotificacao);
            label2.MouseClick += new MouseEventHandler(fecharNotificacao);
            panel.MouseClick += new MouseEventHandler(fecharNotificacao);

            switch (dias)
            {
                case 0:
                    label2.Text += " hoje!";
                    break;
                case 1:
                    label2.Text += " daqui 1 dia!";
                    break;
                case 2:
                    label2.Text += " daqui 2 dias!";
                    break;
                case 3:
                    label2.Text += " daqui 3 dias!";
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Ao clicar na borda do form
            if (m.Msg == WM_NCLBUTTONDWN)
            {
                this.Close();
            }

            base.WndProc(ref m);
        }

        private void fecharNotificacao(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}