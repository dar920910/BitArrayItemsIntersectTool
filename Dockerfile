FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/BitArrayItemsIntersectTool

COPY BitArrayItemsIntersection.Library/ BitArrayItemsIntersection.Library/
COPY BitArrayItemsIntersection.Testing/ BitArrayItemsIntersection.Testing/
COPY BitArrayItemsIntersection.App.CLI/ BitArrayItemsIntersection.App.CLI/
COPY BitArrayItemsIntersection.App.Web/ BitArrayItemsIntersection.App.Web/

RUN dotnet publish BitArrayItemsIntersection.App.CLI/BitArrayItemsIntersection.App.CLI.csproj --output "/usr/local/bin/BitArrayItemsIntersectTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained
RUN dotnet publish BitArrayItemsIntersection.App.Web/BitArrayItemsIntersection.App.Web.csproj --output "/usr/local/bin/BitArrayItemsIntersectTool/Web/" --configuration "Release" --use-current-runtime --no-self-contained

ENV ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_URLS="https://+;http://+" \
    ASPNETCORE_HTTPS_PORT=5002 \
    ASPNETCORE_Kestrel__Certificates__Default__Path=/https/BitArrayItemsIntersection.pfx \
    ASPNETCORE_Kestrel__Certificates__Default__Password="BitArray_Items_Intersection_2023!"

WORKDIR /usr/local/bin/BitArrayItemsIntersectTool