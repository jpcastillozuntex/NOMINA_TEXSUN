<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepIsr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepIsr))
        Me.DatAnio = New System.Windows.Forms.DateTimePicker()
        Me.Cbmes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CbQuincena = New System.Windows.Forms.ComboBox()
        Me.BtConsultar = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.fv = New C1.Win.FlexViewer.C1FlexViewer()
        Me.rp = New C1.Win.FlexReport.C1FlexReport()
        CType(Me.fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatAnio
        '
        Me.DatAnio.CustomFormat = "yyyy"
        Me.DatAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatAnio.Location = New System.Drawing.Point(121, 29)
        Me.DatAnio.Name = "DatAnio"
        Me.DatAnio.ShowUpDown = True
        Me.DatAnio.Size = New System.Drawing.Size(128, 24)
        Me.DatAnio.TabIndex = 172
        '
        'Cbmes
        '
        Me.Cbmes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbmes.FormattingEnabled = True
        Me.Cbmes.Location = New System.Drawing.Point(121, 54)
        Me.Cbmes.Name = "Cbmes"
        Me.Cbmes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cbmes.Size = New System.Drawing.Size(128, 24)
        Me.Cbmes.TabIndex = 173
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "QUINCENA:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 24)
        Me.Label8.TabIndex = 176
        Me.Label8.Text = "MES:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 24)
        Me.Label9.TabIndex = 175
        Me.Label9.Text = "AÑO:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbQuincena
        '
        Me.CbQuincena.BackColor = System.Drawing.Color.LightCyan
        Me.CbQuincena.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbQuincena.FormattingEnabled = True
        Me.CbQuincena.Items.AddRange(New Object() {"1", "2"})
        Me.CbQuincena.Location = New System.Drawing.Point(121, 79)
        Me.CbQuincena.Name = "CbQuincena"
        Me.CbQuincena.Size = New System.Drawing.Size(128, 26)
        Me.CbQuincena.TabIndex = 174
        '
        'BtConsultar
        '
        Me.BtConsultar.BackgroundImage = CType(resources.GetObject("BtConsultar.BackgroundImage"), System.Drawing.Image)
        Me.BtConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtConsultar.Location = New System.Drawing.Point(273, 35)
        Me.BtConsultar.Name = "BtConsultar"
        Me.BtConsultar.Size = New System.Drawing.Size(75, 62)
        Me.BtConsultar.TabIndex = 178
        Me.BtConsultar.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(0, -3)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(1055, 31)
        Me.Label34.TabIndex = 182
        Me.Label34.Text = "REPORTE DESCUENTO POR ISR"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fv
        '
        Me.fv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fv.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.fv.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.fv.Location = New System.Drawing.Point(4, 110)
        Me.fv.Name = "fv"
        Me.fv.Size = New System.Drawing.Size(1047, 617)
        Me.fv.TabIndex = 183
        '
        'rp
        '
        Me.rp.ReportDefinition = resources.GetString("rp.ReportDefinition")
        Me.rp.ReportName = "C1FlexReport1"
        '
        'FrmRepIsr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 729)
        Me.Controls.Add(Me.fv)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.BtConsultar)
        Me.Controls.Add(Me.DatAnio)
        Me.Controls.Add(Me.Cbmes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CbQuincena)
        Me.Name = "FrmRepIsr"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DatAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cbmes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CbQuincena As System.Windows.Forms.ComboBox
    Friend WithEvents BtConsultar As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents fv As C1.Win.FlexViewer.C1FlexViewer
    Friend WithEvents rp As C1.Win.FlexReport.C1FlexReport
End Class
