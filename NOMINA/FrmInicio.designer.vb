<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInicio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInicio))
        Me.menu = New System.Windows.Forms.ToolStrip()
        Me.Txt_msj = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.password = New System.Windows.Forms.GroupBox()
        Me.Foto = New System.Windows.Forms.PictureBox()
        Me.BtAceptar = New System.Windows.Forms.Button()
        Me.TxtNombre = New System.Windows.Forms.Label()
        Me.Pblogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbPassword = New System.Windows.Forms.Label()
        Me.CbEmpresa = New System.Windows.Forms.ComboBox()
        Me.LbEmpresa = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.password.SuspendLayout()
        CType(Me.Foto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pblogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menu
        '
        Me.menu.AutoSize = False
        Me.menu.BackColor = System.Drawing.Color.SkyBlue
        Me.menu.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menu.Location = New System.Drawing.Point(0, 0)
        Me.menu.Name = "menu"
        Me.menu.Size = New System.Drawing.Size(1916, 39)
        Me.menu.TabIndex = 3
        Me.menu.Text = "ToolStrip1"
        '
        'Txt_msj
        '
        Me.Txt_msj.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Txt_msj.Location = New System.Drawing.Point(113, 54)
        Me.Txt_msj.Name = "Txt_msj"
        Me.Txt_msj.Size = New System.Drawing.Size(285, 30)
        Me.Txt_msj.TabIndex = 7
        Me.Txt_msj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TextBox1.BackColor = System.Drawing.Color.Azure
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(118, 95)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(279, 22)
        Me.TextBox1.TabIndex = 1
        '
        'password
        '
        Me.password.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.password.BackColor = System.Drawing.Color.LightBlue
        Me.password.Controls.Add(Me.Txt_msj)
        Me.password.Controls.Add(Me.TextBox1)
        Me.password.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.Location = New System.Drawing.Point(710, 725)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(497, 177)
        Me.password.TabIndex = 6
        Me.password.TabStop = False
        '
        'Foto
        '
        Me.Foto.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Foto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Foto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Foto.Location = New System.Drawing.Point(877, 647)
        Me.Foto.Name = "Foto"
        Me.Foto.Size = New System.Drawing.Size(163, 150)
        Me.Foto.TabIndex = 14
        Me.Foto.TabStop = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtAceptar.Location = New System.Drawing.Point(907, 860)
        Me.BtAceptar.Name = "BtAceptar"
        Me.BtAceptar.Size = New System.Drawing.Size(87, 23)
        Me.BtAceptar.TabIndex = 6
        Me.BtAceptar.UseVisualStyleBackColor = True
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(710, 853)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(496, 40)
        Me.TxtNombre.TabIndex = 7
        Me.TxtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pblogo
        '
        Me.Pblogo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Pblogo.ErrorImage = Nothing
        Me.Pblogo.Location = New System.Drawing.Point(827, 147)
        Me.Pblogo.Name = "Pblogo"
        Me.Pblogo.Size = New System.Drawing.Size(260, 104)
        Me.Pblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pblogo.TabIndex = 8
        Me.Pblogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(793, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(330, 37)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "SISTEMA NOMINAS"
        '
        'lbPassword
        '
        Me.lbPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbPassword.AutoSize = True
        Me.lbPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPassword.Location = New System.Drawing.Point(903, 699)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(126, 24)
        Me.lbPassword.TabIndex = 10
        Me.lbPassword.Text = "PASSWORD"
        '
        'CbEmpresa
        '
        Me.CbEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbEmpresa.ForeColor = System.Drawing.Color.Transparent
        Me.CbEmpresa.FormattingEnabled = True
        Me.CbEmpresa.Location = New System.Drawing.Point(128, 50)
        Me.CbEmpresa.Name = "CbEmpresa"
        Me.CbEmpresa.Size = New System.Drawing.Size(152, 28)
        Me.CbEmpresa.TabIndex = 12
        '
        'LbEmpresa
        '
        Me.LbEmpresa.BackColor = System.Drawing.Color.LimeGreen
        Me.LbEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbEmpresa.Location = New System.Drawing.Point(19, 51)
        Me.LbEmpresa.Name = "LbEmpresa"
        Me.LbEmpresa.Size = New System.Drawing.Size(109, 27)
        Me.LbEmpresa.TabIndex = 13
        Me.LbEmpresa.Text = "EMPRESA:"
        Me.LbEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Monotype Corsiva", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 994)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(212, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Desarrollado por: Mario Chalí"
        '
        'FrmInicio
        '
        Me.AcceptButton = Me.BtAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1916, 1011)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Foto)
        Me.Controls.Add(Me.LbEmpresa)
        Me.Controls.Add(Me.CbEmpresa)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pblogo)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.menu)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.BtAceptar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.password.ResumeLayout(False)
        Me.password.PerformLayout()
        CType(Me.Foto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pblogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Shadows menu As System.Windows.Forms.ToolStrip
    Friend WithEvents Txt_msj As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents password As System.Windows.Forms.GroupBox
    Friend WithEvents BtAceptar As System.Windows.Forms.Button
    Friend WithEvents TxtNombre As System.Windows.Forms.Label
    Friend WithEvents Pblogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbPassword As System.Windows.Forms.Label
    Friend WithEvents CbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents LbEmpresa As System.Windows.Forms.Label
    Friend WithEvents Foto As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
