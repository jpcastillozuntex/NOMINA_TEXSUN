<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBaja))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt2nombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grpbaja = New System.Windows.Forms.GroupBox()
        Me.TxtMateriales = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtMotivo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Cbtipo = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TxtPuesto = New System.Windows.Forms.TextBox()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.TxtBono = New System.Windows.Forms.TextBox()
        Me.Txtindemnizacion = New System.Windows.Forms.TextBox()
        Me.Txtvacaciones = New System.Windows.Forms.TextBox()
        Me.TxtAguinaldo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lbpuesto = New System.Windows.Forms.Label()
        Me.LbCodigo = New System.Windows.Forms.Label()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtBaja = New System.Windows.Forms.TextBox()
        Me.Txtalta = New System.Windows.Forms.TextBox()
        Me.BtImprimir = New System.Windows.Forms.Button()
        Me.BtCalcular = New System.Windows.Forms.Button()
        Me.DatFecha = New System.Windows.Forms.DateTimePicker()
        Me.TxCodigo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rp = New C1.Win.FlexReport.C1FlexReport()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grpbaja.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Aquamarine
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(453, 24)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "BAJA DE EMPLEADO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Txt2nombre
        '
        Me.Txt2nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt2nombre.Location = New System.Drawing.Point(152, 74)
        Me.Txt2nombre.Name = "Txt2nombre"
        Me.Txt2nombre.Size = New System.Drawing.Size(121, 24)
        Me.Txt2nombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "APELLIDO:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNombre
        '
        Me.TxtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.Location = New System.Drawing.Point(152, 49)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(121, 24)
        Me.TxtNombre.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "NOMBRE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fg
        '
        Me.fg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.fg.Location = New System.Drawing.Point(453, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.DefaultSize = 21
        Me.fg.Size = New System.Drawing.Size(535, 157)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 3
        '
        'Grpbaja
        '
        Me.Grpbaja.Controls.Add(Me.TxtMateriales)
        Me.Grpbaja.Controls.Add(Me.Label14)
        Me.Grpbaja.Controls.Add(Me.Label13)
        Me.Grpbaja.Controls.Add(Me.Label12)
        Me.Grpbaja.Controls.Add(Me.TxtMotivo)
        Me.Grpbaja.Controls.Add(Me.Label11)
        Me.Grpbaja.Controls.Add(Me.Cbtipo)
        Me.Grpbaja.Controls.Add(Me.TextBox1)
        Me.Grpbaja.Controls.Add(Me.TxtPuesto)
        Me.Grpbaja.Controls.Add(Me.TxtCodigo)
        Me.Grpbaja.Controls.Add(Me.TxtBono)
        Me.Grpbaja.Controls.Add(Me.Txtindemnizacion)
        Me.Grpbaja.Controls.Add(Me.Txtvacaciones)
        Me.Grpbaja.Controls.Add(Me.TxtAguinaldo)
        Me.Grpbaja.Controls.Add(Me.Label6)
        Me.Grpbaja.Controls.Add(Me.Label5)
        Me.Grpbaja.Controls.Add(Me.Label4)
        Me.Grpbaja.Controls.Add(Me.Label7)
        Me.Grpbaja.Controls.Add(Me.Lbpuesto)
        Me.Grpbaja.Controls.Add(Me.LbCodigo)
        Me.Grpbaja.Controls.Add(Me.lbNombre)
        Me.Grpbaja.Controls.Add(Me.Label8)
        Me.Grpbaja.Controls.Add(Me.Label9)
        Me.Grpbaja.Controls.Add(Me.TxtBaja)
        Me.Grpbaja.Controls.Add(Me.Txtalta)
        Me.Grpbaja.Controls.Add(Me.BtImprimir)
        Me.Grpbaja.Controls.Add(Me.BtCalcular)
        Me.Grpbaja.Controls.Add(Me.DatFecha)
        Me.Grpbaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grpbaja.Location = New System.Drawing.Point(2, 179)
        Me.Grpbaja.Name = "Grpbaja"
        Me.Grpbaja.Size = New System.Drawing.Size(987, 443)
        Me.Grpbaja.TabIndex = 4
        Me.Grpbaja.TabStop = False
        Me.Grpbaja.Text = "Proceso Baja"
        '
        'TxtMateriales
        '
        Me.TxtMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMateriales.Location = New System.Drawing.Point(673, 293)
        Me.TxtMateriales.Name = "TxtMateriales"
        Me.TxtMateriales.ReadOnly = True
        Me.TxtMateriales.Size = New System.Drawing.Size(100, 22)
        Me.TxtMateriales.TabIndex = 48
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SkyBlue
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(543, 292)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 23)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "MATERIALES:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SkyBlue
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(124, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 24)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "MOTIVO:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SkyBlue
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(124, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 24)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "FEC. BAJA:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotivo.Location = New System.Drawing.Point(308, 296)
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.ReadOnly = True
        Me.TxtMotivo.Size = New System.Drawing.Size(100, 22)
        Me.TxtMotivo.TabIndex = 44
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SkyBlue
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(186, 295)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 24)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "MOTIVO:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cbtipo
        '
        Me.Cbtipo.DisplayMember = "s"
        Me.Cbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbtipo.FormattingEnabled = True
        Me.Cbtipo.Items.AddRange(New Object() {"RENUNCIA", "DESPIDO", "ABANDONO"})
        Me.Cbtipo.Location = New System.Drawing.Point(244, 69)
        Me.Cbtipo.Name = "Cbtipo"
        Me.Cbtipo.Size = New System.Drawing.Size(121, 24)
        Me.Cbtipo.TabIndex = 42
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(308, 229)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(221, 22)
        Me.TextBox1.TabIndex = 41
        '
        'TxtPuesto
        '
        Me.TxtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPuesto.Location = New System.Drawing.Point(308, 261)
        Me.TxtPuesto.Name = "TxtPuesto"
        Me.TxtPuesto.ReadOnly = True
        Me.TxtPuesto.Size = New System.Drawing.Size(100, 22)
        Me.TxtPuesto.TabIndex = 40
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(308, 193)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.ReadOnly = True
        Me.TxtCodigo.Size = New System.Drawing.Size(100, 22)
        Me.TxtCodigo.TabIndex = 39
        '
        'TxtBono
        '
        Me.TxtBono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBono.Location = New System.Drawing.Point(673, 268)
        Me.TxtBono.Name = "TxtBono"
        Me.TxtBono.ReadOnly = True
        Me.TxtBono.Size = New System.Drawing.Size(100, 22)
        Me.TxtBono.TabIndex = 38
        '
        'Txtindemnizacion
        '
        Me.Txtindemnizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtindemnizacion.Location = New System.Drawing.Point(673, 243)
        Me.Txtindemnizacion.Name = "Txtindemnizacion"
        Me.Txtindemnizacion.ReadOnly = True
        Me.Txtindemnizacion.Size = New System.Drawing.Size(100, 22)
        Me.Txtindemnizacion.TabIndex = 37
        '
        'Txtvacaciones
        '
        Me.Txtvacaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtvacaciones.Location = New System.Drawing.Point(673, 218)
        Me.Txtvacaciones.Name = "Txtvacaciones"
        Me.Txtvacaciones.ReadOnly = True
        Me.Txtvacaciones.Size = New System.Drawing.Size(100, 22)
        Me.Txtvacaciones.TabIndex = 36
        '
        'TxtAguinaldo
        '
        Me.TxtAguinaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAguinaldo.Location = New System.Drawing.Point(673, 192)
        Me.TxtAguinaldo.Name = "TxtAguinaldo"
        Me.TxtAguinaldo.ReadOnly = True
        Me.TxtAguinaldo.Size = New System.Drawing.Size(100, 22)
        Me.TxtAguinaldo.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(543, 267)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 23)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "BONO 14:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(543, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 23)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "INDEMNIZACION:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(543, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 23)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "VACACIONES:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SkyBlue
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(543, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 23)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "AGUINALDO:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbpuesto
        '
        Me.Lbpuesto.BackColor = System.Drawing.Color.SkyBlue
        Me.Lbpuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbpuesto.Location = New System.Drawing.Point(186, 260)
        Me.Lbpuesto.Name = "Lbpuesto"
        Me.Lbpuesto.Size = New System.Drawing.Size(120, 24)
        Me.Lbpuesto.TabIndex = 30
        Me.Lbpuesto.Text = "PUESTO:"
        Me.Lbpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbCodigo
        '
        Me.LbCodigo.BackColor = System.Drawing.Color.SkyBlue
        Me.LbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCodigo.Location = New System.Drawing.Point(186, 192)
        Me.LbCodigo.Name = "LbCodigo"
        Me.LbCodigo.Size = New System.Drawing.Size(120, 24)
        Me.LbCodigo.TabIndex = 26
        Me.LbCodigo.Text = "CODIGO:"
        Me.LbCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbNombre
        '
        Me.lbNombre.BackColor = System.Drawing.Color.SkyBlue
        Me.lbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNombre.Location = New System.Drawing.Point(186, 228)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(120, 24)
        Me.lbNombre.TabIndex = 29
        Me.lbNombre.Text = "NOMBRE:"
        Me.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(496, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 16)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "A:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(441, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 24)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "CICLO DE LABORAR EN LA EMPRESA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtBaja
        '
        Me.TxtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBaja.Location = New System.Drawing.Point(528, 141)
        Me.TxtBaja.Name = "TxtBaja"
        Me.TxtBaja.ReadOnly = True
        Me.TxtBaja.Size = New System.Drawing.Size(111, 22)
        Me.TxtBaja.TabIndex = 25
        '
        'Txtalta
        '
        Me.Txtalta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtalta.Location = New System.Drawing.Point(372, 141)
        Me.Txtalta.Name = "Txtalta"
        Me.Txtalta.ReadOnly = True
        Me.Txtalta.Size = New System.Drawing.Size(111, 22)
        Me.Txtalta.TabIndex = 24
        '
        'BtImprimir
        '
        Me.BtImprimir.BackgroundImage = CType(resources.GetObject("BtImprimir.BackgroundImage"), System.Drawing.Image)
        Me.BtImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtImprimir.Location = New System.Drawing.Point(476, 354)
        Me.BtImprimir.Name = "BtImprimir"
        Me.BtImprimir.Size = New System.Drawing.Size(65, 52)
        Me.BtImprimir.TabIndex = 23
        Me.BtImprimir.UseVisualStyleBackColor = True
        '
        'BtCalcular
        '
        Me.BtCalcular.BackgroundImage = CType(resources.GetObject("BtCalcular.BackgroundImage"), System.Drawing.Image)
        Me.BtCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtCalcular.Location = New System.Drawing.Point(476, 15)
        Me.BtCalcular.Name = "BtCalcular"
        Me.BtCalcular.Size = New System.Drawing.Size(65, 52)
        Me.BtCalcular.TabIndex = 22
        Me.BtCalcular.UseVisualStyleBackColor = True
        '
        'DatFecha
        '
        Me.DatFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatFecha.Location = New System.Drawing.Point(244, 31)
        Me.DatFecha.Name = "DatFecha"
        Me.DatFecha.Size = New System.Drawing.Size(121, 22)
        Me.DatFecha.TabIndex = 21
        '
        'TxCodigo
        '
        Me.TxCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxCodigo.Location = New System.Drawing.Point(152, 100)
        Me.TxCodigo.Name = "TxCodigo"
        Me.TxCodigo.Size = New System.Drawing.Size(121, 24)
        Me.TxCodigo.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SkyBlue
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(50, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "CODIGO:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rp
        '
        Me.rp.ReportDefinition = resources.GetString("rp.ReportDefinition")
        Me.rp.ReportName = "C1FlexReport1"
        '
        'FrmBaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 624)
        Me.Controls.Add(Me.TxCodigo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Grpbaja)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt2nombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fg)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBaja"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grpbaja.ResumeLayout(False)
        Me.Grpbaja.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt2nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grpbaja As System.Windows.Forms.GroupBox
    Friend WithEvents Cbtipo As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtPuesto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtBono As System.Windows.Forms.TextBox
    Friend WithEvents Txtindemnizacion As System.Windows.Forms.TextBox
    Friend WithEvents Txtvacaciones As System.Windows.Forms.TextBox
    Friend WithEvents TxtAguinaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Lbpuesto As System.Windows.Forms.Label
    Friend WithEvents LbCodigo As System.Windows.Forms.Label
    Friend WithEvents lbNombre As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtBaja As System.Windows.Forms.TextBox
    Friend WithEvents Txtalta As System.Windows.Forms.TextBox
    Friend WithEvents BtImprimir As System.Windows.Forms.Button
    Friend WithEvents BtCalcular As System.Windows.Forms.Button
    Friend WithEvents DatFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtMateriales As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents rp As C1.Win.FlexReport.C1FlexReport
End Class
