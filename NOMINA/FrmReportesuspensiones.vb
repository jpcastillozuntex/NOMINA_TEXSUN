Public Class FrmReportesuspensiones
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim dtfechas As New DataTable
    Dim dtcodigos As New DataTable
    Dim msj As String
    Dim inicio As Date
    Dim final As Date
    Dim mes As Integer
    Dim anio As Integer
    Dim anio2 As Integer
    Dim mes2 As Integer
    Dim empresa As Integer = FrmInicio.empresa
    'Dim empresa As Integer = 1


    Private Sub FrmReportesuspensiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2

    End Sub

    Private Sub crea()
        mes = Format(Datmes.Value, "MM")
        mes2 = Format(Datmes.Value, "MM")
        anio = Format(Datanio.Value, "yyyy")
        anio2 = Format(Datanio.Value, "yyyy")
        If mes = 12 Then
            mes2 = 0
            anio2 = anio + 1
        End If
        inicio = anio & "-" & mes & "-" & "01"
        final = anio2 & "-" & mes2 + 1 & "-" & "01"
    End Sub

    Private Sub BtCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCalcular.Click
        crea()
        Dim mes As String = MonthName(DatePart("M", inicio)).ToUpper
        Cursor = Cursors.WaitCursor
        Dim squery As String = "select a.*, b.nombre,b.segundo_nombre,apellido,segundo_apellido,c.nombre as depart,'" & mes & "' as mes, '" & FrmInicio.CbEmpresa.Text & "' as empresa" &
                        " from TB_SUSPENSION as a, tb_empleado as b " &
                        " left join tb_deptos_empresa as c on b.cod_depart = c.cod_depar " &
                        " where a.cod_empresa = " & empresa &
                        " and a.cod_empresa = b.Codigo_empresa  " &
                        " and a.codigo= b.codigo " &
                        " and fec_fin > '" & inicio & "'" &
                        " and fec_inic < '" & final & "'"
        Try
            cr.Load("C:\Plan_rep\nomina.flxr", "suspensiones")
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.RecordSource = squery
            cr.Render()
            Fv.DocumentSource = cr

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class
