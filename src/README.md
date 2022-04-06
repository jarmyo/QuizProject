# QuizProject

## Tech Stack:

- ASP.NET Core 6
- SQLite
- Bootstrap 5
- EntityFramework 6
- TypeScript

## Data store

This site uses two SQLite Databases, QUizProject to store user login information and QuizData for all Content info.
If you make changes to database in local and push changes data will be overwriting, take care of this.

All images upload are stored in wwwroot/img. 


## Configure

No aditional configuration is needed. Just restore nuget packages, build and deploy.

## Notes

Calculator.cs has the functions to compare valid answers.