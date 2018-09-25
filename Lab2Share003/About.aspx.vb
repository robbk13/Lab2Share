Public Class About
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim a As String = System.IO.Path.GetFileName(Request.ServerVariables("SCRIPT_NAME"))
            Dim b As String = System.IO.Path.GetFileName(Request.Url.ToString())
            Dim c As String = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath)

            Me.pagemarkup.Text = GenerateMarkup.PageMarkupByTemplate(a.ToLower)
        End If
    End Sub
End Class