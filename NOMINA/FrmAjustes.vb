Public Class FrmAjustes
    Dim scr As String
    Dim cs As New ClsConsultas
    Dim dt As New DataTable
    Dim dt_codesc As New DataTable
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa As Integer = 1
    'Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmDescuento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - (537 / 2)
        Me.Left = l / 2 - (752 / 2)
        TxtDepartamento.Enabled = False
        TxtNombre.Enabled = False
        Txt2Nombre.Enabled = False
        TxtApellido.Enabled = False
        Txt2Apellido.Enabled = False
        TxTalta.Enabled = False

    End Sub

    Private Sub BtBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtBuscar.Click
        mensajes.Text = ""
        scr = "SELECT CODIGO, A.NOMBRE, SEGUNDO_NOMBRE,APELLIDO, SEGUNDO_APELLIDO,A.FEC_ALTA,B.NOMBRE AS DEPARTAMENTO FROM  TB_EMPLEADO  AS A " &
                " LEFT JOIN TB_DEPTOS_EMPRESA AS B ON A.COD_DEPART = B.COD_DEPAR" &
                " WHERE ESTADO_EMPLEADO = 'A' AND CODIGO_EMPRESA = " & empresa & " AND CODIGO = '" & TxtCodigo.Text & "'"
        cs.consultas(scr, dt, msj)
        If dt.Rows.Count > 0 Then
            TxtDepartamento.Text = dt.Rows(0)("DEPARTAMENTO")
            TxtNombre.Text = dt.Rows(0)("NOMBRE")
            Txt2Nombre.Text = dt.Rows(0)("SEGUNDO_NOMBRE")
            TxtApellido.Text = dt.Rows(0)("APELLIDO")
            Txt2Apellido.Text = dt.Rows(0)("SEGUNDO_APELLIDO")
            TxTalta.Text = dt.Rows(0)("FEC_ALTA")
        Else
            mensajes.Text = "CODIGO NO EXISTE!"
        End If
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        Dim codigo As Integer
        Dim fec_inic As Date
        Dim msj = "", coment As String
        Dim monto As Double

        If TxtCodigo.Text = "" Or TxtMonto.Text = "" Then
        Else
            codigo = TxtCodigo.Text
            fec_inic = DatInicio.Value
            monto = TxtMonto.Text
            coment = TxtComent.Text
            If cs.Ajustes(codigo, empresa, Format(fec_inic, "yyyy-MM-dd"), monto, coment) Then
                MsgBox("Datos Guardados!!")
            Else
                mensajes.Text = msj
            End If
        End If
    End Sub

    Private Sub TXTmONTO_text(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub TexcODIGO_text(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
End Class