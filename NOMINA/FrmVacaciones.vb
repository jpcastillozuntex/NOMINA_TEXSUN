Imports System.Text
Imports System.IO

Public Class FrmVacaciones
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
    Dim dt_ciclos As New DataTable
    'Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim empresa As Integer = 1
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
            BtGuardar.Enabled = True
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

    Private Sub Cb_anio_vacas()
        scr = "SELECT CICLO FROM TB_VACACIONES WHERE CODIGO = " & TxtCodigo.Text & " AND  ESTADO = 'N' AND COD_EMPRESA = " & empresa
        If cs.consultas(scr, dt_ciclos, msj) Then
            CbCiclos.DataSource = dt_ciclos
            CbCiclos.ValueMember = "ciclo"
            CbCiclos.DisplayMember = "ciclo"
        End If
    End Sub

    Private Sub BtBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtBuscar.Click
        'Cb_anio_vacas()
        Dim cant As New DataTable
        limpia_fg()
        dtfinal.Clear()
        scr = "select a.*,b.NOMBRE as depto  from tb_empleado as a left join TB_DEPTOS_EMPRESA as b on a.COD_DEPART= b.COD_DEPAR" & _
          " where codigo = " & TxtCodigo.Text
        cs.consultas(scr, cant, msj)

        scr = "SELECT A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,C.NOMBRE AS DEPTO,B.FECHA,A.MARCA,A.ESTADO_EMPLEADO,A.FEC_ALTA,CICLO,B.CODIGO,B.COD_EMPRESA FROM TB_EMPLEADO AS A " & _
            " LEFT JOIN TB_VACAc AS B ON A.CODIGO = B.CODIGO AND A.CODIGO_EMPRESA = B.COD_EMPRESA AND FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "'" & _
            " LEFT JOIN TB_DEPTOS_EMPRESA  AS C ON A.COD_DEPART = C.COD_DEPAR " & _
            " WHERE A.CODIGO = " & TxtCodigo.Text & " and ciclo = " & CbCiclos.SelectedValue
        cs.consultas(scr, dtfechas, msj)
        If dtfechas.Rows.Count = 0 Then
            If cant.Rows.Count = 0 Then
                mensajes.Text = "CODIGO NO EXISTE"
            Else
                mensajes.Text = "NO HAY DIAS DE VACACIONES PARA ESTA QUINCENA"
            End If
        End If
        If cant.Rows.Count > 0 Then
            fec_tem = fecha_inic
            If cant.Rows(0)("ESTADO_EMPLEADO") = "B" Or cant.Rows(0)("ESTADO_EMPLEADO") = "S" Then
                mensajes.Text = "EMPLEADO DE BAJA O SUSPENDIDO"
                GroupBox1.Enabled = False
            Else
                GroupBox1.Enabled = True
                mensajes.Text = ""
                TxtDepartamento.Text = cant.Rows(0)("DEPTO")
                TxtNombre.Text = cant.Rows(0)("NOMBRE")
                Txt2Nombre.Text = cant.Rows(0)("SEGUNDO_NOMBRE")
                TxtApellido.Text = cant.Rows(0)("APELLIDO")
                Txt2Apellido.Text = cant.Rows(0)("SEGUNDO_APELLIDO")
                TxtFecalta.Text = cant.Rows(0)("FEC_ALTA")
                For I = 1 To 16
                    Dim dd() As DataRow
                    dd = dtfechas.Select("fecha = '" & fec_tem & "'")
                    If dd.Length > 0 Then
                        fg(1, I) = True
                    End If
                    fec_tem = fec_tem.AddDays(1)
                Next
            End If
        End If
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        dtfinal.Clear()
        fec_tem = fecha_inic
        If CbCiclos.SelectedValue Is Nothing Then
            MsgBox("NO TIENE CICLO, DEBE CRORRER CALCULO DE VACACIONES ANTES DE INGRESAR VACACIONES")
        Else
            For i = 1 To 16
                Dim dtr As DataRow = dtfinal.NewRow
                If fg(1, i) Then
                    dtr("CODIGO") = TxtCodigo.Text
                    dtr("EMPRESA") = empresa
                    dtr("FECHA") = Format(fec_tem, "yyyy-MM-dd")
                    dtr("CICLO") = CbCiclos.SelectedValue
                    dtfinal.Rows.Add(dtr)
                    dtfinal.AcceptChanges()
                End If
                fec_tem = fec_tem.AddDays(1)
            Next
        End If
        If cs.gurda_vacas(dtfinal, msj, dtfechas) = False Then
            'MsgBox(msj)
        Else
            mensajes.Text = "DATOS GUARDADOS."
        End If
    End Sub

    Private Sub creat_tabla()
        dtfinal.Columns.Add("CODIGO")
        dtfinal.Columns.Add("EMPRESA")
        dtfinal.Columns.Add("FECHA")
        dtfinal.Columns.Add("CICLO")
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

    Private Sub TxtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged
        scr = "SELECT DISTINCT(CICLO) FROM TB_VACACIONES WHERE CODIGO = " & TxtCodigo.Text
        If cs.consultas(scr, dt_ciclos, msj) Then
            CbCiclos.DataSource = dt_ciclos
            CbCiclos.ValueMember = "ciclo"
            CbCiclos.DisplayMember = "ciclo"
        End If
    End Sub

End Class