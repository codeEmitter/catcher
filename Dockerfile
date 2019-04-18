FROM microsoft/dotnet:sdk AS build
WORKDIR /src
COPY src/ .
RUN dotnet restore && dotnet publish -c Release -o artifact

FROM microsoft/dotnet:aspnetcore-runtime AS release
WORKDIR /src
COPY --from=build /src/artifact .
COPY docker-entrypoint.sh /usr/local/bin/
RUN chmod 755 /usr/local/bin/docker-entrypoint.sh
ENTRYPOINT ["docker-entrypoint.sh"]