<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCarnet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCarnet))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.BtBuscar = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Pbatras = New System.Windows.Forms.PictureBox()
        Me.Lbapellido = New System.Windows.Forms.Label()
        Me.Lbnombre = New System.Windows.Forms.Label()
        Me.PbFoto = New System.Windows.Forms.PictureBox()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.LbPuesto = New System.Windows.Forms.Label()
        Me.Lbcodigo = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbCodigo = New System.Windows.Forms.ComboBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbatras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(133, 99)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(230, 290)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'BtBuscar
        '
        Me.BtBuscar.BackgroundImage = CType(resources.GetObject("BtBuscar.BackgroundImage"), System.Drawing.Image)
        Me.BtBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtBuscar.Location = New System.Drawing.Point(478, 47)
        Me.BtBuscar.Name = "BtBuscar"
        Me.BtBuscar.Size = New System.Drawing.Size(54, 47)
        Me.BtBuscar.TabIndex = 2
        Me.BtBuscar.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Pbatras
        '
        Me.Pbatras.Image = CType(resources.GetObject("Pbatras.Image"), System.Drawing.Image)
        Me.Pbatras.Location = New System.Drawing.Point(367, 99)
        Me.Pbatras.Name = "Pbatras"
        Me.Pbatras.Size = New System.Drawing.Size(230, 290)
        Me.Pbatras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pbatras.TabIndex = 1
        Me.Pbatras.TabStop = False
        '
        'Lbapellido
        '
        Me.Lbapellido.BackColor = System.Drawing.Color.Transparent
        Me.Lbapellido.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbapellido.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Lbapellido.Location = New System.Drawing.Point(205, 237)
        Me.Lbapellido.Name = "Lbapellido"
        Me.Lbapellido.Size = New System.Drawing.Size(153, 16)
        Me.Lbapellido.TabIndex = 4
        '
        'Lbnombre
        '
        Me.Lbnombre.BackColor = System.Drawing.Color.Transparent
        Me.Lbnombre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbnombre.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Lbnombre.Location = New System.Drawing.Point(205, 218)
        Me.Lbnombre.Name = "Lbnombre"
        Me.Lbnombre.Size = New System.Drawing.Size(153, 16)
        Me.Lbnombre.TabIndex = 3
        '
        'PbFoto
        '
        Me.PbFoto.Location = New System.Drawing.Point(144, 114)
        Me.PbFoto.Name = "PbFoto"
        Me.PbFoto.Size = New System.Drawing.Size(87, 96)
        Me.PbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PbFoto.TabIndex = 94
        Me.PbFoto.TabStop = False
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'LbPuesto
        '
        Me.LbPuesto.BackColor = System.Drawing.Color.Transparent
        Me.LbPuesto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPuesto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LbPuesto.Location = New System.Drawing.Point(165, 256)
        Me.LbPuesto.Name = "LbPuesto"
        Me.LbPuesto.Size = New System.Drawing.Size(187, 18)
        Me.LbPuesto.TabIndex = 5
        '
        'Lbcodigo
        '
        Me.Lbcodigo.BackColor = System.Drawing.Color.Transparent
        Me.Lbcodigo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbcodigo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Lbcodigo.Location = New System.Drawing.Point(210, 356)
        Me.Lbcodigo.Name = "Lbcodigo"
        Me.Lbcodigo.Size = New System.Drawing.Size(75, 20)
        Me.Lbcodigo.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(327, 401)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 63)
        Me.Button1.TabIndex = 7
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(201, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(327, 27)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "IMPRESION DE CARNET"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbCodigo
        '
        Me.CbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCodigo.FormattingEnabled = True
        Me.CbCodigo.Location = New System.Drawing.Point(284, 69)
        Me.CbCodigo.Name = "CbCodigo"
        Me.CbCodigo.Size = New System.Drawing.Size(121, 24)
        Me.CbCodigo.TabIndex = 96
        '
        'TxtNombre
        '
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(284, 46)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(121, 22)
        Me.TxtNombre.TabIndex = 97
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(143, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 22)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "PRIMER NOMBRE:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(143, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 22)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "CODIGO:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCarnet
        '
        Me.AcceptButton = Me.BtBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 498)
        Me.Controls.Add(Me.LbPuesto)
        Me.Controls.Add(Me.Lbapellido)
        Me.Controls.Add(Me.Lbnombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.CbCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Lbcodigo)
        Me.Controls.Add(Me.Pbatras)
        Me.Controls.Add(Me.PbFoto)
        Me.Controls.Add(Me.BtBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCarnet"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Pbatras,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PbFoto,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents BtBuscar As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Lbapellido As System.Windows.Forms.Label
    Friend WithEvents Lbnombre As System.Windows.Forms.Label
    Friend WithEvents Pbatras As System.Windows.Forms.PictureBox
    Friend WithEvents PbFoto As System.Windows.Forms.PictureBox
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Lbcodigo As System.Windows.Forms.Label
    Friend WithEvents LbPuesto As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbCodigo As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
