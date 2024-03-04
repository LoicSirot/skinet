# Skinet project
## Section 2 - API Basics
### Create Project
To create a project using CLI, first you need to create the folder and go inside.  
After, you need to create the solution file:
```
dotnet new sln
```
This will create a solution file with the name of the folder.
Now, you can create the project, in this case a web api:
```
dotnet new webapi -n API --use-controllers
```
Then, you need to add the project to your solution file:
```
dotnet sln add API
```
### Entity Framework
First we are using SQLite, as this is a light database and it's enough for development purpose.  
Nuget:
```
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Sqlite
```
### Create the Architecture
We are going to use 3 projects in this solution. The API project is already created.  
We need to create the Core project:
```
dotnet new classlib -n Core
```
And add it to the solution file:
```
dotnet sln add Core
```
We need to create the Infrastructure project:
```
dotnet new classlib -n Infrastructure
```
And add it to the solution file:
```
dotnet sln add Infrastructure
```
You can verify is all project were added with this command:
```
dotnet sln list
```
Then go inside the API folder and add the reference to Infrastructure:
```
dotnet add reference ../Infrastructure
```
Go back and go inside the Infrastructure folder and add the reference to Core:
```
dotnet add reference ../Core
```
Go back one folder and to make sure everything works, run this command:
```
dotnet restore
```
At this point, if you created some data before, you will need to adjust the projects. Move the Data folder into Infrastructure and move the Entities folder into Core. After that, you will need to adjust the code, the namespace and the references.  
In the API project, remove the Sqlite package from the csproj and paste it inside the Infrastructure project with the corresponding <ItemGroup></ItemGroup> tags.  
Now you need to make sure everything works, so run again the command:
```
dotnet restore
```
And rebuild the projects:
```
dotnet build
```

### Save project to GitHub
To save the project you need to initialize git:
```
git init
``` 
The you can run the command:
```
git status
```
To check the status and the name of the branch. If the name of the branch is not main, or you want to name it otherwise:
```
git branch -m main
```
You can check the status again to see if it has changed.  
Now you need to create the .gitignore:
```
git new gitignore
```
This will create a file with all the folders and files that will not be uploaded to GitHub. You can add any file or folder that you don't want to upload.  
You need to stage all the files, for that use this command:
```
git add .
```
Now, you can commit the changes with the name you want:
```
git commit -m "First commit"
```
And you need to add the correct repository (You need to create it first in GitHub and then copy the link):
```
git remote add origin https://github.com/LoicSirot/skinet.git
```
You can now push it up to the selected repository:
```
git push -u origin main
```
If you are using VSCode, then after creating the gitignore file, you can just stage the changes, add a comment and click on Commit.  

### Section 3 - API Architecture
In the precedent section we have created a Migration, we are going to drop the existing database, but we need to specify the project:
```
dotnet ef database drop -p Infrastructure -s API
```
Now, we will remove the existing Migration, again we need to specify the project:
```
dotnet ef migrations remove -p Infrastructure -s API
```
We going to create now the migration again:
```
dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations
```