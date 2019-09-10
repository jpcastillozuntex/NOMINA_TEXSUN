Imports C1.Win.FlexReport

Public Class Frmamonestacion
    Dim cs As New ClsConsultas
    Dim cadena As String = "CODIGO"
    Dim codigo As String

    Private Sub FrmImpContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler TxtCodigo.GotFocus, AddressOf GotfocusTexto
        AddHandler TxtCodigo.LostFocus, AddressOf LostfocusTexto
        Cbmotivo.SelectedIndex = 0
    End Sub

    Private Sub GotfocusTexto(ByVal sender As Object, ByVal e As System.EventArgs)
        codigo = sender.Text
        TxtCodigo.Text = ""
        sender.ForeColor = Color.Black
    End Sub

    Private Sub LostfocusTexto(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.Text = "" Then 'si salio del textbox sin poner nada
            sender.Text = cadena  'volverle a poner el texto que tenia
            codigo = ""
            sender.ForeColor = Color.LightGray 'y poner la letra en gris
        End If
    End Sub

    Private Sub BtBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBuscar.Click
        If Cbmotivo.Text = "Llamada de atención llegada tarde" Then
            Dim fecha As Date = Format(DatFecha.Value, "yyyy-MM-dd")
            If TxtCodigo.Text = "" Then
                MsgBox("INGRESE CODIGO")
            Else
                Dim strsql As String = " select nombre+' '+segundo_nombre+' '+apellido+' '+segundo_apellido as nombre, codigo,'" & Format(DatFecFalta.Value, "yyyy-MM-dd") & "' AS fecha,'" & Format(DatHora.Value, "HH:mm") & "' as hora  from tb_empleado where codigo = " & TxtCodigo.Text
                Try
                    rp.Load("C:\Plan_rep\Nomina.flxr", "llamada_tarde")
                    rp.DataSource.ConnectionString = cs.con
                    rp.DataSource.RecordSource = strsql
                    Dim fec As TextField = DirectCast(rp.Fields("fecha"), TextField)
                    fec.Text = fecha
                    Dim motiv As TextField = DirectCast(rp.Fields("motivo"), TextField)
                    motiv.Text = fecha
                    Dim user As TextField = DirectCast(rp.Fields("usuario"), TextField)
                    user.Text = fecha
                    rp.Render()
                Catch
                End Try
            End If
        Else
            Dim fecha As Date = Format(DatFecha.Value, "yyyy-MM-dd")
            If TxtCodigo.Text = "" Then
                MsgBox("INGRESE CODIGO")
            Else
                Dim strsql As String = " select nombre+' '+segundo_nombre+' '+apellido+' '+segundo_apellido as nombre, codigo,convert(varchar(MAX),DATENAME(MONTH,'" & Format(DatFecFalta.Value, "yyyy-MM-dd") & "')) as mes,convert(varchar(MAX),DATENAME(DAY,'" & Format(DatFecFalta.Value, "yyyy-MM-dd") & "')) AS dia  from tb_empleado where codigo = " & TxtCodigo.Text
                Try
                    rp.Load("C:\Plan_rep\Nomina.flxr", "llamada")
                    rp.DataSource.ConnectionString = cs.con
                    rp.DataSource.RecordSource = strsql
                    Dim fec As TextField = DirectCast(rp.Fields("fecha"), TextField)
                    fec.Text = fecha
                    Dim motiv As TextField = DirectCast(rp.Fields("motivo"), TextField)
                    motiv.Text = fecha
                    Dim user As TextField = DirectCast(rp.Fields("usuario"), TextField)
                    user.Text = fecha
                    rp.Render()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub


    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> (".") Then
            e.Handled = True
        End If
    End Sub

End Class