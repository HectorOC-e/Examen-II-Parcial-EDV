Public Class CRUD
    Dim conexion As conexion = New conexion()
    Dim tabla As New DataTable
    Private Sub btnEfectuar_Click(sender As Object, e As EventArgs) Handles btnEfectuar.Click
        Select Case cmbCrud.SelectedIndex
            Case 0
            Case 1
            Case 2
            Case 3
                BuscarVenta()
            Case 4
                consultarBase()
        End Select
    End Sub

    'Crear Venta
    'Modificar Venta
    'Eliminar Venta
    'Buscar Venta
    'Consultar Ventas
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
        Dim nombre As String
        nombre = txtnombre.Text
        Try
            tabla = conexion.BuscarVenta(nombre)
            If tabla.Rows.Count <> 0 Then
                dgvBaseDeVentas.DataSource = tabla
            Else
                dgvBaseDeVentas.DataSource = Nothing
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
                txtnombre.Enabled = False
                txtFecha.Enabled = True
            Case 1
                txtPrecio.Enabled = True
                txtCodigoProducto.Enabled = True
                txtCodigoCliente.Enabled = True
                txtPrecio.Enabled = True
                txtnombre.Enabled = False
                txtFecha.Enabled = True
            Case 2
                txtPrecio.Enabled = False
                txtCodigoProducto.Enabled = False
                txtCodigoCliente.Enabled = True
                txtPrecio.Enabled = False
                txtnombre.Enabled = False
                txtFecha.Enabled = False
            Case 3
                txtPrecio.Enabled = False
                txtCodigoProducto.Enabled = False
                txtCodigoCliente.Enabled = False
                txtPrecio.Enabled = False
                txtnombre.Enabled = True
            Case 4
                txtPrecio.Enabled = False
                txtCodigoProducto.Enabled = False
                txtCodigoCliente.Enabled = False
                txtPrecio.Enabled = False
                txtnombre.Enabled = False
                txtFecha.Enabled = False
        End Select
    End Sub

    Private Sub CRUD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.conectar()
    End Sub
End Class
