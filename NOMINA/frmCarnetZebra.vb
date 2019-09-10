''''''''''''''''''''''''''''''''''''''''''''''''
' CONFIDENTIAL AND PROPRIETARY
'
' The source code and other information contained herein is the confidential and the exclusive property of
' ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
' This source code, and any other information contained herein, shall not be copied, reproduced, published,
' displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
' expressly permitted under such license agreement.
'
' Copyright ZIH Corp. 2010
'
' ALL RIGHTS RESERVED
''''''''''''''''''''''''''''''''''''''''''''''''
'File: frmMain.vb
'Description: Form allowing users to select printing and encoding options.
'$Revision: 1 $
'$Date: 2010/12/08 $
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports System
Imports System.Windows.Forms
Imports System.Drawing.Printing

Public Class frmCarnetZebra

#Region "Declarations"
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim scr As String = ""
    Private _graphicsSDKVersion, _prnSDKVersion As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim dt As New DataTable
    Dim buscacodigo As New DataTable
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim foto As IO.MemoryStream
    Dim codigo As String
    Dim nombre, apellido, puesto As String
#End Region

#Region "Local Functions"

    ' Initializes the printer combo box ---------------------------------------------------------------------

    Private Sub cboPrnInit()

        Dim prn = New PrintDocument()
        Dim strPrn As String

        For Each strPrn In PrinterSettings.InstalledPrinters
            Me.cboPrn.Items.Add(strPrn)
        Next

        Me.cboPrn.Sorted = True
        Me.cboPrn.Focus()

    End Sub

    ' Configures the Form based on present dlls -------------------------------------------------------------

    Private Sub FormConfig()

        Dim msg As String = ""

        Me.lblStatus.Text = ""

        ' Printing (Graphics)

        If _graphicsSDKVersion <> "" Then
            Me.gbPrint.Enabled = True
            msg = "Graphics: " & _graphicsSDKVersion & "; "
        End If

        If _prnSDKVersion <> "" Then
            Me.gbMag.Enabled = True
            msg = msg & "Printer: " & _prnSDKVersion & "; "
        End If

        Me.lblVersions.Text = msg

    End Sub

    ' Gets the versions of the SDK's DLLs
    '     if the version = "" then the supporting dll is not present ----------------------------------------

    Private Sub GetSDKVersions()

        Dim g As New VBNetSampleCodeGraphics
        _graphicsSDKVersion = g.GetSDKVersion()
        g = Nothing

        Dim p As New VBNetSampleCodeMag
        _prnSDKVersion = p.GetSDKVersion()
        p = Nothing

    End Sub

    ' Waits for the spooler to clear 
    '     called before a smart card operation --------------------------------------------------------------

    Private Function WaitForSpoolerClear(ByVal prnDriver As String, ByVal seconds As Integer) As Boolean

        Dim g As New VBNetSampleCodeGraphics
        WaitForSpoolerClear = g.IsPrinterReady(prnDriver, seconds)
        g = Nothing

    End Function

#End Region

#Region "Form"

    ' frmMain Load ------------------------------------------------------------------------------------------

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2

        cboPrnInit()
        GetSDKVersions()
        FormConfig()
        codigos()
    End Sub

#End Region

#Region "combo Box"
    Private Sub codigos()
        Try
            scr = "SELECT CODIGO FROM TB_EMPLEADO WHERE ESTADO_empleado IN ('A','S')"
            cs.consultas(scr, dt, msj)
            CbCodigo.DataSource = dt
            CbCodigo.DisplayMember = "CODIGO"
            CbCodigo.ValueMember = "CODIGO"
        Catch
        End Try
    End Sub
#End Region

    Private Sub requi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbCodigo.KeyPress
        cs.AutoCompletar(CbCodigo, e)
    End Sub


#Region "Buttons"
    ' Submit
    '     starts the example code based on Form selections --------------------------------------------------
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim cobro As MsgBoxResult
        cobro = MsgBox("DESEA REALIZAR COBRO ", MsgBoxStyle.OkCancel, "Cobro por Reposicion")
        If cobro = 1 Then
            cs.descuento(codigo, empresa, Format(Today, "yyyy-MM-dd"), 20.0, "02", "Descuento_automatico por carnet")
            MsgBox("Cobro Realizado!", MsgBoxStyle.Information)
        End If

        cbFront.Checked = True
        Dim eject As Integer = 0
        Dim msg As String = ""
        ' Classes
        Dim mag As VBNetSampleCodeMag
        Dim prn As VBNetSampleCodeGraphics
        ' Verifies that a printer has been selected
        If Me.cboPrn.Text = "" Then
            msg = "Error: A printer has not been selected"
            GoTo ExitFunc
        End If
        ' Verifies that at least one selection is made

        If Not Me.cbBack.Checked And Not Me.cbFront.Checked And Not Me.cbMag.Checked Then
            msg = "Error: No Selections"
            GoTo ExitFunc
        End If
        '''''''''''''''''''''''''''''================ CHEQUEAR BANDA MAGNETICA
        'If Me.cbMag.Checked Then
        ' eject = IIf(Me.cbBack.Checked Or Me.cbFront.Checked, 0, 1)
        ' mag = New VBNetSampleCodeMag
        ' mag.MagCode(Me.cboPrn.Text, "ABCDEFGH", "12345678", "87654321", eject, msg)
        ' If msg <> "" Then GoTo ExitFunc
        ' Me.lblStatus.Text = "Magnetic Encoding: No Errors:"
        ' End If
        '''''''''''''''''''''''''''''==================
        prn = New VBNetSampleCodeGraphics
        If Me.cbFront.Checked And Not Me.cbBack.Checked Then
            prn.PrintFrontSideOnlynon(Me.cboPrn.Text, codigo, nombre, apellido, puesto, Application.StartupPath, msg)
            If msg = "" Then Me.lblStatus.Text = "Sin errores : Imprimiendo Frente unicamente"
            ' ElseIf Me.cbFront.Checked And Me.cbBack.Checked Then
            '     prn.PrintBothSides(Me.cboPrn.Text, "Front Side Text", Application.StartupPath, "Back Side Text", msg)
            '    If msg = "" Then Me.lblStatus.Text = "No Errors : Printing Both Sides"

        End If
ExitFunc:
        prn = Nothing
        mag = Nothing
        If msg <> "" Then
            Me.lblStatus.Text = msg
        End If
    End Sub
#End Region

#Region "Check Boxes"

    Private Sub cbFront_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFront.CheckedChanged
        If Not Me.cbFront.Checked Then Me.cbBack.Checked = False
    End Sub

    Private Sub cboPrn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPrn.SelectedIndexChanged

    End Sub

    Private Sub cbBack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBack.CheckedChanged
        If Me.cbBack.Checked Then Me.cbFront.Checked = True
    End Sub

#End Region


    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        buscacodigo.Clear()
        Dim mensaje As String = ""
        If (CbCodigo.Text = "") Then
            MsgBox("INGRESE CODIGO.")
        ElseIf cs.BuscaNombre(buscacodigo, CbCodigo.Text, empresa, mensaje) = True Then
            nombre = buscacodigo.Rows(0)("nombre") & " " & buscacodigo.Rows(0)("segundo_nombre")
            Lbnombre.Text = buscacodigo.Rows(0)("nombre") & " " & buscacodigo.Rows(0)("segundo_nombre")
            apellido = buscacodigo.Rows(0)("Apellido") & " " & buscacodigo.Rows(0)("segundo_apellido")
            Lbapellido.Text = buscacodigo.Rows(0)("Apellido") & " " & buscacodigo.Rows(0)("segundo_apellido")
            codigo = Format(buscacodigo.Rows(0)("codigo"), "0000")
            LbCodigo.Text = Format(buscacodigo.Rows(0)("codigo"), "0000")
            puesto = buscacodigo.Rows(0)("nombre_puesto")

            LbPuesto.Text = buscacodigo.Rows(0)("nombre_puesto")
            If cs.obtienefoto(CbCodigo.Text, empresa, foto, mensaje) = True Then
                pbfoto.Image = RedimensionarImagen(Image.FromStream(foto))
                pbfoto.Image.Save("C:\Plan_rep\foto.jpg")
            Else
                pbfoto.Image = Nothing
            End If
        Else
            MsgBox(mensaje)
        End If
    End Sub

    Private Function RedimensionarImagen(ByRef Imagen As Image) As Image
        Dim BitMap As New Bitmap(Imagen)
        Imagen = Nothing
        Imagen = BitMap.GetThumbnailImage(109, 129, Nothing, IntPtr.Zero)
        Return Imagen
    End Function
End Class
