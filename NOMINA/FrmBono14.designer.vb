<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBono14
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBono14))
        Me.Btejecutar = New System.Windows.Forms.Button()
        Me.datanio = New System.Windows.Forms.DateTimePicker()
        Me.BtImprimir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDeposito = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txtcheques = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtTotales = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rp = New C1.Win.FlexReport.C1FlexReport()
        Me.Fv = New C1.Win.FlexViewer.C1FlexViewer()
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btejecutar
        '
        Me.Btejecutar.BackgroundImage = CType(resources.GetObject("Btejecutar.BackgroundImage"), System.Drawing.Image)
        Me.Btejecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btejecutar.Location = New System.Drawing.Point(135, 29)
        Me.Btejecutar.Name = "Btejecutar"
        Me.Btejecutar.Size = New System.Drawing.Size(65, 51)
        Me.Btejecutar.TabIndex = 10
        Me.Btejecutar.UseVisualStyleBackColor = True
        '
        'datanio
        '
        Me.datanio.CalendarMonthBackground = System.Drawing.Color.SkyBlue
        Me.datanio.CustomFormat = "yyyy"
        Me.datanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datanio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datanio.Location = New System.Drawing.Point(9, 49)
        Me.datanio.Name = "datanio"
        Me.datanio.ShowUpDown = True
        Me.datanio.Size = New System.Drawing.Size(89, 22)
        Me.datanio.TabIndex = 11
        '
        'BtImprimir
        '
        Me.BtImprimir.BackgroundImage = CType(resources.GetObject("BtImprimir.BackgroundImage"), System.Drawing.Image)
        Me.BtImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtImprimir.Location = New System.Drawing.Point(221, 29)
        Me.BtImprimir.Name = "BtImprimir"
        Me.BtImprimir.Size = New System.Drawing.Size(65, 52)
        Me.BtImprimir.TabIndex = 13
        Me.BtImprimir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(388, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 24)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "TOTAL DEPOSITO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDeposito
        '
        Me.TxtDeposito.AutoSize = True
        Me.TxtDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeposito.Location = New System.Drawing.Point(424, 64)
        Me.TxtDeposito.Name = "TxtDeposito"
        Me.TxtDeposito.Size = New System.Drawing.Size(0, 16)
        Me.TxtDeposito.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(552, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 24)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "TOTAL CHEQUES:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txtcheques
        '
        Me.Txtcheques.AutoSize = True
        Me.Txtcheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcheques.Location = New System.Drawing.Point(591, 63)
        Me.Txtcheques.Name = "Txtcheques"
        Me.Txtcheques.Size = New System.Drawing.Size(0, 16)
        Me.Txtcheques.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(399, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Q."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(561, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Q."
        '
        'BtTotales
        '
        Me.BtTotales.BackgroundImage = CType(resources.GetObject("BtTotales.BackgroundImage"), System.Drawing.Image)
        Me.BtTotales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtTotales.Location = New System.Drawing.Point(221, 29)
        Me.BtTotales.Name = "BtTotales"
        Me.BtTotales.Size = New System.Drawing.Size(65, 51)
        Me.BtTotales.TabIndex = 21
        Me.BtTotales.Text = "TOTALES"
        Me.BtTotales.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "CICLO"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Turquoise
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1076, 27)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "CALCULO DE BONO 14"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rp
        '
        Me.rp.ReportDefinition = resources.GetString("rp.ReportDefinition")
        Me.rp.ReportName = "C1FlexReport1"
        '
        'Fv
        '
        Me.Fv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fv.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Fv.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Fv.Location = New System.Drawing.Point(4, 87)
        Me.Fv.Name = "Fv"
        Me.Fv.Size = New System.Drawing.Size(1070, 647)
        Me.Fv.TabIndex = 40
        '
        'FrmBono14
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 737)
        Me.Controls.Add(Me.Fv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtTotales)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txtcheques)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtDeposito)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtImprimir)
        Me.Controls.Add(Me.datanio)
        Me.Controls.Add(Me.Btejecutar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmBono14"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btejecutar As System.Windows.Forms.Button
    Friend WithEvents datanio As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtImprimir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDeposito As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtcheques As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtTotales As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rp As C1.Win.FlexReport.C1FlexReport
    Friend WithEvents Fv As C1.Win.FlexViewer.C1FlexViewer
End Class
