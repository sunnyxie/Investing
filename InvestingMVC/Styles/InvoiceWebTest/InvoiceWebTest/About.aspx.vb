Public Class About1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Populate Fields from Application Info (update Assembly information to update)
        txtName.Text = My.Application.Info.ProductName
        txtVersion.Text = My.Application.Info.Version.ToString
        txtEnvironment.Text = My.Settings.appSecureEnvironment

        ' Populate User Information from AppSecure
        txtUserName.Text = CNRLWebAppHelper.GetCNRLUser.Name
        txtUserID.Text = CNRLWebAppHelper.GetCNRLUser.UserID
        txtRoles.Text = ""
        For Each role As String In DirectCast(CNRLWebAppHelper.GetCNRLUser, CanadianNatural.ApplicationServices.Security.AppSecure.AppSecureUser).AssignedRoles
            txtRoles.Text = txtRoles.Text + role & vbCrLf
        Next
        txtOperations.Text = ""
        For Each operation As String In DirectCast(CNRLWebAppHelper.GetCNRLUser, CanadianNatural.ApplicationServices.Security.AppSecure.AppSecureUser).AvailableOperations
            txtOperations.Text = txtOperations.Text + operation & vbCrLf
        Next
    End Sub

End Class