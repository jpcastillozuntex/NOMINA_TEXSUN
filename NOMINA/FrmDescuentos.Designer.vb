<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDescuentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDescuentos))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt2Apellido = New System.Windows.Forms.TextBox()
        Me.Txt2Nombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtComent = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDepartamento = New System.Windows.Forms.TextBox()
        Me.TxtApellido = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtBuscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DatInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxTalta = New System.Windows.Forms.TextBox()
        Me.BtGuardar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mensajes = New System.Windows.Forms.Label()
        Me.TxtMonto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Cbtipodesc = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SkyBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(73, 307)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(146, 27)
        Me.Label13.TabIndex = 200
        Me.Label13.Text = "FEC. DESCUENTO:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SkyBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(73, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 27)
        Me.Label11.TabIndex = 196
        Me.Label11.Text = "FEC. ALTA:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt2Apellido
        '
        Me.Txt2Apellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2Apellido.Location = New System.Drawing.Point(220, 220)
        Me.Txt2Apellido.Name = "Txt2Apellido"
        Me.Txt2Apellido.Size = New System.Drawing.Size(186, 26)
        Me.Txt2Apellido.TabIndex = 187
        '
        'Txt2Nombre
        '
        Me.Txt2Nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2Nombre.Location = New System.Drawing.Point(220, 191)
        Me.Txt2Nombre.Name = "Txt2Nombre"
        Me.Txt2Nombre.Size = New System.Drawing.Size(186, 26)
        Me.Txt2Nombre.TabIndex = 184
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 28)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "CODIGO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtComent
        '
        Me.TxtComent.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComent.Location = New System.Drawing.Point(220, 394)
        Me.TxtComent.Name = "TxtComent"
        Me.TxtComent.Size = New System.Drawing.Size(186, 26)
        Me.TxtComent.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SkyBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(73, 336)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 27)
        Me.Label12.TabIndex = 198
        Me.Label12.Text = "MONTO DESC:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDepartamento
        '
        Me.TxtDepartamento.AcceptsReturn = True
        Me.TxtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDepartamento.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtDepartamento.Location = New System.Drawing.Point(220, 133)
        Me.TxtDepartamento.MaximumSize = New System.Drawing.Size(187, 30)
        Me.TxtDepartamento.MinimumSize = New System.Drawing.Size(187, 25)
        Me.TxtDepartamento.Name = "TxtDepartamento"
        Me.TxtDepartamento.Size = New System.Drawing.Size(187, 26)
        Me.TxtDepartamento.TabIndex = 182
        '
        'TxtApellido
        '
        Me.TxtApellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApellido.Location = New System.Drawing.Point(220, 249)
        Me.TxtApellido.Name = "TxtApellido"
        Me.TxtApellido.Size = New System.Drawing.Size(186, 26)
        Me.TxtApellido.TabIndex = 186
        '
        'TxtNombre
        '
        Me.TxtNombre.AcceptsReturn = True
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtNombre.Location = New System.Drawing.Point(220, 162)
        Me.TxtNombre.MaximumSize = New System.Drawing.Size(187, 30)
        Me.TxtNombre.MinimumSize = New System.Drawing.Size(187, 25)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(187, 26)
        Me.TxtNombre.TabIndex = 183
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SkyBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(73, 249)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 27)
        Me.Label7.TabIndex = 195
        Me.Label7.Text = "2DO APELLIDO:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(182, 74)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(94, 26)
        Me.TxtCodigo.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(73, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 27)
        Me.Label6.TabIndex = 194
        Me.Label6.Text = "APELLIDO:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(73, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 27)
        Me.Label5.TabIndex = 193
        Me.Label5.Text = "NOMBRE:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtBuscar
        '
        Me.BtBuscar.BackColor = System.Drawing.Color.Transparent
        Me.BtBuscar.BackgroundImage = CType(resources.GetObject("BtBuscar.BackgroundImage"), System.Drawing.Image)
        Me.BtBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtBuscar.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtBuscar.FlatAppearance.BorderSize = 5
        Me.BtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtBuscar.Location = New System.Drawing.Point(294, 55)
        Me.BtBuscar.Name = "BtBuscar"
        Me.BtBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtBuscar.Size = New System.Drawing.Size(69, 55)
        Me.BtBuscar.TabIndex = 189
        Me.BtBuscar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(73, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 27)
        Me.Label4.TabIndex = 192
        Me.Label4.Text = "2DO NOMBRE:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(73, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 27)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "DEPARTAMENTO:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DatInicio
        '
        Me.DatInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatInicio.Location = New System.Drawing.Point(220, 307)
        Me.DatInicio.Name = "DatInicio"
        Me.DatInicio.Size = New System.Drawing.Size(186, 26)
        Me.DatInicio.TabIndex = 202
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(73, 394)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 27)
        Me.Label2.TabIndex = 203
        Me.Label2.Text = "COMENTARIO:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxTalta
        '
        Me.TxTalta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxTalta.Location = New System.Drawing.Point(220, 278)
        Me.TxTalta.Name = "TxTalta"
        Me.TxTalta.Size = New System.Drawing.Size(186, 26)
        Me.TxTalta.TabIndex = 204
        '
        'BtGuardar
        '
        Me.BtGuardar.BackgroundImage = CType(resources.GetObject("BtGuardar.BackgroundImage"), System.Drawing.Image)
        Me.BtGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtGuardar.Location = New System.Drawing.Point(494, 330)
        Me.BtGuardar.Name = "BtGuardar"
        Me.BtGuardar.Size = New System.Drawing.Size(74, 63)
        Me.BtGuardar.TabIndex = 205
        Me.BtGuardar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(151, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(434, 35)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "DESCUENTOS VARIOS"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mensajes
        '
        Me.mensajes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mensajes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mensajes.ForeColor = System.Drawing.Color.OrangeRed
        Me.mensajes.Location = New System.Drawing.Point(444, 108)
        Me.mensajes.Name = "mensajes"
        Me.mensajes.Size = New System.Drawing.Size(265, 52)
        Me.mensajes.TabIndex = 207
        '
        'TxtMonto
        '
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.Location = New System.Drawing.Point(220, 336)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(186, 26)
        Me.TxtMonto.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(73, 365)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 27)
        Me.Label9.TabIndex = 209
        Me.Label9.Text = "TIPO DESC:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cbtipodesc
        '
        Me.Cbtipodesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbtipodesc.FormattingEnabled = True
        Me.Cbtipodesc.Location = New System.Drawing.Point(220, 366)
        Me.Cbtipodesc.Name = "Cbtipodesc"
        Me.Cbtipodesc.Size = New System.Drawing.Size(186, 24)
        Me.Cbtipodesc.TabIndex = 2
        '
        'FrmDescuentos
        '
        Me.AcceptButton = Me.BtBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 498)
        Me.Controls.Add(Me.Cbtipodesc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtMonto)
        Me.Controls.Add(Me.mensajes)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BtGuardar)
        Me.Controls.Add(Me.TxTalta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DatInicio)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txt2Apellido)
        Me.Controls.Add(Me.Txt2Nombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtComent)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtDepartamento)
        Me.Controls.Add(Me.TxtApellido)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtBuscar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "FrmDescuentos"
        Me.ShowIcon = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt2Apellido As System.Windows.Forms.TextBox
    Public WithEvents Txt2Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtComent As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents TxtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellido As System.Windows.Forms.TextBox
    Private WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtBuscar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DatInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxTalta As System.Windows.Forms.TextBox
    Friend WithEvents BtGuardar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents mensajes As System.Windows.Forms.Label
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Cbtipodesc As System.Windows.Forms.ComboBox
End Class
