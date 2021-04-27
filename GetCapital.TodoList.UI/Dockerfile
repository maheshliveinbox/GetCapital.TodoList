#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_14.x | bash - && \
    apt-get install -y build-essential nodejs
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_14.x | bash - && \
    apt-get install -y build-essential nodejs
WORKDIR /src
COPY ["GetCapital.TodoList.UI/GetCapital.TodoList.UI.csproj", "GetCapital.TodoList.UI/"]
COPY ["GetCapital.TodoList.Application/GetCapital.TodoList.Application.csproj", "GetCapital.TodoList.Application/"]
RUN dotnet restore "GetCapital.TodoList.UI/GetCapital.TodoList.UI.csproj"
COPY . .
WORKDIR "/src/GetCapital.TodoList.UI/clientapp"
RUN npm install
WORKDIR "/src/GetCapital.TodoList.UI"
RUN dotnet build "GetCapital.TodoList.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GetCapital.TodoList.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GetCapital.TodoList.UI.dll"]