<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHorasExtras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHorasExtras))
        Me.pp = New C1.Win.C1Preview.C1PrintPreviewControl()
        Me.cr = New C1.C1Report.C1Report()
        Me.Cbmes = New System.Windows.Forms.ComboBox()
        Me.BtConsultar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbCiclo = New System.Windows.Forms.ComboBox()
        Me.DatAnio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbGeneral = New System.Windows.Forms.RadioButton()
        Me.RbSerigrafia = New System.Windows.Forms.RadioButton()
        CType(Me.pp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pp.PreviewPane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pp.SuspendLayout()
        CType(Me.cr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pp
        '
        Me.pp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pp.AvailablePreviewActions = CType((C1.Win.C1Preview.C1PreviewActionFlags.FileSave Or C1.Win.C1Preview.C1PreviewActionFlags.Print), C1.Win.C1Preview.C1PreviewActionFlags)
        Me.pp.Location = New System.Drawing.Point(1, 125)
        Me.pp.Name = "pp"
        Me.pp.NavigationPanelVisible = False
        '
        'pp.PreviewPane
        '
        Me.pp.PreviewPane.Document = Me.cr
        Me.pp.PreviewPane.ExportOptions.Content = New C1.Win.C1Preview.ExporterOptions() {New C1.Win.C1Preview.ExporterOptions("C1dExportProvider", "C1.C1Preview.Export.C1dOptionsForm", False, True, False), New C1.Win.C1Preview.ExporterOptions("RtfExportProvider", "C1.C1Preview.Export.RtfOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("DocxExportProvider", "C1.C1Preview.Export.DocxOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("XlsxExportProvider", "C1.C1Preview.Export.XlsxOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("EmfExportProvider", "C1.C1Preview.Export.EmfOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("TiffExportProvider", "C1.C1Preview.Export.ImagesOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("PngExportProvider", "C1.C1Preview.Export.ImagesOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("JpegExportProvider", "C1.C1Preview.Export.ImagesOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("GifExportProvider", "C1.C1Preview.Export.ImagesOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("BmpExportProvider", "C1.C1Preview.Export.ImagesOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("HtmlExportProvider", "C1.C1Preview.Export.HtmlOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("XpsExportProvider", "C1.C1Preview.Export.DefaultExportOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("C1dxExportProvider", "C1.C1Preview.Export.C1dOptionsForm", False, True, False), New C1.Win.C1Preview.ExporterOptions("C1dbExportProvider", "C1.C1Preview.Export.C1dOptionsForm", False, True, False), New C1.Win.C1Preview.ExporterOptions("C1mdxExportProvider", "C1.C1Preview.Export.C1mdxOptionsForm", False, True, False), New C1.Win.C1Preview.ExporterOptions("ReportHTMLExportProvider", "C1.C1Preview.Export.ReportHtmlOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("ReportRTFExportProvider", "C1.C1Preview.Export.ReportRtfOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("ReportTextExportProvider", "C1.C1Preview.Export.ReportTextOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("ReportMetafileExportProvider", "C1.C1Preview.Export.DefaultExportOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("ReportExcelExportProvider", "C1.C1Preview.Export.DefaultExportOptionsForm", False, True, True), New C1.Win.C1Preview.ExporterOptions("ReportOpenXmlExportProvider", "C1.C1Preview.Export.DefaultExportOptionsForm", False, True, True)}
        '
        '
        '
        Me.pp.PreviewPane.HistoryOptions.SavedActions = C1.Win.C1Preview.HistorySavedActionsEnum.None
        Me.pp.PreviewPane.IntegrateExternalTools = True
        Me.pp.PreviewPane.ShowRulers = C1.Win.C1Preview.ShowRulersFlags.None
        Me.pp.PreviewPane.TabIndex = 0
        Me.pp.PreviewPane.ZoomMode = C1.Win.C1Preview.ZoomModeEnum.ActualSize
        Me.pp.Size = New System.Drawing.Size(1017, 548)
        Me.pp.StatusBarVisible = False
        Me.pp.TabIndex = 28
        Me.pp.Text = "C1PrintPreviewControl1"
        '
        '
        '
        Me.pp.ToolBars.File.Open.Image = CType(resources.GetObject("pp.ToolBars.File.Open.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.Open.Name = "btnFileOpen"
        Me.pp.ToolBars.File.Open.Size = New System.Drawing.Size(32, 33)
        Me.pp.ToolBars.File.Open.Tag = "C1PreviewActionEnum.FileOpen"
        Me.pp.ToolBars.File.Open.ToolTipText = "Open File"
        Me.pp.ToolBars.File.Open.Visible = False
        '
        '
        '
        Me.pp.ToolBars.File.PageSetup.Image = CType(resources.GetObject("pp.ToolBars.File.PageSetup.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.PageSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.PageSetup.Name = "btnPageSetup"
        Me.pp.ToolBars.File.PageSetup.Size = New System.Drawing.Size(23, 33)
        Me.pp.ToolBars.File.PageSetup.Tag = "C1PreviewActionEnum.PageSetup"
        Me.pp.ToolBars.File.PageSetup.ToolTipText = "Page Setup"
        Me.pp.ToolBars.File.PageSetup.Visible = False
        '
        '
        '
        Me.pp.ToolBars.File.Parameters.Image = CType(resources.GetObject("pp.ToolBars.File.Parameters.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.Parameters.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.Parameters.Name = "btnParameters"
        Me.pp.ToolBars.File.Parameters.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.File.Parameters.Tag = "C1PreviewActionEnum.Parameters"
        Me.pp.ToolBars.File.Parameters.ToolTipText = "Report Parameters"
        Me.pp.ToolBars.File.Parameters.Visible = False
        '
        '
        '
        Me.pp.ToolBars.File.Print.AutoSize = False
        Me.pp.ToolBars.File.Print.BackgroundImage = CType(resources.GetObject("pp.ToolBars.File.Print.BackgroundImage"), System.Drawing.Image)
        Me.pp.ToolBars.File.Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pp.ToolBars.File.Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.pp.ToolBars.File.Print.Image = CType(resources.GetObject("pp.ToolBars.File.Print.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.Print.Name = "btnPrint"
        Me.pp.ToolBars.File.Print.Size = New System.Drawing.Size(41, 33)
        Me.pp.ToolBars.File.Print.Tag = "C1PreviewActionEnum.Print"
        Me.pp.ToolBars.File.Print.ToolTipText = "Print"
        '
        '
        '
        Me.pp.ToolBars.File.PrintLayout.Image = CType(resources.GetObject("pp.ToolBars.File.PrintLayout.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.PrintLayout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.PrintLayout.Name = "btnPrintLayout"
        Me.pp.ToolBars.File.PrintLayout.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.File.PrintLayout.Tag = "C1PreviewActionEnum.PrintLayout"
        Me.pp.ToolBars.File.PrintLayout.ToolTipText = "Print Layout"
        Me.pp.ToolBars.File.PrintLayout.Visible = False
        '
        '
        '
        Me.pp.ToolBars.File.Reflow.Image = CType(resources.GetObject("pp.ToolBars.File.Reflow.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.Reflow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.Reflow.Name = "btnReflow"
        Me.pp.ToolBars.File.Reflow.Size = New System.Drawing.Size(23, 33)
        Me.pp.ToolBars.File.Reflow.Tag = "C1PreviewActionEnum.Reflow"
        Me.pp.ToolBars.File.Reflow.ToolTipText = "Reflow"
        Me.pp.ToolBars.File.Reflow.Visible = False
        '
        '
        '
        Me.pp.ToolBars.File.Save.AutoSize = False
        Me.pp.ToolBars.File.Save.BackgroundImage = CType(resources.GetObject("pp.ToolBars.File.Save.BackgroundImage"), System.Drawing.Image)
        Me.pp.ToolBars.File.Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pp.ToolBars.File.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.pp.ToolBars.File.Save.Image = CType(resources.GetObject("pp.ToolBars.File.Save.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.Save.Name = "btnFileSave"
        Me.pp.ToolBars.File.Save.Size = New System.Drawing.Size(41, 33)
        Me.pp.ToolBars.File.Save.Tag = "C1PreviewActionEnum.FileSave"
        Me.pp.ToolBars.File.Save.ToolTipText = "Save File"
        '
        '
        '
        Me.pp.ToolBars.File.Stop.Image = CType(resources.GetObject("pp.ToolBars.File.Stop.Image"), System.Drawing.Image)
        Me.pp.ToolBars.File.Stop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.File.Stop.Name = "btnStop"
        Me.pp.ToolBars.File.Stop.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.File.Stop.Tag = "C1PreviewActionEnum.Stop"
        Me.pp.ToolBars.File.Stop.ToolTipText = "Stop"
        Me.pp.ToolBars.File.Stop.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.GoFirst.Image = CType(resources.GetObject("pp.ToolBars.Navigation.GoFirst.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Navigation.GoFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Navigation.GoFirst.Name = "btnGoFirst"
        Me.pp.ToolBars.Navigation.GoFirst.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Navigation.GoFirst.Tag = "C1PreviewActionEnum.GoFirst"
        Me.pp.ToolBars.Navigation.GoFirst.ToolTipText = "Go To First Page"
        Me.pp.ToolBars.Navigation.GoFirst.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.GoLast.Image = CType(resources.GetObject("pp.ToolBars.Navigation.GoLast.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Navigation.GoLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Navigation.GoLast.Name = "btnGoLast"
        Me.pp.ToolBars.Navigation.GoLast.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Navigation.GoLast.Tag = "C1PreviewActionEnum.GoLast"
        Me.pp.ToolBars.Navigation.GoLast.ToolTipText = "Go To Last Page"
        Me.pp.ToolBars.Navigation.GoLast.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.GoNext.Image = CType(resources.GetObject("pp.ToolBars.Navigation.GoNext.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Navigation.GoNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Navigation.GoNext.Name = "btnGoNext"
        Me.pp.ToolBars.Navigation.GoNext.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Navigation.GoNext.Tag = "C1PreviewActionEnum.GoNext"
        Me.pp.ToolBars.Navigation.GoNext.ToolTipText = "Go To Next Page"
        Me.pp.ToolBars.Navigation.GoNext.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.GoPrev.Image = CType(resources.GetObject("pp.ToolBars.Navigation.GoPrev.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Navigation.GoPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Navigation.GoPrev.Name = "btnGoPrev"
        Me.pp.ToolBars.Navigation.GoPrev.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Navigation.GoPrev.Tag = "C1PreviewActionEnum.GoPrev"
        Me.pp.ToolBars.Navigation.GoPrev.ToolTipText = "Go To Previous Page"
        Me.pp.ToolBars.Navigation.GoPrev.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.HistoryNext.Image = CType(resources.GetObject("pp.ToolBars.Navigation.HistoryNext.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Navigation.HistoryNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Navigation.HistoryNext.Name = "btnHistoryNext"
        Me.pp.ToolBars.Navigation.HistoryNext.Size = New System.Drawing.Size(32, 22)
        Me.pp.ToolBars.Navigation.HistoryNext.Tag = "C1PreviewActionEnum.HistoryNext"
        Me.pp.ToolBars.Navigation.HistoryNext.ToolTipText = "Next View"
        Me.pp.ToolBars.Navigation.HistoryNext.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.HistoryPrev.Image = CType(resources.GetObject("pp.ToolBars.Navigation.HistoryPrev.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Navigation.HistoryPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Navigation.HistoryPrev.Name = "btnHistoryPrev"
        Me.pp.ToolBars.Navigation.HistoryPrev.Size = New System.Drawing.Size(32, 22)
        Me.pp.ToolBars.Navigation.HistoryPrev.Tag = "C1PreviewActionEnum.HistoryPrev"
        Me.pp.ToolBars.Navigation.HistoryPrev.ToolTipText = "Previous View"
        Me.pp.ToolBars.Navigation.HistoryPrev.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.LblOfPages.Name = "lblOfPages"
        Me.pp.ToolBars.Navigation.LblOfPages.Size = New System.Drawing.Size(27, 22)
        Me.pp.ToolBars.Navigation.LblOfPages.Tag = "C1PreviewActionEnum.GoPageCount"
        Me.pp.ToolBars.Navigation.LblOfPages.Text = "of 0"
        Me.pp.ToolBars.Navigation.LblOfPages.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.LblPage.Name = "lblPage"
        Me.pp.ToolBars.Navigation.LblPage.Size = New System.Drawing.Size(33, 22)
        Me.pp.ToolBars.Navigation.LblPage.Tag = "C1PreviewActionEnum.GoPageLabel"
        Me.pp.ToolBars.Navigation.LblPage.Text = "Page"
        Me.pp.ToolBars.Navigation.LblPage.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.NavigationPane.Image = CType(resources.GetObject("pp.ToolBars.Navigation.NavigationPane.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Navigation.NavigationPane.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Navigation.NavigationPane.Name = "btnNavigationPane"
        Me.pp.ToolBars.Navigation.NavigationPane.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Navigation.NavigationPane.Tag = "C1PreviewActionEnum.NavigationPane"
        Me.pp.ToolBars.Navigation.NavigationPane.ToolTipText = "Navigation Pane"
        Me.pp.ToolBars.Navigation.NavigationPane.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Navigation.PageNo.Name = "txtPageNo"
        Me.pp.ToolBars.Navigation.PageNo.Size = New System.Drawing.Size(34, 25)
        Me.pp.ToolBars.Navigation.PageNo.Tag = "C1PreviewActionEnum.GoPageNumber"
        Me.pp.ToolBars.Navigation.PageNo.Text = "1"
        Me.pp.ToolBars.Navigation.PageNo.Visible = False
        Me.pp.ToolBars.Navigation.ToolTipPageNo = Nothing
        '
        '
        '
        Me.pp.ToolBars.Page.Continuous.Image = CType(resources.GetObject("pp.ToolBars.Page.Continuous.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Page.Continuous.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Page.Continuous.Name = "btnPageContinuous"
        Me.pp.ToolBars.Page.Continuous.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Page.Continuous.Tag = "C1PreviewActionEnum.PageContinuous"
        Me.pp.ToolBars.Page.Continuous.ToolTipText = "Continuous View"
        Me.pp.ToolBars.Page.Continuous.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Page.Facing.Image = CType(resources.GetObject("pp.ToolBars.Page.Facing.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Page.Facing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Page.Facing.Name = "btnPageFacing"
        Me.pp.ToolBars.Page.Facing.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Page.Facing.Tag = "C1PreviewActionEnum.PageFacing"
        Me.pp.ToolBars.Page.Facing.ToolTipText = "Pages Facing View"
        Me.pp.ToolBars.Page.Facing.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Page.FacingContinuous.Image = CType(resources.GetObject("pp.ToolBars.Page.FacingContinuous.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Page.FacingContinuous.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Page.FacingContinuous.Name = "btnPageFacingContinuous"
        Me.pp.ToolBars.Page.FacingContinuous.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Page.FacingContinuous.Tag = "C1PreviewActionEnum.PageFacingContinuous"
        Me.pp.ToolBars.Page.FacingContinuous.ToolTipText = "Pages Facing Continuous View"
        Me.pp.ToolBars.Page.FacingContinuous.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Page.Single.Image = CType(resources.GetObject("pp.ToolBars.Page.Single.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Page.Single.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Page.Single.Name = "btnPageSingle"
        Me.pp.ToolBars.Page.Single.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Page.Single.Tag = "C1PreviewActionEnum.PageSingle"
        Me.pp.ToolBars.Page.Single.ToolTipText = "Single Page View"
        Me.pp.ToolBars.Page.Single.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Search.CloseSearch.Image = CType(resources.GetObject("pp.ToolBars.Search.CloseSearch.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Search.CloseSearch.Name = "btnCloseSearch"
        Me.pp.ToolBars.Search.CloseSearch.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Search.CloseSearch.Tag = "C1PreviewActionEnum.CloseSearch"
        Me.pp.ToolBars.Search.CloseSearch.ToolTipText = "Close"
        Me.pp.ToolBars.Search.CloseSearch.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Search.MatchCase.Name = "btnMatchCase"
        Me.pp.ToolBars.Search.MatchCase.Size = New System.Drawing.Size(73, 22)
        Me.pp.ToolBars.Search.MatchCase.Tag = "C1PreviewActionEnum.MatchCase"
        Me.pp.ToolBars.Search.MatchCase.Text = "Match Case"
        Me.pp.ToolBars.Search.MatchCase.ToolTipText = "Search with case sensitivity"
        Me.pp.ToolBars.Search.MatchCase.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Search.MatchWholeWord.Name = "btnMatchWholeWord"
        Me.pp.ToolBars.Search.MatchWholeWord.Size = New System.Drawing.Size(77, 22)
        Me.pp.ToolBars.Search.MatchWholeWord.Tag = "C1PreviewActionEnum.MatchWholeWord"
        Me.pp.ToolBars.Search.MatchWholeWord.Text = "Whole Word"
        Me.pp.ToolBars.Search.MatchWholeWord.ToolTipText = "Match whole word only"
        Me.pp.ToolBars.Search.MatchWholeWord.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Search.SearchLabel.Name = "lblSearch"
        Me.pp.ToolBars.Search.SearchLabel.Size = New System.Drawing.Size(33, 22)
        Me.pp.ToolBars.Search.SearchLabel.Tag = "C1PreviewActionEnum.SearchLabel"
        Me.pp.ToolBars.Search.SearchLabel.Text = "Find:"
        Me.pp.ToolBars.Search.SearchLabel.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Search.SearchNext.Image = CType(resources.GetObject("pp.ToolBars.Search.SearchNext.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Search.SearchNext.Name = "btnSearchNext"
        Me.pp.ToolBars.Search.SearchNext.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Search.SearchNext.Tag = "C1PreviewActionEnum.SearchNext"
        Me.pp.ToolBars.Search.SearchNext.ToolTipText = "Search Next"
        Me.pp.ToolBars.Search.SearchNext.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Search.SearchPrevious.Image = CType(resources.GetObject("pp.ToolBars.Search.SearchPrevious.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Search.SearchPrevious.Name = "btnSearchPrevious"
        Me.pp.ToolBars.Search.SearchPrevious.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Search.SearchPrevious.Tag = "C1PreviewActionEnum.SearchPrevious"
        Me.pp.ToolBars.Search.SearchPrevious.ToolTipText = "Search Previous"
        Me.pp.ToolBars.Search.SearchPrevious.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Search.SearchText.Name = "txtSearchText"
        Me.pp.ToolBars.Search.SearchText.Size = New System.Drawing.Size(200, 25)
        Me.pp.ToolBars.Search.SearchText.Tag = "C1PreviewActionEnum.SearchText"
        Me.pp.ToolBars.Search.SearchText.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Text.Find.Image = CType(resources.GetObject("pp.ToolBars.Text.Find.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Text.Find.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Text.Find.Name = "btnFind"
        Me.pp.ToolBars.Text.Find.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Text.Find.Tag = "C1PreviewActionEnum.Find"
        Me.pp.ToolBars.Text.Find.ToolTipText = "Find Text"
        Me.pp.ToolBars.Text.Find.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Text.Hand.Image = CType(resources.GetObject("pp.ToolBars.Text.Hand.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Text.Hand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Text.Hand.Name = "btnHandTool"
        Me.pp.ToolBars.Text.Hand.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Text.Hand.Tag = "C1PreviewActionEnum.HandTool"
        Me.pp.ToolBars.Text.Hand.ToolTipText = "Hand Tool"
        Me.pp.ToolBars.Text.Hand.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Text.SelectText.Image = CType(resources.GetObject("pp.ToolBars.Text.SelectText.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Text.SelectText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Text.SelectText.Name = "btnSelectTextTool"
        Me.pp.ToolBars.Text.SelectText.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Text.SelectText.Tag = "C1PreviewActionEnum.SelectTextTool"
        Me.pp.ToolBars.Text.SelectText.ToolTipText = "Text Select Tool"
        Me.pp.ToolBars.Text.SelectText.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Zoom.DropZoomFactor.Name = "dropZoomFactor"
        Me.pp.ToolBars.Zoom.DropZoomFactor.Size = New System.Drawing.Size(13, 22)
        Me.pp.ToolBars.Zoom.DropZoomFactor.Tag = "C1PreviewActionEnum.ZoomFactor"
        Me.pp.ToolBars.Zoom.DropZoomFactor.Visible = False
        Me.pp.ToolBars.Zoom.ToolTipZoomFactor = Nothing
        '
        '
        '
        Me.pp.ToolBars.Zoom.ZoomFactor.Name = "txtZoomFactor"
        Me.pp.ToolBars.Zoom.ZoomFactor.Size = New System.Drawing.Size(48, 25)
        Me.pp.ToolBars.Zoom.ZoomFactor.Tag = "C1PreviewActionEnum.ZoomFactor"
        Me.pp.ToolBars.Zoom.ZoomFactor.Text = "100%"
        Me.pp.ToolBars.Zoom.ZoomFactor.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Zoom.ZoomIn.Image = CType(resources.GetObject("pp.ToolBars.Zoom.ZoomIn.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Zoom.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Zoom.ZoomIn.Name = "btnZoomIn"
        Me.pp.ToolBars.Zoom.ZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Zoom.ZoomIn.Tag = "C1PreviewActionEnum.ZoomIn"
        Me.pp.ToolBars.Zoom.ZoomIn.ToolTipText = "Zoom In"
        Me.pp.ToolBars.Zoom.ZoomIn.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Zoom.ZoomInTool.Image = CType(resources.GetObject("pp.ToolBars.Zoom.ZoomInTool.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Zoom.ZoomInTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Zoom.ZoomInTool.Name = "itemZoomInTool"
        Me.pp.ToolBars.Zoom.ZoomInTool.Size = New System.Drawing.Size(156, 22)
        Me.pp.ToolBars.Zoom.ZoomInTool.Tag = "C1PreviewActionEnum.ZoomInTool"
        Me.pp.ToolBars.Zoom.ZoomInTool.Text = "Zoom In Tool"
        Me.pp.ToolBars.Zoom.ZoomInTool.ToolTipText = "Zoom In Tool"
        '
        '
        '
        Me.pp.ToolBars.Zoom.ZoomOut.Image = CType(resources.GetObject("pp.ToolBars.Zoom.ZoomOut.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Zoom.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Zoom.ZoomOut.Name = "btnZoomOut"
        Me.pp.ToolBars.Zoom.ZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.pp.ToolBars.Zoom.ZoomOut.Tag = "C1PreviewActionEnum.ZoomOut"
        Me.pp.ToolBars.Zoom.ZoomOut.ToolTipText = "Zoom Out"
        Me.pp.ToolBars.Zoom.ZoomOut.Visible = False
        '
        '
        '
        Me.pp.ToolBars.Zoom.ZoomOutTool.Image = CType(resources.GetObject("pp.ToolBars.Zoom.ZoomOutTool.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Zoom.ZoomOutTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Zoom.ZoomOutTool.Name = "itemZoomOutTool"
        Me.pp.ToolBars.Zoom.ZoomOutTool.Size = New System.Drawing.Size(156, 22)
        Me.pp.ToolBars.Zoom.ZoomOutTool.Tag = "C1PreviewActionEnum.ZoomOutTool"
        Me.pp.ToolBars.Zoom.ZoomOutTool.Text = "Zoom Out Tool"
        Me.pp.ToolBars.Zoom.ZoomOutTool.ToolTipText = "Zoom Out Tool"
        '
        '
        '
        Me.pp.ToolBars.Zoom.ZoomTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pp.ToolBars.Zoom.ZoomInTool, Me.pp.ToolBars.Zoom.ZoomOutTool})
        Me.pp.ToolBars.Zoom.ZoomTool.Image = CType(resources.GetObject("pp.ToolBars.Zoom.ZoomTool.Image"), System.Drawing.Image)
        Me.pp.ToolBars.Zoom.ZoomTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pp.ToolBars.Zoom.ZoomTool.Name = "btnZoomTool"
        Me.pp.ToolBars.Zoom.ZoomTool.Size = New System.Drawing.Size(32, 22)
        Me.pp.ToolBars.Zoom.ZoomTool.Tag = "C1PreviewActionEnum.ZoomInTool"
        Me.pp.ToolBars.Zoom.ZoomTool.ToolTipText = "Zoom In Tool"
        Me.pp.ToolBars.Zoom.ZoomTool.Visible = False
        '
        'cr
        '
        Me.cr.ReportDefinition = resources.GetString("cr.ReportDefinition")
        Me.cr.ReportName = "C1Report1"
        '
        'Cbmes
        '
        Me.Cbmes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbmes.FormattingEnabled = True
        Me.Cbmes.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cbmes.Location = New System.Drawing.Point(112, 53)
        Me.Cbmes.Name = "Cbmes"
        Me.Cbmes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cbmes.Size = New System.Drawing.Size(128, 24)
        Me.Cbmes.TabIndex = 26
        '
        'BtConsultar
        '
        Me.BtConsultar.BackgroundImage = CType(resources.GetObject("BtConsultar.BackgroundImage"), System.Drawing.Image)
        Me.BtConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtConsultar.Location = New System.Drawing.Point(406, 33)
        Me.BtConsultar.Name = "BtConsultar"
        Me.BtConsultar.Size = New System.Drawing.Size(75, 62)
        Me.BtConsultar.TabIndex = 25
        Me.BtConsultar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 24)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "QUINCENA:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 24)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "MES:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "AÑO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbCiclo
        '
        Me.CbCiclo.BackColor = System.Drawing.Color.SkyBlue
        Me.CbCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbCiclo.FormattingEnabled = True
        Me.CbCiclo.Items.AddRange(New Object() {"1", "2"})
        Me.CbCiclo.Location = New System.Drawing.Point(112, 78)
        Me.CbCiclo.Name = "CbCiclo"
        Me.CbCiclo.Size = New System.Drawing.Size(128, 26)
        Me.CbCiclo.TabIndex = 21
        '
        'DatAnio
        '
        Me.DatAnio.CustomFormat = "yyyy"
        Me.DatAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatAnio.Location = New System.Drawing.Point(112, 28)
        Me.DatAnio.Name = "DatAnio"
        Me.DatAnio.ShowUpDown = True
        Me.DatAnio.Size = New System.Drawing.Size(128, 24)
        Me.DatAnio.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1020, 27)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "REPORTE DE HORAS EXTRAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbGeneral)
        Me.GroupBox1.Controls.Add(Me.RbSerigrafia)
        Me.GroupBox1.Location = New System.Drawing.Point(250, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(138, 65)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'RbGeneral
        '
        Me.RbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbGeneral.Location = New System.Drawing.Point(6, 37)
        Me.RbGeneral.Name = "RbGeneral"
        Me.RbGeneral.Size = New System.Drawing.Size(126, 24)
        Me.RbGeneral.TabIndex = 18
        Me.RbGeneral.TabStop = True
        Me.RbGeneral.Text = "GENEREAL"
        Me.RbGeneral.UseVisualStyleBackColor = True
        '
        'RbSerigrafia
        '
        Me.RbSerigrafia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSerigrafia.Location = New System.Drawing.Point(6, 9)
        Me.RbSerigrafia.Name = "RbSerigrafia"
        Me.RbSerigrafia.Size = New System.Drawing.Size(126, 24)
        Me.RbSerigrafia.TabIndex = 17
        Me.RbSerigrafia.TabStop = True
        Me.RbSerigrafia.Text = "SERIGRAFIA"
        Me.RbSerigrafia.UseVisualStyleBackColor = True
        '
        'FrmHorasExtras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 654)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DatAnio)
        Me.Controls.Add(Me.pp)
        Me.Controls.Add(Me.Cbmes)
        Me.Controls.Add(Me.BtConsultar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbCiclo)
        Me.Name = "FrmHorasExtras"
        Me.ShowIcon = False
        CType(Me.pp.PreviewPane, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pp.ResumeLayout(False)
        Me.pp.PerformLayout()
        CType(Me.cr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pp As C1.Win.C1Preview.C1PrintPreviewControl
    Friend WithEvents Cbmes As System.Windows.Forms.ComboBox
    Friend WithEvents BtConsultar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbCiclo As System.Windows.Forms.ComboBox
    Friend WithEvents DatAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cr As C1.C1Report.C1Report
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents RbSerigrafia As System.Windows.Forms.RadioButton
End Class
