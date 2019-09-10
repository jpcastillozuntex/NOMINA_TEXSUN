Public Class FrmCalcVaca
    '    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim empresa As Integer = 1
    Dim cs As New ClsConsultas
    Dim datos As New DataTable
    Dim dtfinal As New DataTable
    Dim dtconsulta As New DataTable
    Dim msj As String
    Dim scr As String
    Dim mes_dia As String
    Dim fecha_inic As Date
    Dim dias_t As Integer
    Dim dias_v As Double
    Dim fecha As Date
    Dim anio As Integer
    ' Dim dr As DataRow
    Dim j As Integer
    Dim y As String = "dd-MM-yyy"

    Private Sub FrmCalcVaca_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        crea_table()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        j = 0
        Dim i As Integer = 0
        fecha = Format(DatFecha.Value, y)
        scr = "SELECT CODIGO,fec_alta,VAC_LIQ +1 as vac_liq  FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('S','A') AND Codigo_empresa = " & empresa
        cs.consultas(scr, datos, msj)
        fg.Rows.Count = datos.Rows.Count * 1
        For Each dr In datos.Rows
            mes_dia = DatePart(DateInterval.Month, datos.Rows(j)("fec_alta")) & "-" & DatePart(DateInterval.Day, datos.Rows(j)("fec_alta"))
            If datos.Rows(j)("vac_liq") Is DBNull.Value Then
                anio = DatePart(DateInterval.Year, datos.Rows(j)("fec_alta"))
            Else
                anio = datos.Rows(j)("vac_liq")
            End If
            fecha_inic = anio & "-" & mes_dia
            dias_t = DateDiff(DateInterval.Day, fecha_inic, fecha)
            dias_v = dias_t * 15 / 365
            While dias_v > 0
                fg(i + 1, 0) = i + 1
                fg(i + 1, 1) = datos.Rows(j)("codigo")
                fg(i + 1, 2) = datos.Rows(j)("FEC_ALTA")
                fg(i + 1, 3) = Format(fecha_inic, y)
                fg(i + 1, 4) = Format(fecha, y)
                fg(i + 1, 5) = dias_t
                If dias_v > 15 Then
                    fg(i + 1, 6) = 15
                Else
                    fg(i + 1, 6) = Format(dias_v, "##0.00")
                End If
                fg(i + 1, 7) = anio
                fg(i + 1, 8) = dias_t * 15 / 365
                dias_v = dias_v - 15
                anio = anio + 1
                fecha_inic = anio & "-" & mes_dia
                i = i + 1
                fg.Rows.Count = i + 2
            End While
            j = j + 1
        Next

        For n = 1 To fg.Rows.Count - 1
            Dim dr As DataRow = dtfinal.NewRow
            If fg(n, 1) Is Nothing Or fg(n, 2) Is Nothing Or fg(n, 3) Is Nothing Then
            Else
                dr("codigo") = fg(n, 1)
                dr("empresa") = empresa
                dr("fec_inic") = fg(n, 3)
                dr("fec_calc") = fg(n, 4)
                dr("saldo") = fg(n, 6)
                dr("ciclo") = fg(n, 7)
                dtfinal.Rows.Add(dr)
                dtfinal.AcceptChanges()
            End If
        Next
        If cs.ing_vacas(dtfinal, msj) Then

        End If
    End Sub

    Private Function crea_table()
        dtfinal.Columns.Add("codigo")
        dtfinal.Columns.Add("empresa")
        dtfinal.Columns.Add("fec_inic")
        dtfinal.Columns.Add("fec_calc")
        dtfinal.Columns.Add("saldo")
        dtfinal.Columns.Add("ciclo")
        Return dtfinal
    End Function

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        scr = "select * from tb_vacaciones where estado = 'N'"
        If cs.consultas(scr, dtconsulta, msj) Then
            limpia()
            fg.Rows.Count = dtconsulta.Rows.Count + 1
            For i = 0 To dtconsulta.Rows.Count - 1
                fg(i + 1, 1) = dtconsulta.Rows(i)("codigo")
                fg(i + 1, 3) = dtconsulta.Rows(i)("fecha_inic")
                fg(i + 1, 4) = dtconsulta.Rows(i)("fecha_calc")
                fg(i + 1, 6) = dtconsulta.Rows(i)("saldo")
                fg(i + 1, 7) = dtconsulta.Rows(i)("ciclo")
            Next
        Else
        End If
    End Sub

    Private Sub limpia()
        For i = 1 To fg.Rows.Count - 1
            For m = 1 To 8
                fg(i, m) = Nothing
            Next
        Next
    End Sub

End Class