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
'File: VBNetSampleCodeMag.vb
'Description: Example code showing how to apply magnetic encoding.
'$Revision: 1 $
'$Date: 2010/12/08 $
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Option Explicit On

Imports System.Text

Public Class VBNetSampleCodeMag

#Region "SDK DLL Version"

    Public Function GetSDKVersion() As String

        Dim engLevel As Integer = 0
        Dim major As Integer = 0
        Dim minor As Integer = 0

        Dim p = New dllPrinter

        On Error GoTo ExitFunc

        p.GetSDKVer(major, minor, engLevel)

ExitFunc:
        p = Nothing
        If major + minor + engLevel = 0 Then
            GetSDKVersion = ""
        Else
            GetSDKVersion = major.ToString() & "." & minor.ToString() & "." & engLevel.ToString()
        End If

    End Function

#End Region

#Region "Magnetic Encoding"

    ' Magnetic Encoding Example -----------------------------------------------------------------------------

    Public Sub MagCode(ByVal drvName As String, ByVal track1 As String, ByVal track2 As String, _
                                ByVal track3 As String, ByVal eject As Boolean, ByRef msg As String)

        msg = ""

        Dim prn As New dllPrinter
        Dim errValue As Integer = 0

        ' Opens a connection to a printer driver

        If prn.Open(drvName, errValue) = 0 Then
            msg = "Mag Encoder Open Error: " & errValue.ToString()
            GoTo ExitSub
        End If

        ' Encodes tracks 1,2 3
        '     if track data is ""; that track is not encoded

        Dim trksToWrite = 0
        If track1 <> "" Then trksToWrite = 1
        If track2 <> "" Then trksToWrite = trksToWrite Or 2
        If track3 <> "" Then trksToWrite = trksToWrite Or 4

        Dim a As New ASCIIEncoding()

        Dim inTrk1() As Byte = a.GetBytes(track1)
        Dim inTrk2() As Byte = a.GetBytes(track2)
        Dim inTrk3() As Byte = a.GetBytes(track3)

        If prn.WriteMag(trksToWrite, inTrk1, inTrk2, inTrk3, errValue) = 0 Then
            msg = "Mag Encoder Write Error: " & errValue.ToString()
            GoTo ExitSub
        End If

        ' Reads All Three Tracks

        Dim outTrk1(32) As Byte
        Dim outTrk2(32) As Byte
        Dim outTrk3(32) As Byte

        If prn.ReadMag(7, outTrk1, outTrk2, outTrk3, errValue) = 0 Then
            msg = "Mag Encoder Read Error: " & errValue.ToString()
            GoTo ExitSub
        End If

        Dim passed As Boolean = True
        For i As Integer = 0 To track1.Length - 1
            If inTrk1(i) <> outTrk1(i) Or inTrk2(i) <> outTrk2(i) Or inTrk3(i) <> outTrk3(i) Then
                passed = False
                Exit For
            End If
        Next

        If Not passed Then msg = "Mag Written vs. Read Error"

ExitSub:

        If eject Then prn.EjectCard(errValue)
        prn.Close(errValue)
        prn = Nothing

    End Sub

#End Region
End Class
