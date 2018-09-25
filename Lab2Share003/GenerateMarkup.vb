Imports System.Text
Imports System.Text.RegularExpressions

Public Class GenerateMarkup
    Public Shared Function PageMarkupByTemplate(PageName As String) As String
        Dim DB As New markupDataContext
        Dim PageTemplate As String = (From tplate In DB.Contents Where tplate.SectionType = "pagelayout" And tplate.PageName = PageName Select tplate.Markup).FirstOrDefault

        Dim rgx As Regex = New Regex("\{[A-z0-9]+\}", RegexOptions.IgnoreCase)



        For Each m In rgx.Matches(PageTemplate)
            Dim elementname As String = Regex.Match(m.value.ToString, "[A-Xa-z1-9]+").Value.ToString
            Dim elementmarkup As String = (From e In DB.Contents Where e.PageName = PageName And e.SectionName = elementname Select e.Markup).FirstOrDefault

            PageTemplate = PageTemplate.Replace(m.value, elementmarkup)

        Next
        Return PageTemplate
    End Function
End Class
