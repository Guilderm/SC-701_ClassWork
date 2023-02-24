# sets the names and directory
$solutionName = "MidtermExam"
$EntityName = "Entities"
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
dotnet new webapi -n $BackEndName -o $BackEndName --no-https --framework net6.0
cd $BackEndName
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version *
dotnet Add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.* #For some reason it is not getting installed
#dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 6.* #looks like I do not need this pakage
dotnet add package Swashbuckle.AspNetCore --version 6.*
dotnet add package Serilog.aspnetcore --version *
dotnet add package Serilog.Sinks.Console --version *
dotnet add package Serilog.Sinks.File --version *
dotnet add reference ../$DALName/$DALName.csproj
dotnet add reference ../$EntityName/$EntityName.csproj
dotnet new controller -n [ControllerName] -api --no-restore
cd ..

# create the FrontEnd project
dotnet new mvc -n $FrontEndName -o $FrontEndName --no-https --framework net6.0
cd $FrontEndName
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.*
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 6.*
dotnet add package Serilog.aspnetcore --version *
dotnet add package Serilog.Sinks.Console --version *
dotnet add package Serilog.Sinks.File --version *
cd ..

# remove the Class1.cs file from each project
Remove-Item -Path "$basePath\$solutionName\$EntityName\Class1.cs" -Force
Remove-Item -Path "$basePath\$solutionName\$DALName\Class1.cs" -Force

#Remove WeatherForecast
rm "$basePath\$solutionName\$BackEndName\Controllers\WeatherForecastController.cs"
rm "$basePath\$solutionName\$BackEndName\WeatherForecast.cs"

# add folders to each project
mkdir $BackEndName\controller

# create the solution file
dotnet new sln -n $solutionName
dotnet sln $solutionName.sln add `
    ./$EntityName/$EntityName.csproj `
    ./$DALName/$DALName.csproj `
    ./$BackEndName/$BackEndName.csproj `
    ./$FrontEndName/$FrontEndName.csproj

#Clean and build the solution
dotnet clean
dotnet build

# open the solution and start the projects
Invoke-Item "$basePath\$solutionName\$solutionName.sln"
#dotnet run --project ./$BackEndName ./$FrontEndName


################################################################
################################################################
##once the models are created in the Frontend				  ##
##use the fallowing to create the controlers and views		  ##
################################################################
################################################################

# sets the names and directory
$solutionName = "MidtermExam"
$BackEndName = "BackEnd"
$FrontEndName = "FrontEnd"
$basePath = "$($env:USERPROFILE)\Documents\Repositories"

$EntityClassName = "Factura"
$outDir = "Views/" + $EntityClassName
#$model = "${FrontEndName}.Models.${$EntityClassName}ViewModel" #could not get this working
$model = "Frontend.Models.FacturaViewModel"

#checks to see if "dotnet-aspnet-codegenerator" is install before tring to do so.
if (!(dotnet tool list -g | Select-String -Pattern "dotnet-aspnet-codegenerator")) {
    dotnet tool install --global dotnet-aspnet-codegenerator --version *
}

<#
#creates the backend Controller
cd "$basePath\$solutionName\$BackEndName"
dotnet aspnet-codegenerator controller -name $EntityClassName -actions -api -outDir Controllers

#creates the Frontend Controller
cd "$basePath\$solutionName\$FrontEndName"
dotnet aspnet-codegenerator controller -name $EntityClassName -actions -outDir Controllers

#Create the views
dotnet aspnet-codegenerator view Create Create --model $model -outDir $outDir
dotnet aspnet-codegenerator view Edit Edit --model $model -outDir $outDir
dotnet aspnet-codegenerator view Delete Delete --model $model -outDir $outDir
dotnet aspnet-codegenerator view Details Details --model $model -outDir $outDir
dotnet aspnet-codegenerator view Index List --model $model -outDir $outDir
#>