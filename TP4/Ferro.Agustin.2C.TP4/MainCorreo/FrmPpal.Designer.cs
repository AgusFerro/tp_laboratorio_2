namespace MainCorreo
{
    partial class FrmPpal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbEstadoPaquetes = new System.Windows.Forms.GroupBox();
            this.lstEstadoEntregado = new System.Windows.Forms.ListBox();
            this.lstEstadoEnViaje = new System.Windows.Forms.ListBox();
            this.lstEstadoIngresado = new System.Windows.Forms.ListBox();
            this.lblEstadoEntregado = new System.Windows.Forms.Label();
            this.lblEstadoEnViaje = new System.Windows.Forms.Label();
            this.lblEstadoIngresado = new System.Windows.Forms.Label();
            this.gbPaquetes = new System.Windows.Forms.GroupBox();
            this.mtxtTrackingID = new System.Windows.Forms.MaskedTextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.rtbMostrar = new System.Windows.Forms.RichTextBox();
            this.cmsListas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbEstadoPaquetes.SuspendLayout();
            this.gbPaquetes.SuspendLayout();
            this.cmsListas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEstadoPaquetes
            // 
            this.gbEstadoPaquetes.Controls.Add(this.lstEstadoEntregado);
            this.gbEstadoPaquetes.Controls.Add(this.lstEstadoEnViaje);
            this.gbEstadoPaquetes.Controls.Add(this.lstEstadoIngresado);
            this.gbEstadoPaquetes.Controls.Add(this.lblEstadoEntregado);
            this.gbEstadoPaquetes.Controls.Add(this.lblEstadoEnViaje);
            this.gbEstadoPaquetes.Controls.Add(this.lblEstadoIngresado);
            this.gbEstadoPaquetes.Location = new System.Drawing.Point(13, 13);
            this.gbEstadoPaquetes.Name = "gbEstadoPaquetes";
            this.gbEstadoPaquetes.Size = new System.Drawing.Size(773, 293);
            this.gbEstadoPaquetes.TabIndex = 0;
            this.gbEstadoPaquetes.TabStop = false;
            this.gbEstadoPaquetes.Text = "Estado Paquetes";
            // 
            // lstEstadoEntregado
            // 
            this.lstEstadoEntregado.ContextMenuStrip = this.cmsListas;
            this.lstEstadoEntregado.FormattingEnabled = true;
            this.lstEstadoEntregado.Location = new System.Drawing.Point(533, 52);
            this.lstEstadoEntregado.Name = "lstEstadoEntregado";
            this.lstEstadoEntregado.Size = new System.Drawing.Size(209, 212);
            this.lstEstadoEntregado.TabIndex = 5;
            // 
            // lstEstadoEnViaje
            // 
            this.lstEstadoEnViaje.FormattingEnabled = true;
            this.lstEstadoEnViaje.Location = new System.Drawing.Point(278, 52);
            this.lstEstadoEnViaje.Name = "lstEstadoEnViaje";
            this.lstEstadoEnViaje.Size = new System.Drawing.Size(209, 212);
            this.lstEstadoEnViaje.TabIndex = 4;
            // 
            // lstEstadoIngresado
            // 
            this.lstEstadoIngresado.FormattingEnabled = true;
            this.lstEstadoIngresado.Location = new System.Drawing.Point(18, 52);
            this.lstEstadoIngresado.Name = "lstEstadoIngresado";
            this.lstEstadoIngresado.Size = new System.Drawing.Size(209, 212);
            this.lstEstadoIngresado.TabIndex = 3;
            // 
            // lblEstadoEntregado
            // 
            this.lblEstadoEntregado.AutoSize = true;
            this.lblEstadoEntregado.Location = new System.Drawing.Point(530, 16);
            this.lblEstadoEntregado.Name = "lblEstadoEntregado";
            this.lblEstadoEntregado.Size = new System.Drawing.Size(56, 13);
            this.lblEstadoEntregado.TabIndex = 2;
            this.lblEstadoEntregado.Text = "Entregado";
            // 
            // lblEstadoEnViaje
            // 
            this.lblEstadoEnViaje.AutoSize = true;
            this.lblEstadoEnViaje.Location = new System.Drawing.Point(275, 20);
            this.lblEstadoEnViaje.Name = "lblEstadoEnViaje";
            this.lblEstadoEnViaje.Size = new System.Drawing.Size(46, 13);
            this.lblEstadoEnViaje.TabIndex = 1;
            this.lblEstadoEnViaje.Text = "En Viaje";
            // 
            // lblEstadoIngresado
            // 
            this.lblEstadoIngresado.AutoSize = true;
            this.lblEstadoIngresado.Location = new System.Drawing.Point(15, 20);
            this.lblEstadoIngresado.Name = "lblEstadoIngresado";
            this.lblEstadoIngresado.Size = new System.Drawing.Size(54, 13);
            this.lblEstadoIngresado.TabIndex = 0;
            this.lblEstadoIngresado.Text = "Ingresado";
            // 
            // gbPaquetes
            // 
            this.gbPaquetes.Controls.Add(this.mtxtTrackingID);
            this.gbPaquetes.Controls.Add(this.txtDireccion);
            this.gbPaquetes.Controls.Add(this.btnMostrarTodos);
            this.gbPaquetes.Controls.Add(this.btnAgregar);
            this.gbPaquetes.Controls.Add(this.lblDireccion);
            this.gbPaquetes.Controls.Add(this.lblTrackingID);
            this.gbPaquetes.Location = new System.Drawing.Point(505, 322);
            this.gbPaquetes.Name = "gbPaquetes";
            this.gbPaquetes.Size = new System.Drawing.Size(281, 137);
            this.gbPaquetes.TabIndex = 1;
            this.gbPaquetes.TabStop = false;
            this.gbPaquetes.Text = "Paquetes";
            // 
            // mtxtTrackingID
            // 
            this.mtxtTrackingID.Location = new System.Drawing.Point(10, 33);
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.mtxtTrackingID.Name = "mtxtTrackingID";
            this.mtxtTrackingID.Size = new System.Drawing.Size(167, 20);
            this.mtxtTrackingID.TabIndex = 5;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(7, 93);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(170, 20);
            this.txtDireccion.TabIndex = 4;
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(183, 76);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(92, 48);
            this.btnMostrarTodos.TabIndex = 3;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(183, 16);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(92, 46);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(7, 76);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 1;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblTrackingID
            // 
            this.lblTrackingID.AutoSize = true;
            this.lblTrackingID.Location = new System.Drawing.Point(7, 16);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(63, 13);
            this.lblTrackingID.TabIndex = 0;
            this.lblTrackingID.Text = "Tracking ID";
            // 
            // rtbMostrar
            // 
            this.rtbMostrar.Location = new System.Drawing.Point(13, 322);
            this.rtbMostrar.Name = "rtbMostrar";
            this.rtbMostrar.Size = new System.Drawing.Size(468, 137);
            this.rtbMostrar.TabIndex = 2;
            this.rtbMostrar.Text = "";
            // 
            // cmsListas
            // 
            this.cmsListas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmsListas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.cmsListas.Name = "cmsListas";
            this.cmsListas.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsListas.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.mostrarToolStripMenuItem_Click);
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 471);
            this.Controls.Add(this.rtbMostrar);
            this.Controls.Add(this.gbPaquetes);
            this.Controls.Add(this.gbEstadoPaquetes);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por Agustin.Ferro.2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPpal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPpal_Load);
            this.gbEstadoPaquetes.ResumeLayout(false);
            this.gbEstadoPaquetes.PerformLayout();
            this.gbPaquetes.ResumeLayout(false);
            this.gbPaquetes.PerformLayout();
            this.cmsListas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEstadoPaquetes;
        private System.Windows.Forms.ListBox lstEstadoEntregado;
        private System.Windows.Forms.ListBox lstEstadoEnViaje;
        private System.Windows.Forms.ListBox lstEstadoIngresado;
        private System.Windows.Forms.Label lblEstadoEntregado;
        private System.Windows.Forms.Label lblEstadoEnViaje;
        private System.Windows.Forms.Label lblEstadoIngresado;
        private System.Windows.Forms.GroupBox gbPaquetes;
        private System.Windows.Forms.MaskedTextBox mtxtTrackingID;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.RichTextBox rtbMostrar;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip cmsListas;
    }
}

