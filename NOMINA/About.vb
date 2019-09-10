Public Class About
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub obtiene_version()

        versiones.Text = My.Application.Info.Version.ToString
        marca.Text = My.Application.Info.Trademark
        empresa.Text = My.Application.Info.CompanyName
        nombre.Text = My.Application.Info.Description
        copyw.Text = My.Application.Info.Copyright
    End Sub

    Private Sub About_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        obtiene_version()
    End Sub
End Class