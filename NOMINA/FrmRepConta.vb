Imports C1.C1Report
Imports C1.Win.C1FlexGrid

Public Class FrmRepConta
    Dim scr As String
    Dim cs As New ClsConsultas
    Dim dt As New DataTable
    Dim dtmes As New DataTable
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width


    Private Sub FrmRepConta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\reporte.xls", FileIO.UIOption.AllDialogs, _
               FileIO.RecycleOption.SendToRecycleBin, _
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try
        Try
            fg.SaveGrid("C:\Plan_rep\" & "reporte.xls", C1.Win.C1FlexGrid.FileFormatEnum.Excel, FileFlags.AsDisplayed + FileFlags.IncludeMergedRanges + FileFlags.LoadMergedRanges)
            Dim pathPDF As String = "C:\Plan_rep\reporte.xls"
            Process.Start(pathPDF)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtCierra_Click(sender As System.Object, e As System.EventArgs) Handles Btbuscar.Click
        Dim anio As Integer = Format(DatAnio.Value, "yyyy")
        Dim mes As Integer = Cbmes.SelectedValue
        Dim BON As Double
        Dim BON_LEY As Double
        scr = "SELECT C.NOMBRE AS DEPARTAMENTO,A.CODIGO,B.NOMBRE+' '+ B.SEGUNDO_NOMBRE+' '+B.APELLIDO+' '+B.SEGUNDO_APELLIDO AS NOMBRE ,D.NOMBRE_PUESTO,SUM(DIAS)AS DIAS,SUM(ORDINARIO+asueto)AS ORDIN,SUM(A.BONIFICACION+bon_prod) AS BONIFICACION ,b.BONIFICACION as bon_ley," &
                " sum(HORAS+isnull(horas_n,0)) AS HORAS,sum(VACACIONES)AS VAC,SUM(ORDINARIO+HORAS+horas_n+A.BONIFICACION+VACACIONES+ASUETO) AS TOTAL,'Banco Industrial' AS BANCO,E.NOMBRE AS EMP_PAGA,'NOMINA' AS TIPO, a.centro_costo" &
                " FROM TB_NOMINA AS A" &
                " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND A.COD_EMPRESA = B.CODIGO_EMPRESA" &
                " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON B.COD_DEPART = C.COD_DEPAR" &
                " LEFT JOIN TB_PUESTOS AS D ON B.CODIGO_PUESTO =D.CODIGO" &
                " LEFT JOIN TB_EMP_PAGA AS E ON B.EMP_PAGA = E.CODIGO" &
                " WHERE ANIO = " & anio & " And MES =" & mes &
                " GROUP BY A.CODIGO,C.NOMBRE,B.NOMBRE,B.SEGUNDO_NOMBRE,B.APELLIDO,B.SEGUNDO_APELLIDO,D.NOMBRE_PUESTO,E.NOMBRE,b.bonificacion,a.centro_costo"
        If cs.consultas(scr, dt, msj) Then
            For i = 0 To dt.Rows.Count - 1
                BON = dt.Rows(i)("BONIFICACION") - dt.Rows(i)("bon_ley")
                BON_LEY = dt.Rows(i)("bon_ley")
                If BON < 0 Then
                    BON_LEY = dt.Rows(i)("BONIFICACION")
                    BON = 0
                Else
                    BON = dt.Rows(i)("BONIFICACION") - dt.Rows(i)("bon_ley")
                    BON_LEY = dt.Rows(i)("bon_ley")
                End If
                fg.Rows.Count = dt.Rows.Count + 3
                fg(i + 1, 1) = dt.Rows(i)("DEPARTAMENTO")
                fg(i + 1, 2) = dt.Rows(i)("CODIGO")
                fg(i + 1, 3) = dt.Rows(i)("NOMBRE")
                fg(i + 1, 4) = dt.Rows(i)("NOMBRE_PUESTO")
                fg(i + 1, 5) = (dt.Rows(i)("ORDIN") * 0.16) + (dt.Rows(i)("ORDIN") + dt.Rows(i)("HORAS")) * 0.2239
                fg(i + 1, 6) = dt.Rows(i)("DIAS")
                fg(i + 1, 7) = dt.Rows(i)("ORDIN")
                fg(i + 1, 8) = BON
                fg(i + 1, 9) = BON_LEY
                fg(i + 1, 10) = dt.Rows(i)("HORAS")
                fg(i + 1, 11) = dt.Rows(i)("VAC")
                fg(i + 1, 12) = dt.Rows(i)("TOTAL")
                fg(i + 1, 13) = dt.Rows(i)("BANCO")
                fg(i + 1, 14) = dt.Rows(i)("EMP_PAGA")
                fg(i + 1, 15) = dt.Rows(i)("TIPO")
                fg(i + 1, 16) = dt.Rows(i)("CENTRO_COSTO")
            Next
        End If
    End Sub

    Private Sub Combo_box_Mes()
        Dim mes As Integer
        mes = Date.Now.Month
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtmes, msj)
        Cbmes.DataSource = dtmes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
        Cbmes.SelectedIndex = mes - 1
    End Sub

End Class