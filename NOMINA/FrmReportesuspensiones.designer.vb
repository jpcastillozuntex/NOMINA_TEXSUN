<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportesuspensiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportesuspensiones))
        Me.Datmes = New System.Windows.Forms.DateTimePicker()
        Me.Datanio = New System.Windows.Forms.DateTimePicker()
        Me.BtCalcular = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cr = New C1.Win.FlexReport.C1FlexReport()
        Me.Fv = New C1.Win.FlexViewer.C1FlexViewer()
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Datmes
        '
        Me.Datmes.CalendarMonthBackground = System.Drawing.Color.SkyBlue
        Me.Datmes.CustomFormat = "MMMM"
        Me.Datmes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datmes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Datmes.Location = New System.Drawing.Point(118, 67)
        Me.Datmes.Name = "Datmes"
        Me.Datmes.ShowUpDown = True
        Me.Datmes.Size = New System.Drawing.Size(82, 22)
        Me.Datmes.TabIndex = 15
        '
        'Datanio
        '
        Me.Datanio.CalendarMonthBackground = System.Drawing.Color.SkyBlue
        Me.Datanio.CustomFormat = "yyyy"
        Me.Datanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datanio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Datanio.Location = New System.Drawing.Point(118, 40)
        Me.Datanio.Name = "Datanio"
        Me.Datanio.ShowUpDown = True
        Me.Datanio.Size = New System.Drawing.Size(82, 22)
        Me.Datanio.TabIndex = 14
        '
        'BtCalcular
        '
        Me.BtCalcular.BackgroundImage = CType(resources.GetObject("BtCalcular.BackgroundImage"), System.Drawing.Image)
        Me.BtCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtCalcular.Location = New System.Drawing.Point(219, 34)
        Me.BtCalcular.Name = "BtCalcular"
        Me.BtCalcular.Size = New System.Drawing.Size(68, 55)
        Me.BtCalcular.TabIndex = 17
        Me.BtCalcular.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 24)
        Me.Label8.TabIndex = 178
        Me.Label8.Text = "MES:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 24)
        Me.Label9.TabIndex = 177
        Me.Label9.Text = "AÑO:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Label34.Size = New System.Drawing.Size(1051, 31)
        Me.Label34.TabIndex = 181
        Me.Label34.Text = "REPORTE SUSPENDIDOS"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cr
        '
        Me.cr.ReportDefinition = resources.GetString("cr.ReportDefinition")
        Me.cr.ReportName = "C1FlexReport1"
        '
        'Fv
        '
        Me.Fv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fv.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Fv.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Fv.Location = New System.Drawing.Point(6, 95)
        Me.Fv.Name = "Fv"
        Me.Fv.Size = New System.Drawing.Size(1041, 856)
        Me.Fv.TabIndex = 182
        '
        'FrmReportesuspensiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 953)
        Me.Controls.Add(Me.Fv)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtCalcular)
        Me.Controls.Add(Me.Datmes)
        Me.Controls.Add(Me.Datanio)
        Me.Name = "FrmReportesuspensiones"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Datmes As System.Windows.Forms.DateTimePicker
    Friend WithEvents Datanio As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtCalcular As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cr As C1.Win.FlexReport.C1FlexReport
    Friend WithEvents Fv As C1.Win.FlexViewer.C1FlexViewer
End Class
