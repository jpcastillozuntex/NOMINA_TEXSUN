Partial Class Clsconexion
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'El Diseñador de componentes requiere esta llamada.
        InitializeComponent()

    End Sub

    'Component reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de componentes
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de componentes requiere el siguiente procedimiento
    'Se puede modificar usando el Diseñador de componentes.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SqlInsert = New System.Data.SqlClient.SqlCommand()
        Me.SqlConexion = New System.Data.SqlClient.SqlConnection()
        Me.SqlUpdate = New System.Data.SqlClient.SqlCommand()
        Me.SqlDelete = New System.Data.SqlClient.SqlCommand()
        Me.Adaptador = New System.Data.SqlClient.SqlDataAdapter()
        Me.Sqlselect = New System.Data.SqlClient.SqlCommand()
        Me.SqlConConfi = New System.Data.SqlClient.SqlConnection()
        Me.SqlSel = New System.Data.SqlClient.SqlCommand()
        Me.SqlNocAdapter = New System.Data.SqlClient.SqlDataAdapter()
        '
        'SqlInsert
        '
        Me.SqlInsert.Connection = Me.SqlConexion
        '
        'SqlConexion
        '
        Me.SqlConexion.ConnectionString = "Data Source=MARIOCH;Initial Catalog=IMPORT;Persist Security Info=True;User ID=imp" & _
    "ort;Password=importa"
        Me.SqlConexion.FireInfoMessageEventOnUserErrors = False
        '
        'SqlUpdate
        '
        Me.SqlUpdate.Connection = Me.SqlConexion
        '
        'SqlDelete
        '
        Me.SqlDelete.Connection = Me.SqlConexion
        '
        'Adaptador
        '
        Me.Adaptador.AcceptChangesDuringFill = False
        Me.Adaptador.DeleteCommand = Me.SqlDelete
        Me.Adaptador.InsertCommand = Me.SqlInsert
        Me.Adaptador.SelectCommand = Me.Sqlselect
        Me.Adaptador.UpdateCommand = Me.SqlUpdate
        '
        'Sqlselect
        '
        Me.Sqlselect.Connection = Me.SqlConexion
        '
        'SqlConConfi
        '
        Me.SqlConConfi.ConnectionString = "server=192.9.200.183\TEXSUN;Initial Catalog=NOMINAC;Persist Security Info=True;Us" & _
    "er ID=nomi;Password=Texnom_23"
        Me.SqlConConfi.FireInfoMessageEventOnUserErrors = False
        '
        'SqlSel
        '
        Me.SqlSel.Connection = Me.SqlConConfi
        '
        'SqlNocAdapter
        '
        Me.SqlNocAdapter.AcceptChangesDuringFill = False
        Me.SqlNocAdapter.SelectCommand = Me.SqlSel

    End Sub
    Friend WithEvents SqlInsert As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdate As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDelete As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConexion As System.Data.SqlClient.SqlConnection
    Friend WithEvents Adaptador As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents Sqlselect As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConConfi As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlSel As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlNocAdapter As System.Data.SqlClient.SqlDataAdapter

End Class
