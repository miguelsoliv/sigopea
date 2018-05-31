using System.Windows.Forms;

namespace TCC.View
{
    public partial class Notificacao : Form
    {
        public Notificacao(int dias)
        {
            InitializeComponent();

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

        const int WM_NCLBUTTONDWN = 0xA1;

        protected override void WndProc(ref Message m)
        {
            // Ao clicar na borda do form
            if (m.Msg == WM_NCLBUTTONDWN)
            {
                this.Close();
            }

            base.WndProc(ref m);
        }

        private void Notificacao_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}