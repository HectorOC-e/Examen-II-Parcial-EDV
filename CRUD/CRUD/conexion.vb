Imports System.Data.SqlClient
Public Class conexion
    Public conexion As SqlConnection = New SqlConnection("Data Source=HECTOROS\SQLEXPRESS02;Initial Catalog=Tienda;Integrated Security=True")
    Dim cmd As New SqlCommand
    Public Sub conectar()
        Try
            conexion.Open()
            MsgBox("conexion establecida")
        Catch ex As Exception
            MsgBox("Error al conectar")
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function crearventa(idVenta As Integer, fechaVenta As Date, precio As Integer, cantidad As Integer, idcliente As Integer, idproducto As Integer)
        Try
            conexion.Open()
            cmd = New SqlCommand("Ingresarventa", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idVenta", idVenta)
            cmd.Parameters.AddWithValue("@fechaVenta", fechaVenta)
            cmd.Parameters.AddWithValue("@precio", precio)
            cmd.Parameters.AddWithValue("@cantidad", cantidad)
            cmd.Parameters.AddWithValue("@idcliente", idcliente)
            cmd.Parameters.AddWithValue("@idproducto", idproducto)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ConsultarVentas()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ConsultarBase", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

                conexion.Close()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()

        End Try
    End Function

    Public Function BuscarVenta(Codigo As Integer)
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ConsultarVenta", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@codigo", Codigo)
            If cmd.ExecuteNonQuery  Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function
    Public Function eliminarVenta(codigoCliente As Integer) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("EliminarVenta", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@codigoCliente", codigoCliente)

            If cmd.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ModificarVenta(fechaVenta As Date, precio As Integer, cantidad As Integer, idcliente As Integer, idproducto As Integer)
        Try
            conexion.Open()
            cmd = New SqlCommand("ModificarVenta", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fechaVenta", fechaVenta)
            cmd.Parameters.AddWithValue("@precio", precio)
            cmd.Parameters.AddWithValue("@cantidad", cantidad)
            cmd.Parameters.AddWithValue("@idcliente", idcliente)
            cmd.Parameters.AddWithValue("@idproducto", idproducto)

            If cmd.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function


    'TABLA DE CLIENTES
    Public Function RegistrarCliente(idcodigo As Integer, nombre As String, apellido As String, direccion As String)
        Try
            conexion.Open()
            cmd = New SqlCommand("IngresarCliente", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", idcodigo)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@apellido", apellido)
            cmd.Parameters.AddWithValue("@direccion", direccion)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ConsultarClientes()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ConsultarClientes", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

                conexion.Close()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function BuscarCliente(Codigo As Integer)
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("BuscarCliente", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@codigo", Codigo)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function
    Public Function EliminarCliente(codigoCliente As Integer) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("eliminarCliente", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@codigo", codigoCliente)

            If cmd.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ModificarCliente(idcodigo As Integer, nombre As String, apellido As String, direccion As String) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("ActualizarCliente", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@codigo", idcodigo)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@apellido", apellido)
            cmd.Parameters.AddWithValue("@direccion", direccion)


            If cmd.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function


    'Tabla productos
    Public Function IngresarProducto(idProd As Integer, nombreProducto As String, descripcion As String)
        Try
            conexion.Open()
            cmd = New SqlCommand("IngresarProducto", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idProd", idProd)
            cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto)
            cmd.Parameters.AddWithValue("@descripcion", descripcion)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ConsultarProductos()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ConsultarProductos", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

                conexion.Close()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function BuscarProducto(Codigo As Integer)
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("BuscarProductos", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@codigo", Codigo)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function
    Public Function EliminarProducto(Codigo As Integer) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("eliminarProducto", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@codigoProducto", Codigo)

            If cmd.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function ModificarProducto(idProd As Integer, nombreProducto As String, descripcion As String) As Boolean
        Try
            conexion.Open()
            cmd = New SqlCommand("ModificarVenta", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idProd", idProd)
            cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto)
            cmd.Parameters.AddWithValue("@descripcion", descripcion)

            If cmd.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function


End Class
