Imports System.Text
Imports System.IO

Public Class FrmFaltas
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim cs As New ClsConsultas
    Dim dt_ciclo As New DataTable
    Dim scr As String
    Dim msj As String
    Dim dtMes As New DataTable
    Dim dtfechas As New DataTable
    Dim dtfinal As New DataTable
    Dim mes As Integer
    Dim anio As Integer
    Dim ciclo As Integer
    Dim mes2 As Integer
    Dim fecha_inic As Date
    Dim fecha_fin As Date
    Dim fec_tem As Date
    Dim empresa As Integer = 1
    'Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim log As StringBuilder

    Private Sub FrmPermiso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - (631 / 2)
        Me.Left = l / 2 - (1085 / 2)
        BtRegresar.Visible = False
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
        TxtCodigo.Enabled = False
        BtBuscar.Enabled = False
        GroupBox1.Enabled = False
        BtGuardar.Enabled = False
        fg.Rows.Count = 2
        fg.Rows(0).Height = 45
        fg.Rows(1).Height = 45
        creat_tabla()
    End Sub

    Private Sub fechas()
        Dim anio2 As Integer
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        mes2 = mes
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
            fec_tem = CDate(Format(anio2 & "-" & mes2 & "-" & 1))
            fecha_fin = fec_tem.AddDays(-1)
        End If
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        Dim fec_temps As Date = fecha_inic
        Dim dias As Integer
        mes = Cbmes.SelectedValue
        anio = Format(DatAnio.Value, "yyyy")
        scr = "SELECT * FROM TB_CICLO_NOMINA WHERE MES = " & mes & " AND ANIO = " & anio & " AND QUINCENA = " & CbCiclo.Text
        cs.consultas(scr, dt_ciclo, msj)
        fechas()
        fec_temps = fecha_inic
        If dt_ciclo.Rows.Count > 0 Then
            If dt_ciclo.Rows(0)("ESTADO") = "C" Then
                GroupBox1.Enabled = False
            Else
                GroupBox1.Enabled = True
            End If
            BtRegresar.Visible = True
            DatAnio.Enabled = False
            Cbmes.Enabled = False
            CbCiclo.Enabled = False
            TxtCodigo.Enabled = True
            BtBuscar.Enabled = True
            '            BtGuardar.Enabled = True
            dias = DateDiff(DateInterval.Day, fecha_inic, fecha_fin)
            For i = 1 To dias + 1
                fg(0, i) = Format(fec_temps, "dd-MM") & Chr(10) & Format(fec_temps, "ddd")
                fec_temps = fec_temps.AddDays(1)
            Next
        End If
    End Sub

    Private Sub BtRegresar_Click(sender As System.Object, e As System.EventArgs) Handles BtRegresar.Click
        BtRegresar.Visible = False
        DatAnio.Enabled = True
        Cbmes.Enabled = True
        CbCiclo.Enabled = True
        TxtCodigo.Enabled = False
        BtBuscar.Enabled = False
        GroupBox1.Enabled = False
        BtGuardar.Enabled = False
        Limpiar_TextBox(Me)
        Limpiar(Me.GroupBox1)

    End Sub

    Private Sub Combo_box_Mes()
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
        Cbmes.SelectedIndex = Date.Now.Month - 1
    End Sub

    Private Sub BtBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtBuscar.Click
        limpia_fg()
        dtfinal.Clear()
        scr = "SELECT A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,C.NOMBRE AS DEPTO,B.FECHA,A.MARCA,A.ESTADO_EMPLEADO,A.FEC_ALTA,B.COMENT FROM TB_EMPLEADO AS A " & _
            " LEFT JOIN TB_FALTA AS B ON A.CODIGO = B.CODIGO AND A.CODIGO_EMPRESA = B.COD_EMPRESA AND FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "'" & _
            " LEFT JOIN TB_DEPTOS_EMPRESA  AS C ON A.COD_DEPART = C.COD_DEPAR " & _
            " WHERE A.CODIGO = " & TxtCodigo.Text & ""
        cs.consultas(scr, dtfechas, msj)
        If dtfechas.Rows.Count = 0 Then
            mensajes.Text = "CODIGO NO EXISTE"
        Else
            fec_tem = fecha_inic
            If dtfechas.Rows(0)("ESTADO_EMPLEADO") = "B" Or dtfechas.Rows(0)("ESTADO_EMPLEADO") = "S" Then
                mensajes.Text = "EMPLEADO DE BAJA O SUSPENDIDO"
                GroupBox1.Enabled = False
            Else
                GroupBox1.Enabled = True
            End If
            If dtfechas.Rows(0)("MARCA") = "N" Then
                BtGuardar.Enabled = True
                mensajes.Text = ""
                cs.consultas(scr, dtfechas, msj)
                TxtDepartamento.Text = dtfechas.Rows(0)("DEPTO")
                TxtNombre.Text = dtfechas.Rows(0)("NOMBRE")
                Txt2Nombre.Text = dtfechas.Rows(0)("SEGUNDO_NOMBRE")
                TxtApellido.Text = dtfechas.Rows(0)("APELLIDO")
                Txt2Apellido.Text = dtfechas.Rows(0)("SEGUNDO_APELLIDO")
                TxtFecalta.Text = dtfechas.Rows(0)("FEC_ALTA")
                For I = 1 To 16
                    Dim dd() As DataRow
                    dd = dtfechas.Select("fecha = '" & fec_tem & "'")
                    If dd.Length > 0 Then
                        fg(1, I) = True
                    End If
                    fec_tem = fec_tem.AddDays(1)
                Next
            ElseIf dtfechas.Rows(0)("MARCA") = "S" Then
                mensajes.Text = "EMPLEASO SI MARCA"
                BtGuardar.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        Dim dias_sin_guardar As String = ""
        Dim dia As Integer
        dtfinal.Clear()
        fec_tem = fecha_inic
        For i = 1 To 16
            Dim dtr As DataRow = dtfinal.NewRow
            dia = fec_tem.DayOfWeek
            If fg(1, i) Then
                dtr("CODIGO") = TxtCodigo.Text
                    dtr("EMPRESA") = empresa
                    dtr("FECHA") = Format(fec_tem, "yyyy-MM-dd")
                    dtr("COMENT") = empresa
                    dtfinal.Rows.Add(dtr)
                    dtfinal.AcceptChanges()
            End If
            fec_tem = fec_tem.AddDays(1)
        Next
        If cs.gurda_faltas(dt_ciclo.Rows(0)("inicio"), dt_ciclo.Rows(0)("fin"), dtfinal, msj) = False Then

            MsgBox(msj)
        Else
            mensajes.Text = "DATOS GUARDADOS"
            Limpiar(Me.GroupBox1)
            Limpiar_TextBox(Me)
            BtGuardar.Enabled = False
        End If
    End Sub

    Private Sub creat_tabla()
        dtfinal.Columns.Add("CODIGO")
        dtfinal.Columns.Add("EMPRESA")
        dtfinal.Columns.Add("FECHA")
        dtfinal.Columns.Add("COMENT")
        dtfinal.AcceptChanges()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub limpia_fg()
        For i = 0 To 16
            fg(1, i) = False
        Next
    End Sub

    Public Sub Limpiar_TextBox(ByVal formulario As Form)
        For Each control As Control In formulario.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
            End If
        Next
        For i = 0 To 16
            fg(1, i) = False
        Next
        BtGuardar.Enabled = False
    End Sub

    Public Sub Limpiar(ByVal Grupo As Windows.Forms.GroupBox)
        Dim miControl As Object
        For Each miControl In Grupo.Controls
            If miControl.GetType Is GetType(System.Windows.Forms.TextBox) Then
                miControl.Clear()
            End If
            Application.DoEvents()
        Next
    End Sub


    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class