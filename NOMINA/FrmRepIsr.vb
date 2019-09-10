Public Class FrmRepIsr
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

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        CbQuincena.SelectedIndex = 0
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
        cs.consultas(scr, dtfechas, msj)
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Dim f As String = "QUINCENA " & ciclo & " DE " & Cbmes.Text & " DEL " & anio
        Dim strsql As String = "SELECT A.CODIGO,B.NOMBRE,B.SEGUNDO_NOMBRE,B.APELLIDO,B.SEGUNDO_APELLIDO,MONTO,C.NOMBRE AS DEPART,'" & f & "' as fecha, '" & nempresa & "' as nempresa FROM TB_ISR AS A " &
                         " LEFT JOIN TB_EMPLEADO as b on a.codigo = b.CODIGO  AND A.EMPRESA = B.CODIGO_EMPRESA " &
                         " LEFT JOIN TB_DEPTOS_EMPRESA as c on B.COD_DEPART = C.COD_DEPAR " &
                         " where ESTADO_EMPLEADO IN ('A','S')  AND ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & "  AND EMPRESA = A.EMPRESA"
        Try
            rp.Load("C:\Plan_rep\nomina.flxr", "ISR")
            rp.DataSource.ConnectionString = cs.con
            rp.DataSource.RecordSource = strsql
            rp.Render()
            fv.DocumentSource = rp

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbQuincena.Text
        llena_fg()
    End Sub
End Class