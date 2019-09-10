<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCaptaTurno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCaptaTurno))
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.DatAnio = New System.Windows.Forms.DateTimePicker()
        Me.CbCiclo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtConsultar = New System.Windows.Forms.Button()
        Me.BtGuardar = New System.Windows.Forms.Button()
        Me.BtRegresar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cbmes = New System.Windows.Forms.ComboBox()
        CType(Me.fg,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.fg.Location = New System.Drawing.Point(0, 93)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 21
        Me.fg.Size = New System.Drawing.Size(1199, 524)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 0
        '
        'DatAnio
        '
        Me.DatAnio.CustomFormat = "yyyy"
        Me.DatAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.DatAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatAnio.Location = New System.Drawing.Point(117, 5)
        Me.DatAnio.Name = "DatAnio"
        Me.DatAnio.ShowUpDown = true
        Me.DatAnio.Size = New System.Drawing.Size(128, 24)
        Me.DatAnio.TabIndex = 1
        '
        'CbCiclo
        '
        Me.CbCiclo.BackColor = System.Drawing.Color.SkyBlue
        Me.CbCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CbCiclo.FormattingEnabled = true
        Me.CbCiclo.Items.AddRange(New Object() {"1", "2"})
        Me.CbCiclo.Location = New System.Drawing.Point(117, 55)
        Me.CbCiclo.Name = "CbCiclo"
        Me.CbCiclo.Size = New System.Drawing.Size(128, 26)
        Me.CbCiclo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "AÑO:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "MES:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "QUINCENA:"
        '
        'BtConsultar
        '
        Me.BtConsultar.BackgroundImage = CType(resources.GetObject("BtConsultar.BackgroundImage"),System.Drawing.Image)
        Me.BtConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtConsultar.Location = New System.Drawing.Point(257, 9)
        Me.BtConsultar.Name = "BtConsultar"
        Me.BtConsultar.Size = New System.Drawing.Size(75, 62)
        Me.BtConsultar.TabIndex = 7
        Me.BtConsultar.UseVisualStyleBackColor = true
        '
        'BtGuardar
        '
        Me.BtGuardar.BackgroundImage = CType(resources.GetObject("BtGuardar.BackgroundImage"),System.Drawing.Image)
        Me.BtGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtGuardar.Location = New System.Drawing.Point(338, 9)
        Me.BtGuardar.Name = "BtGuardar"
        Me.BtGuardar.Size = New System.Drawing.Size(75, 62)
        Me.BtGuardar.TabIndex = 8
        Me.BtGuardar.UseVisualStyleBackColor = true
        '
        'BtRegresar
        '
        Me.BtRegresar.BackgroundImage = CType(resources.GetObject("BtRegresar.BackgroundImage"),System.Drawing.Image)
        Me.BtRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtRegresar.Location = New System.Drawing.Point(258, 9)
        Me.BtRegresar.Name = "BtRegresar"
        Me.BtRegresar.Size = New System.Drawing.Size(75, 62)
        Me.BtRegresar.TabIndex = 9
        Me.BtRegresar.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(376, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(447, 36)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "CAPTACION TURNOS SERIGRAFIA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cbmes
        '
        Me.Cbmes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbmes.FormattingEnabled = True
        Me.Cbmes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cbmes.Location = New System.Drawing.Point(117, 30)
        Me.Cbmes.Name = "Cbmes"
        Me.Cbmes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cbmes.Size = New System.Drawing.Size(128, 24)
        Me.Cbmes.TabIndex = 11
        '
        'FrmCaptaTurno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1199, 619)
        Me.Controls.Add(Me.Cbmes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtRegresar)
        Me.Controls.Add(Me.BtGuardar)
        Me.Controls.Add(Me.BtConsultar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbCiclo)
        Me.Controls.Add(Me.DatAnio)
        Me.Controls.Add(Me.fg)
        Me.Name = "FrmCaptaTurno"
        Me.ShowIcon = false
        CType(Me.fg,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents DatAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents CbCiclo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtConsultar As System.Windows.Forms.Button
    Friend WithEvents BtGuardar As System.Windows.Forms.Button
    Friend WithEvents BtRegresar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cbmes As System.Windows.Forms.ComboBox
End Class
