Public Class FrmCargaMateriales
    Dim consulta As New ClsConsultas
    Dim buscacodigo As New DataTable
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue
    Dim codigo As String = ""
    Dim codigo_empleado As String = ""
    Dim tabla As New DataTable
    Dim i As Integer 
    Dim script As String = ""
    Dim mensaje As String = ""
    Dim contador As String
    Dim datos As New DataTable



    Private Sub TxtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged
        limpia()
        buscacodigo.Clear()
        If TxtCodigo.Text = "" Then

        Else
            If consulta.BuscaNombre(buscacodigo, TxtCodigo.Text, empresa, mensaje) = True Then
                codigo_empleado = TxtCodigo.Text
                empresa = empresa
                Lbnombre.Text = buscacodigo.Rows(0)("nombre") & " " & buscacodigo.Rows(0)("segundo_nombre") & " " & buscacodigo.Rows(0)("Apellido") & " " & buscacodigo.Rows(0)("segundo_apellido")
                carga()
            Else

            End If
        End If
    End Sub

    Private Sub limpia()
        For i As Integer = 1 To C1FlexGrid1.Rows.Count - 1
            C1FlexGrid1(i, 1) = Nothing
            C1FlexGrid1(i, 2) = Nothing
            C1FlexGrid1(i, 3) = Nothing
            C1FlexGrid1(i, 4) = Nothing
            C1FlexGrid1(i, 5) = Nothing
            C1FlexGrid1(i, 6) = Nothing
            C1FlexGrid1(i, 9) = Nothing
            C1FlexGrid1(i, 10) = Nothing
        Next

    End Sub

    Public Function carga()
        script = "select * from tb_materiales_cargados where cod_empleado = " & codigo_empleado & "and codigo_empresa = " & empresa
        tabla.Clear()
        If consulta.consultas(script, tabla, mensaje) = True Then
            contador = tabla.Rows.Count
            If contador > 0 Then
                C1FlexGrid1.Rows.Count = contador + 1
                For i As Integer = 0 To contador - 1
                    C1FlexGrid1(i + 1, 1) = tabla.Rows(i)("cantidad")
                    C1FlexGrid1(i + 1, 2) = tabla.Rows(i)("codigo_empresa")
                    C1FlexGrid1(i + 1, 3) = tabla.Rows(i)("nombre_material")
                    C1FlexGrid1(i + 1, 4) = tabla.Rows(i)("fec_carga")
                    C1FlexGrid1(i + 1, 5) = tabla.Rows(i)("monto")
                    C1FlexGrid1(i + 1, 6) = tabla.Rows(i)("comentarios")
                    C1FlexGrid1(i + 1, 9) = tabla.Rows(i)("estado")
                    C1FlexGrid1(i + 1, 10) = tabla.Rows(i)("fec_devuel")
                    C1FlexGrid1(i + 1, 11) = tabla.Rows(i)("num_material")
                Next
            Else
                limpia()
                For i As Integer = 0 To contador - 1
                    C1FlexGrid1(i + 1, 1) = Nothing
                    C1FlexGrid1(i + 1, 2) = Nothing
                    C1FlexGrid1(i + 1, 3) = Nothing
                    C1FlexGrid1(i + 1, 4) = Nothing
                    C1FlexGrid1(i + 1, 5) = Nothing
                    C1FlexGrid1(i + 1, 6) = Nothing
                    C1FlexGrid1(i + 1, 9) = Nothing
                Next

            End If
        Else

        End If
        Return True
    End Function

    Private Sub BtGuardarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGuardarCambios.Click
        Dim actualizar As Boolean
        Dim j As Integer
        Dim sqlupdate As String
        For j = 0 To contador - 1
            sqlupdate = "update tb_materiales_cargados set estado = '" & C1FlexGrid1(j + 1, 9) & "', fec_devuel = '" & C1FlexGrid1(j + 1, 10) & "'  where num_material = " & C1FlexGrid1(j + 1, 11)
            If consulta.procedure(sqlupdate, mensaje) = True Then
                actualizar = True
            Else
                actualizar = False
            End If
        Next
        If actualizar = True Then
            MsgBox("DATOS ACTUALIZADOS", MsgBoxStyle.Information)
        Else
            MsgBox("OCURRIO UN ERROR" + mensaje)
        End If

    End Sub


    Private Sub BtGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGuardar.Click
        datos.Clear()
        If codigo_empleado = "" Or empresa = "" Or TxtMaterial.Text = "" Or TxtMonto.Text = "" Or TxtCant.Text = "" Then '''''
            MsgBox("DATOS INCOMPLETOS", MsgBoxStyle.Information)
        Else
            Dim dr As DataRow = datos.NewRow
            dr("Cod_empleado") = codigo_empleado
            dr("Codigo_empresa") = empresa
            dr("nombre_material") = TxtMaterial.Text
            dr("fec_carga") = Format(Datfecha.Value, "yyyy-MM-dd")
            dr("monto") = TxtMonto.Text.ToString
            dr("comentarios") = TxtComentario.Text.ToString
            dr("estado") = "PROD"
            dr("cantidad") = TxtCant.Text
            datos.Rows.Add(dr)
            datos.AcceptChanges()
            Dim mensaje As String = ""
            If consulta.agregamaterial(datos, mensaje) = True Then
                MsgBox("DATOS GUARDADOS")
            Else
                MsgBox(mensaje)
            End If
            carga()
            datos.Clear()
        End If
    End Sub

    Private Sub C1FlexGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1FlexGrid1.Click

    End Sub

    Private Sub FrmCargaMateriales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datos.Columns.Add("cod_empleado")
        datos.Columns.Add("codigo_empresa")
        datos.Columns.Add("nombre_material")
        datos.Columns.Add("fec_carga")
        datos.Columns.Add("monto")
        datos.Columns.Add("comentarios")
        datos.Columns.Add("estado")
        datos.Columns.Add("cantidad")
    End Sub

    Private Sub TxtCodigo_Changed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub Datfecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datfecha.ValueChanged

    End Sub

    Private Sub TxtCodigo_can(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCant.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCodigo__monto(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> (".") Then
            e.Handled = True
        End If
    End Sub



End Class