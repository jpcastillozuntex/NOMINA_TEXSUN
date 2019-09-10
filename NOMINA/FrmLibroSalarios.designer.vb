<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLibroSalarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLibroSalarios))
        Me.BtCalcular = New System.Windows.Forms.Button()
        Me.Datanio = New System.Windows.Forms.DateTimePicker()
        Me.Txtdesde = New System.Windows.Forms.TextBox()
        Me.Txthasta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rp = New C1.Win.FlexReport.C1FlexReport()
        Me.Fv = New C1.Win.FlexViewer.C1FlexViewer()
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtCalcular
        '
        Me.BtCalcular.BackgroundImage = CType(resources.GetObject("BtCalcular.BackgroundImage"), System.Drawing.Image)
        Me.BtCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtCalcular.Location = New System.Drawing.Point(193, 25)
        Me.BtCalcular.Name = "BtCalcular"
        Me.BtCalcular.Size = New System.Drawing.Size(65, 52)
        Me.BtCalcular.TabIndex = 2
        Me.BtCalcular.UseVisualStyleBackColor = True
        '
        'Datanio
        '
        Me.Datanio.CalendarMonthBackground = System.Drawing.Color.SkyBlue
        Me.Datanio.CustomFormat = "yyyy"
        Me.Datanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datanio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Datanio.Location = New System.Drawing.Point(99, 19)
        Me.Datanio.Name = "Datanio"
        Me.Datanio.ShowUpDown = True
        Me.Datanio.Size = New System.Drawing.Size(63, 24)
        Me.Datanio.TabIndex = 4
        '
        'Txtdesde
        '
        Me.Txtdesde.BackColor = System.Drawing.Color.White
        Me.Txtdesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtdesde.Location = New System.Drawing.Point(99, 43)
        Me.Txtdesde.Name = "Txtdesde"
        Me.Txtdesde.Size = New System.Drawing.Size(63, 24)
        Me.Txtdesde.TabIndex = 5
        '
        'Txthasta
        '
        Me.Txthasta.BackColor = System.Drawing.Color.White
        Me.Txthasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txthasta.Location = New System.Drawing.Point(99, 70)
        Me.Txthasta.Name = "Txthasta"
        Me.Txthasta.Size = New System.Drawing.Size(63, 24)
        Me.Txthasta.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "CODIGO:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "AL:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 23)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "AÑO:"
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
        Me.Fv.Location = New System.Drawing.Point(3, 97)
        Me.Fv.Name = "Fv"
        Me.Fv.Size = New System.Drawing.Size(1200, 843)
        Me.Fv.TabIndex = 41
        '
        'FrmLibroSalarios
        '
        Me.AcceptButton = Me.BtCalcular
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 941)
        Me.Controls.Add(Me.Fv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txthasta)
        Me.Controls.Add(Me.Txtdesde)
        Me.Controls.Add(Me.Datanio)
        Me.Controls.Add(Me.BtCalcular)
        Me.Name = "FrmLibroSalarios"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRESION DE LIBRO DE SALARIOS"
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtCalcular As System.Windows.Forms.Button
    Friend WithEvents Datanio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txtdesde As System.Windows.Forms.TextBox
    Friend WithEvents Txthasta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rp As C1.Win.FlexReport.C1FlexReport
    Friend WithEvents Fv As C1.Win.FlexViewer.C1FlexViewer
End Class
