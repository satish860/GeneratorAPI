FROM microsoft/dotnet:2.1.2-aspnetcore-runtime

WORKDIR /app
COPY /bin/Debug/netcoreapp2.1/publish .

ENTRYPOINT ["dotnet","MakerApp.dll"]

