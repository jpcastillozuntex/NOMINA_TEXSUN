Imports System.IO
Imports System.Text
Imports C1.Win.FlexReport
Public Class FrmBono14
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
    'Dim empresa As Integer = 1
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmBono14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(Me.l, a)
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
        Dim monto_fin As Decimal
        dtmontos.Clear()
        dtfinal.Clear()
        dtsueldos.Clear()
        arch.Clear()
        arch2.Clear()
        anio = Format(datanio.Value, f)
        anioantes = Format(datanio.Value, f) - 1
        ciclos_concsulta = anioantes & "-" & anio
        scr = "SELECT COUNT(1) FROM TB_BONO14 WHERE CICLO = '" & ciclos_concsulta & "' AND COD_EMPRESA = " & empresa
        If cs.csescalar(registros, scr, msj) Then
            If registros > 0 Then
                cargapdf()
            Else
                scr = "SELECT A.CODIGO,SUM(DIAS)AS DIAS,sum(ORDINARIO)as ordinario FROM TB_NOMINA AS A " & _
                      " INNER join TB_CICLO_NOMINA AS B ON A.ANIO = B.ANIO AND A.MES = B.MES AND A.QUINCENA = B.QUINCENA AND B.FECHA BETWEEN '" & anioantes & "-07-01' AND '" & anio & "-07-01'" & _
                      " WHERE CODIGO IN (SELECT  CODIGO FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('A','S')) AND A.COD_EMPRESA = " & empresa & _
                      " GROUP BY A.CODIGO"
                If cs.consultas(scr, dtmontos, msj) Then
                    scr = "SELECT FEC_ALTA,CODIGO,SUELDO_BASE FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('A','S') AND CODIGO_EMPRESA = " & empresa & " and  FEC_ALTA < '" & anio & "-06-30'"
                    If cs.consultas(scr, dtsueldos, msj) Then
                        For i = 0 To dtsueldos.Rows.Count - 1
                            monto = 0
                            monto_fin = 0
                            Dim dd() As DataRow
                            dd = dtmontos.Select("codigo = " & dtsueldos.Rows(i)("codigo"))
                            If dd.Length > 0 Then
                                dias = dd(0)("dias")
                                If dias > 365 Then
                                    dias = 365
                                End If
                                monto = dtmontos.Rows(i)("ordinario") / dias
                                fec_inic = CDate(anioantes & "-07-01")
                                fec_alta = dtsueldos.Rows(i)("fec_alta")
                                fec_fin = CDate(anio & "-07-01")
                                If fec_alta > fec_inic Then
                                    fec_inic = fec_alta
                                End If

                                dias_habi = DateDiff(DateInterval.Day, fec_inic, fec_fin)
                                If dias_habi >= 365 Then
                                    monto_fin = monto * 30
                                ElseIf dias_habi <= 365 Then
                                    monto_fin = ((monto * 30) / 365) * dias_habi
                                End If
                                Dim row As DataRow = dtfinal.NewRow
                                row("codigo") = dtsueldos.Rows(i)("codigo")
                                row("cod_empresa") = empresa
                                row("monto") = monto_fin
                                row("ciclo") = anioantes & "-" & anio
                                row("dias_cal") = dias_habi
                                row("fec_alta") = Format(Now(), "yyyy-MM-dd")
                                dtfinal.Rows.Add(row)
                                dtfinal.AcceptChanges()
                            End If
                        Next
                    End If
                End If
                If cs.bono14(dtfinal, msj) Then
                    cargapdf()

                End If
            End If
        End If
        crea_archivos()
    End Sub

    Sub cargapdf()
        ciclos = DatePart(DateInterval.Year, datanio.Value)
        ciclos_concsulta = ciclos - 1 & "-" & ciclos
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Cursor = Cursors.WaitCursor
        Dim strsql As String = "select a.COD_EMPLEADO,b.nombre,b.segundo_nombre,b.apellido,b.segundo_apellido,b.fec_alta,a.*,c.NOMBRE as nombre_depart  from TB_BONO14 as a" & _
                                " left join TB_EMPLEADO as b on a.COD_EMPLEADO = b.codigo and a.COD_EMPRESA = b.codigo_empresa" & _
                                " left join TB_DEPTOS_EMPRESA as c on b.COD_DEPART = c.COD_DEPAR" & _
                                " where a.COD_EMPRESA = " & empresa & " and a.CICLO = '" & ciclos_concsulta & "'"
        Try
            Cursor = Cursors.WaitCursor
            rp.Load("C:\Plan_rep\nomina.flxr", "bono14")
            rp.DataSource.ConnectionString = cs.con
            Dim emp As TextField = DirectCast(rp.Fields("empresa"), TextField)
            emp.Text = empresa.ToString
            Dim ciclo As TextField = DirectCast(rp.Fields("ciclo"), TextField)
            ciclo.Text = " BONO DECRETO 42-92 AÑO " & ciclos.ToString
            Dim fecha As TextField = DirectCast(rp.Fields("fecha"), TextField)
            fecha.Text = Format(Today, "yyyy-MM-dd").ToString
            rp.DataSource.RecordSource = strsql
            rp.Render()
            Fv.DocumentSource = rp
            Fv.Refresh()
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
        If File.Exists(RutaDir & CarpetaLog & "BONO14_NOMINA" & anio & "_" & archivo & ".txt") Then
            My.Computer.FileSystem.DeleteFile(RutaDir & CarpetaLog & "BONO14_NOMINA" & anio & "_" & archivo & ".txt")
        End If
        Try
            Dim Escritor As TextWriter = New StreamWriter(RutaDir & CarpetaLog & "BONO14_NOMINA" & anio & "_" & archivo & ".txt", True)
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
        scr = "select codigo,nombre, segundo_nombre, apellido, segundo_apellido, num_cuenta,tipo_pago,monto_bono from TB_EMPLEADO as a, TB_BONO14 as b" & _
                " where a.codigo = b.cod_empleado" & _
                " and codigo_empresa = " & empresa & _
                " and Codigo_empresa = cod_empresa" & _
                " and ciclo = '" & ciclos_concsulta & "'"
        If cs.consultas(scr, dtarchiv, msj) Then

            For i = 0 To dtarchiv.Rows.Count - 1
                If dtarchiv.Rows(i)("tipo_pago") = "D" Then
                    script = dtarchiv.Rows(i)("codigo") & "," & dtarchiv.Rows(i)("num_cuenta") & "," & Chr(9) & dtarchiv.Rows(i)("nombre") & " " & dtarchiv.Rows(i)("segundo_nombre") & " " & dtarchiv.Rows(i)("apellido") & " " & dtarchiv.Rows(i)("segundo_apellido") & "," & Chr(9) & dtarchiv.Rows(i)("monto_bono") & "," & "Bono 14 periodo " & anio
                    GrabarLog(script, arch)
                End If
                If dtarchiv.Rows(i)("tipo_pago") = "C" Then
                    scrcheque = dtarchiv.Rows(i)("codigo") & ", " & dtarchiv.Rows(i)("nombre") & " " & dtarchiv.Rows(i)("segundo_nombre") & " " & dtarchiv.Rows(i)("apellido") & " " & dtarchiv.Rows(i)("segundo_apellido") & "," & dtarchiv.Rows(i)("monto_bono") & "," & Format(Today, "yyyy-MM-dd") & "," & "bono 14 ciclo" & anio & "-" & anioantes
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
        scr = " select tipo_pago,sum(monto_bono)as monto from TB_EMPLEADO as a, TB_BONO14 as b where a.codigo = b.cod_empleado and codigo_empresa = " & empresa & _
                " and Codigo_empresa = cod_empresa and ciclo = '" & ciclos_concsulta & "'" & _
                " group by tipo_pago"
        If cs.consultas(scr, dttotal_d_c, msj) Then
            Txtcheques.Text = dttotal_d_c.Rows(0)("monto")
            TxtDeposito.Text = dttotal_d_c.Rows(1)("monto")
        End If
    End Sub

    Private Sub BtTotales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtTotales.Click
        ciclos = DatePart(DateInterval.Year, datanio.Value)
        ciclos_concsulta = ciclos - 1 & "-" & ciclos
        Cursor = Cursors.WaitCursor
        Dim strsql As String = "SELECT SUM(MONTO_BONO) AS MONTO,C.NOMBRE,COD_EMPRESA FROM TB_BONO14 AS A" & _
                " LEFT JOIN TB_EMPLEADO AS B ON A.COD_EMPLEADO = B.CODIGO" & _
                " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON B.COD_DEPART = C.COD_DEPAR" & _
                " WHERE A.CICLO = '" & ciclos_concsulta & "'  AND COD_EMPRESA = " & empresa & _
                " GROUP BY C.NOMBRE, COD_EMPRESA"
        Try
            rp.Load("C:\Plan_rep\nomina.flxr", "totales_bono")
            rp.DataSource.ConnectionString = cs.con
            Dim ciclo As TextField = DirectCast(rp.Fields("ciclo"), TextField)
            ciclo.Text = " BONO DECRETO 42-92 AÑO " & ciclos
            rp.DataSource.RecordSource = strsql
            rp.Render()
            Fv.DocumentSource = rp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
        totales()
    End Sub

End Class