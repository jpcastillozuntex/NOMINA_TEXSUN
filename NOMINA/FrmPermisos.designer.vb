<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermisos))
        Me.Txtcod = New System.Windows.Forms.TextBox()
        Me.Datfec = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btguardar = New System.Windows.Forms.Button()
        Me.LbNombre = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CbMotivo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtHoras = New System.Windows.Forms.TextBox()
        Me.Datent = New System.Windows.Forms.DateTimePicker()
        Me.DatSalida = New System.Windows.Forms.DateTimePicker()
        Me.TxtComent = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LbApellido = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Txtcod
        '
        Me.Txtcod.BackColor = System.Drawing.Color.White
        Me.Txtcod.Location = New System.Drawing.Point(170, 71)
        Me.Txtcod.Margin = New System.Windows.Forms.Padding(4)
        Me.Txtcod.Name = "Txtcod"
        Me.Txtcod.Size = New System.Drawing.Size(128, 22)
        Me.Txtcod.TabIndex = 0
        '
        'Datfec
        '
        Me.Datfec.Location = New System.Drawing.Point(170, 205)
        Me.Datfec.Margin = New System.Windows.Forms.Padding(4)
        Me.Datfec.Name = "Datfec"
        Me.Datfec.Size = New System.Drawing.Size(222, 22)
        Me.Datfec.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 252)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "De:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 255)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "A:"
        '
        'Btguardar
        '
        Me.Btguardar.BackgroundImage = CType(resources.GetObject("Btguardar.BackgroundImage"), System.Drawing.Image)
        Me.Btguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btguardar.Location = New System.Drawing.Point(464, 77)
        Me.Btguardar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btguardar.Name = "Btguardar"
        Me.Btguardar.Size = New System.Drawing.Size(73, 61)
        Me.Btguardar.TabIndex = 6
        Me.Btguardar.UseVisualStyleBackColor = True
        '
        'LbNombre
        '
        Me.LbNombre.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LbNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbNombre.Location = New System.Drawing.Point(170, 118)
        Me.LbNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbNombre.Name = "LbNombre"
        Me.LbNombre.Size = New System.Drawing.Size(181, 20)
        Me.LbNombre.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 72)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 21)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "CODIGO:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 207)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 21)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "FECHA"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 297)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 21)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "HORAS"
        '
        'CbMotivo
        '
        Me.CbMotivo.FormattingEnabled = True
        Me.CbMotivo.Location = New System.Drawing.Point(170, 339)
        Me.CbMotivo.Margin = New System.Windows.Forms.Padding(4)
        Me.CbMotivo.Name = "CbMotivo"
        Me.CbMotivo.Size = New System.Drawing.Size(180, 24)
        Me.CbMotivo.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SkyBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 342)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 21)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "MOTIVO:"
        '
        'TxtHoras
        '
        Me.TxtHoras.Location = New System.Drawing.Point(170, 297)
        Me.TxtHoras.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtHoras.Name = "TxtHoras"
        Me.TxtHoras.Size = New System.Drawing.Size(152, 22)
        Me.TxtHoras.TabIndex = 4
        '
        'Datent
        '
        Me.Datent.Location = New System.Drawing.Point(357, 252)
        Me.Datent.Margin = New System.Windows.Forms.Padding(4)
        Me.Datent.Name = "Datent"
        Me.Datent.Size = New System.Drawing.Size(128, 22)
        Me.Datent.TabIndex = 3
        '
        'DatSalida
        '
        Me.DatSalida.Location = New System.Drawing.Point(170, 252)
        Me.DatSalida.Margin = New System.Windows.Forms.Padding(4)
        Me.DatSalida.Name = "DatSalida"
        Me.DatSalida.Size = New System.Drawing.Size(128, 22)
        Me.DatSalida.TabIndex = 2
        '
        'TxtComent
        '
        Me.TxtComent.Location = New System.Drawing.Point(170, 386)
        Me.TxtComent.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtComent.Name = "TxtComent"
        Me.TxtComent.Size = New System.Drawing.Size(152, 22)
        Me.TxtComent.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 387)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 21)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "COMENTARIOS:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(27, 117)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 21)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "NOMBRE:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 162)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 21)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "APELLIDO:"
        '
        'LbApellido
        '
        Me.LbApellido.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.LbApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LbApellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbApellido.Location = New System.Drawing.Point(170, 163)
        Me.LbApellido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbApellido.Name = "LbApellido"
        Me.LbApellido.Size = New System.Drawing.Size(181, 20)
        Me.LbApellido.TabIndex = 22
        '
        'Label34
        '
        Me.Label34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(0, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(658, 31)
        Me.Label34.TabIndex = 182
        Me.Label34.Text = "INGRESO DE PERMISOS"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FrmPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 553)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.LbApellido)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtComent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DatSalida)
        Me.Controls.Add(Me.Datent)
        Me.Controls.Add(Me.TxtHoras)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CbMotivo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LbNombre)
        Me.Controls.Add(Me.Btguardar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Datfec)
        Me.Controls.Add(Me.Txtcod)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FrmPermisos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Datfec As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btguardar As System.Windows.Forms.Button
    Public WithEvents Txtcod As System.Windows.Forms.TextBox
    Friend WithEvents LbNombre As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CbMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents TxtHoras As System.Windows.Forms.TextBox
    Friend WithEvents Datent As System.Windows.Forms.DateTimePicker
    Friend WithEvents DatSalida As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtComent As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LbApellido As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
End Class
