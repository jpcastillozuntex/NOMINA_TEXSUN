<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmreportesaldos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmreportesaldos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fr = New C1.Win.FlexReport.C1FlexReport()
        Me.Fv = New C1.Win.FlexViewer.C1FlexViewer()
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Aquamarine
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1062, 30)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "SALDO DE ANTICIPOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fr
        '
        Me.fr.ReportDefinition = resources.GetString("fr.ReportDefinition")
        Me.fr.ReportName = "C1FlexReport1"
        '
        'Fv
        '
        Me.Fv.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.Fv.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.Fv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fv.Location = New System.Drawing.Point(0, 0)
        Me.Fv.Name = "Fv"
        Me.Fv.Size = New System.Drawing.Size(1064, 895)
        Me.Fv.TabIndex = 49
        '
        'Frmreportesaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 895)
        Me.Controls.Add(Me.Fv)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frmreportesaldos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fr As C1.Win.FlexReport.C1FlexReport
    Friend WithEvents Fv As C1.Win.FlexViewer.C1FlexViewer
End Class
