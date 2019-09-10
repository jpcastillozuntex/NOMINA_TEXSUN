Public Class FrmConsultaEmp
    'Dim script As String
    Dim tabla As New DataTable
    Dim cs As New ClsConsultas
    Dim contador As Integer
    Public F As Integer
    Public empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Public codigo As Integer '= 1
    Dim msj As String

    Public Sub C1FlexGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg.DoubleClick
        F = Fg.RowSel
        codigo = Fg(F, 1)
        FrmVisualizaDatos.Show()
    End Sub

    Private Sub FrmConsultaEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Fg.Rows(0).Height = 26
    End Sub

    Private Sub llena_fg(scr As String)
        tabla.Clear()
        If cs.consultas(scr, tabla, msj) = True Then
            contador = tabla.Rows.Count
            Fg.Rows.Count = contador + 1
            For i = 0 To contador - 1
                Fg(i + 1, 1) = tabla.Rows(i)("codigo")
                Fg(i + 1, 2) = tabla.Rows(i)("nombre") + " " + tabla.Rows(i)("segundo_nombre")
                Fg(i + 1, 3) = tabla.Rows(i)("apellido") + " " + tabla.Rows(i)("segundo_apellido")
                Fg(i + 1, 4) = tabla.Rows(i)("DEPART")
                Fg(i + 1, 5) = tabla.Rows(i)("FEC_ALTA")
            Next
        Else
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNombre.TextChanged
        Dim script As String = "SELECT CODIGO,A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA,B.NOMBRE AS DEPART FROM TB_EMPLEADO AS A" & _
                 " LEFT JOIN TB_DEPTOS_EMPRESA AS B ON A.COD_DEPART = B.COD_DEPAR " & _
                 " WHERE A.NOMBRE LIKE '%" & TxtNombre.Text & "%' and codigo_empresa = " & empresa
        llena_fg(script)
    End Sub

    Private Sub Txt2nombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtApellido.TextChanged
        Dim script As String = "SELECT CODIGO,A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA,B.NOMBRE AS DEPART FROM TB_EMPLEADO AS A" & _
                 " LEFT JOIN TB_DEPTOS_EMPRESA AS B ON A.COD_DEPART = B.COD_DEPAR " & _
                 " WHERE A.APELLIDO LIKE '%" & TxtApellido.Text & "%' and codigo_empresa = " & empresa
        llena_fg(script)
    End Sub

    Private Sub TxCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxCodigo.TextChanged
        Dim script As String = "SELECT CODIGO,A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA,B.NOMBRE AS DEPART FROM TB_EMPLEADO AS A" & _
            " LEFT JOIN TB_DEPTOS_EMPRESA AS B ON A.COD_DEPART = B.COD_DEPAR " & _
            " WHERE A.CODIGO LIKE '%" & TxCodigo.Text & "%'and codigo_empresa = " & empresa
        llena_fg(script)
    End Sub
End Class