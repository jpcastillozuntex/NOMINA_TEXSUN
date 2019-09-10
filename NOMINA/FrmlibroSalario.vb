Imports System.IO
Imports System.Text

Public Class FrmLibroSalario
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim dt_codigo As New DataTable
    Dim anio As Integer
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub Frm_Pre_nomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
    End Sub



    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        REPORTE()
    End Sub

    Private Sub REPORTE()
        anio = Format(DatAnio.Value, "yyyy")
        Try
            Cursor = Cursors.WaitCursor
            cr.Load("C:\Plan_rep\nomina.flxr", "libro_salario_conta")
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.RecordSource = " SELECT A.NOMBRE,A.SEGUNDO_NOMBRE, A.APELLIDO,A.SEGUNDO_APELLIDO,A.FEC_ALTA,A.FEC_BAJA,A.CODIGO,C.NOMBRE AS NOMBRE_DEPAR, B.* ,E.INICIO,E.FIN" &
                                            " FROM TB_EMPLEADO AS A " &
                                            " LEFT JOIN TB_NOMINA AS B ON A.CODIGO = B.CODIGO AND  anio =" & anio &
                                            " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.COD_DEPART = C.COD_DEPAR  " &
                                            " LEFT JOIN TB_CICLO_NOMINA AS E ON B.ANIO = E.ANIO AND B.MES = E.MES AND B.QUINCENA =E.QUINCENA" &
                                            " WHERE A.codigo = " & Cbmes.Text
            cr.Render()
            Fv.DocumentSource = cr
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Combo_box_Mes()
        scr = "select codigo from tb_empleado"
        cs.consultas(scr, dt_codigo, msj)
        Cbmes.DataSource = dt_codigo
        Cbmes.DisplayMember = "codigo"
        Cbmes.ValueMember = "codigo"
    End Sub


End Class