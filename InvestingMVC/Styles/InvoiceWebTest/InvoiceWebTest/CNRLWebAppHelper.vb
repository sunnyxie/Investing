Imports Microsoft.VisualBasic
Imports CanadianNatural.ApplicationServices.Security.Interface
Imports System.IO

Public Class CNRLWebAppHelper

#Region "Security"

    Public Shared Sub SecurityCheck()
        If GetCNRLUser() Is Nothing Then
            HttpContext.Current.Response.Redirect("NoAccess.aspx")
            HttpContext.Current.Response.End()
        End If
    End Sub

    Public Shared Function GetCNRLUser() As ICNRLUser
        Return DirectCast(HttpContext.Current.Session("CURRENT_USER"), CanadianNatural.ApplicationServices.Security.Interface.ICNRLUser)
    End Function

#End Region

#Region "Error Handling"

    Public Shared Sub WriteError(ByVal errorMessage As String)
        Try
            Dim path As String = "~/ErrorLog.txt"
            If (Not File.Exists(System.Web.HttpContext.Current.Server.MapPath(path))) Then
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close()
            End If
            Using w As StreamWriter = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path))
                w.WriteLine(Constants.vbCrLf & "***** New Error *****")
                w.WriteLine("Time : {0}", DateTime.Now.ToString())
                w.WriteLine("User : " & My.User.Name)
                w.WriteLine("Location: " & System.Web.HttpContext.Current.Request.Url.ToString())
                w.WriteLine("Error Message: " & errorMessage)
                w.WriteLine(Constants.vbCrLf)
                w.Flush()
                w.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class
