Requirements for UserAPIData 
•	Visual studio latest version based on requirement, framework 4.7.2,WebAPI,Enity framework,Sqlserver 2019 with database and required project related libraries
1.	SQL Server Setup process
•	Create a sample db in local sqlserver2019 with windows authentication,created “UserInfo” table with column contraints.
•	Inserted some sample data for testing purpose
2.	Web API Setup
•	Installed visual studio 2022 professional for project development.
•	Create a sample Asp.net webapi project” APIDataforUserRegistration” using visual studio version 4.7.2.
•	Added Ado.net entity framework code first from data to existing project.
•	Connected to server source and selected specific data(sampledatabase) and included required tables ,procedure and views 
•	Db setup is done and able to view the connect path in webconfig file.
•	Initial setup is ready of project development.
•	Clean and build the solution to avoid the errors. If any error occurred, included required libraries from nugget package manager.
•	MVC webAPI is now ready to develop, created a controller like as “UserRegistrationController.cs” under controller method section inside the project.
•	Added model as “UserInfo.cs” based on given parameters.
•	Created different verb methods like”HttpGet” for data retrieve,”httpPost” method for “data submission”, “httpPut” for data modification and “httpdelete” for data deletion.
•	And also verified the included the IIS configuration and change the start page like localhost https://localhost:44308/Help  
•	Tested these http verbs using postman tool and able to retrieve and sudmit the data successfully.
