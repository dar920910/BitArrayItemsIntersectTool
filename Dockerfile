FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/BitArrayItemsIntersectTool

COPY BitArrayItemsIntersection.Library/ BitArrayItemsIntersection.Library/
COPY BitArrayItemsIntersection.Testing/ BitArrayItemsIntersection.Testing/
COPY BitArrayItemsIntersection.App.CLI/ BitArrayItemsIntersection.App.CLI/
COPY BitArrayItemsIntersection.App.Web/ BitArrayItemsIntersection.App.Web/

RUN dotnet publish BitArrayItemsIntersection.App.CLI/BitArrayItemsIntersection.App.CLI.csproj --output "/usr/local/bin/BitArrayItemsIntersectTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained
RUN dotnet publish BitArrayItemsIntersection.App.Web/BitArrayItemsIntersection.App.Web.csproj --output "/usr/local/bin/BitArrayItemsIntersectTool/Web/" --configuration "Release" --use-current-runtime --no-self-contained

WORKDIR /usr/local/bin/BitArrayItemsIntersectTool
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://*:5001
EXPOSE 5001