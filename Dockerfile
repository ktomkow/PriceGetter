FROM 192.168.0.133:9997/dotnet3p1sdk-node14:latest as build
WORKDIR /app
COPY . ./

RUN dotnet publish PriceGetter.sln -c Release -o out

FROM 192.168.0.133:9997/dotnet3p1runtime-node14:latest
COPY --from=build /app/out /app
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT="Development"
CMD ["dotnet","PriceGetter.Web.dll"]

