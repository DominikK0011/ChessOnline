FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["ChessOnline.Client/ChessOnline.Client.csproj", "ChessOnline.Client/"]
COPY ["ChessOnline.API/ChessOnline.API.csproj", "ChessOnline.API/"]

RUN dotnet restore "ChessOnline.Client/ChessOnline.Client.csproj"
COPY . .
WORKDIR "/src/ChessOnline.Client"
RUN dotnet build "ChessOnline.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChessOnline.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

COPY --from=publish /app/publish/wwwroot .

COPY ChessOnline.Client/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
