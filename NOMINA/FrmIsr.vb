Imports System.IO

Public Class FrmIsr
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dtmes As New DataTable
    Dim dt As New DataTable
    Dim dt_dept As New DataTable
    Dim dt_cod As New DataTable
    Dim dt_mont As New DataTable
    Dim dtciclo As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim fila As Integer
    Dim pri_qui As Double
    Dim seg_qui As Double
    Dim ciclosisr As Integer
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmBonifciacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        fg.Rows(0).Height = 31
        BtGuardar.Visible = False
        BtRegresar.Visible = False
        fg.Rows.Count = 1
        crea_dt()
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        anio = Format(DatAnio.Value, "yyyy")
        scr = "select count(1) as ciclos from TB_CICLO_NOMINA where anio = " & anio & " and ESTADO in ('P','A')"
        cs.consultas(scr, dtmes, msj)
        ciclosisr = 0
        limpia()
        scr = "select CODIGO,NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA FROM TB_EMPLEADO " & _
                " WHERE CODIGO NOT IN (SELECT CODIGO FROM TB_ISR WHERE '" & anio & "'+ convert(varchar,MES,2) +QUINCENA IN (SELECT '" & anio & "'+MES+QUINCENA FROM TB_CICLO_NOMINA WHERE ESTADO IN ('A','P')))" & _
                "AND ESTADO_EMPLEADO IN ('A','S')"
        If cs.consultas(scr, dt_cod, msj) Then
            fg.Rows.Count = dt_cod.Rows.Count + 1
            For i = 0 To dt_cod.Rows.Count - 1
                fg(i + 1, 1) = dt_cod.Rows(i)("CODIGO")
                fg(i + 1, 2) = Format(dt_cod.Rows(i)("FEC_ALTA"), "yyyy-MM-dd")
                fg(i + 1, 3) = dt_cod.Rows(i)("NOMBRE") & " " & dt_cod.Rows(i)("SEGUNDO_NOMBRE") & " " & dt_cod.Rows(i)("APELLIDO") & " " & dt_cod.Rows(i)("SEGUNDO_APELLIDO")
            Next
            DatAnio.Enabled = False

            BtConsultar.Visible = False
            BtGuardar.Visible = True
            BtRegresar.Visible = True
        End If
    End Sub

    ' Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
    '     ciclosisr = 0
    '     limpia()
    '     anio = Format(DatAnio.Value, "yyyy")
    '     mes = Cbmes.SelectedValue
    '     scr = "SELECT * FROM TB_CICLO_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes
    '     If cs.consultas(scr, dt, msj) Then
    '         If dt.Rows.Count > 0 Then
    '             mensajes.Text = ""
    '             If dt.Rows(0)("ESTADO") = "A" And dt.Rows(1)("ESTADO") = "P" Or dt.Rows(0)("ESTADO") = "P" And dt.Rows(1)("ESTADO") = "P" Then
    '                 ciclosisr = 1
    '                 scr = "select A.CODIGO,NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA,B.MONTO,(SELECT MONTO FROM TB_ISR WHERE CODIGO = A.CODIGO AND MES = " & mes & " AND ANIO = " & anio & " AND QUINCENA = 2)AS MONTO2 from TB_EMPLEADO AS A  " & _
    '                       " LEFT JOIN TB_ISR AS B ON B.CODIGO = A.CODIGO AND ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA =  1" & _
    '                       "WHERE ESTADO_EMPLEADO IN ('S','A')"
    '                 If cs.consultas(scr, dt_cod, msj) Then
    '                     fg.Rows.Count = dt_cod.Rows.Count + 1
    '                     For i = 0 To dt_cod.Rows.Count - 1
    '                         fg(i + 1, 1) = dt_cod.Rows(i)("CODIGO")
    '                         fg(i + 1, 2) = Format(dt_cod.Rows(i)("FEC_ALTA"), "yyyy-MM-dd")
    '                         fg(i + 1, 3) = dt_cod.Rows(i)("NOMBRE") & " " & dt_cod.Rows(i)("SEGUNDO_NOMBRE") & " " & dt_cod.Rows(i)("APELLIDO") & " " & dt_cod.Rows(i)("SEGUNDO_APELLIDO")
    '                         fg(i + 1, 5) = dt_cod.Rows(i)("MONTO")
    '                         fg(i + 1, 6) = dt_cod.Rows(i)("MONTO2")
    '                     Next
    '                     DatAnio.Enabled = False
    '                     Cbmes.Enabled = False
    '                     BtConsultar.Visible = False
    '                     BtGuardar.Visible = True
    '                     BtRegresar.Visible = True
    '                 End If
    '             ElseIf dt.Rows(0)("ESTADO") = "C" And dt.Rows(1)("ESTADO") = "A" Then
    '                 mensajes.Text = "A ESTE MES SOLO LE QUEDA UN CICLO ABIERTO"
    '                 ciclosisr = 2
    '                 scr = "select A.CODIGO,NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,FEC_ALTA,B.MONTO,(SELECT MONTO FROM TB_ISR WHERE CODIGO = A.CODIGO AND MES = " & mes & " AND ANIO = " & anio & " AND QUINCENA = 2)AS MONTO2 from TB_EMPLEADO AS A  " & _
    '                       " LEFT JOIN TB_ISR AS B ON B.CODIGO = A.CODIGO AND ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA =  1" & _
    '                       "WHERE  ESTADO_EMPLEADO IN ('S','A')"
    '                 If cs.consultas(scr, dt_cod, msj) Then
    '                     fg.Rows.Count = dt_cod.Rows.Count + 1
    '                     For i = 0 To dt_cod.Rows.Count - 1
    '                         fg(i + 1, 1) = dt_cod.Rows(i)("CODIGO")
    '                         fg(i + 1, 2) = Format(dt_cod.Rows(i)("FEC_ALTA"), "yyyy-MM-dd")
    '                         fg(i + 1, 3) = dt_cod.Rows(i)("NOMBRE") & " " & dt_cod.Rows(i)("SEGUNDO_NOMBRE") & " " & dt_cod.Rows(i)("APELLIDO") & " " & dt_cod.Rows(i)("SEGUNDO_APELLIDO")
    '                         fg(i + 1, 5) = dt_cod.Rows(i)("MONTO")
    '                         fg(i + 1, 6) = dt_cod.Rows(i)("MONTO2")
    '                     Next
    '                     DatAnio.Enabled = False
    '                     Cbmes.Enabled = False
    '                     BtConsultar.Visible = False
    '                     BtGuardar.Visible = True
    '                     BtRegresar.Visible = True
    '                 End If
    '             ElseIf dt.Rows(0)("ESTADO") = "C" And dt.Rows(1)("ESTADO") = "C" Then
    '                 mensajes.Text = "ESTE MES NO LE QUEDA CICLO PENDIENTE"
    '             End If
    '         Else
    '             mensajes.Text = "CICLO NO EXISTE"
    '         End If
    '     Else
    '         MsgBox("ERROR: " & msj)
    '     End If
    ' End Sub

    Private Sub BtRegresar_Click(sender As System.Object, e As System.EventArgs) Handles BtRegresar.Click
        regresa()
    End Sub

    Private Sub regresa()
        DatAnio.Enabled = True

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
        scr = "select * from TB_CICLO_NOMINA where anio = " & anio & " and ESTADO in ('P','A')"
        If cs.consultas(scr, dtciclo, msj) Then
        End If
        mensajes.Text = ""
        For i = 1 To fg.Rows.Count - 1
            For J = 0 To dtciclo.Rows.Count - 1
                If fg(i, 4) > 0 Then
                    Dim dtr As DataRow = dt_mont.NewRow
                    If fg(i, 1) <> "" And fg(i, 4) <> Nothing Then
                        dtr("CODIGO") = fg(i, 1)
                        dtr("EMPRESA") = empresa
                        dtr("ANIO") = dtciclo.Rows(J)("anio")
                        dtr("MES") = dtciclo.Rows(J)("mes")
                        dtr("ciclo") = dtciclo.Rows(J)("quincena")
                        dtr("MONTO") = fg(i, 5)
                        dt_mont.Rows.Add(dtr)
                        dt_mont.AcceptChanges()
                    End If
                End If
            Next
        Next
        If cs.guarda_isr(dt_mont, msj) Then
            mensajes.Text = "DATOS GUARDADOS!!"
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

    Private Sub fg_Click(sender As System.Object, e As System.EventArgs) Handles fg.BeforeRowColChange
        If fg.ColSel = 4 Then
            Try
                fila = fg.RowSel
                fila = fg.Row
                pri_qui = fg(fila, 4) / dtmes.Rows(0)("ciclos")
                fg(fila, 5) = pri_qui
            Catch EX As Exception
            End Try
        End If
    End Sub

    Private Sub DatAnio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DatAnio.ValueChanged
        scr = "select count(1) as ciclos from TB_CICLO_NOMINA where anio = 2017 and ESTADO in ('P','A')"
        cs.consultas(scr, dtmes, msj)
        anio = Format(DatAnio.Value, "yyyy")
    End Sub

End Class