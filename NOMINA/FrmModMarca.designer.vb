<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModMarca
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModMarca))
        Me.Cbmes = New System.Windows.Forms.ComboBox()
        Me.BtConsultar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbCiclo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbcodigo = New System.Windows.Forms.ComboBox()
        Me.f = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lbanio = New System.Windows.Forms.Label()
        Me.Btguardar = New System.Windows.Forms.Button()
        CType(Me.f, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cbmes
        '
        Me.Cbmes.Enabled = False
        Me.Cbmes.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbmes.FormattingEnabled = True
        Me.Cbmes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cbmes.Location = New System.Drawing.Point(114, 37)
        Me.Cbmes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cbmes.Name = "Cbmes"
        Me.Cbmes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cbmes.Size = New System.Drawing.Size(122, 24)
        Me.Cbmes.TabIndex = 23
        '
        'BtConsultar
        '
        Me.BtConsultar.BackgroundImage = CType(resources.GetObject("BtConsultar.BackgroundImage"), System.Drawing.Image)
        Me.BtConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtConsultar.Location = New System.Drawing.Point(257, 25)
        Me.BtConsultar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtConsultar.Name = "BtConsultar"
        Me.BtConsultar.Size = New System.Drawing.Size(64, 57)
        Me.BtConsultar.TabIndex = 22
        Me.BtConsultar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 23)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "QUINCENA:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 23)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "MES:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "AÑO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbCiclo
        '
        Me.CbCiclo.Enabled = False
        Me.CbCiclo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCiclo.FormattingEnabled = True
        Me.CbCiclo.Items.AddRange(New Object() {"1", "2"})
        Me.CbCiclo.Location = New System.Drawing.Point(114, 65)
        Me.CbCiclo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CbCiclo.Name = "CbCiclo"
        Me.CbCiclo.Size = New System.Drawing.Size(122, 24)
        Me.CbCiclo.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 23)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "CODIGO:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbcodigo
        '
        Me.cbcodigo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcodigo.FormattingEnabled = True
        Me.cbcodigo.Items.AddRange(New Object() {"1", "2"})
        Me.cbcodigo.Location = New System.Drawing.Point(114, 92)
        Me.cbcodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbcodigo.Name = "cbcodigo"
        Me.cbcodigo.Size = New System.Drawing.Size(122, 24)
        Me.cbcodigo.TabIndex = 24
        '
        'f
        '
        Me.f.ColumnInfo = resources.GetString("f.ColumnInfo")
        Me.f.Location = New System.Drawing.Point(5, 130)
        Me.f.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.f.Name = "f"
        Me.f.Rows.DefaultSize = 21
        Me.f.Size = New System.Drawing.Size(869, 434)
        Me.f.StyleInfo = resources.GetString("f.StyleInfo")
        Me.f.TabIndex = 26
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1", "2"})
        Me.ComboBox1.Location = New System.Drawing.Point(114, 93)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(169, 24)
        Me.ComboBox1.TabIndex = 24
        '
        'lbanio
        '
        Me.lbanio.BackColor = System.Drawing.SystemColors.Control
        Me.lbanio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbanio.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbanio.Location = New System.Drawing.Point(115, 10)
        Me.lbanio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbanio.Name = "lbanio"
        Me.lbanio.Size = New System.Drawing.Size(121, 23)
        Me.lbanio.TabIndex = 27
        Me.lbanio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btguardar
        '
        Me.Btguardar.BackgroundImage = CType(resources.GetObject("Btguardar.BackgroundImage"), System.Drawing.Image)
        Me.Btguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btguardar.Location = New System.Drawing.Point(335, 25)
        Me.Btguardar.Name = "Btguardar"
        Me.Btguardar.Size = New System.Drawing.Size(64, 57)
        Me.Btguardar.TabIndex = 28
        Me.Btguardar.UseVisualStyleBackColor = True
        '
        'FrmModMarca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 566)
        Me.Controls.Add(Me.Btguardar)
        Me.Controls.Add(Me.lbanio)
        Me.Controls.Add(Me.f)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbcodigo)
        Me.Controls.Add(Me.Cbmes)
        Me.Controls.Add(Me.BtConsultar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbCiclo)
        Me.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmModMarca"
        Me.ShowIcon = False
        Me.Text = "Modifica Hora de Marcas"
        CType(Me.f, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cbmes As System.Windows.Forms.ComboBox
    Friend WithEvents BtConsultar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbCiclo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbcodigo As System.Windows.Forms.ComboBox
    Friend WithEvents f As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lbanio As System.Windows.Forms.Label
    Friend WithEvents Btguardar As System.Windows.Forms.Button
End Class
