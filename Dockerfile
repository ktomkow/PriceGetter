FROM 172.17.0.1:9997/dotnet3p1sdk-node14 as build
WORKDIR /app
COPY . ./
WORKDIR ./src/PriceGetter.Web
RUN dotnet publish -c Debug -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
COPY --from=build /app/src/PriceGetter.Web/out /app
WORKDIR /app
CMD ["dotnet","PriceGetter.Web.dll"]
