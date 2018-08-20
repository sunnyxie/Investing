Public Class NoAccess
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If CNRLWebAppHelper.GetCNRLUser() Is Nothing Then
            Me.lblError.Text = "You (" & CType(Context.User.Identity, System.Security.Principal.WindowsIdentity).Name & ") do not have access to this website (" & ConfigurationManager.GetSection("MyAppSettings")("appSecureEnvironment") & "\" & ConfigurationManager.GetSection("MyAppSettings")("appSecureAppId") & ").  Please call the help desk to request access."
            HttpContext.Current.Session.Abandon()
        Else
            Response.Redirect("Default.aspx")
        End If
    End Sub

End Class