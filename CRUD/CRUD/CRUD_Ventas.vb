Public Class CRUD_Ventas
    Dim conexion As conexion = New conexion()
    Dim tabla As New DataTable

    Function validarCliente()
        Dim codigoCliente As Integer
        Try
            codigoCliente = txtCodigoCliente.Text
            tabla = conexion.BuscarCliente(codigoCliente)
            If tabla.Rows.Count <> 0 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 1
        End Try
    End Function

    Function ValidarProducto()
        Dim codigoProducto As Integer
        Try
            codigoProducto = txtCodigoProducto.Text
            tabla = conexion.BuscarProducto(codigoProducto)
            If tabla.Rows.Count <> 0 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 1
        End Try
    End Function

    'Crear Venta
    'Modificar Venta
    'Eliminar Venta
    'Buscar Venta
    'Consultar Ventas
    Private Sub crearVenta()
        Dim idVenta, precio, cantidad, idCliente, idProducto As Integer
        Dim fechaVenta As Date
        idVenta = txtnumeroventa.Text
        fechaVenta = txtFecha.Text
        precio = txtPrecio.Text
        cantidad = txtCantidad.Text
        idCliente = txtCodigoCliente.Text
        idProducto = txtCodigoProducto.Text

        Try
            If conexion.crearventa(idVenta, fechaVenta, precio, cantidad, idCliente, idProducto) Then
                MsgBox("Venta registrada con exito")
            Else
                MsgBox("Error al registrar venta")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub consultarBase()
        Try
            tabla = conexion.ConsultarVentas
            If tabla.Rows.Count <> 0 Then
                dgvBaseDeVentas.DataSource = tabla
            Else
                dgvBaseDeVentas.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BuscarVenta()
        Dim codigo As Integer
        codigo = txtCodigoCliente.Text
        Try
            tabla = conexion.BuscarVenta(codigo)
            If tabla.Rows.Count <> 0 Then
                dgvBaseDeVentas.DataSource = tabla
            Else
                MsgBox("El Cliente no existe", vbInformation)
                dgvBaseDeVentas.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub modificarVenta()
        Dim precio, cantidad, idCliente, idProducto As Integer
        Dim fechaVenta As Date
        fechaVenta = txtFecha.Text
        precio = txtPrecio.Text
        cantidad = txtCantidad.Text
        idCliente = txtCodigoCliente.Text
        idProducto = txtCodigoProducto.Text
        Try
            If conexion.ModificarVenta(fechaVenta, precio, cantidad, idCliente, idProducto) Then
                MsgBox("Venta Modificada con exito")
                consultarBase()
            Else
                MsgBox("Error al modificar venta")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub eliminar()
        Dim codigo As Integer
        codigo = txtCodigoCliente.Text
        Try
            If conexion.eliminarVenta(codigo) Then
                MsgBox("Venta eliminada con exito")
            Else
                MsgBox("Error al eliminar venta")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCrud_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCrud.SelectedIndexChanged
        Select Case cmbCrud.SelectedIndex
            Case 0
                txtPrecio.Enabled = True
                txtCodigoProducto.Enabled = True
                txtCodigoCliente.Enabled = True
                txtPrecio.Enabled = True
                txtnumeroventa.Enabled = True
                txtFecha.Enabled = True
                txtCantidad.Enabled = True
                btnEfectuar.Enabled = True


            Case 1
                txtPrecio.Enabled = True
                txtCodigoProducto.Enabled = True
                txtCodigoCliente.Enabled = True
                txtPrecio.Enabled = True
                txtnumeroventa.Enabled = False
                txtFecha.Enabled = True
                btnEfectuar.Enabled = True
                consultarBase()

            Case 2
                txtPrecio.Enabled = False
                txtCodigoProducto.Enabled = False
                txtCodigoCliente.Enabled = True
                txtPrecio.Enabled = False
                txtnumeroventa.Enabled = False
                txtFecha.Enabled = False
                txtCantidad.Enabled = False
                btnEfectuar.Enabled = True

            Case 3
                txtPrecio.Enabled = False
                txtCodigoProducto.Enabled = False
                txtCodigoCliente.Enabled = True
                txtPrecio.Enabled = False
                txtnumeroventa.Enabled = False
                txtCantidad.Enabled = False
                txtFecha.Enabled = False
                btnEfectuar.Enabled = True

            Case 4
                txtPrecio.Enabled = False
                txtCodigoProducto.Enabled = False
                txtCodigoCliente.Enabled = False
                txtPrecio.Enabled = False
                txtnumeroventa.Enabled = False
                txtFecha.Enabled = False
                txtCantidad.Enabled = False
                btnEfectuar.Enabled = False
                consultarBase()

        End Select
    End Sub

    Private Sub dgvBaseDeVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBaseDeVentas.CellContentClick
        txtCodigoCliente.Text = dgvBaseDeVentas.CurrentRow.Cells(0).Value.ToString
        txtCodigoProducto.Text = dgvBaseDeVentas.CurrentRow.Cells(2).Value.ToString
        txtPrecio.Text = dgvBaseDeVentas.CurrentRow.Cells(5).Value.ToString
        txtCantidad.Text = dgvBaseDeVentas.CurrentRow.Cells(4).Value.ToString
        txtFecha.Text = dgvBaseDeVentas.CurrentRow.Cells(6).Value.ToString
    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigoProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoProducto.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtnumeroventa_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnumeroventa.Validating
        If DirectCast(sender, MaskedTextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtCodigoCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtCodigoProducto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCodigoProducto.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtPrecio_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPrecio.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtCantidad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCantidad.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtFecha_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFecha.Validating
        If DirectCast(sender, MaskedTextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub cmbCrud_MouseHover(sender As Object, e As EventArgs) Handles cmbCrud.MouseHover
        ToolTip.SetToolTip(cmbCrud, "Operaciones CRUD")
        ToolTip.ToolTipTitle = "CRUD"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnEfectuar_MouseHover(sender As Object, e As EventArgs) 
        ToolTip.SetToolTip(btnEfectuar, "Ejecutar Operación")
        ToolTip.ToolTipTitle = "Ejecutar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtnumeroventa_MouseHover(sender As Object, e As EventArgs) Handles txtnumeroventa.MouseHover
        ToolTip.SetToolTip(txtnumeroventa, "Numero de la Venta")
        ToolTip.ToolTipTitle = "Venta"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtCodigoCliente_MouseHover(sender As Object, e As EventArgs) Handles txtCodigoCliente.MouseHover
        ToolTip.SetToolTip(txtCodigoCliente, "Codigo del cliente")
        ToolTip.ToolTipTitle = "Cliente"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtCodigoProducto_MouseHover(sender As Object, e As EventArgs) Handles txtCodigoProducto.MouseHover
        ToolTip.SetToolTip(txtCodigoProducto, "Codigo del Producto")
        ToolTip.ToolTipTitle = "Producto"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtPrecio_MouseHover(sender As Object, e As EventArgs) Handles txtPrecio.MouseHover
        ToolTip.SetToolTip(txtPrecio, "Precio unidad del Producto")
        ToolTip.ToolTipTitle = "Precio"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtCantidad_MouseHover(sender As Object, e As EventArgs) Handles txtCantidad.MouseHover
        ToolTip.SetToolTip(txtCantidad, "Cantidad de Producto")
        ToolTip.ToolTipTitle = "Cantidad"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtFecha_MouseHover(sender As Object, e As EventArgs) Handles txtFecha.MouseHover
        ToolTip.SetToolTip(txtFecha, "Fecha de venta")
        ToolTip.ToolTipTitle = "Fecha"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnEfectuar_Click_1(sender As Object, e As EventArgs) Handles btnEfectuar.Click
        If validarCliente() = 0 Then
            MessageBox.Show("El Cliente no Existe, debera registrarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf ValidarProducto() = 0 Then
            MessageBox.Show("El Producto no Existe, debera agregarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Select Case cmbCrud.SelectedIndex
                Case 0
                    If Me.ValidateChildren = True And txtCodigoProducto.Text <> "" And txtCodigoCliente.Text <> "" And txtnumeroventa.Text <> "" And txtPrecio.Text <> "" And txtFecha.Text <> "" And txtCantidad.Text <> "" Then
                        crearVenta()
                        consultarBase()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Case 1
                    If Me.ValidateChildren = True And txtCodigoProducto.Text <> "" And txtCodigoCliente.Text <> "" And txtnumeroventa.Text <> "" And txtPrecio.Text <> "" And txtFecha.Text <> "" And txtCantidad.Text <> "" Then

                        MsgBox("Debe dar click en un Producto", vbInformation)
                        consultarBase()
                        modificarVenta()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Case 2
                    If Me.ValidateChildren = True And txtCodigoCliente.Text <> "" Then

                        eliminar()
                        consultarBase()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Case 3
                    If Me.ValidateChildren = True And txtCodigoCliente.Text <> "" Then
                        BuscarVenta()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Case 4
                    consultarBase()
            End Select
        End If
    End Sub

    Private Sub CRUD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
