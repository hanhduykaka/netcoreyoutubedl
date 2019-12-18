FROM mcr.microsoft.com/dotnet/core/sdk:2.2
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet DangTai.dll