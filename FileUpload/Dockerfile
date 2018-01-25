FROM microsoft/aspnetcore:2.0
WORKDIR /app
EXPOSE 80
RUN ls
COPY  publish  .
COPY sources.list /etc/apt/sources.list
RUN apt-get update && apt-get -y install libgdiplus && apt-get -y install fonts-wqy-zenhei && apt-get clean &&  fc-cache -fv
ENTRYPOINT ["dotnet", "FileUpload.dll"]
