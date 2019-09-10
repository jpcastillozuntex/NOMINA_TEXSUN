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
'File: dllPrinter.vb
'Description: A wrapper class for the Value/Performance Class SDK's Printer/Magnetic Encoding functionality.
'$Revision: 1 $
'$Date: 2010/12/08 $
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports System.Runtime.InteropServices

Public Class dllPrinter

#Region "Declarations"

    ' Local Variables ---------------------------------------------------------------------------------------

    Private _handle As IntPtr
    Private _prnType As Integer

#End Region

#Region "DllImports"

    ' ZBRPrinter.dll Version

    <DllImport("ZBRPrinter.dll", EntryPoint:="ZBRPRNGetSDKVer", CharSet:=CharSet.Ansi, _
        ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Sub ZBRPRNGetSDKVer(ByRef major As Integer, _
                                        ByRef minor As Integer, _
                                        ByRef engLevel As Integer)
    End Sub

    ' Handle

    <DllImport("ZBRPrinter.dll", EntryPoint:="ZBRGetHandle", CharSet:=CharSet.Ansi, ExactSpelling:=True, _
        CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRGetHandle(ByRef prnHandle As IntPtr, _
                                            ByVal devName As String, _
                                            ByRef prnType As Integer, _
                                            ByRef errValue As Integer) As Integer
    End Function

    <DllImport("ZBRPrinter.dll", EntryPoint:="ZBRCloseHandle", CharSet:=CharSet.Ansi, _
        ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRCloseHandle(ByVal prnHandle As IntPtr, _
                                            ByRef errValue As Integer) As Integer
    End Function

    ' Card Movement

    <DllImport("ZBRPrinter.dll", EntryPoint:="ZBRPRNEjectCard", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRPRNEjectCard(ByVal prnHandle As IntPtr, _
                                            ByVal prnType As Integer, _
                                            ByRef errValue As Integer) As Integer
    End Function

    ' Magnetic Encoding

    <DllImport("ZBRPrinter.dll", EntryPoint:="ZBRPRNReadMag", CharSet:=CharSet.Ansi, _
                ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRPRNReadMag(ByVal prnHandle As IntPtr, _
                                            ByVal prnType As Integer, _
                                            ByVal trksToRead As Integer, _
                                            ByVal trkBuf1() As Byte, _
                                            ByRef sz1 As Integer, _
                                            ByVal trkBuf2() As Byte, _
                                            ByRef sz2 As Integer, _
                                            ByVal trkBuf3() As Byte, _
                                            ByRef sz3 As Integer, _
                                            ByRef errValue As Integer) As Integer
    End Function

    <DllImport("ZBRPrinter.dll", EntryPoint:="ZBRPRNWriteMag", CharSet:=CharSet.Ansi, ExactSpelling:=True, _
        CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ZBRPRNWriteMag(ByVal prnHandle As IntPtr, _
                                            ByVal prnType As Integer, _
                                            ByVal trksToWrite As Integer, _
                                            ByVal trk1Buf() As Byte, _
                                            ByVal trk2Buf() As Byte, _
                                            ByVal trk3Buf() As Byte, _
                                            ByRef errValue As Integer) As Integer
    End Function

#End Region

#Region "SDK Information"

    ' ZBRPrinter.dll Version --------------------------------------------------------------------------------

    Public Sub GetSDKVer(ByRef major As Integer, ByRef minor As Integer, ByRef engLevel As Integer)
        ZBRPRNGetSDKVer(major, minor, engLevel)
    End Sub

#End Region

#Region "Handle"

    ' Opens a connection to a printer driver ----------------------------------------------------------------

    Public Function Open(ByVal drvName As String, ByRef errValue As Integer) As Integer
        Open = ZBRGetHandle(_handle, drvName, _prnType, errValue)
    End Function

    ' Closes the connection to a printer driver -------------------------------------------------------------

    Public Function Close(ByRef errValue As Integer) As Integer
        Close = ZBRCloseHandle(_handle, errValue)
    End Function

#End Region

#Region "Card Movement"

    ' Ejects a card from a printer --------------------------------------------------------------------------

    Public Function EjectCard(ByRef errValue As Integer) As Integer
        EjectCard = ZBRPRNEjectCard(_handle, _prnType, errValue)
    End Function

#End Region

#Region "Magnetic Encoding"

    Public Function ReadMag(ByVal tracks As Integer, _
                                ByVal trkBuf1() As Byte, ByVal trkBuf2() As Byte, ByVal trkBuf3() As Byte, _
                                ByRef errValue As Integer) As Integer
        Dim sz1, sz2, sz3 As Integer
        ReadMag = ZBRPRNReadMag(_handle, _prnType, tracks, trkBuf1, sz1, trkBuf2, sz2, trkBuf3, sz3, errValue)

    End Function

    Public Function WriteMag(ByVal trksToWrite As Integer, ByVal trk1Buf() As Byte, _
                                ByVal trk2Buf() As Byte, ByVal trk3Buf() As Byte, _
                                ByRef errValue As Integer) As Integer

        WriteMag = ZBRPRNWriteMag(_handle, _prnType, trksToWrite, trk1Buf, trk2Buf, trk3Buf, errValue)

    End Function

#End Region

End Class
