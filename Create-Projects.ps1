Write-Host "`nStep 1: Creating a New Solution`n"

dotnet new sln
dotnet new gitignore


Write-Host "`nStep 2: Creating Projects from Templates`n"

dotnet new classlib --name "BitArrayItemsIntersection.Library" --framework "net6.0"
dotnet new nunit --name "BitArrayItemsIntersection.Testing" --framework "net6.0"
dotnet new console --name "BitArrayItemsIntersection.App.CLI" --framework "net6.0"
dotnet new web --name "BitArrayItemsIntersection.App.Web" --framework "net6.0"


Write-Host "`nStep 3: Adding References to Projects`n"

dotnet add "BitArrayItemsIntersection.Testing" reference "BitArrayItemsIntersection.Library"
dotnet add "BitArrayItemsIntersection.App.CLI" reference "BitArrayItemsIntersection.Library"
dotnet add "BitArrayItemsIntersection.App.Web" reference "BitArrayItemsIntersection.Library"


Write-Host "`nStep 4: Adding Projects to the Solution`n"

dotnet sln add "BitArrayItemsIntersection.Library"
dotnet sln add "BitArrayItemsIntersection.Testing"
dotnet sln add "BitArrayItemsIntersection.App.CLI"
dotnet sln add "BitArrayItemsIntersection.App.Web"


Write-Host "`nStep 5: Displaying Projects from the Solution`n"

dotnet sln list
