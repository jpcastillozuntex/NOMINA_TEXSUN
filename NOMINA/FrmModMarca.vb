Public Class FrmModMarca
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim scr As String
    Dim cs As New ClsConsultas
    Dim dtmarcafin As New DataTable
    Dim msj As String
    Dim dtMes As New DataTable
    Dim dtcodigo As New DataTable
    Dim dtciclo As New DataTable
    Dim dt_marcas As New DataTable
    Dim dt_guarda As New DataTable

    Private Sub FrmModMarca_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2

        f.Rows.Count = 1
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
        crea_table()
        codigos()
        scr = "select * from tb_ciclo_nomina where estado = 'a' "
        If cs.consultas(scr, dtciclo, msj) Then
            lbanio.Text = dtciclo.Rows(0)("anio")
            Cbmes.SelectedValue = dtciclo.Rows(0)("mes")
            CbCiclo.Text = dtciclo.Rows(0)("quincena")
        End If
    End Sub

    Private Sub Combo_box_Mes()
        Dim mes As Integer
        mes = Date.Now.Month
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
        Cbmes.SelectedIndex = mes - 1
    End Sub

    Private Sub codigos()
        scr = "select codigo from tb_empleado where ESTADO_EMPLEADO in('A','S')"
        cs.consultas(scr, dtcodigo, msj)
        cbcodigo.DataSource = dtcodigo
        cbcodigo.DisplayMember = "codigo"
        cbcodigo.ValueMember = "codigo"
    End Sub

    Private Sub requi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbcodigo.KeyPress
        cs.AutoCompletar(cbcodigo, e)
    End Sub

    Private Sub crea_table()
        dt_guarda.Columns.Add("CODIGO")
        dt_guarda.Columns.Add("FECHA", GetType(Date))
        dt_guarda.Columns.Add("HORA")
        dt_guarda.Columns.Add("HORA_N")
        dt_guarda.AcceptChanges()
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        scr = "SELECT A.CODIGO,A.NOMBRE,A.SEGUNDO_NOMBRE,APELLIDO,B.FECHA,B.HORA,B.CODIGO AS CODIGO_RELOJ FROM TB_EMPLEADO AS A" & _
                " LEFT JOIN TB_MARCA AS B ON A.CODIGO_RELOJ = B.CODIGO" & _
                " WHERE a.CODIGO = " & cbcodigo.Text & _
                " AND FECHA BETWEEN '" & dtciclo.Rows(0)("INICIO") & "' AND '" & dtciclo.Rows(0)("FIN") & "'"
        If cs.consultas(scr, dt_marcas, msj) Then
            For I = 0 To dt_marcas.Rows.Count - 1
                f.Rows.Count = dt_marcas.Rows.Count + 2
                f(I + 1, 1) = dt_marcas.Rows(I)("codigo")
                f(I + 1, 2) = dt_marcas.Rows(I)("nombre") & " " & dt_marcas.Rows(I)("segundo_nombre") & " " & dt_marcas.Rows(I)("apellido")
                f(I + 1, 3) = dt_marcas.Rows(I)("codigo_reloj")
                f(I + 1, 4) = dt_marcas.Rows(I)("fecha")
                f(I + 1, 5) = dt_marcas.Rows(I)("hora")
                f(I + 1, 6) = dt_marcas.Rows(I)("hora")
            Next
        End If
    End Sub






    Private Sub Btguardar_Click(sender As System.Object, e As System.EventArgs) Handles Btguardar.Click
        f.Rows.Count = 1
        dt_guarda.Rows.Clear()
        For I = 1 To f.Rows.Count - 2
            If f(I, 1) > 0 Then
                Dim dtr As DataRow = dt_guarda.NewRow
                dtr("codigo") = f(I, 3)
                dtr("fecha") = CDate(Format(f(I, 4), "yyyy-MM-dd"))
                dtr("hora") = f(I, 5)
                dtr("hora_n") = f(I, 6)
                dt_guarda.Rows.Add(dtr)
                dt_guarda.AcceptChanges()
            End If
        Next
        If cs.actualiza_marcas(dt_guarda, msj) Then
            MsgBox("Datos Actualizados!!")
        End If
    End Sub
End Class