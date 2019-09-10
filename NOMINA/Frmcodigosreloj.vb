Public Class Frmcodigosreloj
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim dt As New DataTable
    Dim dtcodigo As New DataTable
    Dim scr As String
    Dim num As Int32
    Dim col2 As Int32
    Dim codigo As Integer
    Dim cod As String

    Private Sub Frmcodigosreloj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtcodigo.Columns.Add("codigo")
        dtcodigo.AcceptChanges()

        scr = "SELECT CODIGO_RELOJ FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('A','S')"
        cs.consultas(scr, dt, msj)

        For I = 1000 To 2000
            Dim dtr As DataRow = dtcodigo.NewRow
            Dim dr As DataRow()
            cod = I
            dr = dt.Select("codigo_reloj = " & cod)
            If dr.Length < 1 Then
                dtr("codigo") = I
                dtcodigo.Rows.Add(dtr)
                dtcodigo.AcceptChanges()
            End If
        Next

        num = dtcodigo.Rows.Count + 2
        fg.Rows.Count = num / 4 + 2
        col2 = (num - 5) / 4
        For i = 0 To fg.Rows.Count - 2
            fg(i + 1, 0) = i + 1
            fg(i + 1, 1) = dtcodigo.Rows(i)("codigo")
            fg(i + 1, 2) = dtcodigo.Rows(col2 + i)("codigo")
            fg(i + 1, 3) = dtcodigo.Rows(col2 * 2 + i)("codigo")
            Try
                fg(i + 1, 4) = dtcodigo.Rows(col2 * 3 + i)("codigo")
            Catch
            End Try
        Next

    End Sub

    Private Sub creatabla()



    End Sub


End Class