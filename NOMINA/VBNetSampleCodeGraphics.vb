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
'File: VBNetSampleCodeGraphics.vb
'Description: Example code showing how to print graphics and text to a card.
'$Revision: 1 $
'$Date: 2010/12/08 $
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Option Explicit On

Imports System.Threading
Imports System.IO
Imports System.Text

Public Class VBNetSampleCodeGraphics
    Dim cs As New ClsConsultas
    Dim log As New StringBuilder
#Region "Enumerations"

    Enum Font_Style As Integer
        Bold = 1
        Italic = 2
        Underline = 4
        StrikeThru = 8
    End Enum
#End Region

#Region "SDK DLL Version"

    Public Function GetSDKVersion() As String

        Dim engLevel As Integer = 0
        Dim major As Integer = 0
        Dim minor As Integer = 0

        Dim g = New dllGraphics

        On Error GoTo ExitFunc

        g.GetSDKVer(major, minor, engLevel)

ExitFunc:
        g = Nothing
        If major + minor + engLevel = 0 Then
            GetSDKVersion = ""
        Else
            GetSDKVersion = major.ToString() & "." & minor.ToString() & "." & engLevel.ToString()
        End If

    End Function

#End Region

#Region "Is Printer Ready"

    ' Waits for print spooler to clear ----------------------------------------------------------------------

    Public Function IsPrinterReady(ByVal drvName As String, ByVal seconds As Integer) As Boolean

        Dim ready As Boolean = False
        Dim errValue As Integer = 0

        Dim g As New dllGraphics

        For i As Integer = 0 To seconds - 1
            If g.IsPrinterReady(drvName, errValue) <> 0 Then
                ready = True
                Exit For
            End If
            Thread.Sleep(1000)
        Next

        g = Nothing
        IsPrinterReady = ready

    End Function

#End Region

#Region "Printing Example Code"
    ' Printing on front side only ---------------------------------------------------------------------------

    Public Sub PrintFrontSideOnly(ByVal drvName As String, ByVal codigo As String, ByVal nombre As String, ByVal apellido As String, ByVal puesto As String, ByVal imgPath As String, _
                                 ByRef msg As String)
        msg = ""
        On Error GoTo exitFunc
        ' Creates a graphic buffer
        Dim g As New dllGraphics
        Dim errValue As Integer
        Dim largo As Integer
        Dim l_letra As Integer
        If g.InitGraphics(drvName, errValue) = 0 Then
            msg = "Printing InitGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Places an Image into the graphic buffer for front side
        If g.DrawImage("C:\Plan_rep\be.png", 7, 5, 630, 1050, errValue) = 0 Then
            msg = "Printing DrawImage Error: " & errValue.ToString()
            GoTo ExitFunc
        End If
        If g.DrawImage("C:\Plan_rep\" & codigo & ".jpg", 145, 230, 370, 430, errValue) = 0 Then
            msg = "Printing DrawImage Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Draws Text into the graphic buffer for front side
        Dim fontStyle As Integer = Font_Style.Bold


        If g.DrawText(15, 680, nombre, "Arial", 12, fontStyle, &HFFFFFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        If g.DrawText(15, 740, apellido, "Arial", 12, fontStyle, &HFFFFFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If


        largo = puesto.Length
        l_letra = 626 / 22
        Dim p = (l_letra * largo) / 2
        Dim ancho = CInt(313 - p)

        If g.DrawText(ancho, 840, puesto, "Arial", 11, fontStyle, &HFFFFFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If
        If g.DrawText(250, 925, codigo, "Arial", 16, fontStyle, &HFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If
        ' Sends barcode data to the monochrome buffer
        ' If g.DrawBarcode(35, 500, 0, 0, 1, 3, 30, 1, "12345678", errValue) = 0 Then
        ' msg = "Printing DrawBarcode Error: " & errValue.ToString()
        ' GoTo ExitFunc
        ' End If
        ' Prints the graphic buffer (front side)

        If g.PrintGraphics(errValue) = 0 Then
            msg = "Printing PrintGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Releases the graphics buffer
        If g.CloseGraphics(errValue) = 0 Then
            msg = "Printing CloseGraphics Error: " & errValue.ToString()
        End If
exitFunc:
        g = Nothing

    End Sub

    Public Sub PrintFrontSideOnlynon(ByVal drvName As String, ByVal codigo As String, ByVal nombre As String, ByVal apellido As String, ByVal puesto As String, ByVal imgPath As String, ByRef msg As String)
        msg = ""
        On Error GoTo ExitFunc
        ' Creates a graphic buffer
        Dim g As New dllGraphics
        Dim errValue As Integer
        Dim largo As Integer
        Dim l_letra As Integer
        If g.InitGraphics(drvName, errValue) = 0 Then
            msg = "Printing InitGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Places an Image into the graphic buffer for front side
        If g.DrawImage("C:\Plan_rep\be.png", 7, 5, 630, 1050, errValue) = 0 Then
            msg = "Printing DrawImage Error: " & errValue.ToString()
            GoTo ExitFunc
        End If
        If g.DrawImage("C:\Plan_rep\foto.jpg", 145, 230, 370, 430, errValue) = 0 Then
            msg = "Printing DrawImage Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Draws Text into the graphic buffer for front side
        Dim fontStyle As Integer = Font_Style.Bold


        If g.DrawText(15, 680, nombre, "Arial", 12, fontStyle, &HFFFFFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        If g.DrawText(15, 740, apellido, "Arial", 12, fontStyle, &HFFFFFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If


        largo = puesto.Length
        l_letra = 626 / 22
        Dim p = (l_letra * largo) / 2
        Dim ancho = CInt(313 - p)

        If g.DrawText(ancho, 840, puesto, "Arial", 11, fontStyle, &HFFFFFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If
        If g.DrawText(250, 925, codigo, "Arial", 16, fontStyle, &HFF, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If
        ' Sends barcode data to the monochrome buffer
        ' If g.DrawBarcode(35, 500, 0, 0, 1, 3, 30, 1, "12345678", errValue) = 0 Then
        ' msg = "Printing DrawBarcode Error: " & errValue.ToString()
        ' GoTo ExitFunc
        ' End If
        ' Prints the graphic buffer (front side)

        If g.PrintGraphics(errValue) = 0 Then
            msg = "Printing PrintGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Releases the graphics buffer
        If g.CloseGraphics(errValue) = 0 Then
            msg = "Printing CloseGraphics Error: " & errValue.ToString()
        End If
ExitFunc:
        g = Nothing

    End Sub

    Public Sub PrintBothSides(ByVal drvName As String, ByVal frontText As String, ByVal imgPath As String, _
                              ByVal backText As String, ByRef msg As String)

        msg = ""

        On Error GoTo ExitFunc

        ' Creates a graphic buffer

        Dim g As New dllGraphics
        Dim errValue As Integer

        If g.InitGraphics(drvName, errValue) = 0 Then
            msg = "Printing InitGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Draws Text into the graphic buffer for front side

        Dim fontStyle As Integer = Font_Style.Bold _
                                    Or Font_Style.Italic _
                                    Or Font_Style.StrikeThru _
                                    Or Font_Style.Underline

        If g.DrawText(35, 575, frontText, "Arial", 12, fontStyle, &HFF0000, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Places an Image into the graphic buffer for front side

        If g.DrawImage(imgPath & "C:\Plan_rep\frente.png", 7, 5, 1050, 630, errValue) = 0 Then
            msg = "Printing DrawImage Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Sends barcode data to the monochrome buffer

        If g.DrawBarcode(35, 500, 0, 0, 1, 3, 30, 1, "", errValue) = 0 Then
            msg = "Printing DrawBarcode Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        'Prints the graphic buffer (front side)

        If g.PrintGraphics(errValue) = 0 Then
            msg = "Printing PrintGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Clears the graphic buffer

        If g.ClearGraphics(errValue) = 0 Then
            msg = "Printing ClearGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Draws text into the graphic buffer (back side)

        If g.DrawText(35, 575, backText, "Arial", 12, fontStyle, 0, errValue) = 0 Then
            msg = "Printing DrawText Error: " & errValue.ToString()
            GoTo ExitFunc
        End If

        ' Prints the graphic buffer (back side)

        If g.PrintGraphics(errValue) = 0 Then
            msg = "Printing PrintGraphics Error: " & errValue.ToString()
            GoTo ExitFunc
        End If


        If g.DrawImage(imgPath & "C:\Plan_rep\atras.png", 7, 5, 1050, 630, errValue) = 0 Then

            msg = "Printing DrawImage Error: " & errValue.ToString()
            GoTo ExitFunc
        End If


        ' Releases the graphics buffer

        If g.CloseGraphics(errValue) = 0 Then
            msg = "Printing CloseGraphics Error: " & errValue.ToString()
        End If

ExitFunc:
        g = Nothing
    End Sub


#End Region
    Private Sub GrabarLog(ByVal script As String)
        Dim Texto As String = String.Concat(script)
        log.AppendLine(Texto)
    End Sub

    Private Sub AbrirLog()
        log = New StringBuilder
    End Sub

    Private Sub eliminar_archivo(nombre As String)
        Dim dsj As New MsgBoxResult
        Dim file As Boolean
        file = My.Computer.FileSystem.FileExists("c:\Plan_rep\ordenes\" & nombre & ".csv")
        If file = True Then
            dsj = MsgBox("El Archivo ya existe, Desea Reemplazarlo", MsgBoxStyle.OkCancel, "")
            If dsj = MsgBoxResult.Cancel Then
                Exit Sub
            ElseIf dsj = MsgBoxResult.Ok Then
                My.Computer.FileSystem.DeleteFile("c:\Plan_rep\ordenes\" & nombre & ".csv")
                CerrarLog(nombre)
            End If
        Else
            CerrarLog(nombre)
        End If
    End Sub

    Private Sub CerrarLog(nombre As String)
        Try
            Dim Escritor As TextWriter = New StreamWriter("c:\Plan_rep\ordenes\" & nombre & ".csv", True)
            Escritor.WriteLine(log.ToString)
            Escritor.Close()
        Catch ex As Exception
            EventLog.WriteEntry("MonitorServicio", "Error: " & ex.Message.ToString)
        End Try
        MsgBox("Orden creada Correctamente")
    End Sub

End Class
