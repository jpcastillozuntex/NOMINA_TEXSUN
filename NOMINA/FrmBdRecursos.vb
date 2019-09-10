Imports C1.Win.C1FlexGrid

Public Class FrmBdRecursos
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dt As New DataTable

    Private Sub Fg1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmBdRecursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(l - 20, a - 10)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2

        fg(0, 1) = "Codigo"
        fg(0, 2) = "Tipo_trabajador"
        fg(0, 3) = "Nombre"
        fg(0, 4) = "Apellido"
        fg(0, 5) = "Discapacidad"
        fg(0, 6) = "Lactancia"
        fg(0, 7) = "Embarazo"
        fg(0, 8) = "Bajas"
        fg(0, 9) = "Suspensión"

        fg(0, 10) = "Apellido_casada"
        fg(0, 11) = "Fec_alta"
        fg(0, 12) = "Fec_Baja"
        fg(0, 13) = "Sueldo_base"
        fg(0, 14) = "Frecuencia"
        fg(0, 15) = "direccion"
        fg(0, 16) = "Fec_nacimiento"
        fg(0, 17) = "sexo"
        fg(0, 18) = "cedula"
        fg(0, 19) = "DPI"
        fg(0, 20) = "Nombre"
        fg(0, 21) = "Nombre municipio"
        fg(0, 22) = "Nombre Puesto"
        fg(0, 23) = "Afiliacion_igss"
        fg(0, 24) = "Depto"
        fg(0, 25) = "Bonif"
        fg(0, 26) = "Num_Locker"
        fg(0, 27) = "Mama"
        fg(0, 28) = "Telefono"
        fg(0, 29) = "NIT"
        fg(0, 30) = "Num_Cuenta"
        fg(0, 31) = "No_Tarjeta"
        fg(0, 32) = "Tipo_pago"
        fg(0, 33) = "Motivo_Baja"
        fg(0, 34) = "Observaciones"
        fg(0, 35) = "Escolaridad"
        fg(0, 36) = "Estado_Civil"
        fg(0, 37) = "Avecindado"


        scr = "select a.codigo,'' as Tipo_trabajador,a.nombre +' '+ segundo_nombre,Apellido +' '+ segundo_apellido,'' as Discapacidad,'' as Lactancia ," &
               " '' as Embarazo,'' as Bajas, ''as  Suspensión, Apellido_casada,Fec_alta,Fec_Baja," &
                " Sueldo_base, 'Quincenal' as Frecuencia, direccion,Fec_nacimiento, sexo,'' as cedula, DPI, c.nombre,b.nombre_municipio,f.nombre_puesto," &
                " 	Afiliacion_igss,e.nombre, a.bonificacion,  num_Locker, iif(NUM_HIJOS>0,'s','n') as mama, telefono,NIT,Num_Cuenta,	''as No_Tarjeta,Tipo_pago,''Motivo_Baja,''as Observaciones," &
                " '' as Escolaridad,	Estado_Civil,''as Avecindado  " &
                " from tb_empleado as a" &
                " left join tb_municipio  as b on b.codigo = SUBSTRING(a.dpi,12,2) and b.cod_departamento = SUBSTRING(a.dpi,10,2) " &
                " left join tb_departamento as c on c.codigo_departamento = SUBSTRING(a.dpi,10,2) " &
                " left join tb_deptos_empresa as e on a.cod_depart = e.cod_depar" &
                " left join tb_puestos as f on a.codigo_puesto = f.codigo"

        If cs.consultas(scr, dt, msj) Then
            fg.Rows.Count = dt.Rows.Count + 1
            For i = 0 To dt.Rows.Count - 1
                For j = 0 To 36
                    fg(i + 1, j + 1) = dt.Rows(i)(j)
                Next
            Next
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\repRh.xls", FileIO.UIOption.AllDialogs,
               FileIO.RecycleOption.SendToRecycleBin,
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try

        fg.SaveGrid("C:\Plan_rep\" & "repRh.xls", C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells)
        Dim pathPDF As String = "C:\Plan_rep\repRh.xls"
        Process.Start(pathPDF)

    End Sub
End Class