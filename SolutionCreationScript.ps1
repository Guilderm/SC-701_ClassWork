# sets the names and directory
$solutionName = "MidtermExam"
$EntityName = "Entity"
$DALName = "DAL"
$BackEndName = "BackEnd"
$FrontEndName = "FrontEnd"
$DBName = "Comercio"
$basePath = "$($env:USERPROFILE)\Documents\Repositories"


# create the solution folder
New-Item -ItemType Directory -Path $basePath\$solutionName -Force
cd "$basePath\$solutionName"

# create the Entity project
dotnet new classlib -n $EntityName -o $EntityName --framework net6.0
cd $EntityName
dotnet add package Microsoft.EntityFrameworkCore --version 6.*
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.*
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.*
dotnet ef dbcontext scaffold "Server=.;Database=$DBName;Integrated Security=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --force
cd ..

# create the DAL project
dotnet new classlib -n $DALName -o $DALName --framework net6.0
cd $DALName
dotnet add reference ../$EntityName/$EntityName.csproj
cd ..

# create the BackEnd project
dotnet new webapi -n $BackEndName -o $BackEndName --framework net6.0
cd $BackEndName
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version *
dotnet add package Swashbuckle.AspNetCore --version 6.*
dotnet add package Serilog.aspnetcore --version *
dotnet add package Serilog.Sinks.Console --version *
dotnet add package Serilog.Sinks.File --version *
dotnet add reference ../$DALName/$DALName.csproj
dotnet add reference ../$EntityName/$EntityName.csproj
cd ..

# create the FrontEnd project
dotnet new mvc -n $FrontEndName -o $FrontEndName --framework net6.0
cd $FrontEndName
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.*
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 6.*
dotnet add package Serilog.aspnetcore --version *
dotnet add package Serilog.Sinks.Console --version *
dotnet add package Serilog.Sinks.File --version *
cd ..

# create the solution file
dotnet new sln -n $solutionName
dotnet sln $solutionName.sln add ./$FrontEndName/$FrontEndName.csproj ./$EntityName/$EntityName.csproj ./$DALName/$DALName.csproj ./$BackEndName/$BackEndName.csproj

# open the solution
Invoke-Item "$basePath\$solutionName\$solutionName.sln"