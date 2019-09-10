Imports System.Net
Imports Newtonsoft.Json
Imports System.Text
Imports C1.Win.FlexReport

Public Class pruebas
    Dim cs As New ClsConsultas
    'Install Newtonsoft.json
    '-----------------------
    '
    'PM> Install-Package Newtonsoft.Json -Version 6.0.8
    'Sample Usage  '------------
    'Dim jsonPost As New JsonPost("http://192.168.254.104:8000")
    'Dim dictData As New Dictionary(Of String, Object)
    'dictData.Add("test_key", "test_value")
    'jsonPost.postData(dictData)
    Private urlToPost As String = ""

    Public Sub New(ByVal urlToPost As String)
        Me.urlToPost = urlToPost
    End Sub

    Public Function postData(ByVal dictData As Dictionary(Of String, Object)) As Boolean
        Dim webClient As New WebClient()
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte
        Try
            webClient.Headers("content-type") = "application/json"
            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
            resByte = webClient.UploadData(Me.urlToPost, "post", reqString)
            resString = Encoding.Default.GetString(resByte)
            Console.WriteLine(resString)
            webClient.Dispose()
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return False
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim strsql As String = "SELECT SUM(MONTO_BONO) AS MONTO,C.NOMBRE,COD_EMPRESA FROM TB_BONO14 AS A" &
              " LEFT JOIN TB_EMPLEADO AS B ON A.COD_EMPLEADO = B.CODIGO" &
              " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON B.COD_DEPART = C.COD_DEPAR" &
              " WHERE A.CICLO = '2017-2018'  AND COD_EMPRESA =1 " &
              " GROUP BY C.NOMBRE, COD_EMPRESA"
        Try
            rp.Load("C:\Plan_rep\nomina.flxr", "totales_bono")
            rp.DataSource.ConnectionString = cs.con
            Dim ciclo As TextField = DirectCast(rp.Fields("ciclo"), TextField)
            ciclo.Text = "BONO DECRETO 42-92 AÑO  2017"

            rp.DataSource.RecordSource = strsql
            rp.Render()
            fv.DocumentSource = rp
            fv.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class



