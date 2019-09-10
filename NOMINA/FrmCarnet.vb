'Imports Microsoft.VisualBasic.PowerPacks.Printing
Imports System.Drawing.Imaging


Public Class FrmCarnet
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    'Dim empresa As Integer = 1
    Dim buscar As New ClsConsultas
    Dim codigo As String
    Dim buscacodigo As New DataTable
    Dim foto As IO.MemoryStream
    Dim scr As String
    Dim dt_codigo As New DataTable
    Dim msj As String

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim width As Integer = 225
        Dim height As Integer = 335
        Dim ancho As Integer = 108
        Dim alto As Integer = 123
        Dim prFont As New Font("Arial", 10, FontStyle.Bold)
        Dim cod As New Font("Arial", 11, FontStyle.Bold)

        e.Graphics.DrawImage(PictureBox1.Image, 20, 50, width, height)
        e.Graphics.DrawImage(Pbatras.Image, 250, 50, width, height)
        e.Graphics.DrawImage(PbFoto.Image, 21, 60, ancho, alto)
        e.Graphics.DrawString(buscacodigo.Rows(0)("nombre") + " " + buscacodigo.Rows(0)("segundo_nombre"), prFont, Brushes.Blue, 80, 185)
        e.Graphics.DrawString(buscacodigo.Rows(0)("apellido") + " " + buscacodigo.Rows(0)("segundo_apellido"), prFont, Brushes.Blue, 80, 200)
        e.Graphics.DrawString(buscacodigo.Rows(0)("nombre_puesto"), prFont, Brushes.Black, 20, 230)
        Dim codigo As String = Format(buscacodigo.Rows(0)("codigo"), "0000")
        'e.Graphics.DrawString(buscacodigo.Rows(0)("codigo"), cod, Brushes.Blue, 40, 350)
        e.Graphics.DrawString(codigo, cod, Brushes.Blue, 110, 350)
        'buscacodigo.Clear()
    End Sub



    Private Sub BtBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBuscar.Click
        buscacodigo.Clear()
        Dim mensaje As String = ""
        If (CbCodigo.Text = "") Then
            MsgBox("INGRESE CODIGO.")
        ElseIf buscar.BuscaNombre(buscacodigo, CbCodigo.Text, empresa, mensaje) = True Then
            codigo = CbCodigo.Text
            Lbnombre.Text = buscacodigo.Rows(0)("nombre") & " " & buscacodigo.Rows(0)("segundo_nombre")
            Lbapellido.Text = buscacodigo.Rows(0)("Apellido") & " " & buscacodigo.Rows(0)("segundo_apellido")
            Lbcodigo.Text = Format(buscacodigo.Rows(0)("codigo"), "0000")
            LbPuesto.Text = buscacodigo.Rows(0)("nombre_puesto")
            If buscar.obtienefoto(CbCodigo.Text, empresa, foto, mensaje) = True Then
                PbFoto.Image = Image.FromStream(foto)
            Else
                PbFoto.Image = Nothing
            End If
        Else
            MsgBox(mensaje)
        End If

    End Sub
    Private Sub requi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbCodigo.KeyPress
        buscar.AutoCompletar(CbCodigo, e)
    End Sub

    Private Sub TxtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNombre.TextChanged
        scr = "SELECT CODIGO FROM TB_EMPLEADO WHERE NOMBRE LIKE '" & TxtNombre.Text & "%'"
        If buscar.consultas(scr, dt_codigo, msj) Then
            CbCodigo.DataSource = dt_codigo
            CbCodigo.DisplayMember = "CODIGO"
            CbCodigo.ValueMember = "CODIGO"
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cobro As MsgBoxResult
        If (PbFoto.Image Is Nothing Or Lbnombre.Text = "") Then
            MsgBox("Faltan datos Para imprimir Carnet")
        Else
            cobro = MsgBox("DESEA REALIZAR COBRO ", MsgBoxStyle.OkCancel, "Cobro por Reposicion")
            If cobro = 1 Then
                buscar.descuento(codigo, empresa, Format(Today, "yyyy-MM-dd"), 20.0, "02", "Descuento_automatico por carnet")
                MsgBox("cobro realizado")
                PrintDialog1.Document = PrintDocument1
                PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
                PrintDialog1.AllowSomePages = True
                If PrintDialog1.ShowDialog = DialogResult.OK Then
                    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
                    PrintDocument1.Print()
                    Lbnombre.Text = ""
                    Lbapellido.Text = ""
                    Lbcodigo.Text = ""
                    LbPuesto.Text = ""
                End If
            Else
                PrintDialog1.Document = PrintDocument1
                PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
                PrintDialog1.AllowSomePages = True
                If PrintDialog1.ShowDialog = DialogResult.OK Then
                    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
                    PrintDocument1.Print()
                    Lbnombre.Text = ""
                    Lbapellido.Text = ""
                    Lbcodigo.Text = ""
                    LbPuesto.Text = ""
                End If
            End If

            End If
    End Sub

    Private Sub cb_codigo()
        Try
            scr = "SELECT CODIGO FROM TB_EMPLEADO"
            buscar.consultas(scr, dt_codigo, msj)
            CbCodigo.DataSource = dt_codigo
            CbCodigo.DisplayMember = "CODIGO"
            CbCodigo.ValueMember = "CODIGO"
        Catch
        End Try
    End Sub

    Private Sub FrmCarnet_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cb_codigo()
    End Sub


End Class