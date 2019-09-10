Public Class frmPruebas1
    Dim cs As New ClsConsultas


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub frmPruebas1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strsql As String = "SELECT SUM(MONTO_BONO) AS MONTO,C.NOMBRE,COD_EMPRESA FROM TB_BONO14 AS A" &
              " LEFT JOIN TB_EMPLEADO AS B ON A.COD_EMPLEADO = B.CODIGO" &
              " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON B.COD_DEPART = C.COD_DEPAR" &
              " WHERE A.CICLO = '2017-2018'  AND COD_EMPRESA = 1" &
              " GROUP BY C.NOMBRE, COD_EMPRESA"
        Try
            rp.Load("C:\Plan_rep\nomina.xml", "totales_bono")
            rp.DataSource.ConnectionString = cs.con
            'rp.Fields("ciclo").Text = " BONO DECRETO 42-92 AÑO " & ciclos
            rp.DataSource.RecordSource = strsql
            rp.Render()
            fv.DocumentSource = rp
            fv.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class