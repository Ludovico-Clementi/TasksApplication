This project is an exercise about creating a full working app.
The purpose of the application is to record and save information about users, and activities:
An user can sign up and log in, then in the main view he can add, remove and mark as completed one or more activites.
This project uses the folowing technologies:
-API with AspNetCore(.NET & C#) 
-Two applications version, in order to be supported multiple OS:
  >WinUI 3
  >MAUI
The structure of the project also consists in a centralized control of the Dtos and of the part that manages the
business logic in applications.
Due to this centralization of logic controls, only 2 tests project will be needed: one for the API Controllers and the other
for the business logic of Core Project.
TasksApp Solution therefore will contains the following projects:
-API (Request Handler)
-DataModels (Class Library with Dto storage) 
-Core (Utility Class, junction between API and Apps)
-MauiApp (App supported by most OS)
-WinUIApp (App native for Windows OS)
-TestCore (Testing Proj for Core)
-TestAPI (Testing Proj for API Request Handling)
