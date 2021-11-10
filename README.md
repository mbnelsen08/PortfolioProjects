# PortfolioProjects

#CarDealershipApp Notes#

The CarDealershipApp is my final assessment for the bootcamp. I am not quite finished with this project. But, you can take a look at the work in progess.

I need to complete the views and controllers for the admin portion of the app.

This app utilizes ASP.NET Identity and Code-first Entity Framework to manage users and user roles. Users in specific roles are only allowed access to certain sections of the app.
I still need to write the code to only allow certain roles access to specific actions in my controllers.

This app uses dependency injection, factory classes and interfaces for the repository classes. This is so I can run the app in 'test' mode and not make an unwanted changes to my database.

I included the SQL files for the database creation, table creation, stored procedures and a database reset file.


#DvdLibraryAssessment Notes#

This folder includes a UI written in html, css and javascript. I used jquery to control events on the page and to make ajax calls to the API I wrote in C#.

The API features dependency injection again for 'test' and 'prod' modes. I named the repository 'DapperRepository'. But, I didn't actually use Dapper, just standard ADO.NET.

The SQL files show the database and stored procedures I created which are called on by the API.

#FlooringMasteryAssessment Notes#
This is a console app that reads and writes to local text files.

#VendingMachine Notes#
This is a UI written in css, html, and javascript. It uses jquery and ajax to make HTTP requests to an API provided by the Software Guild. 
