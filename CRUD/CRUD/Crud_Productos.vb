Public Class Crud_Productos
    Dim conexion As conexion = New conexion()
    Dim tabla As New DataTable

    Private Sub btnEfectuar_Click(sender As Object, e As EventArgs) Handles btnEfectuar.Click
        If ValidarProducto() = 1 Then
            MessageBox.Show("El Producto ya Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Select Case cmbCrud.SelectedIndex
                Case 0
                    If Me.ValidateChildren = True And txtCodigoProducto.Text <> "" And txtProducto.Text <> "" And txtDescripcion.Text <> "" Then

                        AgregarProducto()
                        consultarBase()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Case 1
                    If Me.ValidateChildren = True And txtCodigoProducto.Text <> "" And txtProducto.Text <> "" And txtDescripcion.Text <> "" Then
                        MsgBox("Debe dar click en un Producto", vbInformation)
                        consultarBase()
                        modificarProducto()

                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Case 2
                    If Me.ValidateChildren = True And txtCodigoProducto.Text <> "" Then

                        eliminarProducto()
                        consultarBase()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Case 3
                    If Me.ValidateChildren = True And txtCodigoProducto.Text <> "" Then
                        buscarProducto()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Case 4
                    consultarBase()
                Case Else
                    MsgBox("Debe seleccionar una operacion", vbInformation)
            End Select
        End If
    End Sub
    Function ValidarProducto()
        Dim codigo As Integer
        Try
            codigo = txtCodigoProducto.Text
            tabla = conexion.BuscarProducto(codigo)
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

    Private Sub AgregarProducto()
        Dim codigoProducto As Integer
        Dim nombre, descripcion As String

        codigoProducto = txtCodigoProducto.Text
        nombre = txtProducto.Text
        descripcion = txtDescripcion.Text


        Try
            If conexion.IngresarProducto(codigoProducto, nombre, descripcion) Then
                MsgBox("Producto registrado con exito")
            Else
                MsgBox("Error al registrar Cliente")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub consultarBase()
        Try
            tabla = conexion.ConsultarProductos
            If tabla.Rows.Count <> 0 Then
                dgvBaseDeProductos.DataSource = tabla
            Else
                dgvBaseDeProductos.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub buscarProducto()
        Dim codigo As Integer
        codigo = txtCodigoProducto.Text
        Try
            tabla = conexion.BuscarProducto(codigo)
            If tabla.Rows.Count <> 0 Then
                dgvBaseDeProductos.DataSource = tabla
            Else
                MsgBox("El Producto no existe", vbInformation)
                dgvBaseDeProductos.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub modificarProducto()
        Dim codigoProducto As Integer
        Dim nombre, descripcion As String

        codigoProducto = txtCodigoProducto.Text
        nombre = txtProducto.Text
        descripcion = txtDescripcion.Text


        Try
            If conexion.ModificarProducto(codigoProducto, nombre, descripcion) Then
                MsgBox("Producto Modificado con exito")
                consultarBase()
            Else
                MsgBox("Error al modificar Producto")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub eliminarProducto()
        Dim codigo As Integer
        codigo = txtCodigoProducto.Text
        Try
            If conexion.EliminarProducto(codigo) Then
                MsgBox("Producto eliminado con exito")
            Else
                MsgBox("Error al eliminar Producto")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCrud_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCrud.SelectedIndexChanged
        Select Case cmbCrud.SelectedIndex
            Case 0
                txtCodigoProducto.Enabled = True
                txtProducto.Enabled = True
                txtDescripcion.Enabled = True
                btnEfectuar.Enabled = True

            Case 1
                txtCodigoProducto.Enabled = False
                txtProducto.Enabled = True
                txtDescripcion.Enabled = True
                btnEfectuar.Enabled = True
                consultarBase()

            Case 2
                txtCodigoProducto.Enabled = True
                txtProducto.Enabled = False
                txtDescripcion.Enabled = False
                btnEfectuar.Enabled = True

            Case 3
                txtCodigoProducto.Enabled = True
                txtProducto.Enabled = False
                txtDescripcion.Enabled = False
                btnEfectuar.Enabled = True

            Case 4
                txtCodigoProducto.Enabled = False
                txtProducto.Enabled = False
                txtDescripcion.Enabled = False
                btnEfectuar.Enabled = False
                consultarBase()

        End Select
    End Sub

    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtCodigoProducto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCodigoProducto.Validating
        If DirectCast(sender, MaskedTextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtProducto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtProducto.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDescripcion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtCodigoProducto_MouseHover(sender As Object, e As EventArgs) Handles txtCodigoProducto.MouseHover
        ToolTip.SetToolTip(txtCodigoProducto, "Codigo del Producto")
        ToolTip.ToolTipTitle = "Codigo Producto"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtProducto_MouseHover(sender As Object, e As EventArgs) Handles txtProducto.MouseHover
        ToolTip.SetToolTip(txtProducto, "Nombre del Producto")
        ToolTip.ToolTipTitle = "Nombre Producto"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtDescripcion_MouseHover(sender As Object, e As EventArgs) Handles txtDescripcion.MouseHover
        ToolTip.SetToolTip(txtDescripcion, "Descripción del Producto")
        ToolTip.ToolTipTitle = "Descripción"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub cmbCrud_MouseHover(sender As Object, e As EventArgs) Handles cmbCrud.MouseHover
        ToolTip.SetToolTip(cmbCrud, "Operaciones CRUD")
        ToolTip.ToolTipTitle = "CRUD"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnEfectuar_MouseHover(sender As Object, e As EventArgs) Handles btnEfectuar.MouseHover
        ToolTip.SetToolTip(btnEfectuar, "Ejecutar Operación")
        ToolTip.ToolTipTitle = "Ejecutar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub dgvBaseDeProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBaseDeProductos.CellContentClick
        txtCodigoProducto.Text = dgvBaseDeProductos.CurrentRow.Cells(0).Value.ToString
        txtDescripcion.Text = dgvBaseDeProductos.CurrentRow.Cells(2).Value.ToString
    End Sub

End Class