FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/BIBF.Test.Web.Host/BIBF.Test.Web.Host.csproj", "src/BIBF.Test.Web.Host/"]
COPY ["src/BIBF.Test.Web.Core/BIBF.Test.Web.Core.csproj", "src/BIBF.Test.Web.Core/"]
COPY ["src/BIBF.Test.Application/BIBF.Test.Application.csproj", "src/BIBF.Test.Application/"]
COPY ["src/BIBF.Test.Core/BIBF.Test.Core.csproj", "src/BIBF.Test.Core/"]
COPY ["src/BIBF.Test.EntityFrameworkCore/BIBF.Test.EntityFrameworkCore.csproj", "src/BIBF.Test.EntityFrameworkCore/"]
WORKDIR "/src/src/BIBF.Test.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/BIBF.Test.Web.Host", "src/BIBF.Test.Web.Host"]
COPY ["src/BIBF.Test.Web.Core", "src/BIBF.Test.Web.Core"]
COPY ["src/BIBF.Test.Application", "src/BIBF.Test.Application"]
COPY ["src/BIBF.Test.Core", "src/BIBF.Test.Core"]
COPY ["src/BIBF.Test.EntityFrameworkCore", "src/BIBF.Test.EntityFrameworkCore"]
WORKDIR "/src/src/BIBF.Test.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "BIBF.Test.Web.Host.dll"]
