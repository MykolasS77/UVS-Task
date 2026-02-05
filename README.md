# UVS Test Description
Build a console app which will add and get employees from a database using ORM (e.g. Entity Framework).

## Will test

 * Basic application architecture
 * Testability
 * Attention to detail

## Language

C#

## Requirements

 * Docker or a local sql instance
 * Dotnet core
 * powershell

## App setup instructions:

* Install Docker Desktop.
* Right click on 'DatabaseSchema\AssignmentDetails' directory and open in terminal. 
* Run '.\setUpDocker.ps1' command.
* Open Docker Desktop, click on "Containers" and make sure the 'employee-database-container' is running.
<img width="950" height="562" alt="image" src="https://github.com/user-attachments/assets/08668887-0c23-44f8-b685-ec771362be33" />


## To Run App

* Make sure that proper environment variables are set (values provided at the top of 'verifySubmission.ps1' file).
* If no values have been added to database yet, run '.\verifySubmission.ps1' command to test the application.
* To run on your own, change directory to 'DatabaseSchema'.
* Run one of the commands based on these templates:
  * dotnet run set-employee --employeeId [enter positive number] --employeeName [enter a name] --employeeSalary [enter positive number]
  * dotnet run get-employee --employeeId [enter positive number] 

## To Run Tests

* Open 'Tests' in command terminal. 
* Run 'dotnet test' command.