FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/BooleanArrayExploreTool

COPY BooleanArrayExploring.Library/ BooleanArrayExploring.Library/
COPY BooleanArrayExploring.Testing/ BooleanArrayExploring.Testing/
COPY BooleanArrayExploring.App.CLI/ BooleanArrayExploring.App.CLI/
COPY BooleanArrayExploring.App.Web/ BooleanArrayExploring.App.Web/

RUN dotnet publish BooleanArrayExploring.App.CLI/BooleanArrayExploring.App.CLI.csproj --output "/usr/local/bin/BooleanArrayExploreTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained
RUN dotnet publish BooleanArrayExploring.App.Web/BooleanArrayExploring.App.Web.csproj --output "/usr/local/bin/BooleanArrayExploreTool/Web/" --configuration "Release" --use-current-runtime --no-self-contained

ENV ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_URLS="https://+;http://+" \
    ASPNETCORE_HTTPS_PORT=5002 \
    ASPNETCORE_Kestrel__Certificates__Default__Path=/https/BooleanArrayExploring.pfx \
    ASPNETCORE_Kestrel__Certificates__Default__Password="Boolean_Array_Exploring_2023!"

WORKDIR /usr/local/bin/BooleanArrayExploreTool