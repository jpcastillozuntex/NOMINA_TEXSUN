Public Class FrmAsuetos
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
    Dim empresa As Integer = 1
    Dim f As String = "yyyy-MM-dd"

    'Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmBonifciacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        fg.Rows(0).Height = 31
        BtGuardar.Visible = False
        BtRegresar.Visible = False
        DatFecha.MinDate = Today.AddDays(-15)
        fg.Rows.Count = 1
        crea_dt()
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        limpia()
        scr = "select A.CODIGO,NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA,B.FECHA_ASUETO from TB_EMPLEADO AS A " & _
              "left join TB_ASUETO as b on a.CODIGO=b.COD_EMPLEADO and b.FECHA_ASUETO = '" & Format(DatFecha.Value, f) & "'" & _
              "WHERE ESTADO_EMPLEADO IN ('S','A')"

        If cs.consultas(scr, dt_cod, msj) Then
            fg.Rows.Count = dt_cod.Rows.Count + 1
            For i = 0 To dt_cod.Rows.Count - 1
                fg(i + 1, 1) = dt_cod.Rows(i)("CODIGO")
                fg(i + 1, 2) = Format(DatFecha.Value, "yyyy-MM-dd")
                fg(i + 1, 3) = dt_cod.Rows(i)("NOMBRE") & " " & dt_cod.Rows(i)("SEGUNDO_NOMBRE") & " " & dt_cod.Rows(i)("APELLIDO") & " " & dt_cod.Rows(i)("SEGUNDO_APELLIDO")
                If IsDBNull(dt_cod.Rows(i)("fecha_asueto")) = True Then
                    fg(i + 1, 4) = False
                Else
                    fg(i + 1, 4) = True
                End If
            Next
            BtConsultar.Visible = False
            BtGuardar.Visible = True
            BtRegresar.Visible = True
        End If
    End Sub

    Private Sub BtRegresar_Click(sender As System.Object, e As System.EventArgs) Handles BtRegresar.Click
        regresa()
    End Sub

    Private Sub regresa()
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
        dt_mont.Clear()
        For i = 1 To fg.Rows.Count - 1
            Dim dtr As DataRow = dt_mont.NewRow
            If fg(i, 1) <> "" And fg(i, 4) = True Then
                dtr("CODIGO") = fg(i, 1)
                dtr("EMPRESA") = empresa
                dtr("FECHA") = fg(i, 2)
                dt_mont.Rows.Add(dtr)
                dt_mont.AcceptChanges()
            End If
        Next
        If cs.guarda_asueto(dt_mont, msj) Then
            regresa()
            limpia()
            mensajes.Text = "DATOS GUARDADOS!!"
        Else
            mensajes.Text = msj
        End If
    End Sub

    Private Sub crea_dt()
        dt_mont.Columns.Add("CODIGO")
        dt_mont.Columns.Add("EMPRESA")
        dt_mont.Columns.Add("FECHA")
        dt_mont.AcceptChanges()
    End Sub

    Private Sub fg_Click(sender As System.Object, e As System.EventArgs) Handles fg.Click

    End Sub
End Class