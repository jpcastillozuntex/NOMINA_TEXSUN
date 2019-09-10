Imports C1.Win.FlexReport
Public Class FrmComprobantePagobono14
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dtplani As New DataTable
    Dim fecha As Date
    Dim fec_letras As String
    Dim dtfechas As New DataTable
    Dim ciclos As Integer
    Dim fechas As String
    Dim fecha2 As String
    Dim ciclo As String
    Dim empresa As String = FrmInicio.CbEmpresa.SelectedValue
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub FrmComprobantePagobono14_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1080, a - 10)
        Me.Top = a / 2 - (a / 2)
        Me.Left = l / 2 - (1080 / 2)
    End Sub

    Public Sub convierte_fecha(ByVal fecha As Date)
        Dim mes As String
        mes = MonthName(Month(fecha))
        fec_letras = DatePart("d", fecha) & " De " & mes & " del " & Format(fecha, "yyyy")
        fec_letras = UCase(fec_letras)
    End Sub

    Private Sub BtImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtConsultar.Click
        ciclos = DatePart(DateInterval.Year, DatAnio.Value)
        ciclo = ciclos - 1 & "-" & ciclos
        fechas = "01-07-" & ciclos - 1
        fecha2 = "30-06-" & ciclos
        fecha = Format(datfecha.Value, "dd-MM-yyyy")
        convierte_fecha(fecha)
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Cursor = Cursors.WaitCursor
        Dim strsql As String = "SELECT A.*,B.NOMBRE,B.SEGUNDO_NOMBRE,B.APELLIDO,B.SEGUNDO_APELLIDO,B.FEC_ALTA,C.NOMBRE AS DEPARTAMENTO FROM TB_BONO14 AS A" &
                                " LEFT JOIN TB_EMPLEADO AS B ON A.COD_EMPLEADO= B.CODIGO " &
                                " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON B.COD_DEPART = C.COD_DEPAR" &
                                " WHERE CICLO = '" & ciclo & "' AND A.COD_EMPRESA = " & empresa
        Try
            cr.Load("C:\Plan_rep\nomina.flxr", "comprobante_bono_14")
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.RecordSource = strsql
            'cr.Fields("empresa").Text = nempresa
            'cr.Fields("fecha").Text = datfecha.Value
            'cr.Fields("periodo").Text = fechas & " AL " & fecha2
            'cr.Fields("ciclo").Text = " BONO DECRETO 42-92 AÑO " & ciclos


            Dim periodo As TextField = DirectCast(cr.Fields("periodo"), TextField)
            periodo.Text = " BONO DECRETO 42-92 AÑO " & ciclos
            Dim fec As TextField = DirectCast(cr.Fields("fecha"), TextField)
            fec.Text = fecha
            Dim emp As TextField = DirectCast(cr.Fields("empresa"), TextField)
            emp.Text = nempresa

            cr.Render()
            Fv.DocumentSource = cr

        Catch ex As Exception
            MsgBox(ex.Message)
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub


End Class