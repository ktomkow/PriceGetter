FROM localhost:9997/dotnet3p1sdk-node14
WORKDIR /App
COPY . ./
WORKDIR ./src/PriceGetter.Web
RUN dotnet publish -c Release -o out
