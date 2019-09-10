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
'File: dllGraphics.vb
'Description: A wrapper class for the Value/Performance Class SDK's Graphics functionality.
'$Revision: 1 $
'$Date: 2010/12/08 $
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports System.Text
Imports System.Runtime.InteropServices

Public Class dllGraphics

#Region "Declarations"

    ' Private Variables -------------------------------------------------------------------------------------

    Private _handle As IntPtr

#End Region

#Region "DLLImport"

    ' Check Print Spooler -----------------------------------------------------------------------------------

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIIsPrinterReady", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDIIsPrinterReady(ByVal printerName As String, ByRef err As Integer) As Integer
    End Function

    ' ZBRGraphics.dll Version -------------------------------------------------------------------------------

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIGetSDKVer", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDISDKVer(ByRef major As Integer, ByRef minor As Integer, _
                                            ByRef engLevel As Integer) As Integer
    End Function

    ' Initialization ----------------------------------------------------------------------------------------

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIInitGraphics", CharSet:=CharSet.Ansi, _
            ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDIInitGraphics(ByVal printerName As String, ByRef printerDC As IntPtr, _
                                                ByRef err As Integer) As Integer
    End Function

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDICloseGraphics", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDICloseGraphics(ByVal printerDC As IntPtr, ByRef err As Integer) As Integer
    End Function

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIClearGraphics", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDIClearGraphics(ByRef err As Integer) As Integer
    End Function

    ' Print -------------------------------------------------------------------------------------------------

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIPrintGraphics", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDIPrintGraphics(ByVal printerDC As IntPtr, ByRef err As Integer) As Integer
    End Function

    ' Draw --------------------------------------------------------------------------------------------------

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIDrawText", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDIDrawText(ByVal x As Integer, ByVal y As Integer, ByVal text As String, _
                                          ByVal font As String, ByVal fontSize As Integer, _
                                          ByVal fontStyle As Integer, ByVal fontColor As Integer, _
                                          ByRef err As Integer) As Integer
    End Function

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIDrawImageRect", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDIDrawImageRect(ByVal filename As String, ByVal x As Integer, _
                                               ByVal y As Integer, ByVal width As Integer, _
                                               ByVal height As Integer, ByRef err As Integer) As Integer
    End Function

    <DllImport("ZBRGraphics.dll", EntryPoint:="ZBRGDIDrawBarCode", CharSet:=CharSet.Ansi, _
            ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGDIDrawBarcode(ByVal x As Integer, ByVal y As Integer, _
                                            ByVal rotation As Integer, ByVal barcodeType As Integer, _
                                            ByVal widthRatio As Integer, ByVal multiplier As Integer, _
                                            ByVal height As Integer, ByVal textUnder As Integer, _
                                            ByVal data() As Byte, ByRef err As Integer) As Integer
    End Function

#End Region

#Region "Print Spooler"

    ' Checks to see if any jobs are in the print spooler ----------------------------------------------------

    Public Function IsPrinterReady(ByVal drvName As String, ByRef errValue As Integer) As Integer
        IsPrinterReady = ZBRGDIIsPrinterReady(drvName, errValue)
    End Function

#End Region

#Region "SDK DLL Version"

    ' Gets ZBRGrphics.dll Version ---------------------------------------------------------------------------

    Public Sub GetSDKVer(ByRef major As Integer, ByRef minor As Integer, ByRef engLevel As Integer)
        ZBRGDISDKVer(major, minor, engLevel)
    End Sub

#End Region

#Region "Graphics Initialization"

    ' Creates a device context and initializes a graphic buffer ---------------------------------------------

    Public Function InitGraphics(ByVal drvName As String, ByRef errValue As Integer) As Integer
        InitGraphics = ZBRGDIInitGraphics(drvName, _handle, errValue)
    End Function

    ' Releases the device context and the graphic buffer ----------------------------------------------------

    Public Function CloseGraphics(ByRef errValue As Integer) As Integer
        CloseGraphics = ZBRGDICloseGraphics(_handle, errValue)
    End Function

    ' Clears the graphic buffer -----------------------------------------------------------------------------

    Public Function ClearGraphics(ByRef errValue As Integer) As Integer
        ClearGraphics = ZBRGDIClearGraphics(errValue)
    End Function

#End Region

#Region "Draw"

    ' Draws text into the graphic buffer --------------------------------------------------------------------

    Public Function DrawText(ByVal x As Integer, ByVal y As Integer, ByVal text As String, _
                                ByVal font As String, ByVal fontSize As Integer, ByVal fontStyle As Integer, _
                                ByVal textColor As Integer, ByRef errValue As Integer) As Integer

        DrawText = ZBRGDIDrawText(x, y, text, font, fontSize, fontStyle, textColor, errValue)
    End Function

    ' Places a file image into the graphic buffer -----------------------------------------------------------

    Public Function DrawImage(ByVal filename As String, ByVal x As Integer, ByVal y As Integer, _
                                ByVal width As Integer, ByVal height As Integer, _
                                ByRef errValue As Integer) As Integer

        DrawImage = ZBRGDIDrawImageRect(filename, x, y, width, height, errValue)

    End Function

    ' Draws a barcode into the monochrome buffer ------------------------------------------------------------

    Public Function DrawBarcode(ByVal x As Integer, ByVal y As Integer, ByVal rotation As Integer, _
                                    ByVal barcodeType As Integer, ByVal widthRatio As Integer, _
                                    ByVal multiplier As Integer, ByVal height As Integer, _
                                    ByVal textUnder As Integer, ByVal barcodeData As String, _
                                    ByRef errValue As Integer) As Integer


        Dim a As New ASCIIEncoding
        DrawBarcode = ZBRGDIDrawBarcode(x, y, rotation, barcodeType, widthRatio, multiplier, height, textUnder, _
                                            a.GetBytes(barcodeData), errValue)
    End Function

#End Region

#Region "Print"

    ' Prints the graphis buffer data ------------------------------------------------------------------------

    Public Function PrintGraphics(ByRef errValue As Integer) As Integer
        PrintGraphics = ZBRGDIPrintGraphics(_handle, errValue)
    End Function

#End Region

End Class
