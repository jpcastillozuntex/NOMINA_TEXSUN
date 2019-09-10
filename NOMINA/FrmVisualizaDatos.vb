Public Class FrmVisualizaDatos
    Dim cs As New ClsConsultas
    Dim codigo As String = FrmConsultaEmp.codigo.ToString
    Dim empresa As String = FrmInicio.CbEmpresa.SelectedValue
    'Dim empresa As String = "1"
    Dim datosrec As New DataTable
    Dim f As String = "dd-MM-yyyy"
    Dim msj As String
    Dim sexo As String

    Private Sub FrmVisualizaDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datosrec.Clear()
        Dim tipopago As String = ""
        Dim script As String = " SELECT A.*,B.NOMBRE AS NOMBRE_DEPART,C.NOMBRE AS NOMBRE_DEPARTAMENTO,D.NOMBRE_MUNICIPIO,E.NOMBRE_PUESTO,F.NOMBRE_PAIS  FROM TB_EMPLEADO AS A " & _
                                " LEFT JOIN TB_DEPTOS_EMPRESA AS B ON A.COD_DEPART = B.COD_DEPAR" & _
                                " LEFT JOIN TB_DEPARTAMENTO AS C ON A.COD_DEPARTAMENTO = C.CODIGO_DEPARTAMENTO" & _
                                " LEFT JOIN TB_MUNICIPIO AS D ON A.COD_MUNICIPIO = D.CODIGO AND D.COD_DEPARTAMENTO = CODIGO_DEPARTAMENTO" & _
                                " LEFT JOIN TB_PAIS AS F ON A.COD_PAIS = F.CODIGO_PAIS " & _
                                " LEFT JOIN TB_PUESTOS AS E ON A.CODIGO_PUESTO = E.CODIGO" & _
                                " WHERE CODIGO_EMPRESA = " & empresa & " And A.codigo = " & codigo
        If cs.consultas(script, datosrec, msj) Then
            'MsgBox("Ingrese los datos completos")
            If datosrec.Rows(0)("tipo_pago") = "C" Then
                tipopago = "Cheque"
            ElseIf datosrec.Rows(0)("tipo_pago") = "D" Then
                tipopago = "Deposito"
            End If
            If datosrec.Rows(0)("sexo") = "F" Then
                sexo = "FEMENINO"
            Else
                sexo = "MASCULINO"
            End If
            LbCodigo.Text = Format(datosrec.Rows(0)("codigo"), "0000")
            Lbempresa.Text = FrmInicio.CbEmpresa.Text
            LbDepartamento.Text = datosrec.Rows(0)("NOMBRE_depart").ToString
            Lbnombre.Text = datosrec.Rows(0)("nombre").ToString
            LbsegundoNombre.Text = datosrec.Rows(0)("segundo_nombre").ToString
            LbApellido.Text = datosrec.Rows(0)("apellido").ToString
            LbSegundoApellido.Text = datosrec.Rows(0)("segundo_apellido").ToString
            LbDp1.Text = datosrec.Rows(0)("dpi").ToString
            Lbdeptamento.Text = datosrec.Rows(0)("NOMBRE_DEPARTAMENTO").ToString
            Lbmunicipio.Text = datosrec.Rows(0)("NOMBRE_municipio").ToString
            LbFrecuencia.Text = datosrec.Rows(0)("frecuencia_pago").ToString
            LbTelefono.Text = datosrec.Rows(0)("telefono").ToString
            LbDireccion.Text = datosrec.Rows(0)("direccion").ToString
            lbseccion.Text = datosrec.Rows(0)("cod_depart").ToString
            Lbsexo.Text = sexo
            Lbestadocivil.Text = datosrec.Rows(0)("estado_civil").ToString
            Lbnit.Text = datosrec.Rows(0)("nit").ToString
            Lbpais.Text = datosrec.Rows(0)("cod_pais").ToString
            Lbfechaalta.Text = Format(datosrec.Rows(0)("fec_alta"), f)
            LbFecbaja.Text = Format(datosrec.Rows(0)("fec_baja"), f)
            lbfecnacimiento.Text = Format(datosrec.Rows(0)("fec_nacimiento"), f)
            lbIgss.Text = datosrec.Rows(0)("afiliacion_igss").ToString
            lbCuenta.Text = datosrec.Rows(0)("num_cuenta").ToString
            lbEstado.Text = datosrec.Rows(0)("estado_empleado").ToString
            LbTipoEmpleado.Text = datosrec.Rows(0)("tipo_empleado").ToString
            LbApellidocasada.Text = datosrec.Rows(0)("apellido_casada").ToString
            LbnumHijos.Text = datosrec.Rows(0)("num_hijos").ToString
            LbNombreEsposo.Text = datosrec.Rows(0)("Nombre_esposo").ToString
            LbSueldoBase.Text = datosrec.Rows(0)("marca").ToString
            lb_vac.Text = datosrec.Rows(0)("vac_liq").ToString
            LbIrtra.Text = datosrec.Rows(0)("af_irtra").ToString
            lb_horas.Text = datosrec.Rows(0)("horas_ex").ToString
            Lbtipopago.Text = tipopago
            Lbcodigopuesto.Text = datosrec.Rows(0)("NOMBRE_PUESTO").ToString
        End If
    End Sub
    
End Class