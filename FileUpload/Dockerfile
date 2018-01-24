FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY FileUpload/FileUpload.csproj FileUpload/
RUN dotnet restore
COPY . .
WORKDIR /src/FileUpload
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
RUN apt-get update 
RUN apt-get install libgdiplus
RUN cd /usr/lib
RUN ln -s libgdiplus.so gdiplus.dll
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FileUpload.dll"]
