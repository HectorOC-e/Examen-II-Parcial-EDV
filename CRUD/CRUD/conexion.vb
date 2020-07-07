Imports System.Data.SqlClient
Public Class conexion
    Public conexion As SqlConnection = New SqlConnection("Data Source=HECTOROS\SQLEXPRESS02;Initial Catalog=Tienda;Integrated Security=True")
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
        End Try
    End Function

    Public Function BuscarVenta(nombre As String)
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ConsultarVenta", conexion)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Nombre", nombre)
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
        End Try
    End Function

End Class
