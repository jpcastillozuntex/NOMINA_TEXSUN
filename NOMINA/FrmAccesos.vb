Imports System.IO
Imports System.Text

Public Class FrmAccesos
    Dim scr As String
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim dt_cliente As New DataTable
    Dim dt_mat As New DataTable
    Dim dt As New DataTable
    Dim dt_user As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa = FrmInicio.CbEmpresa.DisplayMember
    Dim linea As Integer
    Dim Empres_val = FrmInicio.CbEmpresa.SelectedValue
    Dim dt_guarda As New DataTable
    Dim codigo As Integer
    Dim idrol As String = ""

    Private Sub FrmPandroid_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        fg.Rows.Count = 1
        scr = "SELECT * FROM TC_ROL"
        If cs.consultas(scr, dt, msj) Then
            f.Rows.Count = dt.Rows.Count + 2
            For i = 0 To dt.Rows.Count - 1
                f(i + 1, 0) = dt.Rows(i)("IDROL")
                f(i + 1, 1) = dt.Rows(i)("ROL_DESCRIPCION")
                f(i + 1, 2) = dt.Rows(i)("ESTADO")
                f(i + 1, 3) = dt.Rows(i)("FECHA_CREACION")
            Next
        Else
            MsgBox(msj)
        End If
        crea_tabla()
    End Sub

    Private Sub f_Click(sender As System.Object, e As System.EventArgs) Handles f.Click
        linea = f.RowSel
        fg.Rows.Count = 1
        If f(linea, 0) Is Nothing Then
        Else
            f.SetCellStyle(linea, 1, "verde")
            codigo = f(linea, 0)
            scr = "SELECT A.COD_MENU,TITULO,COD_PADRE,B.COD_MENU AS COD_MENU_B,IDROL from TC_MENU AS A " & _
                   "LEFT JOIN TT_ROL_MENU  AS B ON A.COD_MENU = B.COD_MENU AND B.IDROL= '" & f(linea, 0) & "'"
            If cs.consultas(scr, dt_cliente, msj) Then
                fg.Rows.Count = dt_cliente.Rows.Count + 1
                For i = 0 To dt_cliente.Rows.Count - 1
                    If IsDBNull(dt_cliente.Rows(i)("COD_MENU_B")) = True Then
                        fg(i + 1, 1) = False
                    Else
                        fg(i + 1, 1) = True
                    End If
                    fg(i + 1, 2) = dt_cliente.Rows(i)("TITULO")
                    fg(i + 1, 0) = dt_cliente.Rows(i)("cod_menu")
                    fg(i + 1, 3) = dt_cliente.Rows(i)("IDROL")
                Next
            End If
        End If
        idrol = f(linea, 0)
    End Sub

    Private Sub f_rowcol(sender As System.Object, e As System.EventArgs) Handles f.RowColChange
        For i = 0 To f.Rows.Count
            f.SetCellStyle(linea, 1, "default")
        Next
    End Sub

    Private Sub Btir_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        dt_guarda.Clear()
        Try
            For i = 1 To fg.Rows.Count - 1
                If fg(i, 1) = True Then
                    Dim dtr As DataRow = dt_guarda.NewRow
                    dtr("codmenu") = fg(i, 0)
                    dtr("id_rol") = fg(i, 3)
                    dt_guarda.Rows.Add(dtr)
                    dt_guarda.AcceptChanges()
                End If
            Next
            If cs.guarda_rol(dt_guarda, idrol, msj) Then
                MsgBox("DATOS GUARDADOS!!")
            Else
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub crea_tabla()
        dt_guarda.Columns.Add("codmenu")
        dt_guarda.Columns.Add("id_rol")
    End Sub

End Class
