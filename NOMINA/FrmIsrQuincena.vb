Public Class FrmISRquincenal
    Dim msj As String
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim dtfechas As New DataTable
    Dim empresa As String = FrmInicio.empresa
    Dim planilla As String
    Dim dtmes As New DataTable
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim dtguarda As New DataTable

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '      Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        CbQuincena.SelectedIndex = 0
        crea_table()
    End Sub

    Private Sub crea_table()
        dtguarda.Columns.Add("codigo")
        dtguarda.Columns.Add("anio")
        dtguarda.Columns.Add("mes")
        dtguarda.Columns.Add("quincena")
        dtguarda.Columns.Add("monto")
        dtguarda.Columns.Add("empresa")
    End Sub

    Private Sub Combo_box_Mes()
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
        Cbmes.SelectedIndex = Date.Now.Month - 1
    End Sub

    Private Sub llena_fg()
        fg.Rows.Count = 1
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Dim scr As String = "SELECT A.CODIGO,a.NOMBRE,A.SEGUNDO_NOMBRE,A.APELLIDO,A.SEGUNDO_APELLIDO,MONTO,C.NOMBRE AS DEPART FROM TB_EMPLEADO AS A  " & _
            " LEFT JOIN TB_ISR as b on a.codigo = b.CODIGO  AND B.EMPRESA = A.CODIGO_EMPRESA AND ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & "  AND B.EMPRESA = A.CODIGO_EMPRESA" & _
            " LEFT JOIN TB_DEPTOS_EMPRESA as c on A.COD_DEPART = C.COD_DEPAR  " & _
            " where ESTADO_EMPLEADO IN ('A','S')"
        If cs.consultas(scr, dtfechas, msj) Then
            fg.Rows.Count = dtfechas.Rows.Count + 1
            For I = 0 To dtfechas.Rows.Count - 1
                fg(I + 1, 1) = dtfechas.Rows(I)("codigo")
                fg(I + 1, 2) = dtfechas.Rows(I)("nombre") & " " & dtfechas.Rows(I)("segundo_nombre") & " " & dtfechas.Rows(I)("apellido") & " " & dtfechas.Rows(I)("segundo_apellido")
                fg(I + 1, 3) = dtfechas.Rows(I)("monto")
            Next
        End If
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbQuincena.Text
        llena_fg()
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        Dim estado As String = ""
        dtguarda.Rows.Clear()
        dtguarda.Rows.Clear()
        For i = 1 To fg.Rows.Count - 1
            If fg(i, 4) > 0 Then
                Dim dtr As DataRow = dtguarda.NewRow
                dtr("codigo") = fg(i, 1)
                dtr("anio") = Format(DatAnio.Value, "yyyy")
                dtr("mes") = Cbmes.SelectedValue
                dtr("quincena") = CbQuincena.Text
                dtr("monto") = fg(i, 3) + fg(i, 4)
                dtr("empresa") = empresa
                dtguarda.Rows.Add(dtr)
                dtguarda.AcceptChanges()
            End If
        Next
        If dtguarda.Rows.Count > 0 Then

            scr = "select estado from tb_ciclo_nomina where ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & ""
            cs.csescalar(estado, scr, msj)
            If estado = "C" Then
                MsgBox("Este ciclo ya esta Cerrado!")
            Else
                If cs.actualiza_isr(dtguarda, msj) Then
                    MsgBox("Datos Actualizados!")
                    fg.Rows.Count = 1
                End If
            End If
        End If
    End Sub
End Class