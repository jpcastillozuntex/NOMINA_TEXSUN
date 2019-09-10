<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCarnetcirculacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCarnetcirculacion))
        Me.gbMag = New System.Windows.Forms.GroupBox()
        Me.cbMag = New System.Windows.Forms.CheckBox()
        Me.gbPrint = New System.Windows.Forms.GroupBox()
        Me.cbBack = New System.Windows.Forms.CheckBox()
        Me.cbFront = New System.Windows.Forms.CheckBox()
        Me.gbPrinters = New System.Windows.Forms.GroupBox()
        Me.cboPrn = New System.Windows.Forms.ComboBox()
        Me.lblVersions = New System.Windows.Forms.Label()
        Me.gbDLLVersions = New System.Windows.Forms.GroupBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.pbfoto = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbCodigo = New System.Windows.Forms.ComboBox()
        Me.BtConsultar = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.LbCodigo = New System.Windows.Forms.Label()
        Me.Lbnombre = New System.Windows.Forms.Label()
        Me.Lbapellido = New System.Windows.Forms.Label()
        Me.LbPuesto = New System.Windows.Forms.Label()
        Me.Lbpue = New System.Windows.Forms.TextBox()
        Me.Lbape = New System.Windows.Forms.TextBox()
        Me.TxtNom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Txtcod = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChB1 = New System.Windows.Forms.CheckBox()
        Me.gbMag.SuspendLayout()
        Me.gbPrint.SuspendLayout()
        Me.gbPrinters.SuspendLayout()
        Me.gbDLLVersions.SuspendLayout()
        CType(Me.pbfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMag
        '
        Me.gbMag.Controls.Add(Me.cbMag)
        Me.gbMag.Enabled = False
        Me.gbMag.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMag.Location = New System.Drawing.Point(13, 355)
        Me.gbMag.Name = "gbMag"
        Me.gbMag.Size = New System.Drawing.Size(17, 21)
        Me.gbMag.TabIndex = 17
        Me.gbMag.TabStop = False
        Me.gbMag.Text = "Magnetic Encoder:"
        Me.gbMag.Visible = False
        '
        'cbMag
        '
        Me.cbMag.AutoSize = True
        Me.cbMag.Location = New System.Drawing.Point(10, 30)
        Me.cbMag.Name = "cbMag"
        Me.cbMag.Size = New System.Drawing.Size(66, 20)
        Me.cbMag.TabIndex = 6
        Me.cbMag.Text = "Check"
        Me.cbMag.UseVisualStyleBackColor = True
        '
        'gbPrint
        '
        Me.gbPrint.Controls.Add(Me.cbBack)
        Me.gbPrint.Controls.Add(Me.cbFront)
        Me.gbPrint.Enabled = False
        Me.gbPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPrint.Location = New System.Drawing.Point(48, 335)
        Me.gbPrint.Name = "gbPrint"
        Me.gbPrint.Size = New System.Drawing.Size(26, 37)
        Me.gbPrint.TabIndex = 16
        Me.gbPrint.TabStop = False
        Me.gbPrint.Text = "Print Selections:"
        Me.gbPrint.Visible = False
        '
        'cbBack
        '
        Me.cbBack.AutoSize = True
        Me.cbBack.Location = New System.Drawing.Point(109, 30)
        Me.cbBack.Name = "cbBack"
        Me.cbBack.Size = New System.Drawing.Size(58, 20)
        Me.cbBack.TabIndex = 4
        Me.cbBack.Text = "Back"
        Me.cbBack.UseVisualStyleBackColor = True
        '
        'cbFront
        '
        Me.cbFront.AutoSize = True
        Me.cbFront.Location = New System.Drawing.Point(9, 30)
        Me.cbFront.Name = "cbFront"
        Me.cbFront.Size = New System.Drawing.Size(60, 20)
        Me.cbFront.TabIndex = 3
        Me.cbFront.Text = "Front"
        Me.cbFront.UseVisualStyleBackColor = True
        '
        'gbPrinters
        '
        Me.gbPrinters.Controls.Add(Me.cboPrn)
        Me.gbPrinters.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPrinters.Location = New System.Drawing.Point(16, 187)
        Me.gbPrinters.Name = "gbPrinters"
        Me.gbPrinters.Size = New System.Drawing.Size(278, 61)
        Me.gbPrinters.TabIndex = 15
        Me.gbPrinters.TabStop = False
        Me.gbPrinters.Text = "Impresora"
        '
        'cboPrn
        '
        Me.cboPrn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrn.Location = New System.Drawing.Point(3, 23)
        Me.cboPrn.Name = "cboPrn"
        Me.cboPrn.Size = New System.Drawing.Size(242, 22)
        Me.cboPrn.TabIndex = 1
        '
        'lblVersions
        '
        Me.lblVersions.AutoSize = True
        Me.lblVersions.Location = New System.Drawing.Point(16, 30)
        Me.lblVersions.Name = "lblVersions"
        Me.lblVersions.Size = New System.Drawing.Size(104, 16)
        Me.lblVersions.TabIndex = 0
        Me.lblVersions.Text = "No DLLs Found"
        '
        'gbDLLVersions
        '
        Me.gbDLLVersions.Controls.Add(Me.lblVersions)
        Me.gbDLLVersions.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDLLVersions.Location = New System.Drawing.Point(16, 60)
        Me.gbDLLVersions.Name = "gbDLLVersions"
        Me.gbDLLVersions.Size = New System.Drawing.Size(29, 15)
        Me.gbDLLVersions.TabIndex = 20
        Me.gbDLLVersions.TabStop = False
        Me.gbDLLVersions.Text = "DLL Versions:"
        Me.gbDLLVersions.Visible = False
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSubmit.Location = New System.Drawing.Point(437, 335)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(65, 36)
        Me.btnSubmit.TabIndex = 14
        Me.btnSubmit.Text = "Imprimir"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'pbfoto
        '
        Me.pbfoto.BackgroundImage = CType(resources.GetObject("pbfoto.BackgroundImage"), System.Drawing.Image)
        Me.pbfoto.Location = New System.Drawing.Point(362, 6)
        Me.pbfoto.Name = "pbfoto"
        Me.pbfoto.Padding = New System.Windows.Forms.Padding(47, 68, 0, 0)
        Me.pbfoto.Size = New System.Drawing.Size(200, 316)
        Me.pbfoto.TabIndex = 21
        Me.pbfoto.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 24)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "CODIGO:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbCodigo
        '
        Me.CbCodigo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCodigo.FormattingEnabled = True
        Me.CbCodigo.Location = New System.Drawing.Point(74, 11)
        Me.CbCodigo.Name = "CbCodigo"
        Me.CbCodigo.Size = New System.Drawing.Size(112, 24)
        Me.CbCodigo.TabIndex = 100
        '
        'BtConsultar
        '
        Me.BtConsultar.BackgroundImage = CType(resources.GetObject("BtConsultar.BackgroundImage"), System.Drawing.Image)
        Me.BtConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtConsultar.Location = New System.Drawing.Point(192, 6)
        Me.BtConsultar.Name = "BtConsultar"
        Me.BtConsultar.Size = New System.Drawing.Size(41, 32)
        Me.BtConsultar.TabIndex = 102
        Me.BtConsultar.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(5, 21)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(63, 16)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "lblStatus"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.lblStatus)
        Me.gbStatus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gbStatus.Location = New System.Drawing.Point(16, 254)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(277, 49)
        Me.gbStatus.TabIndex = 19
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Estado:"
        '
        'LbCodigo
        '
        Me.LbCodigo.Location = New System.Drawing.Point(416, 284)
        Me.LbCodigo.Name = "LbCodigo"
        Me.LbCodigo.Size = New System.Drawing.Size(95, 20)
        Me.LbCodigo.TabIndex = 103
        Me.LbCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbnombre
        '
        Me.Lbnombre.BackColor = System.Drawing.Color.Transparent
        Me.Lbnombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbnombre.Location = New System.Drawing.Point(375, 208)
        Me.Lbnombre.Name = "Lbnombre"
        Me.Lbnombre.Size = New System.Drawing.Size(176, 18)
        Me.Lbnombre.TabIndex = 104
        '
        'Lbapellido
        '
        Me.Lbapellido.BackColor = System.Drawing.Color.Transparent
        Me.Lbapellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbapellido.Location = New System.Drawing.Point(375, 231)
        Me.Lbapellido.Name = "Lbapellido"
        Me.Lbapellido.Size = New System.Drawing.Size(176, 18)
        Me.Lbapellido.TabIndex = 105
        '
        'LbPuesto
        '
        Me.LbPuesto.BackColor = System.Drawing.Color.Transparent
        Me.LbPuesto.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPuesto.Location = New System.Drawing.Point(390, 254)
        Me.LbPuesto.Name = "LbPuesto"
        Me.LbPuesto.Size = New System.Drawing.Size(142, 18)
        Me.LbPuesto.TabIndex = 106
        Me.LbPuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbpue
        '
        Me.Lbpue.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbpue.Location = New System.Drawing.Point(117, 150)
        Me.Lbpue.Name = "Lbpue"
        Me.Lbpue.Size = New System.Drawing.Size(178, 24)
        Me.Lbpue.TabIndex = 119
        '
        'Lbape
        '
        Me.Lbape.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbape.Location = New System.Drawing.Point(117, 125)
        Me.Lbape.Name = "Lbape"
        Me.Lbape.Size = New System.Drawing.Size(178, 24)
        Me.Lbape.TabIndex = 118
        '
        'TxtNom
        '
        Me.TxtNom.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNom.Location = New System.Drawing.Point(117, 100)
        Me.TxtNom.Name = "TxtNom"
        Me.TxtNom.Size = New System.Drawing.Size(178, 24)
        Me.TxtNom.TabIndex = 117
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Puesto:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Apelldio"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Nombre:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(617, 322)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 54)
        Me.Button1.TabIndex = 120
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Txtcod
        '
        Me.Txtcod.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcod.Location = New System.Drawing.Point(117, 75)
        Me.Txtcod.Name = "Txtcod"
        Me.Txtcod.Size = New System.Drawing.Size(178, 24)
        Me.Txtcod.TabIndex = 122
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Codigo:"
        '
        'ChB1
        '
        Me.ChB1.AutoSize = True
        Me.ChB1.Location = New System.Drawing.Point(75, 41)
        Me.ChB1.Name = "ChB1"
        Me.ChB1.Size = New System.Drawing.Size(61, 17)
        Me.ChB1.TabIndex = 123
        Me.ChB1.Text = "Manual"
        Me.ChB1.UseVisualStyleBackColor = True
        '
        'frmCarnetConfi
        '
        Me.AcceptButton = Me.BtConsultar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 384)
        Me.Controls.Add(Me.ChB1)
        Me.Controls.Add(Me.Txtcod)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Lbpue)
        Me.Controls.Add(Me.Lbape)
        Me.Controls.Add(Me.TxtNom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lbnombre)
        Me.Controls.Add(Me.LbPuesto)
        Me.Controls.Add(Me.Lbapellido)
        Me.Controls.Add(Me.LbCodigo)
        Me.Controls.Add(Me.BtConsultar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CbCodigo)
        Me.Controls.Add(Me.pbfoto)
        Me.Controls.Add(Me.gbDLLVersions)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.gbMag)
        Me.Controls.Add(Me.gbPrint)
        Me.Controls.Add(Me.gbPrinters)
        Me.Controls.Add(Me.gbStatus)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Name = "frmCarnetConfi"
        Me.ShowIcon = False
        Me.Text = "Impresion de Carnet"
        Me.gbMag.ResumeLayout(False)
        Me.gbMag.PerformLayout()
        Me.gbPrint.ResumeLayout(False)
        Me.gbPrint.PerformLayout()
        Me.gbPrinters.ResumeLayout(False)
        Me.gbDLLVersions.ResumeLayout(False)
        Me.gbDLLVersions.PerformLayout()
        CType(Me.pbfoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents gbMag As System.Windows.Forms.GroupBox
    Private WithEvents cbMag As System.Windows.Forms.CheckBox
    Private WithEvents gbPrint As System.Windows.Forms.GroupBox
    Private WithEvents cbBack As System.Windows.Forms.CheckBox
    Private WithEvents cbFront As System.Windows.Forms.CheckBox
    Private WithEvents gbPrinters As System.Windows.Forms.GroupBox
    Private WithEvents cboPrn As System.Windows.Forms.ComboBox
    Private WithEvents lblVersions As System.Windows.Forms.Label
    Private WithEvents gbDLLVersions As System.Windows.Forms.GroupBox
    Private WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents pbfoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbCodigo As System.Windows.Forms.ComboBox
    Friend WithEvents BtConsultar As System.Windows.Forms.Button
    Private WithEvents lblStatus As System.Windows.Forms.Label
    Private WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents LbCodigo As System.Windows.Forms.Label
    Friend WithEvents Lbnombre As System.Windows.Forms.Label
    Friend WithEvents Lbapellido As System.Windows.Forms.Label
    Friend WithEvents LbPuesto As System.Windows.Forms.Label
    Friend WithEvents Lbpue As System.Windows.Forms.TextBox
    Friend WithEvents Lbape As System.Windows.Forms.TextBox
    Friend WithEvents TxtNom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChB1 As System.Windows.Forms.CheckBox

End Class
