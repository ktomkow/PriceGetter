FROM 192.168.0.133:9997/dotnet3p1sdk-node14:latest as build
WORKDIR /app
COPY . ./

WORKDIR ./src/PriceGetter.Web
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
COPY --from=build /app/src/PriceGetter.Web/out /app
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT="Development"
CMD ["dotnet","PriceGetter.Web.dll"]
