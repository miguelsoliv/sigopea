namespace TCC.View
{
    partial class EnvioDeEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvioDeEmail));
            this.textPara = new System.Windows.Forms.TextBox();
            this.textAssunto = new System.Windows.Forms.TextBox();
            this.textMensagem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btAnexar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBoxAnexos = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // textPara
            // 
            this.errorProvider.SetIconPadding(this.textPara, 5);
            this.textPara.Location = new System.Drawing.Point(47, 12);
            this.textPara.Name = "textPara";
            this.textPara.Size = new System.Drawing.Size(266, 20);
            this.textPara.TabIndex = 0;
            // 
            // textAssunto
            // 
            this.errorProvider.SetIconPadding(this.textAssunto, 5);
            this.textAssunto.Location = new System.Drawing.Point(63, 49);
            this.textAssunto.Name = "textAssunto";
            this.textAssunto.Size = new System.Drawing.Size(250, 20);
            this.textAssunto.TabIndex = 1;
            // 
            // textMensagem
            // 
            this.textMensagem.AcceptsReturn = true;
            this.textMensagem.AcceptsTab = true;
            this.errorProvider.SetIconPadding(this.textMensagem, 5);
            this.textMensagem.Location = new System.Drawing.Point(77, 89);
            this.textMensagem.Multiline = true;
            this.textMensagem.Name = "textMensagem";
            this.textMensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textMensagem.Size = new System.Drawing.Size(236, 45);
            this.textMensagem.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Para";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assunto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mensagem";
            // 
            // btEnviar
            // 
            this.btEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btEnviar.Image")));
            this.btEnviar.Location = new System.Drawing.Point(15, 200);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(75, 27);
            this.btEnviar.TabIndex = 3;
            this.btEnviar.Text = "&Enviar";
            this.btEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // btAnexar
            // 
            this.btAnexar.Image = ((System.Drawing.Image)(resources.GetObject("btAnexar.Image")));
            this.btAnexar.Location = new System.Drawing.Point(140, 200);
            this.btAnexar.Name = "btAnexar";
            this.btAnexar.Size = new System.Drawing.Size(75, 27);
            this.btAnexar.TabIndex = 4;
            this.btAnexar.Text = "&Anexar";
            this.btAnexar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAnexar.UseVisualStyleBackColor = true;
            this.btAnexar.Click += new System.EventHandler(this.btAnexar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.Location = new System.Drawing.Point(255, 200);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 27);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Arquivos JPG/PNG|*.jpg;*.png|Todos os arquivos|*.*";
            this.openFileDialog.Title = "Selecione a Imagem";
            // 
            // listBoxAnexos
            // 
            this.listBoxAnexos.FormattingEnabled = true;
            this.listBoxAnexos.Location = new System.Drawing.Point(63, 144);
            this.listBoxAnexos.Name = "listBoxAnexos";
            this.listBoxAnexos.Size = new System.Drawing.Size(250, 43);
            this.listBoxAnexos.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Anexos";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(319, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 124;
            this.label13.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(319, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(319, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 126;
            this.label6.Text = "*";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 200;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // EnvioDeEmail
            // 
            this.AcceptButton = this.btEnviar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(342, 239);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxAnexos);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAnexar);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textMensagem);
            this.Controls.Add(this.textAssunto);
            this.Controls.Add(this.textPara);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "EnvioDeEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio de Email";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnvioDeEmail_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPara;
        private System.Windows.Forms.TextBox textAssunto;
        private System.Windows.Forms.TextBox textMensagem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Button btAnexar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listBoxAnexos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}