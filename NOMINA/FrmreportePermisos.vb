Imports C1.C1Report
Imports C1.Win.C1FlexGrid
Imports System.Drawing.Printing
Imports System.Text
Imports System.IO


Public Class FrmreportePermisos

    Inherits System.Windows.Forms.Form
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim cs As New ClsConsultas
    Dim dtdatos As New DataTable
    Dim dtcodigos As New DataTable
    Dim dtcodper As New DataTable
    Dim dtmes As New DataTable
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim mes2 As Integer
    Dim fecha_inic As Date
    Dim fecha_fin As Date
    Dim msj As String
    Dim inicio As Date
    Dim final As Date
    Dim empresa As Integer = FrmInicio.empresa
    'Dim empresa As Integer = 1
    Dim scr As String


    Private Sub FrmreportePermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0

    End Sub

    Private Sub fechas()
        Dim anio2 As Integer
        Dim fec_temp As Date
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        If mes = 12 Then
            mes2 = 1
            anio2 = anio + 1
        Else
            mes2 = mes + 1
            anio2 = anio
        End If
        If ciclo = "1" Then
            fecha_inic = CDate(Format(anio & "-" & mes & "-" & 1))
            fecha_fin = CDate(Format(anio & "-" & mes & "-" & 15))
        ElseIf ciclo = "2" Then
            fecha_inic = CDate(Format(anio & "-" & mes & "-" & 16))
            fec_temp = CDate(Format(anio2 & "-" & mes2 & "-" & 1))
            fecha_fin = fec_temp.AddDays(-1)
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

    Private Sub guarda_pdf()
        fechas()
        Dim f As String = "Del " & fecha_inic & " Al " & fecha_fin
        Try
            rp.Load("C:\Plan_rep\nomina.flxr", "permiso")
            rp.DataSource.ConnectionString = cs.con
            rp.DataSource.RecordSource = "SELECT a.*, B.NOMBRE,B.SEGUNDO_NOMBRE,B.APELLIDO,B.SEGUNDO_APELLIDO,C.NOMBRE AS DEPART,'" & f & "' as fechas,DESCRIPCION FROM TB_PERMISO AS A " &
                        " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO" &
                        " LEFt JOIN TB_DEPTOS_EMPRESA AS C ON b.COD_DEPART = c.COD_DEPAR " &
                        " LEFT JOIN TB_CATPERMISO AS D ON A.COD_PERMISO = D.COD_PERMISO" &
                        " WHERE FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' AND CODIGO_EMPRESA = " & empresa
            rp.Render()
            Fv.DocumentSource = rp

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Btimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImprimir.Click
        guarda_pdf()
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class


