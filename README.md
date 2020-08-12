# Job Board CRUD

## Description
This is a small portable app for maintenance of a Job Board. (Technical Test for Saongroup job application).
Within is the sqlite file with some records to use the list out method.

## Installation & Requirements
- Net Core 3.1+
- Net Standard 2.0+
- Visual Studio or Visual Studio Code to test the solution.

If you use Visual Studio Code, open a terminal, navigate to the root folder of the solution and type:
```
dotnet restore
```
If you use Visual Studio, you should clean the solution and build to restore the packages.

To test the solution you need to run both projects SaongroupTest.Api from Backend folder and SaongroupTest.WebApp.

The solution is made using clean architecture and Repository Pattern + Unit of Work pattern.
It uses sqlite database to avoid scripts.
