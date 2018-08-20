TO SETUP YOUR NEW WEB APP PROJECT
*********************************

1)  Create the application in AppSecure.  Be sure to create at least one operation and assign 
	it to at least one role (login will fail if roles have no operations assigned).  Assign
	the service_appsecure user to a role within the application (IMPORTANT, without this the application
	cannot connect to AppSecure).

2)  Update the appSecureAppId in Web.Config to match your AppSecure configuration.

3)  Update Site.Master's div_header section to display the correct application name.

4)  Update Menu.XML to reflect desired menu structure.  Add a security_op_id to any element (menu or submenu)
	that must secured through AppSecure.  The value for the attribute must be the OPERATION (not role) that 
	is required to see the menu.  Note that submenus for any secured menu item will also be trimmed if their 
	parent is.

5)  Add the business object project to the solution.  Add reference from the web application to the business
	object project(s).  Update the reference path on the business object project(s) to point to the web
	application's external bin folder.
