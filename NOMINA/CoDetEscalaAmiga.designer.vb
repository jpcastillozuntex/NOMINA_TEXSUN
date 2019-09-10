<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoDetEscalaAmiga
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoDetEscalaAmiga))
        Me.f = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lbCpo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cbmodelo = New System.Windows.Forms.ComboBox()
        Me.escala1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbEstilo = New System.Windows.Forms.Label()
        Me.escala2 = New System.Windows.Forms.Timer(Me.components)
        Me.escala3 = New System.Windows.Forms.Timer(Me.components)
        Me.escala4 = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbcolor = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.S = New System.Windows.Forms.CheckBox()
        Me.R = New System.Windows.Forms.CheckBox()
        Me.C = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.js = New System.Windows.Forms.CheckBox()
        Me.fs = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.BtGuardar = New System.Windows.Forms.Button()
        Me.rbpequeñas = New System.Windows.Forms.RadioButton()
        Me.rbgrandes = New System.Windows.Forms.RadioButton()
        Me.Mt = New System.Windows.Forms.CheckBox()
        CType(Me.f, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'f
        '
        Me.f.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Rows
        Me.f.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
        Me.f.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Custom
        Me.f.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.f.ColumnInfo = resources.GetString("f.ColumnInfo")
        Me.f.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f.Location = New System.Drawing.Point(3, 79)
        Me.f.Name = "f"
        Me.f.Rows.DefaultSize = 19
        Me.f.Size = New System.Drawing.Size(1179, 542)
        Me.f.StyleInfo = resources.GetString("f.StyleInfo")
        Me.f.TabIndex = 0
        '
        'lbCpo
        '
        Me.lbCpo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbCpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbCpo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCpo.Location = New System.Drawing.Point(87, 5)
        Me.lbCpo.Name = "lbCpo"
        Me.lbCpo.Size = New System.Drawing.Size(251, 22)
        Me.lbCpo.TabIndex = 1
        Me.lbCpo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "cpo:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(366, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Modelo:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cbmodelo
        '
        Me.Cbmodelo.FormattingEnabled = True
        Me.Cbmodelo.Location = New System.Drawing.Point(440, 6)
        Me.Cbmodelo.Name = "Cbmodelo"
        Me.Cbmodelo.Size = New System.Drawing.Size(181, 22)
        Me.Cbmodelo.TabIndex = 5
        '
        'escala1
        '
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 21)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Estilo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbEstilo
        '
        Me.lbEstilo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbEstilo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbEstilo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstilo.Location = New System.Drawing.Point(87, 29)
        Me.lbEstilo.Name = "lbEstilo"
        Me.lbEstilo.Size = New System.Drawing.Size(251, 22)
        Me.lbEstilo.TabIndex = 8
        Me.lbEstilo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'escala2
        '
        '
        'escala3
        '
        '
        'escala4
        '
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(894, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(275, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "\\192.9.200.134\Validacion_nest_telas\"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(894, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "estilo_R_1"
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(771, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 18)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Rata de archivo:"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(772, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 17)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Formato Nombre:"
        '
        'lbcolor
        '
        Me.lbcolor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcolor.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcolor.Location = New System.Drawing.Point(87, 54)
        Me.lbcolor.Name = "lbcolor"
        Me.lbcolor.Size = New System.Drawing.Size(251, 22)
        Me.lbcolor.TabIndex = 51
        Me.lbcolor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.Label9.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 21)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Color:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'S
        '
        Me.S.AutoSize = True
        Me.S.Location = New System.Drawing.Point(787, 54)
        Me.S.Name = "S"
        Me.S.Size = New System.Drawing.Size(33, 18)
        Me.S.TabIndex = 52
        Me.S.Text = "S"
        Me.S.UseVisualStyleBackColor = True
        '
        'R
        '
        Me.R.AutoSize = True
        Me.R.Location = New System.Drawing.Point(826, 54)
        Me.R.Name = "R"
        Me.R.Size = New System.Drawing.Size(33, 18)
        Me.R.TabIndex = 53
        Me.R.Text = "R"
        Me.R.UseVisualStyleBackColor = True
        '
        'C
        '
        Me.C.AutoSize = True
        Me.C.Location = New System.Drawing.Point(863, 54)
        Me.C.Name = "C"
        Me.C.Size = New System.Drawing.Size(33, 18)
        Me.C.TabIndex = 54
        Me.C.Text = "C"
        Me.C.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(661, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 21)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Tipo tela Nester:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'js
        '
        Me.js.AutoSize = True
        Me.js.Location = New System.Drawing.Point(899, 54)
        Me.js.Name = "js"
        Me.js.Size = New System.Drawing.Size(33, 18)
        Me.js.TabIndex = 56
        Me.js.Text = "J"
        Me.js.UseVisualStyleBackColor = True
        '
        'fs
        '
        Me.fs.AutoSize = True
        Me.fs.Location = New System.Drawing.Point(938, 54)
        Me.fs.Name = "fs"
        Me.fs.Size = New System.Drawing.Size(33, 18)
        Me.fs.TabIndex = 57
        Me.fs.Text = "F"
        Me.fs.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Costeo.My.Resources.Resources.recalcular
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(367, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 45)
        Me.Button1.TabIndex = 58
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnExcel
        '
        Me.BtnExcel.BackgroundImage = CType(resources.GetObject("BtnExcel.BackgroundImage"), System.Drawing.Image)
        Me.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnExcel.Location = New System.Drawing.Point(713, 5)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(49, 43)
        Me.BtnExcel.TabIndex = 46
        Me.BtnExcel.UseVisualStyleBackColor = True
        '
        'BtGuardar
        '
        Me.BtGuardar.BackgroundImage = CType(resources.GetObject("BtGuardar.BackgroundImage"), System.Drawing.Image)
        Me.BtGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtGuardar.Location = New System.Drawing.Point(655, 5)
        Me.BtGuardar.Name = "BtGuardar"
        Me.BtGuardar.Size = New System.Drawing.Size(51, 43)
        Me.BtGuardar.TabIndex = 6
        Me.BtGuardar.UseVisualStyleBackColor = True
        '
        'rbpequeñas
        '
        Me.rbpequeñas.AutoSize = True
        Me.rbpequeñas.Location = New System.Drawing.Point(440, 34)
        Me.rbpequeñas.Name = "rbpequeñas"
        Me.rbpequeñas.Size = New System.Drawing.Size(102, 18)
        Me.rbpequeñas.TabIndex = 59
        Me.rbpequeñas.TabStop = True
        Me.rbpequeñas.Text = "T. pequeñas"
        Me.rbpequeñas.UseVisualStyleBackColor = True
        '
        'rbgrandes
        '
        Me.rbgrandes.AutoSize = True
        Me.rbgrandes.Location = New System.Drawing.Point(440, 58)
        Me.rbgrandes.Name = "rbgrandes"
        Me.rbgrandes.Size = New System.Drawing.Size(95, 18)
        Me.rbgrandes.TabIndex = 60
        Me.rbgrandes.TabStop = True
        Me.rbgrandes.Text = "T. grandes"
        Me.rbgrandes.UseVisualStyleBackColor = True
        '
        'Mt
        '
        Me.Mt.AutoSize = True
        Me.Mt.Location = New System.Drawing.Point(977, 54)
        Me.Mt.Name = "Mt"
        Me.Mt.Size = New System.Drawing.Size(33, 18)
        Me.Mt.TabIndex = 61
        Me.Mt.Text = "M"
        Me.Mt.UseVisualStyleBackColor = True
        '
        'CoDetEscalaAmiga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 625)
        Me.Controls.Add(Me.Mt)
        Me.Controls.Add(Me.rbgrandes)
        Me.Controls.Add(Me.rbpequeñas)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.fs)
        Me.Controls.Add(Me.js)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.C)
        Me.Controls.Add(Me.R)
        Me.Controls.Add(Me.S)
        Me.Controls.Add(Me.lbcolor)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnExcel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbEstilo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtGuardar)
        Me.Controls.Add(Me.Cbmodelo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbCpo)
        Me.Controls.Add(Me.f)
        Me.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CoDetEscalaAmiga"
        Me.ShowIcon = False
        Me.Text = "Desgloce Escalas"
        CType(Me.f, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents f As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbCpo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cbmodelo As System.Windows.Forms.ComboBox
    Friend WithEvents BtGuardar As System.Windows.Forms.Button
    Friend WithEvents escala1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbEstilo As System.Windows.Forms.Label
    Friend WithEvents escala2 As System.Windows.Forms.Timer
    Friend WithEvents escala3 As System.Windows.Forms.Timer
    Friend WithEvents escala4 As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbcolor As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents S As System.Windows.Forms.CheckBox
    Friend WithEvents R As System.Windows.Forms.CheckBox
    Friend WithEvents C As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents js As System.Windows.Forms.CheckBox
    Friend WithEvents fs As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents rbpequeñas As RadioButton
    Friend WithEvents rbgrandes As RadioButton
    Friend WithEvents Mt As CheckBox
End Class
