Imports System.IO
Imports System.Text
Public Class FrmAguinaldo
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim scr As String
    Dim f As String = "yyyy"
    Dim dtmontos As New DataTable
    Dim dtfinal As New DataTable
    Dim dtsueldos As New DataTable
    Dim monto As Decimal
    'Dim monto_tot As Decimal
    Dim dias As Integer
    Dim fec_alta As Date
    Dim fecha As Date
    Dim dias_habi As Integer
    Dim fec_inic As Date
    Dim fec_alta1 As Date
    Dim fec_fin As Date
    Dim anio As String
    Dim anioantes As Integer
    Dim CarpetaLog As String = "\Plan_rep\"
    Dim RutaDir As String = "c:"
    Dim arch As New StringBuilder
    Dim arch2 As New StringBuilder
    Dim script As String
    Dim scrcheque As String
    'Dim numero As Integer
    Dim ciclos_concsulta As String
    Dim dtarchiv As New DataTable
    Dim ciclos As Integer
    Dim dttotal_d_c As New DataTable
    Dim registros As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa As Integer = 1
    'Dim empresa = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmBono14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1082, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        dtfinal.Columns.Add("codigo")
        dtfinal.Columns.Add("cod_empresa")
        dtfinal.Columns.Add("monto")
        dtfinal.Columns.Add("ciclo")
        dtfinal.Columns.Add("dias_cal")
        dtfinal.Columns.Add("fec_alta")
    End Sub

    Private Sub Btejecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btejecutar.Click
        dtmontos.Clear()
        dtfinal.Clear()
        dtsueldos.Clear()
        arch.Clear()
        arch2.Clear()
        anio = Format(datanio.Value, f)
        anioantes = Format(datanio.Value, f) - 1
        ciclos_concsulta = anioantes & "-" & anio
        scr = "SELECT COUNT(1) FROM TB_AGUINALDO WHERE CICLO = '" & ciclos_concsulta & "' AND COD_EMPRESA = " & empresa
        If cs.csescalar(registros, scr, msj) Then
            If registros > 0 Then
                cargapdf()
            Else
                scr = "SELECT A.CODIGO,SUM(ORDINARIO)/SUM(DIAS)AS SUELDO, sum(dias)as dias FROM TB_NOMINA AS A  INNER join TB_CICLO_NOMINA AS B ON A.ANIO = B.ANIO AND A.MES = B.MES AND A.QUINCENA = B.QUINCENA AND B.FECHA BETWEEN '" & anioantes & "-12-01' AND '" & anio & "-11-30' WHERE CODIGO IN (SELECT  CODIGO FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('A','S')) AND A.COD_EMPRESA = 1 GROUP BY A.CODIGO"
                If cs.consultas(scr, dtmontos, msj) Then
                    scr = "SELECT FEC_ALTA,CODIGO,SUELDO_BASE FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('A','S') AND CODIGO_EMPRESA = " & empresa & "and FEC_ALTA < '" & anio & "-12-01'"
                    If cs.consultas(scr, dtsueldos, msj) Then
                        For i = 0 To dtsueldos.Rows.Count - 1
                            Dim dd() As DataRow
                            dd = dtmontos.Select("codigo = " & dtsueldos.Rows(i)("codigo"))
                            If dd.Length > 0 Then
                                dias = dd(0)("dias")
                                'If dias > 365 Then
                                ' dias = 365
                                'End If
                                monto = dtmontos.Rows(i)("sueldo") * 30 / 365
                                fec_inic = CDate(anioantes & "-11-30")
                                fec_alta = dtsueldos.Rows(i)("fec_alta")
                                fec_fin = CDate(anio & "-11-30")
                                If fec_alta > fec_inic Then
                                    fec_inic = fec_alta
                                End If
                                dias_habi = DateDiff(DateInterval.Day, fec_inic, fec_fin)
                                If dias_habi < 365 Then
                                    dias_habi = dias_habi + 1
                                ElseIf dias_habi > 365 Then
                                    dias_habi = 365
                                End If
                                Dim row As DataRow = dtfinal.NewRow
                                row("codigo") = dtsueldos.Rows(i)("codigo")
                                row("cod_empresa") = empresa
                                row("monto") = monto * dias_habi
                                row("ciclo") = anioantes & "-" & anio
                                row("dias_cal") = dias_habi
                                row("fec_alta") = Format(Now(), "yyyy-MM-dd")
                                dtfinal.Rows.Add(row)
                                dtfinal.AcceptChanges()
                            End If
                        Next
                    End If
                End If
                If cs.Aguinaldo(dtfinal, msj) Then
                    cargapdf()
                End If
            End If
        Else
            MsgBox(msj)
        End If
        crea_archivos()
    End Sub

    Sub cargapdf()
        ciclos = DatePart(DateInterval.Year, datanio.Value)
        ciclos_concsulta = ciclos - 1 & "-" & ciclos
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Cursor = Cursors.WaitCursor
        Dim strsql As String = "select a.COD_EMPLEADO,b.nombre,b.segundo_nombre,b.apellido,b.segundo_apellido,b.fec_alta,a.*,c.NOMBRE as nombre_depart  from TB_AGUINALDO as a" & _
                                " left join TB_EMPLEADO as b on a.COD_EMPLEADO = b.codigo and a.COD_EMPRESA = b.codigo_empresa" & _
                                " left join TB_DEPTOS_EMPRESA as c on b.COD_DEPART = c.COD_DEPAR" & _
                                " where a.COD_EMPRESA = " & empresa & " and a.CICLO = '" & ciclos_concsulta & "'"
        Try
            Cursor = Cursors.WaitCursor
            flex_Report.Load("C:\Plan_rep\nomina.xml", "aguinaldo")
            flex_Report.DataSource.ConnectionString = cs.con
            ' flex_Report.Fields("empresa").Text = nempresa
            ' flex_Report.Fields("ciclo").Text = "AGUINALDO AÑO " & ciclos
            ' flex_Report.Fields("fecha").Text = Format(Today, "yyyy-MM-dd")
            flex_Report.DataSource.RecordSource = strsql
            flex_Report.Render()
            pp.Document = flex_Report
            pp.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
        totales()
    End Sub

    Private Sub GrabarLog(ByVal script As String, ByVal arch As StringBuilder)
        Dim Texto As String = String.Concat(script)
        arch.AppendLine(Texto)
    End Sub

    Private Sub GrabarLog1(ByVal script As String, ByVal arch As StringBuilder)
        Dim Texto As String = String.Concat(script)
        arch.AppendLine(Texto)
    End Sub

    Private Sub CerrarLog(ByVal archivo As String, ByVal arch As StringBuilder)
        anio = Format(datanio.Value, f)
        If File.Exists(RutaDir & CarpetaLog & "AGUINALDO_NOM_" & anio & "_" & archivo & ".txt") Then
            My.Computer.FileSystem.DeleteFile(RutaDir & CarpetaLog & "AGUINALDO_NOM_" & anio & "_" & archivo & ".txt")
        End If
        Try
            Dim Escritor As TextWriter = New StreamWriter(RutaDir & CarpetaLog & "AGUINALDO_NOM_" & anio & "_" & archivo & ".txt", True)
            Escritor.WriteLine(arch.ToString)
            Escritor.Close()
        Catch ex As Exception
            EventLog.WriteEntry("MonitorServicio", "Error: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub crea_archivos()
        anio = Format(datanio.Value, f)
        Cursor = Cursors.WaitCursor
        ciclos = DatePart(DateInterval.Year, datanio.Value)
        ciclos_concsulta = ciclos - 1 & "-" & ciclos
        scr = "select codigo,nombre, segundo_nombre, apellido, segundo_apellido, num_cuenta,tipo_pago,monto from TB_EMPLEADO as a, TB_AGUINALDO as b" & _
                " where a.codigo = b.cod_empleado" & _
                " and codigo_empresa = " & empresa & _
                " and Codigo_empresa = cod_empresa" & _
                " and ciclo = '" & ciclos_concsulta & "'"
        If cs.consultas(scr, dtarchiv, msj) Then

            For i = 0 To dtarchiv.Rows.Count - 1
                If dtarchiv.Rows(i)("tipo_pago") = "D" Then
                    script = dtarchiv.Rows(i)("codigo") & "," & dtarchiv.Rows(i)("num_cuenta") & "," & Chr(9) & dtarchiv.Rows(i)("nombre") & " " & dtarchiv.Rows(i)("segundo_nombre") & " " & dtarchiv.Rows(i)("apellido") & " " & dtarchiv.Rows(i)("segundo_apellido") & "," & Chr(9) & dtarchiv.Rows(i)("monto") & "," & "Aguinaldo " & anio
                    GrabarLog(script, arch)
                End If
                If dtarchiv.Rows(i)("tipo_pago") = "C" Then
                    scrcheque = dtarchiv.Rows(i)("codigo") & ", " & dtarchiv.Rows(i)("nombre") & " " & dtarchiv.Rows(i)("segundo_nombre") & " " & dtarchiv.Rows(i)("apellido") & " " & dtarchiv.Rows(i)("segundo_apellido") & "," & dtarchiv.Rows(i)("monto") & "," & Format(Today, "yyyy-MM-dd") & "," & "Aguinaldo" & anio & "-" & anioantes
                    GrabarLog1(scrcheque, arch2)
                End If
            Next
            Dim c As String = "CHEQUE"
            Dim d As String = "DEPOSITO"
            CerrarLog(d, arch)
            CerrarLog(c, arch2)
            MsgBox("ARCHIVO CREADO EN C:\Plan_rep")
        End If
        totales()
        Cursor = Cursors.Default
    End Sub

    Private Sub totales()
        ciclos = DatePart(DateInterval.Year, datanio.Value)
        ciclos_concsulta = ciclos - 1 & "-" & ciclos
        scr = " select tipo_pago,sum(monto)as monto from TB_EMPLEADO as a, TB_aguinaldo as b where a.codigo = b.cod_empleado and codigo_empresa = " & empresa & _
                " and Codigo_empresa = cod_empresa and ciclo = '" & ciclos_concsulta & "'" & _
                " group by tipo_pago"
        If cs.consultas(scr, dttotal_d_c, msj) Then
            Txtcheques.Text = dttotal_d_c.Rows(0)("monto")
            TxtDeposito.Text = dttotal_d_c.Rows(1)("monto")
        End If
    End Sub

    Private Sub BtTotales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnResumen.Click
        ciclos = DatePart(DateInterval.Year, datanio.Value)
        ciclos_concsulta = ciclos - 1 & "-" & ciclos
        Cursor = Cursors.WaitCursor
        Dim strsql As String = "SELECT SUM(MONTO) AS MONTO,C.NOMBRE,COD_EMPRESA FROM TB_AGUINALDO AS A" & _
                " LEFT JOIN TB_EMPLEADO AS B ON A.COD_EMPLEADO = B.CODIGO" & _
                " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON B.COD_DEPART = C.COD_DEPAR" & _
                " WHERE A.CICLO = '" & ciclos_concsulta & "'  AND COD_EMPRESA = " & empresa & _
                " GROUP BY C.NOMBRE, COD_EMPRESA"
        Try
            flex_Report.Load("C:\Plan_rep\nomina.xml", "totales_aguinaldo")
            flex_Report.DataSource.ConnectionString = cs.con
            ''flex_Report.Fields("ciclo").Text = "AGUINALDO DEL CICLO" & ciclos
            flex_Report.DataSource.RecordSource = strsql
            flex_Report.Render()
            pp.Document = flex_Report
            pp.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
        totales()
    End Sub

End Class
