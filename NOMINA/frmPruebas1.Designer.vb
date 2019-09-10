<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPruebas1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPruebas1))
        Me.fv = New C1.Win.FlexViewer.C1FlexViewer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rp = New C1.Win.FlexReport.C1FlexReport()
        CType(Me.fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fv
        '
        Me.fv.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.fv.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.fv.Location = New System.Drawing.Point(93, 12)
        Me.fv.Name = "fv"
        Me.fv.Size = New System.Drawing.Size(680, 420)
        Me.fv.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 133)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rp
        '
        Me.rp.ReportDefinition = resources.GetString("rp.ReportDefinition")
        Me.rp.ReportName = "C1FlexReport1"
        '
        'frmPruebas1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 544)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.fv)
        Me.Name = "frmPruebas1"
        Me.Text = "frmPruebas1"
        CType(Me.fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fv As C1.Win.FlexViewer.C1FlexViewer
    Friend WithEvents Button1 As Button
    Friend WithEvents rp As C1.Win.FlexReport.C1FlexReport
End Class
