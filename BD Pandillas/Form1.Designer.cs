namespace BD_Pandillas
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbx_1 = new System.Windows.Forms.PictureBox();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asistenciaAEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asistenciaPorPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomarAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.capitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarSaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbx_1
            // 
            this.pbx_1.Location = new System.Drawing.Point(115, 101);
            this.pbx_1.Name = "pbx_1";
            this.pbx_1.Size = new System.Drawing.Size(317, 135);
            this.pbx_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_1.TabIndex = 0;
            this.pbx_1.TabStop = false;
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturarToolStripMenuItem,
            this.mostrarToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.asistenciaAEventosToolStripMenuItem});
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.personasToolStripMenuItem.Text = "Personas";
            // 
            // capturarToolStripMenuItem
            // 
            this.capturarToolStripMenuItem.Name = "capturarToolStripMenuItem";
            this.capturarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.capturarToolStripMenuItem.Text = "Capturar";
            this.capturarToolStripMenuItem.Click += new System.EventHandler(this.capturarToolStripMenuItem_Click);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buscarToolStripMenuItem.Text = "Buscar";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // asistenciaAEventosToolStripMenuItem
            // 
            this.asistenciaAEventosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asistenciaPorPersonaToolStripMenuItem});
            this.asistenciaAEventosToolStripMenuItem.Name = "asistenciaAEventosToolStripMenuItem";
            this.asistenciaAEventosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asistenciaAEventosToolStripMenuItem.Text = "Asistencia a Eventos";
            // 
            // asistenciaPorPersonaToolStripMenuItem
            // 
            this.asistenciaPorPersonaToolStripMenuItem.Name = "asistenciaPorPersonaToolStripMenuItem";
            this.asistenciaPorPersonaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.asistenciaPorPersonaToolStripMenuItem.Text = "Asistencia por persona";
            this.asistenciaPorPersonaToolStripMenuItem.Click += new System.EventHandler(this.asistenciaPorPersonaToolStripMenuItem_Click);
            // 
            // eventosToolStripMenuItem
            // 
            this.eventosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturarToolStripMenuItem1,
            this.mostrarToolStripMenuItem1,
            this.buscarToolStripMenuItem1,
            this.modificarToolStripMenuItem1,
            this.listaDeAsistenciaToolStripMenuItem});
            this.eventosToolStripMenuItem.Name = "eventosToolStripMenuItem";
            this.eventosToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.eventosToolStripMenuItem.Text = "Eventos";
            // 
            // capturarToolStripMenuItem1
            // 
            this.capturarToolStripMenuItem1.Name = "capturarToolStripMenuItem1";
            this.capturarToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.capturarToolStripMenuItem1.Text = "Capturar";
            this.capturarToolStripMenuItem1.Click += new System.EventHandler(this.capturarToolStripMenuItem1_Click);
            // 
            // mostrarToolStripMenuItem1
            // 
            this.mostrarToolStripMenuItem1.Name = "mostrarToolStripMenuItem1";
            this.mostrarToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.mostrarToolStripMenuItem1.Text = "Mostrar";
            this.mostrarToolStripMenuItem1.Click += new System.EventHandler(this.mostrarToolStripMenuItem1_Click);
            // 
            // buscarToolStripMenuItem1
            // 
            this.buscarToolStripMenuItem1.Name = "buscarToolStripMenuItem1";
            this.buscarToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.buscarToolStripMenuItem1.Text = "Buscar";
            this.buscarToolStripMenuItem1.Click += new System.EventHandler(this.buscarToolStripMenuItem1_Click);
            // 
            // modificarToolStripMenuItem1
            // 
            this.modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            this.modificarToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.modificarToolStripMenuItem1.Text = "Modificar";
            this.modificarToolStripMenuItem1.Click += new System.EventHandler(this.modificarToolStripMenuItem1_Click);
            // 
            // listaDeAsistenciaToolStripMenuItem
            // 
            this.listaDeAsistenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tomarAsistenciaToolStripMenuItem,
            this.consultarAsistenciaToolStripMenuItem});
            this.listaDeAsistenciaToolStripMenuItem.Name = "listaDeAsistenciaToolStripMenuItem";
            this.listaDeAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.listaDeAsistenciaToolStripMenuItem.Text = "Lista de Asistencia";
            // 
            // tomarAsistenciaToolStripMenuItem
            // 
            this.tomarAsistenciaToolStripMenuItem.Name = "tomarAsistenciaToolStripMenuItem";
            this.tomarAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.tomarAsistenciaToolStripMenuItem.Text = "Capturar Asistencia";
            this.tomarAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.tomarAsistenciaToolStripMenuItem_Click);
            // 
            // consultarAsistenciaToolStripMenuItem
            // 
            this.consultarAsistenciaToolStripMenuItem.Name = "consultarAsistenciaToolStripMenuItem";
            this.consultarAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.consultarAsistenciaToolStripMenuItem.Text = "Consultar Asistencia";
            this.consultarAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.consultarAsistenciaToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturarToolStripMenuItem2,
            this.mostrarToolStripMenuItem2,
            this.buscarToolStripMenuItem2,
            this.modificarToolStripMenuItem2});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // capturarToolStripMenuItem2
            // 
            this.capturarToolStripMenuItem2.Name = "capturarToolStripMenuItem2";
            this.capturarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.capturarToolStripMenuItem2.Text = "Capturar";
            this.capturarToolStripMenuItem2.Click += new System.EventHandler(this.capturarToolStripMenuItem2_Click);
            // 
            // mostrarToolStripMenuItem2
            // 
            this.mostrarToolStripMenuItem2.Name = "mostrarToolStripMenuItem2";
            this.mostrarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.mostrarToolStripMenuItem2.Text = "Mostrar";
            this.mostrarToolStripMenuItem2.Click += new System.EventHandler(this.mostrarToolStripMenuItem2_Click);
            // 
            // buscarToolStripMenuItem2
            // 
            this.buscarToolStripMenuItem2.Name = "buscarToolStripMenuItem2";
            this.buscarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.buscarToolStripMenuItem2.Text = "Buscar";
            this.buscarToolStripMenuItem2.Click += new System.EventHandler(this.buscarToolStripMenuItem2_Click);
            // 
            // modificarToolStripMenuItem2
            // 
            this.modificarToolStripMenuItem2.Name = "modificarToolStripMenuItem2";
            this.modificarToolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem2.Text = "Modificar";
            this.modificarToolStripMenuItem2.Click += new System.EventHandler(this.modificarToolStripMenuItem2_Click);
            // 
            // capitalToolStripMenuItem
            // 
            this.capitalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarSaldoToolStripMenuItem});
            this.capitalToolStripMenuItem.Name = "capitalToolStripMenuItem";
            this.capitalToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.capitalToolStripMenuItem.Text = "Capital";
            // 
            // consultarSaldoToolStripMenuItem
            // 
            this.consultarSaldoToolStripMenuItem.Name = "consultarSaldoToolStripMenuItem";
            this.consultarSaldoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.consultarSaldoToolStripMenuItem.Text = "Consultar Saldo";
            this.consultarSaldoToolStripMenuItem.Click += new System.EventHandler(this.consultarSaldoToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personasToolStripMenuItem,
            this.eventosToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.movimientosToolStripMenuItem,
            this.capitalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturarToolStripMenuItem3,
            this.mostrarToolStripMenuItem3,
            this.buscarToolStripMenuItem3});
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.movimientosToolStripMenuItem.Text = "Movimientos";
            // 
            // capturarToolStripMenuItem3
            // 
            this.capturarToolStripMenuItem3.Name = "capturarToolStripMenuItem3";
            this.capturarToolStripMenuItem3.Size = new System.Drawing.Size(120, 22);
            this.capturarToolStripMenuItem3.Text = "Capturar";
            this.capturarToolStripMenuItem3.Click += new System.EventHandler(this.capturarToolStripMenuItem3_Click);
            // 
            // mostrarToolStripMenuItem3
            // 
            this.mostrarToolStripMenuItem3.Name = "mostrarToolStripMenuItem3";
            this.mostrarToolStripMenuItem3.Size = new System.Drawing.Size(120, 22);
            this.mostrarToolStripMenuItem3.Text = "Mostrar";
            this.mostrarToolStripMenuItem3.Click += new System.EventHandler(this.mostrarToolStripMenuItem3_Click);
            // 
            // buscarToolStripMenuItem3
            // 
            this.buscarToolStripMenuItem3.Name = "buscarToolStripMenuItem3";
            this.buscarToolStripMenuItem3.Size = new System.Drawing.Size(120, 22);
            this.buscarToolStripMenuItem3.Text = "Buscar";
            this.buscarToolStripMenuItem3.Click += new System.EventHandler(this.buscarToolStripMenuItem3_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 357);
            this.Controls.Add(this.pbx_1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dioses del Nilo Salón de Eventos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_1;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem capitalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarSaldoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem listaDeAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tomarAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asistenciaAEventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asistenciaPorPersonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem3;
    }
}

