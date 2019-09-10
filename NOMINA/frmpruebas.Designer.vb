<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pruebas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pruebas))
        Me.fv = New C1.Win.FlexViewer.C1FlexViewer()
        Me.rp = New C1.Win.FlexReport.C1FlexReport()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fv
        '
        Me.fv.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.fv.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.fv.Location = New System.Drawing.Point(186, 3)
        Me.fv.Name = "fv"
        Me.fv.Size = New System.Drawing.Size(797, 540)
        Me.fv.TabIndex = 0
        '
        'rp
        '
        Me.rp.ReportDefinition = resources.GetString("rp.ReportDefinition")
        Me.rp.ReportName = "C1FlexReport1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(41, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 555)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.fv)
        Me.Name = "pruebas"
        Me.Text = "pruebas"
        CType(Me.fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fv As C1.Win.FlexViewer.C1FlexViewer
    Friend WithEvents rp As C1.Win.FlexReport.C1FlexReport
    Friend WithEvents Button1 As Button
End Class
