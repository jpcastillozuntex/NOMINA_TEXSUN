

Public Class FrmIngHoras
    Dim cs As New ClsConsultas
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim scr As String
    Dim dtmes As New DataTable
    Dim dtfechas As New DataTable
    Dim dthoras As New DataTable
    Dim msj As String
    Dim dt_depto As New DataTable
    Dim dt_horass As New DataTable

    Private Sub BtConsultar_Click(sender As Object, e As EventArgs) Handles BtConsultar.Click
        scr = "select * from TB_CICLO_NOMINA where anio = " & Format(DatAnio.Value, "yyyy") & " and mes = " & Cbmes.SelectedValue & " and QUINCENA = " & CbCiclo.Text
        If cs.consultas(scr, dtfechas, msj) Then
            scr = "select * from tb_horas_extras where fecha between '" & dtfechas.Rows(0)("inicio") & "' and '" & dtfechas.Rows(0)("fin") & "'"

            scr = " Select a.codigo,a.depart,cod_empleado,b.fecha,b.horas from tb_pre_nomina As a " &
            " Left Join tb_horas_extras as b on a.codigo = b.cod_empleado" &
            " where b.fecha between '" & dtfechas.Rows(0)("inicio") & "' and '" & dtfechas.Rows(0)("fin") & "'" &
            " And a.ANIO = " & Format(DatAnio.Value, "yyyy") & " And mes = " & Cbmes.SelectedValue & " And quincena = " & CbCiclo.Text &
            " and depart = '" & cbdepto.SelectedValue & "'"
            If cs.consultas(scr, dthoras, msj) Then
                llenafg()
            End If
        End If
    End Sub

    Private Sub llenafg()
        fg.Rows.Count = 1
        fg.Rows.Count = dthoras.Rows.Count + 1
        For i = 0 To dthoras.Rows.Count - 1
            fg(i, 1) = dthoras.Rows(i)("cod_empleado")
            fg(i, 2) = dthoras.Rows(i)("fecha")
            fg(i, 3) = dthoras.Rows(i)("horas")
        Next
    End Sub

    Private Sub FrmIngHoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - (Me.Height / 2)
        Me.Left = l / 2 - (Me.Width / 2)
        Combo_box_Mes()
        Combo_depto()
        CbCiclo.SelectedIndex = 0
        dt_horass.Columns.Add("codigo")
        dt_horass.Columns.Add("fecha")
        dt_horass.Columns.Add("horas")
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

    Private Sub Combo_depto()
        scr = "select * from TB_DEPTOS_EMPRESA"
        If cs.consultas(scr, dt_depto, msj) Then
            cbdepto.DataSource = dt_depto
            cbdepto.DisplayMember = "nombre"
            cbdepto.ValueMember = "cod_depar"
            cbdepto.SelectedIndex = 1
        End If
    End Sub

    Private Sub BtGuardar_Click(sender As Object, e As EventArgs) Handles BtGuardar.Click

        For i = 0 To fg.Rows.Count - 1
            If IsNothing(fg(i, 1)) = True Then
            Else
                Dim dr As DataRow = dt_horass.NewRow
                dr("codigo") = fg(i, 1)
                dr("fecha") = fg(i, 2)
                dr("horas") = fg(i, 3)
                dt_horass.Rows.Add(dr)
                dt_horass.AcceptChanges()
            End If
        Next
        If cs.actualiza_horas(dt_horass, msj) Then
            MsgBox("Datos guardados!")
        End If

    End Sub
End Class