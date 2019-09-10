<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngHoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngHoras))
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BtGuardar = New System.Windows.Forms.Button()
        Me.BtConsultar = New System.Windows.Forms.Button()
        Me.DatAnio = New System.Windows.Forms.DateTimePicker()
        Me.Cbmes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CbCiclo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbdepto = New System.Windows.Forms.ComboBox()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Location = New System.Drawing.Point(2, 108)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(849, 460)
        Me.fg.TabIndex = 184
        '
        'BtGuardar
        '
        Me.BtGuardar.BackColor = System.Drawing.Color.Transparent
        Me.BtGuardar.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtGuardar.FlatAppearance.BorderSize = 5
        Me.BtGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtGuardar.Image = CType(resources.GetObject("BtGuardar.Image"), System.Drawing.Image)
        Me.BtGuardar.Location = New System.Drawing.Point(336, 12)
        Me.BtGuardar.Name = "BtGuardar"
        Me.BtGuardar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtGuardar.Size = New System.Drawing.Size(68, 58)
        Me.BtGuardar.TabIndex = 192
        Me.BtGuardar.UseVisualStyleBackColor = False
        '
        'BtConsultar
        '
        Me.BtConsultar.BackgroundImage = CType(resources.GetObject("BtConsultar.BackgroundImage"), System.Drawing.Image)
        Me.BtConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtConsultar.Location = New System.Drawing.Point(265, 12)
        Me.BtConsultar.Name = "BtConsultar"
        Me.BtConsultar.Size = New System.Drawing.Size(68, 58)
        Me.BtConsultar.TabIndex = 191
        Me.BtConsultar.UseVisualStyleBackColor = True
        '
        'DatAnio
        '
        Me.DatAnio.CustomFormat = "yyyy"
        Me.DatAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatAnio.Location = New System.Drawing.Point(113, 6)
        Me.DatAnio.Name = "DatAnio"
        Me.DatAnio.ShowUpDown = True
        Me.DatAnio.Size = New System.Drawing.Size(128, 24)
        Me.DatAnio.TabIndex = 185
        '
        'Cbmes
        '
        Me.Cbmes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbmes.FormattingEnabled = True
        Me.Cbmes.Location = New System.Drawing.Point(113, 31)
        Me.Cbmes.Name = "Cbmes"
        Me.Cbmes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cbmes.Size = New System.Drawing.Size(128, 24)
        Me.Cbmes.TabIndex = 186
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Quincena:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 24)
        Me.Label8.TabIndex = 189
        Me.Label8.Text = "Mes:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 24)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "Año:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbCiclo
        '
        Me.CbCiclo.BackColor = System.Drawing.Color.LightCyan
        Me.CbCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCiclo.FormattingEnabled = True
        Me.CbCiclo.Items.AddRange(New Object() {"1", "2"})
        Me.CbCiclo.Location = New System.Drawing.Point(113, 56)
        Me.CbCiclo.Name = "CbCiclo"
        Me.CbCiclo.Size = New System.Drawing.Size(128, 24)
        Me.CbCiclo.TabIndex = 187
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 24)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "Depto:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbdepto
        '
        Me.cbdepto.BackColor = System.Drawing.Color.LightCyan
        Me.cbdepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbdepto.FormattingEnabled = True
        Me.cbdepto.Items.AddRange(New Object() {"1", "2"})
        Me.cbdepto.Location = New System.Drawing.Point(113, 82)
        Me.cbdepto.Name = "cbdepto"
        Me.cbdepto.Size = New System.Drawing.Size(128, 26)
        Me.cbdepto.TabIndex = 193
        '
        'FrmIngHoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 566)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbdepto)
        Me.Controls.Add(Me.BtGuardar)
        Me.Controls.Add(Me.BtConsultar)
        Me.Controls.Add(Me.DatAnio)
        Me.Controls.Add(Me.Cbmes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CbCiclo)
        Me.Controls.Add(Me.fg)
        Me.Name = "FrmIngHoras"
        Me.ShowIcon = False
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BtGuardar As Button
    Friend WithEvents BtConsultar As Button
    Friend WithEvents DatAnio As DateTimePicker
    Friend WithEvents Cbmes As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CbCiclo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbdepto As ComboBox
End Class
