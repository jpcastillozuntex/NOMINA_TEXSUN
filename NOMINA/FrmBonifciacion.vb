Public Class FrmBonificacion
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dtmes As New DataTable
    Dim dt As New DataTable
    Dim dt_dept As New DataTable
    Dim dt_cod As New DataTable
    Dim dt_mont As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim empresa As Integer = 1
    'Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmBonifciacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        Combo_deptos()
        fg.Rows(0).Height = 31
        BtGuardar.Visible = False
        BtRegresar.Visible = False
        CbCiclo.SelectedIndex = 0
        fg.Rows.Count = 1
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
        crea_dt()
    End Sub

    Private Sub Combo_deptos()
        scr = "SELECT DISTINCT(COD_DEPART),TB_DEPTOS_EMPRESA.NOMBRE FROM TB_EMPLEADO " & _
              " LEFT JOIN TB_DEPTOS_EMPRESA ON TB_EMPLEADO.COD_DEPART = TB_DEPTOS_EMPRESA.COD_DEPAR " & _
               " WHERE ESTADO_EMPLEADO IN ('S','A')"
        cs.consultas(scr, dt_dept, msj)
        CbDeptos.DataSource = dt_dept
        CbDeptos.DisplayMember = "NOMBRE"
        CbDeptos.ValueMember = "COD_DEPART"
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        limpia()
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        scr = "SELECT * FROM TB_CICLO_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo
        If cs.consultas(scr, dt, msj) Then
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("ESTADO") = "A" Then
                    scr = "select A.CODIGO,NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA,B.MONTO from TB_EMPLEADO AS A " & _
                          " LEFT JOIN TB_BONIFICACION AS B ON B.CODIGO = A.CODIGO AND ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA =  " & ciclo & _
                          "WHERE COD_DEPART = '" & CbDeptos.SelectedValue & "' AND ESTADO_EMPLEADO IN ('S','A')"
                    If cs.consultas(scr, dt_cod, msj) Then
                        fg.Rows.Count = dt_cod.Rows.Count + 1
                        For i = 0 To dt_cod.Rows.Count - 1
                            fg(i + 1, 1) = dt_cod.Rows(i)("CODIGO")
                            fg(i + 1, 2) = Format(dt_cod.Rows(i)("FEC_ALTA"), "yyyy-MM-dd")
                            fg(i + 1, 3) = dt_cod.Rows(i)("NOMBRE") & " " & dt_cod.Rows(i)("SEGUNDO_NOMBRE") & " " & dt_cod.Rows(i)("APELLIDO") & " " & dt_cod.Rows(i)("SEGUNDO_APELLIDO")
                            fg(i + 1, 4) = dt_cod.Rows(i)("MONTO")
                        Next
                        CbCiclo.Enabled = False
                        DatAnio.Enabled = False
                        Cbmes.Enabled = False
                        CbDeptos.Enabled = False
                        BtConsultar.Visible = False
                        BtGuardar.Visible = True
                        BtRegresar.Visible = True
                    End If
                ElseIf dt.Rows(0)("ESTADO") = "C" Then
                    mensajes.Text = "ESTE CICLO YA ESTA CERRADO"
                ElseIf dt.Rows(0)("ESTADO") = "P" Then
                    mensajes.Text = "EL CICLO AUN NO ESTA ACTIVO"
                End If
            Else
                mensajes.Text = "CICLO NO EXISTE"
            End If
        Else
            MsgBox("ERROR: " & msj)
        End If
    End Sub


    Private Sub BtRegresar_Click(sender As System.Object, e As System.EventArgs) Handles BtRegresar.Click
        regresa()
    End Sub

    Private Sub regresa()
        CbCiclo.Enabled = True
        DatAnio.Enabled = True
        Cbmes.Enabled = True
        CbDeptos.Enabled = True
        BtConsultar.Visible = True
        BtGuardar.Visible = False
        BtRegresar.Visible = False
        limpia()
        fg.Rows.Count = 1
    End Sub

    Private Sub limpia()
        For i = 1 To fg.Rows.Count - 1
            fg(i, 1) = ""
            fg(i, 2) = Nothing
            fg(i, 3) = ""
            fg(i, 4) = Nothing
        Next
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        For i = 1 To fg.Rows.Count - 1
            Dim dtr As DataRow = dt_mont.NewRow
            If fg(i, 1) <> "" And fg(i, 4) <> Nothing Then
                dtr("CODIGO") = fg(i, 1)
                dtr("EMPRESA") = empresa
                dtr("ANIO") = anio
                dtr("MES") = mes
                dtr("CICLO") = ciclo
                dtr("MONTO") = fg(i, 4)
                dt_mont.Rows.Add(dtr)
                dt_mont.AcceptChanges()
            End If
        Next
        If cs.guarda_bonif(dt_mont, msj) Then
            regresa()
        Else
            mensajes.Text = msj
        End If
    End Sub

    Private Sub crea_dt()
        dt_mont.Columns.Add("CODIGO")
        dt_mont.Columns.Add("EMPRESA")
        dt_mont.Columns.Add("ANIO")
        dt_mont.Columns.Add("MES")
        dt_mont.Columns.Add("CICLO")
        dt_mont.Columns.Add("MONTO")
        dt_mont.AcceptChanges()
    End Sub



    Private Sub mensajes_Click(sender As System.Object, e As System.EventArgs) Handles mensajes.Click

    End Sub
End Class