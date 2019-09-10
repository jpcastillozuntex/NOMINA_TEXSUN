Imports C1.Win.FlexReport

Public Class Frmcomprobante_aguina
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dtplani As New DataTable
    Dim fecha As Date
    Dim fec_letras As String
    Dim ciclos As Integer
    Dim fechas As String
    Dim fecha2 As String
    Dim ciclo As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa As String = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmComprobanteAguinal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1080, a - 10)
        Me.Top = a / 2 - (a / 2)
        Me.Left = l / 2 - (1080 / 2)
        Dim mes As String
        mes = MonthName(Month(fecha))
        fec_letras = DatePart("d", fecha) & " De " & mes & " del " & Format(fecha, "yyyy")
        fec_letras = UCase(fec_letras)
    End Sub

    Public Sub convierte_fecha(ByVal fecha As Date)
        Dim mes As String
        mes = MonthName(Month(fecha))
        fec_letras = DatePart("d", fecha) & " De " & mes & " del " & Format(fecha, "yyyy")
        fec_letras = UCase(fec_letras)
    End Sub

    Private Sub BtImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtConsultar.Click
        ciclos = DatePart(DateInterval.Year, DatAnio.Value)
        ciclo = Format(DatAnio.Value, "yyyy")
        fechas = "01-12-" & ciclos - 1
        fecha2 = "30-11-" & ciclos
        fecha = Format(datfecha.Value, "dd-MM-yyyy")
        convierte_fecha(fecha)
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Cursor = Cursors.WaitCursor
        Dim strsql As String = "SELECT A.COD_EMPLEADO,A.COD_EMPRESA,A.MONTO,A.CICLO,A.DIAS_CALCULO,B.NOMBRE,B.SEGUNDO_NOMBRE,B.APELLIDO,B.SEGUNDO_APELLIDO,B.FEC_ALTA,C.NOMBRE AS DEPARTAMENTO FROM TB_AGUINALDO AS A " &
                            " LEFT JOIN TB_EMPLEADO AS B ON A.COD_EMPLEADO= B.CODIGO" &
                            " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON B.COD_DEPART = C.COD_DEPAR" &
                            " WHERE CICLO = '" & ciclo - 1 & "-" & ciclos & "' AND COD_EMPRESA = 1"
        Try
            rp.Load("C:\Plan_rep\nomina.flxr", "comprobante_agui")
            rp.DataSource.ConnectionString = cs.con

            Dim periodo As TextField = DirectCast(rp.Fields("periodo"), TextField)
            periodo.Text = "CORRESPONDIENTE DEL " & fechas.ToString & " Al " & fecha2.ToString
            Dim fec As TextField = DirectCast(rp.Fields("fecha"), TextField)
            fec.Text = fecha
            Dim emp As TextField = DirectCast(rp.Fields("empresa"), TextField)
            emp.Text = nempresa
            rp.DataSource.RecordSource = strsql
            rp.Render()
            Fv.DocumentSource = rp
        Catch ex As Exception
            MsgBox(ex.Message)
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

End Class