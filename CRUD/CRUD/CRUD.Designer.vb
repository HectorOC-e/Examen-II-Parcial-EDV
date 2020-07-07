<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRUD
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvBaseDeVentas = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnEfectuar = New System.Windows.Forms.Button()
        Me.cmbCrud = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.txtCodigoProducto = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvBaseDeVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvBaseDeVentas
        '
        Me.dgvBaseDeVentas.AllowUserToAddRows = False
        Me.dgvBaseDeVentas.AllowUserToDeleteRows = False
        Me.dgvBaseDeVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBaseDeVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBaseDeVentas.Location = New System.Drawing.Point(3, 18)
        Me.dgvBaseDeVentas.Name = "dgvBaseDeVentas"
        Me.dgvBaseDeVentas.ReadOnly = True
        Me.dgvBaseDeVentas.RowHeadersWidth = 51
        Me.dgvBaseDeVentas.RowTemplate.Height = 24
        Me.dgvBaseDeVentas.Size = New System.Drawing.Size(911, 308)
        Me.dgvBaseDeVentas.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvBaseDeVentas)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 253)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(917, 329)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Base de datos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.MaskedTextBox1)
        Me.GroupBox2.Controls.Add(Me.txtFecha)
        Me.GroupBox2.Controls.Add(Me.Fecha)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtCantidad)
        Me.GroupBox2.Controls.Add(Me.txtPrecio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtCodigoProducto)
        Me.GroupBox2.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox2.Controls.Add(Me.txtnombre)
        Me.GroupBox2.Location = New System.Drawing.Point(39, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(660, 210)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ingresar Datos"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnEfectuar)
        Me.GroupBox3.Controls.Add(Me.cmbCrud)
        Me.GroupBox3.Location = New System.Drawing.Point(743, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(210, 210)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CRUD"
        '
        'btnEfectuar
        '
        Me.btnEfectuar.Location = New System.Drawing.Point(61, 123)
        Me.btnEfectuar.Name = "btnEfectuar"
        Me.btnEfectuar.Size = New System.Drawing.Size(95, 26)
        Me.btnEfectuar.TabIndex = 1
        Me.btnEfectuar.Text = "Efectuar"
        Me.btnEfectuar.UseVisualStyleBackColor = True
        '
        'cmbCrud
        '
        Me.cmbCrud.FormattingEnabled = True
        Me.cmbCrud.Items.AddRange(New Object() {"Crear Venta", "Modificar Venta", "Eliminar Venta", "Buscar Venta", "Consultar Ventas"})
        Me.cmbCrud.Location = New System.Drawing.Point(46, 76)
        Me.cmbCrud.Name = "cmbCrud"
        Me.cmbCrud.Size = New System.Drawing.Size(121, 24)
        Me.cmbCrud.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Codigo Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Codigo Producto"
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Location = New System.Drawing.Point(350, 142)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(47, 17)
        Me.Fecha.TabIndex = 11
        Me.Fecha.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(350, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cantidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(350, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Precio"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(481, 139)
        Me.txtFecha.Mask = "0000-00-00"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(100, 22)
        Me.txtFecha.TabIndex = 12
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'txtnombre
        '
        Me.txtnombre.Location = New System.Drawing.Point(166, 48)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(100, 22)
        Me.txtnombre.TabIndex = 0
        '
        'txtCodigoProducto
        '
        Me.txtCodigoProducto.Location = New System.Drawing.Point(166, 137)
        Me.txtCodigoProducto.Name = "txtCodigoProducto"
        Me.txtCodigoProducto.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigoProducto.TabIndex = 2
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(166, 90)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigoCliente.TabIndex = 1
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(481, 48)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 22)
        Me.txtPrecio.TabIndex = 6
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(481, 90)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 22)
        Me.txtCantidad.TabIndex = 7
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(314, 182)
        Me.MaskedTextBox1.Mask = "999"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(100, 22)
        Me.MaskedTextBox1.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(205, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Numero venta"
        '
        'CRUD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 603)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CRUD"
        Me.Text = "Form1"
        CType(Me.dgvBaseDeVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvBaseDeVentas As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnEfectuar As Button
    Friend WithEvents cmbCrud As ComboBox
    Friend WithEvents Fecha As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFecha As MaskedTextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtCodigoProducto As TextBox
    Friend WithEvents txtCodigoCliente As TextBox
    Friend WithEvents txtnombre As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
End Class
