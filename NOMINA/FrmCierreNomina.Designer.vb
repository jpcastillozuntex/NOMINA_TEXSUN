<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCierreNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCierreNomina))
        Me.DatAnio = New System.Windows.Forms.DateTimePicker()
        Me.Cbmes = New System.Windows.Forms.ComboBox()
        Me.BtCierra = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbCiclo = New System.Windows.Forms.ComboBox()
        Me.mensajes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cr = New C1.Win.FlexReport.C1FlexReport()
        Me.Fv = New C1.Win.FlexViewer.C1FlexViewer()
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatAnio
        '
        Me.DatAnio.CustomFormat = "yyyy"
        Me.DatAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatAnio.Location = New System.Drawing.Point(113, 7)
        Me.DatAnio.Name = "DatAnio"
        Me.DatAnio.ShowUpDown = True
        Me.DatAnio.Size = New System.Drawing.Size(128, 24)
        Me.DatAnio.TabIndex = 36
        '
        'Cbmes
        '
        Me.Cbmes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbmes.FormattingEnabled = True
        Me.Cbmes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cbmes.Location = New System.Drawing.Point(113, 32)
        Me.Cbmes.Name = "Cbmes"
        Me.Cbmes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cbmes.Size = New System.Drawing.Size(128, 24)
        Me.Cbmes.TabIndex = 35
        '
        'BtCierra
        '
        Me.BtCierra.BackgroundImage = CType(resources.GetObject("BtCierra.BackgroundImage"), System.Drawing.Image)
        Me.BtCierra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtCierra.Location = New System.Drawing.Point(266, 12)
        Me.BtCierra.Name = "BtCierra"
        Me.BtCierra.Size = New System.Drawing.Size(75, 62)
        Me.BtCierra.TabIndex = 34
        Me.BtCierra.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 24)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "QUINCENA:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 24)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "MES:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "AÑO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbCiclo
        '
        Me.CbCiclo.BackColor = System.Drawing.Color.SkyBlue
        Me.CbCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCiclo.FormattingEnabled = True
        Me.CbCiclo.Items.AddRange(New Object() {"1", "2"})
        Me.CbCiclo.Location = New System.Drawing.Point(113, 57)
        Me.CbCiclo.Name = "CbCiclo"
        Me.CbCiclo.Size = New System.Drawing.Size(128, 26)
        Me.CbCiclo.TabIndex = 30
        '
        'mensajes
        '
        Me.mensajes.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress
        Me.mensajes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.mensajes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mensajes.ForeColor = System.Drawing.Color.OrangeRed
        Me.mensajes.Location = New System.Drawing.Point(380, 57)
        Me.mensajes.Name = "mensajes"
        Me.mensajes.Size = New System.Drawing.Size(417, 40)
        Me.mensajes.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.BackColor = System.Drawing.Color.MediumTurquoise
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(344, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(488, 41)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "CIERRE  DE NOMINA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Fv.Location = New System.Drawing.Point(4, 89)
        Me.Fv.Name = "Fv"
        Me.Fv.Size = New System.Drawing.Size(1171, 672)
        Me.Fv.TabIndex = 41
        '
        'FrmCierreNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 763)
        Me.Controls.Add(Me.Fv)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.mensajes)
        Me.Controls.Add(Me.DatAnio)
        Me.Controls.Add(Me.Cbmes)
        Me.Controls.Add(Me.BtCierra)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbCiclo)
        Me.Name = "FrmCierreNomina"
        Me.ShowIcon = False
        CType(Me.Fv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DatAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cbmes As System.Windows.Forms.ComboBox
    Friend WithEvents BtCierra As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbCiclo As System.Windows.Forms.ComboBox
    Friend WithEvents mensajes As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cr As C1.Win.FlexReport.C1FlexReport
    Friend WithEvents Fv As C1.Win.FlexViewer.C1FlexViewer
End Class
