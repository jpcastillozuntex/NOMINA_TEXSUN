Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Text.RegularExpressions

Public Class FrmParametros
    Dim Imagen As Image
    Dim frecuencia As String
    Dim pago As String
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim dt_p As New DataTable
    Dim datos As New DataTable
    Dim dt_empresa As New DataTable
    Dim dt_relojes As New DataTable
    Dim dt_f As New DataTable
    Dim relojes As Integer
    Dim bonif As String
    Dim cierre As Integer

    Private Sub FrmAgregarPer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        crea_table()
        cb_empresa()
        GroupBox4.Enabled = False
        Grouprelojes.Enabled = False
        Panel1.Enabled = False
        Panel2.Enabled = False
        Panel3.Enabled = False
        Panel4.Enabled = False
        GrpbonProd.Enabled = False
        Panel5.Enabled = False
    End Sub

    Private Sub checkRejex(ByVal strFindin As String)
        Dim myRegex As New Regex("^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$")
        If myRegex.IsMatch(strFindin) Then
            mensajes.Text = "ip correcta"
            mensajes.ForeColor = Color.Green
        Else
            mensajes.Text = "Ingrese un numero de ip valido"
            mensajes.ForeColor = Color.Red
        End If
    End Sub

    Private Sub cb_empresa()
        Try
            scr = "SELECT *  FROM TB_EMPRESA"
            cs.consultas(scr, dt_empresa, msj)
            CbEmpresa.DataSource = dt_empresa
            CbEmpresa.DisplayMember = "NOMBRE_EMPRESA"
            CbEmpresa.ValueMember = "CODIGO"
        Catch
        End Try
    End Sub

    Private Sub limpia()
        Dim ctl As Object
        For Each ctl In Me.Controls
            If TypeOf ctl Is RadioButton Then
                ctl.Value = False
            ElseIf TypeOf ctl Is TextBox Then
                ctl.Text = Nothing
            End If
        Next
    End Sub

    Private Sub CbEmpresa_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Btconsultar.Click
        GroupBox4.Enabled = True
        Grouprelojes.Enabled = True
        Panel1.Enabled = True
        Panel2.Enabled = True
        Panel3.Enabled = True
        Panel4.Enabled = True
        GrpbonProd.Enabled = True
        Panel5.Enabled = True
        scr = "SELECT * FROM RELOJES"
        Try
            cs.consultas(scr, dt_relojes, msj)
        Catch
        End Try
        scr = "select * from tb_parametros where cod_empresa = " & CbEmpresa.SelectedValue
        If cs.consultas(scr, dt_p, msj) Then
            TxtIgss.Text = dt_p.Rows(0)("igss")
            Try
                If dt_p.Rows(0)("hora_extra") = "S" Then
                    Rbhorassi.Checked = True
                    RbhorasNo.Checked = False
                Else
                    Rbhorassi.Checked = False
                    RbhorasNo.Checked = True
                End If
            Catch
            End Try
            Try
                If dt_p.Rows(0)("BON_PROD") = "S" Then
                    Bonif_no.Checked = False
                    Bonif_si.Checked = True
                Else
                    Bonif_si.Checked = False
                    Bonif_no.Checked = True
                End If
            Catch
            End Try
            Try
                If dt_p.Rows(0)("JORNADA") = "MAT" Then
                    Rbnoc.Checked = False
                    RbMat.Checked = True
                ElseIf dt_p.Rows(0)("JORNADA") = "VESP" Then
                    RbMat.Checked = False
                    Rbnoc.Checked = True
                End If
            Catch
            End Try
            Try
                If dt_p.Rows(0)("RELOJES") = 1 Then
                    relojes2.Checked = False
                    relojes3.Checked = False
                    relojes1.Checked = True
                    Txtip1.Text = dt_relojes.Rows(0)("ip")
                ElseIf dt_p.Rows(0)("RELOJES") = 2 Then
                    relojes1.Checked = False
                    relojes3.Checked = False
                    relojes2.Checked = True
                    Txtip1.Text = dt_relojes.Rows(0)("ip")
                    TxtIp2.Text = dt_relojes.Rows(1)("ip")
                ElseIf dt_p.Rows(0)("RELOJES") = 3 Then
                    relojes1.Checked = False
                    relojes2.Checked = False
                    relojes3.Checked = True
                    Txtip1.Text = dt_relojes.Rows(0)("ip")
                    TxtIp2.Text = dt_relojes.Rows(1)("ip")
                    Txtip3.Text = dt_relojes.Rows(2)("ip")
                End If
            Catch
            End Try
            Try
                If dt_p.Rows(0)("CIERRE") = 8 Then
                    Cierre15.Checked = False
                    calendar15.Checked = False
                    cierre8.Checked = True
                ElseIf dt_p.Rows(0)("CIERRE") = 15 Then
                    cierre8.Checked = False
                    calendar15.Checked = False
                    Cierre15.Checked = True
                ElseIf dt_p.Rows(0)("CIERRE") = 152 Then
                    cierre8.Checked = False
                    Cierre15.Checked = False
                    calendar15.Checked = True
                End If
            Catch
            End Try
            Try
                If dt_p.Rows(0)("DIA_CIERRE") = 1 Then
                    martes.Checked = False
                    miercoles.Checked = False
                    jueves.Checked = False
                    viernes.Checked = False
                    lunes.Checked = True
                ElseIf dt_p.Rows(0)("DIA_CIERRE") = 2 Then
                    miercoles.Checked = False
                    jueves.Checked = False
                    viernes.Checked = False
                    lunes.Checked = False
                    martes.Checked = True
                ElseIf dt_p.Rows(0)("DIA_CIERRE") = 3 Then
                    jueves.Checked = False
                    viernes.Checked = False
                    lunes.Checked = False
                    martes.Checked = False
                    miercoles.Checked = True
                ElseIf dt_p.Rows(0)("DIA_CIERRE") = 4 Then
                    viernes.Checked = False
                    lunes.Checked = False
                    martes.Checked = False
                    miercoles.Checked = False
                    jueves.Checked = True
                ElseIf dt_p.Rows(0)("DIA_CIERRE") = 5 Then
                    lunes.Checked = False
                    martes.Checked = False
                    miercoles.Checked = False
                    jueves.Checked = False
                    viernes.Checked = True
                End If
            Catch
            End Try
            Try
                If dt_p.Rows(0)("SALARIO_IND") = "S" Then
                    RbSalarioGnrl.Checked = False
                    rbSalarioindi.Checked = True
                    salario.Enabled = False
                ElseIf dt_p.Rows(0)("SALARIO_IND") = "N" Then
                    RbSalarioGnrl.Checked = True
                    rbSalarioindi.Checked = False
                    salario.Enabled = True
                    salario.Text = dt_p.Rows(0)("SALARIO_DIARIO")
                End If
            Catch ex As Exception
            End Try
            Try
                If dt_p.Rows(0)("SABADO") = "S" Then
                    Sabado_No.Checked = False
                    Sabado_si.Checked = True
                    Txt_Ent_sabado.Text = dt_p.Rows(0)("ENT_SABADO")
                    Txt_sal_sabado.Text = dt_p.Rows(0)("SAL_SABADO")
                ElseIf dt_p.Rows(0)("SABADO") = "N" Then
                    Sabado_si.Checked = False
                    Sabado_No.Checked = True
                    Txt_Ent_sabado.Enabled = False
                    Txt_sal_sabado.Enabled = False
                End If
            Catch ex As Exception
            End Try
            ENTRADA.Text = dt_p.Rows(0)("entrada").ToString
            SALIDA.Text = dt_p.Rows(0)("salida").ToString
            TxtBonif_ley.Text = dt_p.Rows(0)("BONIFICACION").ToString
        End If
    End Sub

    Private Sub Grouprelojes_Enter(sender As System.Object, e As System.EventArgs) Handles relojes1.CheckedChanged, relojes2.CheckedChanged, relojes3.CheckedChanged
        If relojes1.Checked = True Then
            relojes = 1
            TxtIp2.Enabled = False
            Txtip3.Enabled = False
        ElseIf relojes2.Checked = True Then
            relojes = 2
            TxtIp2.Enabled = True
            Txtip3.Enabled = False
        ElseIf relojes3.Checked = True Then
            relojes = 3
            TxtIp2.Enabled = True
            Txtip3.Enabled = True
        End If
    End Sub

    Private Sub C1TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txtip1.LostFocus
        checkRejex(Txtip1.Text)
    End Sub

    Private Sub TxtIp2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtIp2.LostFocus
        checkRejex(TxtIp2.Text)
    End Sub

    Private Sub Txtip3_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txtip3.LostFocus
        checkRejex(Txtip3.Text)
    End Sub

    Private Sub GrpbonProd_Enter(sender As System.Object, e As System.EventArgs) Handles Bonif_no.CheckedChanged, Bonif_si.CheckedChanged
        If Bonif_si.Checked = True Then
            Bonif_no.Checked = False
            bonif = "S"
        ElseIf Bonif_no.Checked = True Then
            bonif = "N"
            Bonif_si.Checked = False
        End If
    End Sub

    Private Sub Panel4_Paint(sender As System.Object, e As System.EventArgs) Handles rbSalarioindi.CheckedChanged, RbSalarioGnrl.CheckedChanged
        If RbSalarioGnrl.Checked = True Then
            rbSalarioindi.Checked = False
            salario.Enabled = True
        ElseIf rbSalarioindi.Checked = True Then
            RbSalarioGnrl.Checked = False
            salario.Enabled = False
        End If
    End Sub

    Private Sub Panel5_Paint(sender As System.Object, e As System.EventArgs) Handles Sabado_No.CheckedChanged, Sabado_si.CheckedChanged
        If Sabado_si.Checked = True Then
            Sabado_No.Checked = False
            Txt_Ent_sabado.Enabled = True
            Txt_sal_sabado.Enabled = True
        ElseIf Sabado_No.Checked = True Then
            Sabado_si.Checked = False
            Txt_Ent_sabado.Enabled = False
            Txt_sal_sabado.Enabled = False
        End If
    End Sub

    Private Sub crea_table()
        dt_f.Columns.Add("COD_EMPRESA")
        dt_f.Columns.Add("IGSS")
        dt_f.Columns.Add("HORA_EXTRA")
        dt_f.Columns.Add("BONIFICACION")
        dt_f.Columns.Add("SALARIO_IND")
        dt_f.Columns.Add("SALARIO_DIARIO")
        dt_f.Columns.Add("BON_PROD")
        dt_f.Columns.Add("JORNADA")
        dt_f.Columns.Add("RELOJES")
        dt_f.Columns.Add("CIERRE")
        dt_f.Columns.Add("DIA_CIERRE")
        dt_f.Columns.Add("ENTRADA")
        dt_f.Columns.Add("SALIDA")
        dt_f.Columns.Add("SABADO")
        dt_f.Columns.Add("ENT_SABADO")
        dt_f.Columns.Add("SAL_SABADO")
        dt_f.AcceptChanges()
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        dt_f.Clear()
        dt_relojes.Clear()
        Dim dtr As DataRow = dt_f.NewRow
        dtr("COD_EMPRESA") = CbEmpresa.SelectedValue
        dtr("IGSS") = TxtIgss.Text
        If Rbhorassi.Checked = True Then
            dtr("HORA_EXTRA") = "S"
        ElseIf Rbhorassi.Checked = False Then
            dtr("HORA_EXTRA") = "N"
        End If
        dtr("BONIFICACION") = TxtBonif_ley.Text
        If RbSalarioGnrl.Checked = True Then
            dtr("SALARIO_IND") = "S"
            dtr("SALARIO_DIARIO") = salario.Text
        ElseIf RbSalarioGnrl.Checked = True Then
            dtr("SALARIO_IND") = "N"
        End If
        If Bonif_si.Checked = True Then
            dtr("BON_PROD") = "S"
        ElseIf Bonif_no.Checked = True Then
            dtr("BON_PROD") = "N"
        End If
        If Rbnoc.Checked = True Then
            dtr("JORNADA") = "NOC"
        ElseIf RbMat.Checked = True Then
            dtr("JORNADA") = "MAT"
        End If
        If relojes1.Checked = True Then
            dtr("RELOJES") = 1
        ElseIf relojes2.Checked = True Then
            dtr("RELOJES") = 2
        ElseIf relojes3.Checked = True Then
            dtr("RELOJES") = 3
        End If
        If Cierre15.Checked = True Then
            dtr("CIERRE") = 15
        ElseIf cierre8.Checked = True Then
            dtr("CIERRE") = 8
        ElseIf calendar15.Checked = True Then
            dtr("CIERRE") = 152
        End If
        If lunes.Checked = True Then
            dtr("DIA_CIERRE") = 1
        ElseIf martes.Checked = True Then
            dtr("DIA_CIERRE") = 2
        ElseIf miercoles.Checked = True Then
            dtr("DIA_CIERRE") = 3
        ElseIf jueves.Checked = True Then
            dtr("DIA_CIERRE") = 4
        ElseIf viernes.Checked = True Then
            dtr("DIA_CIERRE") = 5
        End If
        dtr("ENTRADA") = ENTRADA.Text
        dtr("SALIDA") = SALIDA.Text
        If Sabado_si.Checked = True Then
            dtr("SABADO") = "S"
            dtr("ENT_SABADO") = Txt_Ent_sabado.Text
            dtr("SAL_SABADO") = Txt_sal_sabado.Text
        ElseIf Sabado_No.Checked = True Then
            dtr("SABADO") = "N"
        End If
        dt_f.Rows.Add(dtr)
        dt_f.AcceptChanges()
        Dim dtr_r As DataRow = dt_relojes.NewRow
        If relojes1.Checked = True Then
            dt_relojes.Rows.Add(Txtip1.Text)
            dt_relojes.AcceptChanges()
        ElseIf relojes2.Checked = True Then
            dt_relojes.Rows.Add(Txtip1.Text)
            dt_relojes.Rows.Add(TxtIp2.Text)
            dt_relojes.AcceptChanges()
        ElseIf relojes3.Checked = True Then
            dt_relojes.Rows.Add(Txtip1.Text)
            dt_relojes.Rows.Add(TxtIp2.Text)
            dt_relojes.Rows.Add(Txtip3.Text)
            dt_relojes.AcceptChanges()
        End If
        dt_relojes.Rows.Add(dtr_r)
        dt_relojes.AcceptChanges()
        If cs.parametros(dt_f, dt_relojes, msj) Then
            MsgBox("DATOS GUARDADS!!. :>) ")
        Else
            MsgBox(msj)
        End If
    End Sub
End Class

