Public Class RegistrarCliente
    Dim conexion As conexion = New conexion()
    Dim tabla As New DataTable

    Private Sub btnEfectuar_Click(sender As Object, e As EventArgs) Handles btnEfectuar.Click
        If validarCliente() = 1 Then
            MessageBox.Show("El Cliente ya Existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Select Case cmbCrud.SelectedIndex
                Case 0
                    If Me.ValidateChildren = True And txtCodigoCliente.Text <> "" And txtPrimerNombre.Text <> "" And txtPrimerApellido.Text <> "" And txtDireccion.Text <> "" Then
                        RegistrarCliente()
                        consultarBase()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case 1
                    If Me.ValidateChildren = True And txtCodigoCliente.Text <> "" And txtPrimerNombre.Text <> "" And txtPrimerApellido.Text <> "" And txtDireccion.Text <> "" Then
                        MsgBox("Debe dar click en un Cliente", vbInformation)
                        consultarBase()
                        ModificarCliente()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Case 2
                    If Me.ValidateChildren = True And txtCodigoCliente.Text <> "" Then
                        EliminarCliente()
                        consultarBase()
                    Else
                        MessageBox.Show("Debe llenar las casillas necesarias", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Case 3
                    If Me.ValidateChildren = True And txtCodigoCliente.Text <> "" Then
                        buscarCliente()
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

    Private Sub RegistrarCliente()
        Dim Clientecodigo As Integer
        Dim nombre, apellido, direccion As String

        Clientecodigo = txtCodigoCliente.Text
        nombre = txtPrimerNombre.Text
        apellido = txtPrimerApellido.Text
        direccion = txtDireccion.Text

        Try
            If conexion.RegistrarCliente(Clientecodigo, nombre, apellido, direccion) Then
                MsgBox("Cliente registrado con exito")
            Else
                MsgBox("Error al registrar Cliente")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub consultarBase()
        Try
            tabla = conexion.ConsultarClientes
            If tabla.Rows.Count <> 0 Then
                dgvBaseDeClientes.DataSource = tabla
            Else
                dgvBaseDeClientes.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function validarCliente()
        Dim codigo As Integer
        Try
            codigo = txtCodigoCliente.Text
            tabla = conexion.BuscarCliente(codigo)
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

    Private Sub buscarCliente()
        Dim codigo As Integer
        codigo = txtCodigoCliente.Text
        Try
            tabla = conexion.BuscarCliente(codigo)
            If tabla.Rows.Count <> 0 Then
                dgvBaseDeClientes.DataSource = tabla
            Else
                MsgBox("El Cliente no existe", vbInformation)
                dgvBaseDeClientes.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ModificarCliente()
        Dim Clientecodigo As Integer
        Dim nombre, apellido, direccion As String

        Clientecodigo = txtCodigoCliente.Text
        nombre = txtPrimerNombre.Text
        apellido = txtPrimerApellido.Text
        direccion = txtDireccion.Text

        Try
            If conexion.ModificarCliente(Clientecodigo, nombre, apellido, direccion) Then
                MsgBox("Cliente Modificado con exito")
                consultarBase()
            Else
                MsgBox("Error al modificar Cliente")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub EliminarCliente()
        Dim codigo As Integer
        codigo = txtCodigoCliente.Text
        Try
            If conexion.EliminarCliente(codigo) Then
                MsgBox("Cliente eliminado con exito")
            Else
                MsgBox("Error al eliminar Cliente")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbCrud_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCrud.SelectedIndexChanged
        Select Case cmbCrud.SelectedIndex
            Case 0
                txtCodigoCliente.Enabled = True
                txtPrimerNombre.Enabled = True
                txtPrimerApellido.Enabled = True
                txtDireccion.Enabled = True
                btnEfectuar.Enabled = True

            Case 1
                txtCodigoCliente.Enabled = False
                txtPrimerNombre.Enabled = True
                txtPrimerApellido.Enabled = True
                txtDireccion.Enabled = True
                btnEfectuar.Enabled = True
                consultarBase()

            Case 2
                txtCodigoCliente.Enabled = True
                txtPrimerNombre.Enabled = False
                txtPrimerApellido.Enabled = False
                txtDireccion.Enabled = False
                btnEfectuar.Enabled = True

            Case 3
                txtCodigoCliente.Enabled = True
                txtPrimerNombre.Enabled = False
                txtPrimerApellido.Enabled = False
                txtDireccion.Enabled = False
                btnEfectuar.Enabled = True

            Case 4
                txtCodigoCliente.Enabled = False
                txtPrimerNombre.Enabled = False
                txtPrimerApellido.Enabled = False
                txtDireccion.Enabled = False
                btnEfectuar.Enabled = False
                consultarBase()

        End Select
    End Sub

    Private Sub txtPrimerNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrimerNombre.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtPrimerApellido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrimerApellido.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtCodigoCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCodigoCliente.Validating
        If DirectCast(sender, MaskedTextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtPrimerNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPrimerNombre.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtPrimerApellido_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPrimerApellido.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtDireccion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDireccion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorValidacion.SetError(sender, "")
        Else
            Me.ErrorValidacion.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtCodigoCliente_MouseHover(sender As Object, e As EventArgs) Handles txtCodigoCliente.MouseHover
        ToolTip.SetToolTip(txtCodigoCliente, "Codigo del cliente")
        ToolTip.ToolTipTitle = "CODIGO"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtPrimerNombre_MouseHover(sender As Object, e As EventArgs) Handles txtPrimerNombre.MouseHover
        ToolTip.SetToolTip(txtPrimerNombre, "Primer Nombre del cliente")
        ToolTip.ToolTipTitle = "Nombre Cliente"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtPrimerApellido_MouseHover(sender As Object, e As EventArgs) Handles txtPrimerApellido.MouseHover
        ToolTip.SetToolTip(txtPrimerNombre, "Primer Apellido del cliente")
        ToolTip.ToolTipTitle = "Apellido Cliente"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub txtDireccion_MouseHover(sender As Object, e As EventArgs) Handles txtDireccion.MouseHover
        ToolTip.SetToolTip(txtDireccion, "Direccion del cliente")
        ToolTip.ToolTipTitle = "Direccion Cliente"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub btnEfectuar_MouseHover(sender As Object, e As EventArgs) Handles btnEfectuar.MouseHover
        ToolTip.SetToolTip(btnEfectuar, "Efectuar Operacion")
        ToolTip.ToolTipTitle = "Operacion"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub cmbCrud_MouseHover(sender As Object, e As EventArgs) Handles cmbCrud.MouseHover
        ToolTip.SetToolTip(cmbCrud, "Opciones de operaciones CRUD")
        ToolTip.ToolTipTitle = "CRUD"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub dgvBaseDeClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBaseDeClientes.CellContentClick
        txtCodigoCliente.Text = dgvBaseDeClientes.CurrentRow.Cells(0).Value.ToString
        txtDireccion.Text = dgvBaseDeClientes.CurrentRow.Cells(2).Value.ToString
    End Sub

End Class