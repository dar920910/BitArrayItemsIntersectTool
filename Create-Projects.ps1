Write-Host "`nStep 1: Creating a New Solution`n"

dotnet new sln
dotnet new gitignore


Write-Host "`nStep 2: Creating Projects from Templates`n"

dotnet new classlib --name "BooleanArrayExploring.Library" --framework "net6.0"
dotnet new nunit --name "BooleanArrayExploring.Testing" --framework "net6.0"
dotnet new console --name "BooleanArrayExploring.App.CLI" --framework "net6.0"
dotnet new web --name "BooleanArrayExploring.App.Web" --framework "net6.0"


Write-Host "`nStep 3: Adding References to Projects`n"

dotnet add "BooleanArrayExploring.Testing" reference "BooleanArrayExploring.Library"
dotnet add "BooleanArrayExploring.App.CLI" reference "BooleanArrayExploring.Library"
dotnet add "BooleanArrayExploring.App.Web" reference "BooleanArrayExploring.Library"


Write-Host "`nStep 4: Adding Projects to the Solution`n"

dotnet sln add "BooleanArrayExploring.Library"
dotnet sln add "BooleanArrayExploring.Testing"
dotnet sln add "BooleanArrayExploring.App.CLI"
dotnet sln add "BooleanArrayExploring.App.Web"


Write-Host "`nStep 5: Displaying Projects from the Solution`n"

dotnet sln list
