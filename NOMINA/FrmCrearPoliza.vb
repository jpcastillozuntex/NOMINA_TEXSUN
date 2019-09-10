Imports C1.Win.C1FlexGrid

Public Class FrmCrearPoliza
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim dtcuentas As New DataTable
    Dim dtdatos As New DataTable
    Dim dttotales As New DataTable
    Dim dtvacas As New DataTable
    Dim msj As String
    Dim fil As Integer = 1
    Dim nom As Integer = 1


    Private Sub FrmCrearPoliza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim campo1 As String = "nombre_empresa"
        Dim campo2 As String = "codigo"
        Dim tabla As String = "tb_empresa"
        Dim AlgunMensaje As String = ""
        Dim Lista As New DataTable
        Try
            CbEmpresa.DataSource = Lista
            CbEmpresa.DisplayMember = "nombre_empresa"
            CbEmpresa.ValueMember = "codigo"
        Catch dx As Exception
            MsgBox(dx.Message)
        End Try


        Dim list As New DataTable
        scr = "select TOP(8)NUM_PLANILLA,fec_final  from TB_CICLO_PLANILLA WHERE cod_empresa = " & CbEmpresa.SelectedValue & " AND estado = 'C' ORDER BY num_planilla DESC"
        If cs.consultas(scr, list, msj) Then
            Cbciclo.DataSource = list
            Cbciclo.DisplayMember = "fec_final"
            Cbciclo.ValueMember = "num_planilla"
        Else
            MsgBox(msj)
        End If
    End Sub

    '''_
    Private Sub buscadatos()
        scr = "SELECT sum(horas)as horas,sum(dias_ord)as dias_ord,sum(bonificacion)as bonificacion,sum(anticipo)as anticipo,SUM(vacaciones)as vacaciones,sum(septimo)as septimo,sum(vacaciones)as vacas,sum(igss)as igss,sum(otros_desc)as otros_desc,sum(total_devenga)as total_deven,sum(total_desc) as total_desc, sum(total_recibe)as total_recib,(select SUM(monto_cuota) from TB_DET_ANTICIPO where num_planilla = 467)as desc_antici, CN_SUBCUENTA.descripcion,(select sum(cantidad_descuento) from tb_descuento where num_planilla = " & Cbciclo.SelectedValue & " and cod_empresa = " & CbEmpresa.SelectedValue & " and cod_descuento = 4)as desc_mat,(select sum(cantidad_descuento) from tb_descuento where num_planilla = " & Cbciclo.SelectedValue & " and cod_empresa = " & CbEmpresa.SelectedValue & " and cod_descuento = 2)as desc_tel," &
              " CN_SUBCUENTA.CODIGO, TIPO, CENTRO" &
               " FROM TB_FINAL_PLANILLA, CN_SUBCUENTA" &
                " where num_planilla = " & Cbciclo.SelectedValue &
               " and TB_FINAL_PLANILLA.cod_empresa = 1 " &
               " and tipo in ('11','21','71')" &
               " group by CN_SUBCUENTA.descripcion,CN_SUBCUENTA.codigo,CN_SUBCUENTA.tipo,CN_SUBCUENTA.CENTRO"
        If cs.consultas(scr, dttotales, msj) Then
            scr = "select * from TB_CUENTA where codigo not in ('4','5')"
            If cs.consultas(scr, dtcuentas, msj) Then
                scr = " SELECT sum(horas)as horas,sum(dias_ord)as dias_ord,sum(bonificacion)as bonificacion,sum(anticipo)as anticipo,sum(septimo)as septimo,sum(vacaciones)as vacas,sum(igss)as igss,sum(otros_desc)as otros_desc,sum(total_devenga)as total_deven,sum(total_desc) as total_desc, sum(total_recibe)as total_recib, TB_CUENTA.codigo as cuenta,CN_SUBCUENTA.codigo,CN_SUBCUENTA.descripcion,CN_SUBCUENTA.tipo,TB_CUENTA.nombre,CN_SUBCUENTA.centro" &
                        " FROM TB_FINAL_PLANILLA, tb_CUENTA, TB_SECCION, CN_SUBCUENTA" &
                        " where num_planilla = " & Cbciclo.SelectedValue &
                        " AND TB_FINAL_PLANILLA.seccion= TB_SECCION.codigo" &
                        " and TB_FINAL_PLANILLA.cod_empresa = " & CbEmpresa.SelectedValue &
                        " AND TB_CUENTA.CODIGO = TB_SECCION.cod_cuenta" &
                        " AND TB_SECCION.cod_empresa= 1 " &
                        " and tipo = 51" &
                    " group by  TB_CUENTA.CODIGO,TB_SECCION.cod_cuenta,CN_SUBCUENTA.codigo,CN_SUBCUENTA.DESCRIPCION,cn_subcuenta.tipo,TB_CUENTA.nombre, CN_SUBCUENTA.centro" &
                    " ORDER BY tipo desc, cn_subcuenta.codigo asc"
                If cs.consultas(scr, dtdatos, msj) Then
                Else
                    MsgBox(msj)
                End If
            Else
                MsgBox(msj)
            End If
        Else
            MsgBox(msj)
        End If
    End Sub

    Private Sub limpia()
        For i = 1 To fg.Rows.Count - 1
            fg(i, 1) = ""
            fg(i, 2) = ""
            fg(i, 3) = Nothing
            fg(i, 4) = Nothing
        Next
    End Sub

    Private Sub Btejecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btejecutar.Click
        limpia()
        dtcuentas.Clear()
        dtdatos.Clear()
        dttotales.Clear()
        buscadatos()
        fil = 1
        nom = 1
        fg.Rows.Count = dtdatos.Rows.Count * 3
        For i = 0 To dtcuentas.Rows.Count - 1
            Dim dd() As DataRow
            Dim dr As DataRow
            dd = dtdatos.Select("cuenta ='" & dtcuentas.Rows(i)("codigo") & "'")
            For Each dr In dd
                If dr("codigo") = "0001" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")
                    fg(fil + 1, 3) = dr("dias_ord") + dr("septimo")
                    fil = fil + 1
                ElseIf dr("codigo") = "0002" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")
                    fg(fil + 1, 3) = dr("horas")
                    fil = fil + 1
                ElseIf dr("codigo") = "0003" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")
                    fg(fil + 1, 3) = (dr("dias_ord") + dr("septimo")) * 8.333 / 100
                    fil = fil + 1
                ElseIf dr("codigo") = "0004" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")

                    fg(fil + 1, 3) = (dr("VACAS"))
                    fil = fil + 1
                ElseIf dr("codigo") = "0005" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")
                    fg(fil + 1, 3) = (dr("dias_ord") + dr("septimo") + dr("horas")) * 9.7220057 / 100
                    fil = fil + 1
                ElseIf dr("codigo") = "0006" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")
                    fg(fil + 1, 3) = (dr("dias_ord") + dr("septimo") + dr("horas")) * 12.67 / 100
                    fil = fil + 1
                ElseIf dr("codigo") = "0007" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")
                    fg(fil + 1, 3) = (dr("dias_ord") + dr("septimo")) * 8.333 / 100
                    fil = fil + 1
                ElseIf dr("codigo") = "0008" And dr("tipo") = "51" Then
                    fg(fil + 1, 1) = dr("tipo") & dr("cuenta") & dr("centro") & dr("codigo")
                    fg(fil + 1, 2) = dr("descripcion")
                    fg(fil + 1, 3) = dr("bonificacion")
                    fil = fil + 1
                End If
                fg(nom, 2) = dr("nombre")
                fg.SetCellStyle(nom, 1, fg.Styles("FirstCustomStyle"))
                fg.SetCellStyle(nom, 2, fg.Styles("FirstCustomStyle"))
                fg.SetCellStyle(nom, 3, fg.Styles("FirstCustomStyle"))
            Next
            nom = nom + 10
            fil = nom

        Next
        fil = nom
        For I = 0 To dttotales.Rows.Count - 1
            If dttotales.Rows(I)("tipo") = "11" And dttotales.Rows(I)("centro") = "02" And dttotales.Rows(I)("codigo") = "0001" Then
                fg(fil + 1, 4) = dttotales.Rows(I)("anticipo")
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "01" And dttotales.Rows(I)("codigo") = "0001" Then
                fg(fil + 1, 4) = dttotales.Rows(I)("total_recib")
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "01" And dttotales.Rows(I)("codigo") = "0002" Then
                fg(fil + 1, 4) = (dttotales.Rows(I)("bonificacion") + dttotales.Rows(I)("horas") + dttotales.Rows(I)("dias_ord") + dttotales.Rows(I)("septimo")) * 5.0 / 100 - dttotales.Rows(I)("vacaciones")
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "01" And dttotales.Rows(I)("codigo") = "0003" Then
                fg(fil + 1, 4) = (dttotales.Rows(I)("dias_ord") + dttotales.Rows(I)("septimo")) * 8.333 / 100
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "01" And dttotales.Rows(I)("codigo") = "0004" Then
                fg(fil + 1, 4) = (dttotales.Rows(I)("dias_ord") + dttotales.Rows(I)("septimo")) * 8.333 / 100
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "01" And dttotales.Rows(I)("codigo") = "0005" Then
                fg(fil + 1, 4) = (dttotales.Rows(I)("horas") + dttotales.Rows(I)("dias_ord") + dttotales.Rows(I)("septimo")) * (9.7220057 / 100)
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "05" And dttotales.Rows(I)("codigo") = "0001" Then
                fg(fil + 1, 4) = dttotales.Rows(I)("igss")
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & "01" & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "05" And dttotales.Rows(I)("codigo") = "0002" Then
                fg(fil + 1, 4) = (dttotales.Rows(I)("horas") + dttotales.Rows(I)("dias_ord") + dttotales.Rows(I)("septimo")) * 12.67 / 100
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & "01" & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "71" And dttotales.Rows(I)("centro") = "01" And dttotales.Rows(I)("codigo") = "0004" Then
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("centro") & dttotales.Rows(I)("codigo")
                fil = fil + 1
            ElseIf dttotales.Rows(I)("tipo") = "71" And dttotales.Rows(I)("centro") = "02" And dttotales.Rows(I)("codigo") = "0006" Then
                fg(fil + 1, 4) = dttotales.Rows(I)("desc_tel")
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & "01" & dttotales.Rows(I)("codigo")
                fil = fil + 1

            ElseIf dttotales.Rows(I)("tipo") = "21" And dttotales.Rows(I)("centro") = "02" And dttotales.Rows(I)("codigo") = "0001" Then
                fg(fil + 1, 4) = dttotales.Rows(I)("OTROS_DESC")
                fg(fil + 1, 2) = dttotales.Rows(I)("descripcion")
                fg(fil + 1, 1) = dttotales.Rows(I)("tipo") & dttotales.Rows(I)("centro") & "02" & dttotales.Rows(I)("codigo")
                fil = fil + 1
            End If

        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\poliza.xls", FileIO.UIOption.AllDialogs,
               FileIO.RecycleOption.SendToRecycleBin,
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try
        Try
            fg.SaveExcel("C:\Plan_rep\" & "poliza.xls", FileFlags.IncludeFixedCells)
            Dim pathPDF As String = "C:\Plan_rep\poliza.xls"
            Process.Start(pathPDF)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class