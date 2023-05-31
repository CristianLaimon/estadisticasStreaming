namespace estadisticasStreaming
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStripPrincipal = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirNuevoArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirConsumotxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créditosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hechoPorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dianaYulissaSesmaSantiagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kristanRuízLimónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoVisto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioEstreno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.director = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minutosVistos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStripPrincipal.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::estadisticasStreaming.Properties.Resources.Background_dark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 71);
            this.panel1.TabIndex = 0;
            // 
            // statusStripPrincipal
            // 
            this.statusStripPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripPrincipal.Location = new System.Drawing.Point(0, 628);
            this.statusStripPrincipal.Name = "statusStripPrincipal";
            this.statusStripPrincipal.Size = new System.Drawing.Size(1107, 26);
            this.statusStripPrincipal.TabIndex = 2;
            this.statusStripPrincipal.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.créditosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 71);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1107, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirNuevoArchivoToolStripMenuItem,
            this.abrirConsumotxtToolStripMenuItem});
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // abrirNuevoArchivoToolStripMenuItem
            // 
            this.abrirNuevoArchivoToolStripMenuItem.Name = "abrirNuevoArchivoToolStripMenuItem";
            this.abrirNuevoArchivoToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.abrirNuevoArchivoToolStripMenuItem.Text = "Abrir archivo existente...";
            this.abrirNuevoArchivoToolStripMenuItem.Click += new System.EventHandler(this.abrirNuevoArchivoToolStripMenuItem_Click);
            // 
            // abrirConsumotxtToolStripMenuItem
            // 
            this.abrirConsumotxtToolStripMenuItem.Name = "abrirConsumotxtToolStripMenuItem";
            this.abrirConsumotxtToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.abrirConsumotxtToolStripMenuItem.Text = "Abrir consumo.txt";
            this.abrirConsumotxtToolStripMenuItem.Click += new System.EventHandler(this.abrirConsumotxtToolStripMenuItem_Click);
            // 
            // créditosToolStripMenuItem
            // 
            this.créditosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hechoPorToolStripMenuItem,
            this.dianaYulissaSesmaSantiagoToolStripMenuItem,
            this.kristanRuízLimónToolStripMenuItem});
            this.créditosToolStripMenuItem.Name = "créditosToolStripMenuItem";
            this.créditosToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.créditosToolStripMenuItem.Text = "Créditos";
            // 
            // hechoPorToolStripMenuItem
            // 
            this.hechoPorToolStripMenuItem.Name = "hechoPorToolStripMenuItem";
            this.hechoPorToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.hechoPorToolStripMenuItem.Text = "Hecho por:";
            // 
            // dianaYulissaSesmaSantiagoToolStripMenuItem
            // 
            this.dianaYulissaSesmaSantiagoToolStripMenuItem.Name = "dianaYulissaSesmaSantiagoToolStripMenuItem";
            this.dianaYulissaSesmaSantiagoToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.dianaYulissaSesmaSantiagoToolStripMenuItem.Text = "Diana Yulissa Sesma Santiago";
            // 
            // kristanRuízLimónToolStripMenuItem
            // 
            this.kristanRuízLimónToolStripMenuItem.Name = "kristanRuízLimónToolStripMenuItem";
            this.kristanRuízLimónToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.kristanRuízLimónToolStripMenuItem.Text = "Kristan Ruíz Limón";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuenta,
            this.edad,
            this.pais,
            this.productoVisto,
            this.tipo,
            this.anioEstreno,
            this.genero,
            this.director,
            this.clasificacion,
            this.duracion,
            this.minutosVistos});
            this.dataGridView1.Location = new System.Drawing.Point(31, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1039, 424);
            this.dataGridView1.TabIndex = 4;
            // 
            // cuenta
            // 
            this.cuenta.HeaderText = "Cuenta";
            this.cuenta.MinimumWidth = 6;
            this.cuenta.Name = "cuenta";
            this.cuenta.ReadOnly = true;
            this.cuenta.Width = 125;
            // 
            // edad
            // 
            this.edad.HeaderText = "Edad";
            this.edad.MinimumWidth = 6;
            this.edad.Name = "edad";
            this.edad.ReadOnly = true;
            this.edad.Width = 125;
            // 
            // pais
            // 
            this.pais.HeaderText = "País";
            this.pais.MinimumWidth = 6;
            this.pais.Name = "pais";
            this.pais.ReadOnly = true;
            this.pais.Width = 125;
            // 
            // productoVisto
            // 
            this.productoVisto.HeaderText = "ProductoVisto";
            this.productoVisto.MinimumWidth = 6;
            this.productoVisto.Name = "productoVisto";
            this.productoVisto.ReadOnly = true;
            this.productoVisto.Width = 125;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.MinimumWidth = 6;
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 125;
            // 
            // anioEstreno
            // 
            this.anioEstreno.HeaderText = "AñoEstreno";
            this.anioEstreno.MinimumWidth = 6;
            this.anioEstreno.Name = "anioEstreno";
            this.anioEstreno.ReadOnly = true;
            this.anioEstreno.Width = 125;
            // 
            // genero
            // 
            this.genero.HeaderText = "Género";
            this.genero.MinimumWidth = 6;
            this.genero.Name = "genero";
            this.genero.ReadOnly = true;
            this.genero.Width = 125;
            // 
            // director
            // 
            this.director.HeaderText = "Director";
            this.director.MinimumWidth = 6;
            this.director.Name = "director";
            this.director.ReadOnly = true;
            this.director.Width = 125;
            // 
            // clasificacion
            // 
            this.clasificacion.HeaderText = "Clasificación";
            this.clasificacion.MinimumWidth = 6;
            this.clasificacion.Name = "clasificacion";
            this.clasificacion.ReadOnly = true;
            this.clasificacion.Width = 125;
            // 
            // duracion
            // 
            this.duracion.HeaderText = "Duración";
            this.duracion.MinimumWidth = 6;
            this.duracion.Name = "duracion";
            this.duracion.ReadOnly = true;
            this.duracion.Width = 125;
            // 
            // minutosVistos
            // 
            this.minutosVistos.HeaderText = "Minutos Vistos";
            this.minutosVistos.MinimumWidth = 6;
            this.minutosVistos.Name = "minutosVistos";
            this.minutosVistos.ReadOnly = true;
            this.minutosVistos.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(882, 577);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Seleccionar archivo...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::estadisticasStreaming.Properties.Resources.BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1107, 654);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStripPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStripPrincipal.ResumeLayout(false);
            this.statusStripPrincipal.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private StatusStrip statusStripPrincipal;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem abrirNuevoArchivoToolStripMenuItem;
        private ToolStripMenuItem créditosToolStripMenuItem;
        private ToolStripMenuItem hechoPorToolStripMenuItem;
        private ToolStripMenuItem dianaYulissaSesmaSantiagoToolStripMenuItem;
        private ToolStripMenuItem kristanRuízLimónToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn cuenta;
        private DataGridViewTextBoxColumn edad;
        private DataGridViewTextBoxColumn pais;
        private DataGridViewTextBoxColumn productoVisto;
        private DataGridViewTextBoxColumn tipo;
        private DataGridViewTextBoxColumn anioEstreno;
        private DataGridViewTextBoxColumn genero;
        private DataGridViewTextBoxColumn director;
        private DataGridViewTextBoxColumn clasificacion;
        private DataGridViewTextBoxColumn duracion;
        private DataGridViewTextBoxColumn minutosVistos;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem abrirConsumotxtToolStripMenuItem;
    }
}