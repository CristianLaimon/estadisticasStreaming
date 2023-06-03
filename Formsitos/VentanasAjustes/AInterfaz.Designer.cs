namespace estadisticasStreaming.Formsitos.VentanasAjustes
{
    partial class AInterfaz
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureOpcion2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxOpcion1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOpcion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpcion1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cambiar fondo:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::estadisticasStreaming.Properties.Resources.FolderIcono;
            this.pictureBox1.Location = new System.Drawing.Point(306, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(198, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Personalizado";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureOpcion2);
            this.groupBox1.Controls.Add(this.pictureBoxOpcion1);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 124);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Predeterminados";
            // 
            // pictureOpcion2
            // 
            this.pictureOpcion2.Image = global::estadisticasStreaming.Properties.Resources.BackGround;
            this.pictureOpcion2.Location = new System.Drawing.Point(186, 35);
            this.pictureOpcion2.Name = "pictureOpcion2";
            this.pictureOpcion2.Size = new System.Drawing.Size(116, 64);
            this.pictureOpcion2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureOpcion2.TabIndex = 1;
            this.pictureOpcion2.TabStop = false;
            this.pictureOpcion2.Click += new System.EventHandler(this.pictureOpcion2_Click);
            // 
            // pictureBoxOpcion1
            // 
            this.pictureBoxOpcion1.BackgroundImage = global::estadisticasStreaming.Properties.Resources.Fondo1;
            this.pictureBoxOpcion1.Image = global::estadisticasStreaming.Properties.Resources.Fondo1;
            this.pictureBoxOpcion1.Location = new System.Drawing.Point(31, 35);
            this.pictureBoxOpcion1.Name = "pictureBoxOpcion1";
            this.pictureBoxOpcion1.Size = new System.Drawing.Size(109, 64);
            this.pictureBoxOpcion1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOpcion1.TabIndex = 0;
            this.pictureBoxOpcion1.TabStop = false;
            this.pictureBoxOpcion1.Click += new System.EventHandler(this.pictureBoxOpcion1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AInterfaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 185);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "AInterfaz";
            this.Text = "AInterfaz";
            this.Load += new System.EventHandler(this.AInterfaz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureOpcion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpcion1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private GroupBox groupBox1;
        private PictureBox pictureOpcion2;
        private PictureBox pictureBoxOpcion1;
        private OpenFileDialog openFileDialog1;
    }
}