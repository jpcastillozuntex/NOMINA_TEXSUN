Imports System.Runtime.InteropServices

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents picCapture As System.Windows.Forms.PictureBox
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents foto As System.Windows.Forms.PictureBox
    Friend WithEvents picDestination As System.Windows.Forms.PictureBox
    Friend WithEvents sfdImage As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.foto = New System.Windows.Forms.PictureBox()
        Me.picDestination = New System.Windows.Forms.PictureBox()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.foto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDestination, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picCapture
        '
        Me.picCapture.BorderStyle = BorderStyle.Fixed3D
        Me.picCapture.Location = New System.Drawing.Point(8, 48)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(528, 389)
        Me.picCapture.SizeMode = PictureBoxSizeMode.StretchImage
        Me.picCapture.TabIndex = 0
        Me.picCapture.TabStop = False
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(8, 12)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(128, 30)
        Me.lstDevices.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = AnchorStyles.None
        Me.btnSave.BackColor = Color.DeepSkyBlue
        Me.btnSave.Location = New System.Drawing.Point(387, 477)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 32)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Capturar"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = Color.DeepSkyBlue
        Me.btnStop.Location = New System.Drawing.Point(437, 515)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(79, 32)
        Me.btnStop.TabIndex = 5
        Me.btnStop.Text = "Aceptar"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'sfdImage
        '
        Me.sfdImage.FileName = "Webcam1"
        Me.sfdImage.Filter = "Bitmap|*.bmp"
        '
        'Button1
        '
        Me.Button1.Anchor = AnchorStyles.None
        Me.Button1.BackColor = Color.DeepSkyBlue
        Me.Button1.Location = New System.Drawing.Point(487, 477)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Opciones"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'foto
        '
        Me.foto.Location = New System.Drawing.Point(585, 64)
        Me.foto.Name = "foto"
        Me.foto.Size = New System.Drawing.Size(333, 320)
        Me.foto.SizeMode = PictureBoxSizeMode.StretchImage
        Me.foto.TabIndex = 7
        Me.foto.TabStop = False
        Me.foto.Visible = False
        '
        'picDestination
        '
        Me.picDestination.Location = New System.Drawing.Point(582, 34)
        Me.picDestination.Name = "picDestination"
        Me.picDestination.Size = New System.Drawing.Size(333, 431)
        Me.picDestination.SizeMode = PictureBoxSizeMode.StretchImage
        Me.picDestination.TabIndex = 8
        Me.picDestination.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(952, 555)
        Me.Controls.Add(Me.picDestination)
        Me.Controls.Add(Me.foto)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lstDevices)
        Me.Controls.Add(Me.picCapture)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Toma Fotografia"
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.foto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDestination, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Const WM_USER As Short = &H400S
    Public Const WM_CAP_START As Short = WM_USER
    Public Const WM_CAP_DLG_VIDEOSOURCE As Integer = WM_CAP_START + 42

    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30

    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0 ' Current device ID
    Dim hHwnd As Integer ' Handle to preview window

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadDeviceList()
        If lstDevices.Items.Count > 0 Then
            '  btnStart.Enabled = True
            lstDevices.SelectedIndex = 0
            ' btnStart.Enabled = True
        Else
            lstDevices.Items.Add("No Capture Device")
            'btnStart.Enabled = False
        End If
        btnStop.Enabled = False
        btnSave.Enabled = False
        picCapture.SizeMode = PictureBoxSizeMode.StretchImage
        picCapture.SizeMode = PictureBoxSizeMode.AutoSize

        iDevice = lstDevices.SelectedIndex
        OpenPreviewWindow()
    End Sub

    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        ' 
        ' Load name of all avialable devices into the lstDevices
        '
        Do
            '
            '   Get Driver name and version
            '
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            '
            ' If there was a device add device name to the list
            '
            If bReturn Then lstDevices.Items.Add(strName.Trim)
            x += 1
        Loop Until bReturn = False
    End Sub

    Private Sub OpenPreviewWindow()
        Dim iHeight As Integer = picCapture.Height
        Dim iWidth As Integer = picCapture.Width
        '
        ' Open Preview window in picturebox
        '
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
            480, picCapture.Handle.ToInt32, 0)

        '
        ' Connect to device
        '
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            '
            'Set the preview scale
            '
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            '
            'Set the preview rate in milliseconds
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            '
            'Start previewing the image from the camera
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            '
            ' Resize window to fit in picturebox
            '
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, 640, 480, _
                    SWP_NOMOVE Or SWP_NOZORDER)

            btnSave.Enabled = True
            btnStop.Enabled = True
            '   btnStart.Enabled = False
        Else
            '
            ' Error connecting to device close window
            ' 
            DestroyWindow(hHwnd)

            btnSave.Enabled = False
        End If
    End Sub

    Function capDlgVideoSource(ByVal lwnd As Integer) As Boolean
        capDlgVideoSource = SendMessage(lwnd, WM_CAP_DLG_VIDEOSOURCE, 0, 0)
    End Function

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        iDevice = lstDevices.SelectedIndex
        OpenPreviewWindow()
    End Sub

    Private Sub ClosePreviewWindow()
        '
        ' Disconnect from device
        '
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)
        '
        ' close window
        '
        DestroyWindow(hHwnd)
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        'ClosePreviewWindow()
        Try
            Dim dir As String = "c:\Plan_rep\foto_g.jpg"
            Try
                My.Computer.FileSystem.DeleteFile(dir)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            picDestination.Image.Save("c:\Plan_rep\foto_g.jpg", Imaging.ImageFormat.Jpeg)
            FrmModEmpleados.actualiza()
        Catch ex As Exception
            MsgBox(ex.Message & "hola")
        End Try
        Me.Close()
    End Sub

    Private Sub corta_imagen()
        'Grab the content of the first PictureBox and save it as a bitmap
        Dim sourcebmp As New Bitmap(foto.Image)
        '  Create an empty bitmap the size of the second PictureBox
        Dim destinationbmp As New Bitmap(picDestination.Width, picDestination.Height)
        ' Create a Graphics object for the destination
        Dim gr As Graphics = Graphics.FromImage(destinationbmp)

        ' Set the size of the area you want to copy
        'Dim selectionrectangle As New Rectangle(140, 20, 270, 400)
        Dim selectionrectangle As New Rectangle(140, 20, 300, 400)
        ' Set the size of the destination rectangle to match the size of the second PictureBox
        Dim destinationrectangle As New Rectangle(0, 0, picDestination.Width, picDestination.Height)

        ' Draw selected area on to the destination bitmap.
        gr.DrawImage(sourcebmp, destinationrectangle, selectionrectangle, GraphicsUnit.Pixel)

        ' Set the drawn destination bitmap as the image of the second PictureBox
        picDestination.Image = destinationbmp

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim data As IDataObject
        Dim bmap As Image
        '
        ' Copy image to clipboard
        '
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 640, 480)
        '
        ' Get image from clipboard and convert it to a bitmap
        '
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            '            Dim imagen As New Bitmap(New Bitmap(bmap), 320, 288)
            '           imagen.Save("c:\Plan_rep\foto1", System.Drawing.Imaging.ImageFormat.Jpeg)
            foto.Image = bmap
            'ClosePreviewWindow()
            'btnSave.Enabled = False
            'btnStop.Enabled = False
            'btnStart.Enabled = True
            'If sfdImage.ShowDialog = DialogResult.OK Then
            ' bmap.Save(sfdImage.FileName, Imaging.ImageFormat.Bmp)
            'End If
        End If
        corta_imagen()
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnStop.Enabled Then
            ClosePreviewWindow()
        End If
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        capDlgVideoSource(hHwnd)
    End Sub




End Class
