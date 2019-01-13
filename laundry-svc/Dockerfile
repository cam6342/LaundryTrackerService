FROM microsoft/dotnet:3.0-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53430
EXPOSE 44377

FROM microsoft/dotnet:3.0-sdk AS build
WORKDIR /src
COPY ["laundry-svc/laundry-svc.csproj", "laundry-svc/"]
RUN dotnet restore "laundry-svc/laundry-svc.csproj"
COPY . .
WORKDIR "/src/laundry-svc"
RUN dotnet build "laundry-svc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "laundry-svc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "laundry-svc.dll"]