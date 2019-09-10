<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsuetos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsuetos))
        Me.BtConsultar = New System.Windows.Forms.Button()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BtGuardar = New System.Windows.Forms.Button()
        Me.mensajes = New System.Windows.Forms.Label()
        Me.BtRegresar = New System.Windows.Forms.Button()
        Me.DatFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtConsultar
        '
        Me.BtConsultar.BackgroundImage = CType(resources.GetObject("BtConsultar.BackgroundImage"), System.Drawing.Image)
        Me.BtConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtConsultar.Location = New System.Drawing.Point(264, 19)
        Me.BtConsultar.Name = "BtConsultar"
        Me.BtConsultar.Size = New System.Drawing.Size(75, 62)
        Me.BtConsultar.TabIndex = 41
        Me.BtConsultar.UseVisualStyleBackColor = True
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Location = New System.Drawing.Point(0, 126)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(1013, 496)
        Me.fg.TabIndex = 46
        '
        'BtGuardar
        '
        Me.BtGuardar.BackgroundImage = CType(resources.GetObject("BtGuardar.BackgroundImage"), System.Drawing.Image)
        Me.BtGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtGuardar.Location = New System.Drawing.Point(360, 19)
        Me.BtGuardar.Name = "BtGuardar"
        Me.BtGuardar.Size = New System.Drawing.Size(75, 62)
        Me.BtGuardar.TabIndex = 47
        Me.BtGuardar.UseVisualStyleBackColor = True
        '
        'mensajes
        '
        Me.mensajes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mensajes.ForeColor = System.Drawing.Color.OrangeRed
        Me.mensajes.Location = New System.Drawing.Point(554, 27)
        Me.mensajes.Name = "mensajes"
        Me.mensajes.Size = New System.Drawing.Size(359, 49)
        Me.mensajes.TabIndex = 48
        '
        'BtRegresar
        '
        Me.BtRegresar.BackgroundImage = CType(resources.GetObject("BtRegresar.BackgroundImage"), System.Drawing.Image)
        Me.BtRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtRegresar.Location = New System.Drawing.Point(264, 19)
        Me.BtRegresar.Name = "BtRegresar"
        Me.BtRegresar.Size = New System.Drawing.Size(75, 62)
        Me.BtRegresar.TabIndex = 49
        Me.BtRegresar.UseVisualStyleBackColor = True
        '
        'DatFecha
        '
        Me.DatFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatFecha.Location = New System.Drawing.Point(117, 40)
        Me.DatFecha.Name = "DatFecha"
        Me.DatFecha.Size = New System.Drawing.Size(143, 24)
        Me.DatFecha.TabIndex = 50
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 24)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "FECHA:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmAsuetos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 624)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DatFecha)
        Me.Controls.Add(Me.BtRegresar)
        Me.Controls.Add(Me.mensajes)
        Me.Controls.Add(Me.BtGuardar)
        Me.Controls.Add(Me.fg)
        Me.Controls.Add(Me.BtConsultar)
        Me.Name = "FrmAsuetos"
        Me.ShowIcon = False
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtConsultar As System.Windows.Forms.Button
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BtGuardar As System.Windows.Forms.Button
    Friend WithEvents mensajes As System.Windows.Forms.Label
    Friend WithEvents BtRegresar As System.Windows.Forms.Button
    Friend WithEvents DatFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
