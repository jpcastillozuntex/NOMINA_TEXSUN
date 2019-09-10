<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambioPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambioPassword))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPanterior = New System.Windows.Forms.TextBox()
        Me.TxtPnuevo1 = New System.Windows.Forms.TextBox()
        Me.TxtPnuevo2 = New System.Windows.Forms.TextBox()
        Me.Pbfoto = New System.Windows.Forms.PictureBox()
        Me.Btguardar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LbNombre = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mensajes = New System.Windows.Forms.Label()
        CType(Me.Pbfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Pass Ant:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Pass. Nuevo:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Pass. Nuevo:"
        '
        'TxtPanterior
        '
        Me.TxtPanterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPanterior.Location = New System.Drawing.Point(125, 131)
        Me.TxtPanterior.Name = "TxtPanterior"
        Me.TxtPanterior.Size = New System.Drawing.Size(113, 22)
        Me.TxtPanterior.TabIndex = 5
        Me.TxtPanterior.UseSystemPasswordChar = True
        '
        'TxtPnuevo1
        '
        Me.TxtPnuevo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPnuevo1.Location = New System.Drawing.Point(125, 163)
        Me.TxtPnuevo1.Name = "TxtPnuevo1"
        Me.TxtPnuevo1.Size = New System.Drawing.Size(113, 22)
        Me.TxtPnuevo1.TabIndex = 6
        Me.TxtPnuevo1.UseSystemPasswordChar = True
        '
        'TxtPnuevo2
        '
        Me.TxtPnuevo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPnuevo2.Location = New System.Drawing.Point(125, 195)
        Me.TxtPnuevo2.Name = "TxtPnuevo2"
        Me.TxtPnuevo2.Size = New System.Drawing.Size(113, 22)
        Me.TxtPnuevo2.TabIndex = 7
        Me.TxtPnuevo2.UseSystemPasswordChar = True
        '
        'Pbfoto
        '
        Me.Pbfoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pbfoto.Location = New System.Drawing.Point(340, 70)
        Me.Pbfoto.Name = "Pbfoto"
        Me.Pbfoto.Size = New System.Drawing.Size(251, 233)
        Me.Pbfoto.TabIndex = 8
        Me.Pbfoto.TabStop = False
        '
        'Btguardar
        '
        Me.Btguardar.BackgroundImage = CType(resources.GetObject("Btguardar.BackgroundImage"), System.Drawing.Image)
        Me.Btguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btguardar.Location = New System.Drawing.Point(291, 341)
        Me.Btguardar.Name = "Btguardar"
        Me.Btguardar.Size = New System.Drawing.Size(62, 57)
        Me.Btguardar.TabIndex = 26
        Me.Btguardar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Aquamarine
        Me.Label6.Font = New System.Drawing.Font("Perpetua Titling MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(643, 26)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "CAMBIO DE PASSWORD"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LbNombre
        '
        Me.LbNombre.BackColor = System.Drawing.Color.LightBlue
        Me.LbNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbNombre.Location = New System.Drawing.Point(125, 95)
        Me.LbNombre.Name = "LbNombre"
        Me.LbNombre.Size = New System.Drawing.Size(190, 23)
        Me.LbNombre.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SkyBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 23)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "NOMBRE:"
        '
        'mensajes
        '
        Me.mensajes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mensajes.Location = New System.Drawing.Point(19, 57)
        Me.mensajes.Name = "mensajes"
        Me.mensajes.Size = New System.Drawing.Size(295, 28)
        Me.mensajes.TabIndex = 30
        '
        'FrmCambioPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 462)
        Me.Controls.Add(Me.mensajes)
        Me.Controls.Add(Me.LbNombre)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Btguardar)
        Me.Controls.Add(Me.Pbfoto)
        Me.Controls.Add(Me.TxtPnuevo2)
        Me.Controls.Add(Me.TxtPnuevo1)
        Me.Controls.Add(Me.TxtPanterior)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "FrmCambioPassword"
        Me.ShowIcon = False
        CType(Me.Pbfoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPanterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtPnuevo1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPnuevo2 As System.Windows.Forms.TextBox
    Friend WithEvents Pbfoto As System.Windows.Forms.PictureBox
    Friend WithEvents Btguardar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LbNombre As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mensajes As System.Windows.Forms.Label
End Class
