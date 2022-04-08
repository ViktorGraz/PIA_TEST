# Interview example
The subject of this coding example is a task list. When you download the repository, everything is already built so that the application can display a list of tasks. 
The application already contains a set of tasks - on these tasks you should work during this coding example. 
The idea is to revise the existing code base and adding some extensions.

## What should you do?
- Take 2-3 hours to work on the example
- Set up the solution as described in the "Set up" section below
- Follow the "guidelines" for your development described below
- You will find the tasks you need to solve in the application itself once you open it in your browser
- There are many tasks that can probably take longer than 2-3 hours in total. Nevertheless, try to work on each task. For the tasks that you cannot solve in the time, include some comments in the solution where and how you would solve them (e.g. pseudocode).
- The tasks in the example are ordered by difficulty (easier tasks at the top), they were created to cover technical skills from junior to senior level. If you don't know how to solve a task, try to explain your steps on how you would approach the task.
- When you are done with the task, send us an email with a link to your repository.

## Guidelines
- Work in a public Github repository so we can review your code.
- Use best practices whenever possible.
- Use Gitflow and work on separate branches for each task
- Before submitting code to us, make sure you've merged everything back into the master branch, because that's the branch we'll be reviewing.

## Set up
- Download the zip file from the MFT server to your computer
- Create a public Github repository on your account
- Transfer the code to your repository
- Open the solution at /src/PIA.DotNet.Interview.sln in your Visual Studio
- Restore the Nuget packages for the solution
- In the PIA.DotNet.Interview.Core\Database\DbContext class, edit the DATABASE_PATH constant field to a path in the root of your repo, such as. @"C:\Source\database.json" if your repository is located at C:\Source.
- Launch the application from Visual Studio
- You should now see the task list for this example in your browser
- Make sure that the database.json file was created where you expected it to be and that it was committed to your Git repository

## Need help?
If you have any problems setting up or working on the project, don't hesitate to contact your interview contact person