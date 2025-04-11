FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ARG PUBLISH_PATH="./Todo.Web/publish"
WORKDIR /app
EXPOSE 80
EXPOSE 5001

COPY $PUBLISH_PATH .

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "Todo.Web.dll"]