<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiniquito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiniquito))
        Me.DatFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtBuscar = New System.Windows.Forms.Button()
        Me.TxtCodigoX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.report = New C1.Win.FlexReport.C1FlexReport()
        Me.Fv = New C1.Win.FlexViewer.C1FlexViewer()
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatFecha
        '
        Me.DatFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatFecha.Location = New System.Drawing.Point(83, 39)
        Me.DatFecha.Name = "DatFecha"
        Me.DatFecha.Size = New System.Drawing.Size(107, 22)
        Me.DatFecha.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(7, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 23)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "FECHA:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtBuscar
        '
        Me.BtBuscar.BackgroundImage = CType(resources.GetObject("BtBuscar.BackgroundImage"), System.Drawing.Image)
        Me.BtBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtBuscar.Location = New System.Drawing.Point(205, 4)
        Me.BtBuscar.Name = "BtBuscar"
        Me.BtBuscar.Size = New System.Drawing.Size(71, 57)
        Me.BtBuscar.TabIndex = 23
        Me.BtBuscar.UseVisualStyleBackColor = True
        '
        'TxtCodigoX
        '
        Me.TxtCodigoX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoX.Location = New System.Drawing.Point(82, 6)
        Me.TxtCodigoX.Name = "TxtCodigoX"
        Me.TxtCodigoX.Size = New System.Drawing.Size(111, 22)
        Me.TxtCodigoX.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 23)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "CODIGO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'report
        '
        Me.report.ReportDefinition = resources.GetString("report.ReportDefinition")
        Me.report.ReportName = "C1FlexReport1"
        '
        'Fv
        '
        Me.Fv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fv.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Fv.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Fv.Location = New System.Drawing.Point(3, 67)
        Me.Fv.Name = "Fv"
        Me.Fv.Size = New System.Drawing.Size(947, 603)
        Me.Fv.TabIndex = 27
        '
        'FrmFiniquito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 671)
        Me.Controls.Add(Me.Fv)
        Me.Controls.Add(Me.DatFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtBuscar)
        Me.Controls.Add(Me.TxtCodigoX)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmFiniquito"
        Me.ShowIcon = False
        Me.Text = "Impresion Finiquito"
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DatFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtBuscar As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents report As C1.Win.FlexReport.C1FlexReport
    Friend WithEvents Fv As C1.Win.FlexViewer.C1FlexViewer
End Class
