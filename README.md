# Test applications For Cash Dispensing System

## cashdispenseddemoxamarin.MobileAppService

This is the Backend Webservices written in ASP.Net Core 1.1 which is cross platform.
If you are on a Mac you will need:
- Xamarin Studio - with the latest updates installed
- or Visual Studio for Mac - with the latest updates installed

If you are on a Windows machine you will need:
Visual Studio 2017 - with the latest updates installed

Open cashdispenseddemoxamarin/cashdispenseddemoxamarin.sln in either of the above editors depending on your operationing system and choice of editor

Run the project and make a note of the port number that it runs on in the browser window that opens

## cashdispenseddemoxamarin

This is the Xamarin App which allows the iOS and Android Applications to be run.

If you are on a Mac you will need:
- Xamarin Studio - with the latest updates installed
- or Visual Studio for Mac - with the latest updates installed

If you are on a Windows machine you will need:
Visual Studio 2017 - with the latest updates installed

Open cashdispenseddemoxamarin/cashdispenseddemoxamarin.sln in either of the above editors

Right click on the iOS project if you're on a Mac or the Android project if you're on Windows (or a Mac) and choose 'set as startup project'

in the cashdispenseddemoxamarin project which is in the "Common" solution folder open the App.xaml.cs file and check that the port number in the BackendUrl static variable matches the one that opened in the browser above. If it doesn't change the port number to match yours

Then do a full rebuild of the solution and then click the Play button.

Login the application as either of the following users:

UserName:
richard@superbank.co.za
Password:
testmale

UserName:
sally@superbank.co.za
Password:
testfemale

Then click Add at the top right to add a transaction and save when you are done filling in the required information 
