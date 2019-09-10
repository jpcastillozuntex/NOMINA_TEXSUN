Imports C1.Win.C1FlexGrid
Imports System.Data.OleDb
Imports System.Text
Imports System.IO

Public Class CoDetEscalaAmiga
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim ms As String
    Dim q100 = CoEscalaMario.q100
    Dim min = CoEscalaMario.min
    Dim max = CoEscalaMario.max
    Dim cpo = CoEscalaMario.cpo
    Dim escala = CoEscalaMario.escala
    Dim estilo = CoEscalaMario.estilo
    Dim estilo_c = CoEscalaMario.estilo_c
    Dim dt_cortes = CoEscalaMario.dt_cortes
    Dim color_cpo As String = CoEscalaMario.color
    Dim M(4, 11) As Integer
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim rg As C1.Win.C1FlexGrid.CellRange
    Dim cliente = CoEscalaMario.cliente
    Dim dt_modelos As New DataTable
    Dim msj As String
    Dim pat As String = "\\192.9.200.134\Validaciones\"
    Dim pat_bd As String = "\\192.9.200.134\Database\Texsun\Test\"
    Dim imput_mtx As String = "\\192.9.200.134\Input\"
    Dim d_esc As New DataTable
    Dim empresa As String = FrmInicio.empresa
    'Dim pat As String = "C:\validaciones\"
    'Dim pat_bd As String = "C:\bd_nester\"
    'Dim imput_mtx As String = "C:\imput_nestserver\"

    Dim fila As Integer
    Dim col As Integer
    Dim arch1 As String
    Dim arch2 As String
    Dim arch3 As String
    Dim arch4 As String

    Dim arch1_imp As String
    Dim arch2_imp As String
    Dim arch3_imp As String
    Dim arch4_imp As String
    Dim dt_escala As New DataTable
    Dim d_e_f As New DataTable
    Dim dt_combos As New DataTable
    Dim cont As Integer = 0
    Dim log As New StringBuilder
    Dim arc1 As Boolean = False
    Dim arc2 As Boolean = False
    Dim arc3 As Boolean = False
    Dim arc4 As Boolean = False
    Public watchfolder As FileSystemWatcher
    Dim dt_desgloce As New DataTable
    Dim mescala(10) As Integer

    Private Sub CoDetEscalaAmiga_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        rbpequeñas.Checked = True
        f(5, 14) = 0
        BtGuardar.Visible = False
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        f.Rows.Count = 16
        Formatos()

        For i = 0 To 9
            f(2, i + 2) = q100(i)
        Next
        '''''''VALIDA SI SE CORRE ESCALA AMIGA
        If min = 0 And max = 0 Or max = min Then
            For I = 0 To q100.Length - 1
                If (q100(I) * 2 / 100) < 1 And q100(I) > 0 Then
                    mescala(I) = q100(I) + 1
                ElseIf (q100(I) * 2 / 100) > 1 And q100(I) > 0 Then
                    mescala(I) = q100(I) + (q100(I) * 2 / 100)
                End If
            Next
        Else
            mescala = Escala_amiga(q100, min, max)
        End If
        ''''''''IMPRIME ESCALA AMIGA O ESCALA NO AMIGA
        For i = 0 To 9
            f(4, i + 2) = mescala(i)
        Next
        Busca_modelos()
        lbCpo.Text = cpo
        lbEstilo.Text = estilo
        lbcolor.Text = color_cpo
        Solicita_Escalas()
        '  End If
        CREATABLE()
    End Sub


    Private Sub Solicita_Escalas()
        For i = 0 To 3
            For j = 0 To 10
                M(i, j) = 0
            Next
        Next
        If rbgrandes.Checked = True Then
            M = cs.Desgloce_escalas_columbia(mescala, 8)
        ElseIf rbpequeñas.Checked = True Then
            M = cs.Desgloce_escalas(mescala)
        End If

        For i = 0 To 3
            For j = 0 To 10
                f(i + 7, j + 2) = M(i, j)
            Next
        Next

        scr = "SELECT T1,T2,T3,T4,T5,T6,T7,T8,T9,T0 FROM E_TALLAS_M WHERE ESCALA ='" & escala & "'"
        If cs.Consultajt(scr, dt_escala, msj) Then
        Else
            scr = "SELECT T1,T2,T3,T4,T5,T6,T7,T8,T9,T0 FROM E_TALLAS WHERE ESCALA ='" & escala & "'"
        End If
        If cs.Consultajt(scr, dt_escala, msj) Then
            f(0, 2) = dt_escala(0)(0)
            f(0, 3) = dt_escala(0)(1)
            f(0, 4) = dt_escala(0)(2)
            f(0, 5) = dt_escala(0)(3)
            f(0, 6) = dt_escala(0)(4)
            f(0, 7) = dt_escala(0)(5)
            f(0, 8) = dt_escala(0)(6)
            f(0, 9) = dt_escala(0)(7)
            f(0, 10) = dt_escala(0)(8)
            f(0, 11) = dt_escala(0)(9)
        End If

        f(7, 0) = 1
        f(8, 0) = 1
        f(9, 0) = 1
        f(10, 0) = 1
    End Sub

    Private Sub Busca_modelos()
        scr = "select * from pa_patron WHERE CLIENTE = '" & cliente & "'"
        If cs.Consultas(scr, dt_modelos, msj) Then
            Cbmodelo.DataSource = dt_modelos
            Cbmodelo.ValueMember = "ESTILO"
            Cbmodelo.SelectedValue = "ESTILO"
            Cbmodelo.SelectedIndex = 0
        End If
    End Sub

    Private Sub Formatos()
        f(2, 1) = "Sumtoria total:"
        f(4, 1) = "Escala M:"
        f(6, 1) = "Total x talla:"
        f(7, 1) = "Tend. 1:"
        f(8, 1) = "Tend. 2:"
        f(9, 1) = "Tend. 3:"
        f(10, 1) = "Tend. 4:"

        f(6, 14) = "Marker Width"
        f(6, 15) = "Marker Lenght"
        f(6, 16) = "Efficiency"

        f(11, 15) = "Consumo Total"
        f(12, 15) = "Consumo + 5%"
        f(13, 15) = "yield"
        f(14, 15) = "Consumo libras"
        f(15, 15) = "Libs * prenda"
        f(1, 13) = "NOMBRE TELA"
        f(2, 13) = "ROTACION"
        f(3, 13) = "ANCHO TELA"
        f(4, 13) = "EXTRAS"

        f.SetCellStyle(2, 1, "titulos")
        f.SetCellStyle(4, 1, "titulos")
        f.SetCellStyle(6, 1, "titulos")
        f.SetCellStyle(7, 1, "titulos")
        f.SetCellStyle(8, 1, "titulos")
        f.SetCellStyle(9, 1, "titulos")
        f.SetCellStyle(10, 1, "titulos")

        f.SetCellStyle(6, 14, "titulos_c")
        f.SetCellStyle(6, 15, "titulos_c")
        f.SetCellStyle(6, 16, "titulos_c")
        f.SetCellStyle(6, 17, "titulos_c")

        rg = f.GetCellRange(2, 2, 2, 11)
        rg.Style = f.Styles("sumatoria")
        rg = f.GetCellRange(4, 2, 4, 11)
        rg.Style = f.Styles("escala_amiga")
        rg = f.GetCellRange(6, 2, 6, 11)
        rg.Style = f.Styles("total")
        rg = f.GetCellRange(7, 2, 10, 11)
        rg.Style = f.Styles("escalas")

        rg = f.GetCellRange(7, 12, 10, 12)
        rg.Style = f.Styles("capas")

        Dim bool As CellStyle = f.Styles.Add("bool")
        bool.DataType = GetType(Boolean)
        bool.TextAlign = TextAlignEnum.CenterCenter
        bool.BackColor = Drawing.Color.LightGray

        Dim deci As CellStyle = f.Styles.Add("deci")
        deci.DataType = GetType(Decimal)
        deci.Format = "N3"
        deci.TextAlign = TextAlignEnum.CenterCenter
        deci.BackColor = Drawing.Color.Green

        rg = f.GetCellRange(7, 13, 10, 13)
        rg.Style = f.Styles("bool")

        Dim deci_i As CellStyle = f.Styles.Add("deci_i")
        deci_i.DataType = GetType(Decimal)
        deci_i.Format = "N3"

        rg = f.GetCellRange(13, 15, 13, 15)
        rg.Style = f.Styles("deci")

        rg = f.GetCellRange(7, 15, 14, 15)
        rg.Style = f.Styles("deci_i")

        rg = f.GetCellRange(7, 17, 15, 17)
        rg.Style = f.Styles("deci_i")
        Dim tela2 As String = ""
        '================================
        '================================ESTO ES TEMPORAL MIENTRAS SE TRABAJA EL CLIENTE THE NORTH FACE
        'If cliente = "THE NORTH FACE" Then
        scr = "SELECT * FROM COMBO_TELA_1 WHERE VERIFICA_TELAS <>'NULL'" &
               " AND ESTILO = '" & estilo_c & "' AND CLIENTE = '" & cliente & "' and COLOR = '" & color_cpo & "' "
        cs.Consultajt(scr, dt_combos, msj)
        For I = 0 To dt_combos.Rows.Count - 1
            tela2 = tela2 & dt_combos.Rows(I)("codigo") & "/" & dt_combos.Rows(I)("color_tela") & "/" & dt_combos.Rows(I)("componente") & "|"
        Next

        Dim tela As String = "S|R|C"
        Dim t_tela2 As CellStyle = f.Styles.Add("t_tela2")
        t_tela2.DataType = GetType(String)
        t_tela2.ComboList = tela2
        t_tela2.ForeColor = Color.DimGray
        t_tela2.Font = New Font(Font, FontStyle.Bold)
        t_tela2.BackColor = Color.Yellow
        t_tela2.Border.Color = Color.LightGray
        t_tela2.Border.Style = BorderStyleEnum.Double
        rg = f.GetCellRange(1, 15, 1, 15)
        rg.Style = f.Styles("t_tela2")

        Dim rotacionas As String = "180|NONE"
        Dim rota As CellStyle = f.Styles.Add("rota")
        rota.DataType = GetType(String)
        rota.ComboList = rotacionas
        rota.ForeColor = Color.DimGray
        rota.Font = New Font(Font, FontStyle.Bold)
        rota.BackColor = Color.Yellow
        rota.Border.Color = Color.LightGray

        rg = f.GetCellRange(2, 14, 2, 14)
        rg.Style = f.Styles("rota")

        Dim anch As CellStyle = f.Styles.Add("anch")
        anch.DataType = GetType(Decimal)
        anch.ForeColor = Color.DimGray
        anch.Font = New Font(Font, FontStyle.Bold)
        anch.BackColor = Color.Yellow
        anch.Border.Color = Color.LightGray

        rg = f.GetCellRange(3, 14, 3, 14)
        rg.Style = f.Styles("anch")

        rg = f.GetCellRange(4, 14, 4, 14)
        rg.Style = f.Styles("anch")

        f(3, 14) = 0
        f(4, 14) = 0



        Dim updown As CellStyle = f.Styles.Add("updown")
        updown.ComboList = "1|2|3|4|5"
        updown.BackColor = Color.Aquamarine

        rg = f.GetCellRange(7, 0, 7, 0)
        rg.Style = f.Styles("updown")
        rg = f.GetCellRange(8, 0, 8, 0)
        rg.Style = f.Styles("updown")
        rg = f.GetCellRange(9, 0, 9, 0)
        rg.Style = f.Styles("updown")
        rg = f.GetCellRange(10, 0, 10, 0)
        rg.Style = f.Styles("updown")

    End Sub

    Function Escala_amiga(dt100() As Integer, min As Integer, max As Integer) As Integer()
        Dim minii As Integer
        Dim dtmax(10) As Decimal
        Dim dtamiga(10) As Integer
        Dim dtmin(10) As Decimal
        Dim dtrangos(10) As Integer
        Dim rango_ordenado() As Integer
        Dim promed(10) As Integer
        Dim eamiga(10) As Integer
        Dim preamiga(10) As Integer
        '''''''''' minimo 
        For i = 0 To 9
            dtmin(i) = FormatNumber(dt100(i) * (1 + (-min / 100)), 2)
        Next
        '''''''''' maximo
        For i = 0 To 9
            dtmax(i) = FormatNumber(dt100(i) * (1 + (max / 100)), 2)
        Next
        '''''''''' rangos
        For i = 0 To 9
            dtrangos(i) = Fix(dtmax(i) - dtmin(i))
        Next
        rango_ordenado = dtrangos
        Array.Sort(rango_ordenado)
        ''''''''''''''''''obtiene el numero menos de los rangos
        For i = 0 To 9
            If rango_ordenado(i) > 0 Then
                minii = rango_ordenado(i)
                Exit For
            End If
        Next
        ''''''''''''''''''''''''''''''''promedio
        For i = 0 To 9
            promed(i) = 0.5 * (dtmax(i) + dtmin(i)) + 0.35 * (dtmax(i) - dtmin(i))
        Next
        ''''''''''''''''ESCALA AMIGA
        For i = 0 To 9
            '''''''''''''''''''''RESTRICCIONES PARA CANTIDADES PEQUEÑAS
            If dt100(i) <= 100 And dt100(i) >= 50 Then
                preamiga(i) = dt100(i) + 8
            ElseIf dt100(i) <= 50 And dt100(i) >= 25 Then
                preamiga(i) = dt100(i) + 5
            ElseIf dt100(i) <= 25 And dt100(i) > 0 Then
                preamiga(i) = dt100(i) + 2
            ElseIf dt100(i) > 100 Then
                '''''''''''''''''''ESCALA AMIGA
                preamiga(i) = Fix((promed(i) / minii)) * minii

            End If
        Next
        Return preamiga
    End Function

    Private Sub F_Click(sender As System.Object, e As System.EventArgs) Handles f.BeforeEdit
        fila = f.RowSel
        col = f.ColSel
        For i = 2 To 11
            f(6, i) = (f(7, i) * f(7, 12)) + (f(8, i) * f(8, 12)) + (f(9, i) * f(9, 12)) + (f(10, i) * f(10, 12))
            'For j = 7 To 10
            'Next
        Next
        f(6, 12) = f(6, 2) + f(6, 3) + f(6, 4) + f(6, 5) + f(6, 6) + f(6, 7) + f(6, 8) + f(6, 9) + f(6, 10) + f(6, 11)
        f(4, 12) = f(4, 2) + f(4, 3) + f(4, 4) + f(4, 5) + f(4, 6) + f(4, 7) + f(4, 8) + f(4, 9) + f(4, 10) + f(4, 11)

        If f(6, 12) <> f(4, 12) Then
            rg = f.GetCellRange(6, 12, 6, 12)
            rg.Style = f.Styles("rojo")
        Else
            rg = f.GetCellRange(6, 12, 6, 12)
            rg.Style = f.Styles("total")
        End If
        For i = 2 To 11
            If f(6, i) < f(4, i) Then
                rg = f.GetCellRange(6, i, 6, i)
                rg.Style = f.Styles("rojo")
            Else
                rg = f.GetCellRange(6, i, 6, i)
                rg.Style = f.Styles("sumatoria")
            End If
        Next
        For i = 7 To 10
            f(i, 17) = f(i, 12) * f(i, 15)
        Next

        '''''''''SUMATRIA DE CONSUMOS 
        f(11, 17) = f(7, 17) + f(8, 17) + f(9, 17) + f(10, 17)
        f(12, 17) = f(11, 17) + ((f(7, 17) + f(8, 17) + f(9, 17) + f(10, 17)) * 0.05)
        'f(13, 15)  '''''''yiel
        Try
            f(14, 17) = f(12, 17) / f(13, 17)
            f(15, 17) = (f(14, 17) / f(6, 12)) + f(4, 14)
            BtGuardar.Visible = True
        Catch
            BtGuardar.Visible = False
        End Try
    End Sub

    Private Sub Cbfabri_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbmodelo.KeyPress
        cs.AutoCompletar(Cbmodelo, e)
    End Sub

    Private Sub Form1_closed(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Leex_excel(ByVal archivo As String, ByVal arc As Integer)
        Dim objConn As OleDbConnection
        Dim oleDA As OleDbDataAdapter
        Dim ds As DataSet
        Dim dt As New DataTable
        Dim FileName As String = pat & archivo
        Try
            Dim connectionString As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1"""
            objConn = New OleDbConnection(connectionString)
            oleDA = New OleDbDataAdapter("select * from [Sheet1$]", objConn)
            ds = New DataSet()
            oleDA.Fill(ds)
            dt = ds.Tables(0)
            f(6 + arc, 14) = dt.Rows(9)(2)
            f(6 + arc, 15) = dt.Rows(10)(2) + (2 / 36)
            f(6 + arc, 16) = dt.Rows(11)(2)
            ds.Dispose()
            oleDA.Dispose()
            objConn.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Escala1_Tick(sender As System.Object, e As System.EventArgs) Handles escala1.Tick
        Dim msj As String = pat & arch1
        If My.Computer.FileSystem.FileExists(pat & arch1) Then
            leex_excel(arch1, 1)
            f(7, 13) = False
            escala1.Stop()
        Else
        End If
    End Sub

    Private Sub Escala2_Tick(sender As System.Object, e As System.EventArgs) Handles escala2.Tick
        Dim msj As String = pat & arch2
        If My.Computer.FileSystem.FileExists(pat & arch2) Then
            Leex_excel(arch2, 2)
            f(8, 13) = False
            escala2.Stop()
        Else
        End If
    End Sub

    Private Sub Escala3_Tick(sender As System.Object, e As System.EventArgs) Handles escala3.Tick
        Dim msj As String = pat & arch3
        If My.Computer.FileSystem.FileExists(pat & arch3) Then
            Leex_excel(arch3, 3)
            f(9, 13) = False
            escala3.Stop()
        Else
        End If
    End Sub

    Private Sub Escala4_Tick(sender As System.Object, e As System.EventArgs) Handles escala4.Tick
        Dim msj As String = pat & arch4
        If My.Computer.FileSystem.FileExists(pat & arch4) Then
            Leex_excel(arch4, 4)
            f(10, 13) = False
            escala4.Stop()
        End If
    End Sub

    Private Sub BtnExcel_Click(sender As System.Object, e As System.EventArgs) Handles BtnExcel.Click
        Try
            f.SaveGrid("C:\Plan_rep\" & "validacion.xls", FileFormatEnum.Excel, FileFlags.AsDisplayed + FileFlags.IncludeMergedRanges)
            Dim pathPDF As String = "C:\Plan_rep\validacion.xls"
            Process.Start(pathPDF)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CREATABLE()
        d_e_f.Columns.Add("CLIENTE")
        d_e_f.Columns.Add("ESTILO")
        d_e_f.Columns.Add("CPO")
        d_e_f.Columns.Add("COLOR")
        d_e_f.Columns.Add("EMPRESA")
        d_e_f.Columns.Add("LARGO_MARKER")
        d_e_f.Columns.Add("EFICIENCIA")
        d_e_f.Columns.Add("CONSUMO_UNIDAD")
        d_e_f.Columns.Add("CONSUMO_TOTAL")
        d_e_f.Columns.Add("CONSUMO_TOT_YARDAS")
        d_e_f.Columns.Add("TIPO_TELA")
        d_e_f.Columns.Add("COLOR_TELA")
        d_e_f.Columns.Add("XS")
        d_e_f.Columns.Add("S")
        d_e_f.Columns.Add("M")
        d_e_f.Columns.Add("l")
        d_e_f.Columns.Add("XL")
        d_e_f.Columns.Add("XL2")
        d_e_f.Columns.Add("XL3")
        d_e_f.Columns.Add("XL4")
        d_e_f.Columns.Add("XL5")
        d_e_f.Columns.Add("XL6")
        d_e_f.Columns.Add("TOTAL")

        d_esc.Columns.Add("cpo")
        d_esc.Columns.Add("estilo")
        d_esc.Columns.Add("color")
        d_esc.Columns.Add("cod_tela")
        d_esc.Columns.Add("color_tela")
        d_esc.Columns.Add("linea")
        d_esc.Columns.Add("lienzos")
        d_esc.Columns.Add("T1")
        d_esc.Columns.Add("T2")
        d_esc.Columns.Add("T3")
        d_esc.Columns.Add("T4")
        d_esc.Columns.Add("T5")
        d_esc.Columns.Add("T6")
        d_esc.Columns.Add("T7")
        d_esc.Columns.Add("T8")
        d_esc.Columns.Add("T9")
        d_esc.Columns.Add("T0")
        d_esc.Columns.Add("ARCH")
        d_esc.Columns.Add("LARGO")
        d_esc.Columns.Add("YIELD")
        d_esc.Columns.Add("extra")

        dt_escala.Rows.Add("lienzos")
        dt_escala.Rows.Add("t1")
        dt_escala.Rows.Add("t2")
        dt_escala.Rows.Add("t3")
        dt_escala.Rows.Add("t4")
        dt_escala.Rows.Add("t5")
        dt_escala.Rows.Add("t6")
        dt_escala.Rows.Add("t7")
        dt_escala.Rows.Add("t8")
        dt_escala.Rows.Add("t9")
        dt_escala.Rows.Add("t0")
        dt_escala.Rows.Add("")

    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        Dim cod() As String
        Dim arc As Boolean = False
        If f(1, 15) = "" Then
            MsgBox("no se eligio tipo de tela!!")
        Else
            d_e_f.Rows.Clear()
            d_esc.Rows.Clear()
            Dim dtr As DataRow = d_e_f.NewRow
            dtr("ESTILO") = estilo_c
            dtr("CLIENTE") = cliente
            dtr("EMPRESA") = FrmInicio.empresa
            dtr("CONSUMO_UNIDAD") = f(15, 17)
            dtr("CONSUMO_TOTAL") = f(15, 17) * f(6, 12)
            dtr("CONSUMO_TOT_YARDAS") = f(11, 17)
            Try
                cod = f(1, 15).split("/")
                dtr("TIPO_TELA") = cod(0)
                dtr("COLOR_TELA") = cod(1)
            Catch
            End Try
            dtr("xs") = f(6, 2)
            dtr("s") = f(6, 3)
            dtr("m") = f(6, 4)
            dtr("l") = f(6, 5)
            dtr("xl") = f(6, 6)
            dtr("xl2") = f(6, 7)
            dtr("xl3") = f(6, 8)
            dtr("xl4") = f(6, 9)
            dtr("xl5") = f(6, 10)
            dtr("xl6") = f(6, 11)
            dtr("total") = f(6, 12)
            dtr("CPO") = cpo
            dtr("color") = color_cpo
            d_e_f.Rows.Add(dtr)
            d_e_f.AcceptChanges()

            For i = 7 To 10
                Dim d_r As DataRow = d_esc.NewRow
                d_r("cpo") = cpo
                d_r("estilo") = estilo_c
                d_r("color") = color_cpo
                d_r("cod_tela") = cod(0)
                d_r("color_tela") = cod(1)
                d_r("linea") = i - 7
                d_r("lienzos") = f(i, 12)
                d_r("T1") = f(i, 2)
                d_r("T2") = f(i, 3)
                d_r("T3") = f(i, 4)
                d_r("T4") = f(i, 5)
                d_r("T5") = f(i, 6)
                d_r("T6") = f(i, 7)
                d_r("T7") = f(i, 8)
                d_r("T8") = f(i, 9)
                d_r("T9") = f(i, 10)
                d_r("T0") = f(i, 11)
                d_r("ARCH") = UCase(f(i, 18))
                d_r("YIELD") = f(13, 17)
                d_r("EXTRA") = f(5, 14)
                d_esc.Rows.Add(d_r)
                d_esc.AcceptChanges()
                If f(i, 18) = "" Then
                Else
                    arc = True
                End If
            Next
            If arc = False Then
                MsgBox("no se crearon ordenes para nes server!!")
            Else
                If cs.guarda_cpo_da(d_e_f, d_esc, msj) Then
                    MsgBox("Datos Guardados!")
                Else
                    MsgBox(msj)
                End If
            End If
        End If
    End Sub

    Private Sub Crea_file(nombre As String, ByVal fila As Integer)
        If f(2, 14) = "" Or f(3, 14) <= 0 Then
            MsgBox("Faltan datos para crear una orden ")
        Else
            Dim pat_imput As String = ""
            Dim tallas As String = ""
            Dim titulos As String = ""
            Dim ancho As Integer
            For i = 2 To 11
                If f(fila, i) > 0 Then
                    tallas = tallas & f(0, i) & "," & f(fila, i) & " "
                    titulos = titulos & f(0, i) & " "
                End If
            Next
            Dim Prueba As String = ""
            AbrirLog()
            GrabarLog("")
            GrabarLog("INPUT BEGIN")
            GrabarLog(" [FILE] :" & nombre)
            GrabarLog(" [ORDER DETAILS] :")
            GrabarLog(" [CUSTOMER] : ")
            GrabarLog(" [GAP] : 0")
            GrabarLog(" [GAP TYPE] : SUM")
            GrabarLog("")
            GrabarLog(" [HSHRINK] :0")
            GrabarLog(" [VSHRINK] :0")
            GrabarLog(" [SPREAD] :[SINGLE]")
            GrabarLog(" [TUBULAR] : ")
            GrabarLog("")
            If f(3, 14) > 0 Then
                ancho = f(3, 14) * 25.4
            End If
            GrabarLog(" [WIDTH] :" & ancho)
            GrabarLog(" [NEST TIME] : 1")
            GrabarLog("PROPERTIES BEGIN")
            GrabarLog("  [NAME] : P1PN")
            GrabarLog("  [ROTATION TYPE] : [BUNDLE]")
            GrabarLog("  [ROTATION FREEDOM] : [" & f(2, 14) & "]") ''''' NECESITO PRGUNTAR SI ES RATATIVO O NO REEMPLAZAR EL 180
            GrabarLog("  [FLIP TYPE] : [BUNDLE]")
            GrabarLog("  [FLIP FREEDOM] : [NONE]")
            GrabarLog("  [TILT] : 0")
            GrabarLog("  [INITIAL ANGLE] : 0")
            GrabarLog("  [BLOCK H] : 0")
            GrabarLog("  [BLOCK V] : 0")
            GrabarLog(" [GAP] : 0")
            GrabarLog(" [GAP TYPE] : SUM ")
            GrabarLog("")
            GrabarLog("  [HSHRINK] : 0")
            GrabarLog("  [VSHRINK] : 0")
            GrabarLog("PROPERTIES END")
            GrabarLog("")
            GrabarLog("")
            GrabarLog("MODEL BEGIN")
            GrabarLog("   [PATH] :" & pat_bd & estilo & ".mdy")
            GrabarLog("   [SIZES] :" & tallas)
            GrabarLog("  DESIGN BEGIN")
            GrabarLog("   [NAME] : DEFAULT")
            If S.Checked = True Then
                GrabarLog("   FABRIC BEGIN")
                GrabarLog("     [NAME] : S")
                GrabarLog("     [PATTERNS] : [ALL]")
                GrabarLog("   FABRIC END ")
            End If
            If R.Checked = True Then
                GrabarLog("   FABRIC BEGIN")
                GrabarLog("     [NAME] : R")
                GrabarLog("     [PATTERNS] : [ALL]")
                GrabarLog("   FABRIC END ")
            End If
            If C.Checked = True Then
                GrabarLog("   FABRIC BEGIN")
                GrabarLog("     [NAME] : C")
                GrabarLog("     [PATTERNS] : [ALL]")
                GrabarLog("   FABRIC END ")
            End If
            If js.Checked = True Then
                GrabarLog("   FABRIC BEGIN")
                GrabarLog("     [NAME] : J")
                GrabarLog("     [PATTERNS] : [ALL]")
                GrabarLog("   FABRIC END ")
            End If
            If fs.Checked = True Then
                GrabarLog("   FABRIC BEGIN")
                GrabarLog("     [NAME] : F")
                GrabarLog("     [PATTERNS] : [ALL]")
                GrabarLog("   FABRIC END ")
            End If
            If Mt.Checked = True Then
                GrabarLog("   FABRIC BEGIN")
                GrabarLog("     [NAME] : M")
                GrabarLog("     [PATTERNS] : [ALL]")
                GrabarLog("   FABRIC END ")
            End If
            GrabarLog(" DESIGN END")
            GrabarLog("PROPERTIES BEGIN")
            GrabarLog("  [NAME] : P1PN")
            GrabarLog("  [SIZES] : " & titulos)
            GrabarLog("PROPERTIES END")
            GrabarLog("")
            GrabarLog("MODEL End")
            GrabarLog("")
            GrabarLog("INPUT End")
            CerrarLog(nombre)
        End If
    End Sub

    Private Sub GrabarLog(ByVal script As String)
        Dim Texto As String = String.Concat(script)
        log.AppendLine(Texto)
    End Sub

    Private Sub AbrirLog()
        log = New StringBuilder
    End Sub

    Private Sub CerrarLog(nombre As String)
        Try
            Dim Escritor As TextWriter = New StreamWriter(imput_mtx & nombre & ".mtx", True)
            Escritor.WriteLine(log.ToString)
            Escritor.Close()
        Catch ex As Exception
            EventLog.WriteEntry("MonitorServicio", "Error: " & ex.Message.ToString)
        End Try
        nombre = ""
        MsgBox("Orden creada Correctamente")
    End Sub

    Private Sub Eliminar_archivo(nombre As String)
        My.Computer.FileSystem.DeleteFile(imput_mtx & nombre & ".mtx")
    End Sub

    Private Sub F_Click_1(sender As System.Object, e As System.EventArgs) Handles f.AfterEdit
        Dim colo As String
        Dim CPO_NAME As String
        Dim t_las As String = ""
        If S.Checked = False And R.Checked = False And C.Checked = False And js.Checked = False And fs.Checked = False And Mt.Checked = False Then
            MsgBox("seleccione alguna para el modelo")
        Else
            If S.Checked = True Then
                t_las = "S"
            End If
            If R.Checked = True Then
                t_las = t_las & "R"
            End If
            If C.Checked = True Then
                t_las = t_las & "C"
            End If
            If js.Checked = True Then
                t_las = t_las & "J"
            End If
            If fs.Checked = True Then
                t_las = t_las & "F"
            End If

            If Mt.Checked = True Then
                t_las = t_las & "M"
            End If
            rg = f.GetCellRange(1, 14, 1, 14)
            colo = color_cpo.Replace("/", "")
            CPO_NAME = cpo.Replace("/", "")
            CPO_NAME = CPO_NAME.Replace(".", "")
            If fila = 7 And col = 13 Then
                If f(fila, col) = True Then
                    ''''' crea el archivo mty
                    arch1_imp = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_1"
                    If arc1 = False Then
                        If File.Exists(pat_bd & estilo & ".mdy") Then
                            Crea_file(arch1_imp, fila)
                            arc1 = True
                        Else
                            MsgBox("no existe el archivo del modelo para este estilo!! ")
                            f(fila, col) = False
                            escala1.Stop()
                        End If
                    Else
                    End If
                    arch1 = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_1.XLS"
                    f(fila, 18) = arch1
                    escala1.Interval = 3000
                    escala1.Start()
                End If
            ElseIf fila = 8 And col = 13 Then
                If f(fila, col) = True Then
                    arch2_imp = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_2"
                    If arc2 = False Then
                        If File.Exists(pat_bd & estilo & ".mdy") Then
                            Crea_file(arch2_imp, fila)
                            arc2 = True
                        Else
                            MsgBox("no existe el archivo del modelo para este estilo!! ")
                            f(fila, col) = False
                            escala2.Stop()
                        End If
                    Else
                    End If
                    arch2 = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_2.XLS"
                    f(fila, 18) = arch2
                    escala2.Interval = 3000
                    escala2.Start()
                End If
            ElseIf fila = 9 And col = 13 Then
                If f(fila, col) = True Then
                    arch3_imp = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_3"
                    If arc3 = False Then
                        If File.Exists(pat_bd & estilo & ".mdy") Then
                            Crea_file(arch3_imp, fila)
                            arc3 = True
                        Else
                            MsgBox("no existe el archivo del modelo para este estilo!! ")
                            f(fila, col) = False
                            escala3.Stop()
                        End If
                    Else
                    End If
                    arch3 = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_3.XLS"
                    f(fila, 18) = arch3
                    escala3.Interval = 3000
                    escala3.Start()
                End If
            ElseIf fila = 10 And col = 13 Then
                If f(fila, col) = True Then
                    arch4_imp = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_4"
                    If arc4 = False Then
                        If File.Exists(pat_bd & estilo & ".mdy") Then
                            Crea_file(arch4_imp, fila)
                            arc4 = True
                        Else
                            MsgBox("no existe el archivo del modelo para este estilo!! ")
                            f(fila, col) = False
                            escala4.Stop()
                        End If
                    Else
                    End If
                    arch4 = empresa & "_" & CPO_NAME & "_" & estilo & "_" & colo & "_" & t_las & "_4.XLS"
                    f(fila, 18) = arch4
                    escala4.Interval = 3000
                    escala4.Start()
                End If
            ElseIf fila = 1 And col = 15 Then
                arc1 = False
                arc2 = False
                arc3 = False
                arc4 = False
            ElseIf fila = 7 And col = 0 Then
                multiEscala(fila, 0, f(fila, 0))
            ElseIf fila = 8 And col = 0 Then
                multiEscala(fila, 1, f(fila, 0))
            ElseIf fila = 9 And col = 0 Then
                multiEscala(fila, 2, f(fila, 0))
            ElseIf fila = 10 And col = 0 Then
                multiEscala(fila, 3, f(fila, 0))
            End If
        End If
    End Sub


    Private Sub multiEscala(ByVal fila As Integer, ByVal filaescala As Integer, ByVal x As Integer)
        If x = 1 Then
            f(fila, 12) = M(0, 10)
            For i = 2 To 11
                f(fila, i) = M(filaescala, i - 2)
            Next
        Else
            f(fila, 12) = CInt(M(filaescala, 10) / x)
            For i = 2 To 11
                f(fila, i) = M(filaescala, i - 2) * x
            Next
        End If
    End Sub

    Private Sub CoDetEscalaAmiga_close(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Solicita_Escalas()
    End Sub

    Private Sub f_Click_2(sender As Object, e As EventArgs) Handles f.Click

    End Sub
End Class

