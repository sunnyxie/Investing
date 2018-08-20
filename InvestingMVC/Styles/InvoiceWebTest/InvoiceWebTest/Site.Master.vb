Imports System.Xml

Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Is this the No Access page?  If not, check page security
        If Not Me.Page.AppRelativeVirtualPath = "~/NoAccess.aspx" Then

            ' Do the basic security check (redirects if no access)
            CNRLWebAppHelper.SecurityCheck()

            ' Update menu items when page is first loaded (but not on postbacks)
            If Not Page.IsPostBack Then
                'Update Menu
                Dim availOps As List(Of String) = CNRLWebAppHelper.GetCNRLUser.AvailableOperations()
                Dim menuXML As New XmlDocument()
                menuXML.Load(Server.MapPath("Menu.xml"))
                Dim nodesToCheck As XmlNodeList = menuXML.SelectNodes("//@security_op_id")
                For Each node As XmlAttribute In nodesToCheck
                    If Not availOps.Contains(node.InnerText) Then
                        node.OwnerElement.ParentNode.RemoveChild(node.OwnerElement)
                    End If
                Next
                menu_xml_data_source.DataFile = ""
                menu_xml_data_source.Data = menuXML.InnerXml.ToString
                menu_xml_data_source.XPath = "//Menu"
                menu_top.DataBind()
            End If

        End If
    End Sub

End Class