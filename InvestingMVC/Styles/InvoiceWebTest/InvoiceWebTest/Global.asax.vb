Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Private mObjectFactory As CanadianNatural.ApplicationServices.BusinessObjects.MereMortals.CNRLObjectFactory = Nothing

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' When the session starts we will log the user in using AppSecure.  If they do not have access we redirect them to the 
        ' NoAccess.aspx page, otherwise we log them in and store the User object in the Session.

        ' First, create a security provider and login as service_appsecure (we use impersonation). *** REMEMBER, the service_appsecure user must belong to a role in your application's AppSecure configuration for this to work! ***
        Dim login_result As String = ""
        Dim genericSecurityProvider As New CanadianNatural.ApplicationServices.Security.AppSecure.WebAppProvider
        Dim iSecurityProvider As CanadianNatural.ApplicationServices.Security.Interface.ICNRLWebAuthenticationProvider = CanadianNatural.ApplicationServices.Security.AppSecure.WebAppProvider.Login(My.Settings.appSecureURL, My.Settings.appSecureEnvironment, My.Settings.appSecureAppId, login_result)
        mObjectFactory = New CanadianNatural.ApplicationServices.BusinessObjects.MereMortals.CNRLObjectFactory(My.Settings.appSecureAppId, iSecurityProvider)
        If iSecurityProvider Is Nothing Then
            Response.Write("service_appsecure account login failed, please ensure that the AppSecure application ID is correct in web.config and that service_appsecure user has been assigned a role in your AppSecure settings and that global.asax is updated to point to the correct environment.")
            Response.End()
            Session_End(Me, Nothing)
            Exit Sub
        End If

        ' Get User's SID
        Dim UserSID As String = DirectCast(User.Identity, System.Security.Principal.WindowsIdentity).User.ToString

        ' Next, Store the resulting user login object for later in a session variable(CURRENT_USER in this case).
        Session("CURRENT_USER") = iSecurityProvider.LoginUser(UserSID, "", login_result)

        ' If the user couldn't be logged in, redirect to the NoAccess.aspx page and end the session.
        If Session("CURRENT_USER") Is Nothing Then
            Response.Redirect("NoAccess.aspx")
            Response.End()
            Session_End(Me, Nothing)
        End If

        ' Store the login result 
        Session("LOGIN_RESULT") = login_result
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Try
            '  If Response.IsClientConnected AndAlso Not Response.IsRequestBeingRedirected Then
            Dim lastError = Server.GetLastError()
            CNRLWebAppHelper.WriteError(lastError.Message.ToString)
            Server.ClearError()
            Response.Redirect("Error.aspx?ERR=" & lastError.Message.ToString)
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends

        ' Release the ICNRLUser object for the user's session
        Session("CURRENT_USER") = Nothing
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class