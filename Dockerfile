ARG REPO=mcr.microsoft.com/dotnet/core/aspnet
FROM $REPO:3.1-alpine3.12 AS base

# # Add dependencies for disabling invariant mode (set in base image)
RUN apk add --no-cache icu-libs 

# #Runs tzdata
# RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

# Install .NET Core SDK
RUN dotnet_sdk_version=3.1.403 \
    && wget -O dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$dotnet_sdk_version/dotnet-sdk-$dotnet_sdk_version-linux-musl-x64.tar.gz \
    && dotnet_sha512='3f3d9e96553718f1c8dd8774afb9a892ece64be4f4ec98a50fb4c0f18d358ee739032189ebc38809464ae69aa435e529c65b4f907a59d603e042f649b055a2ae' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -C /usr/share/dotnet -oxzf dotnet.tar.gz ./packs ./sdk ./templates ./LICENSE.txt ./ThirdPartyNotices.txt \
    && rm dotnet.tar.gz \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY . .

RUN dotnet restore "Api/Api.csproj"

FROM base AS publish
RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish

ARG REPO=mcr.microsoft.com/dotnet/core/runtime-deps
FROM $REPO:3.1-alpine3.12

ENV \
    # Unset the value from the base image
    ASPNETCORE_URLS=http://+:80 \
    # Disable the invariant mode (set in base image)
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    LC_ALL=en_US.UTF-8 \
    LANG=en_US.UTF-8 \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip \
    # PowerShell telemetry for docker image usage
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetCoreSDK-Alpine-3.10 \
    #Set TimeZone variable to S�o Paulo
    TZ=America/Sao_Paulo 
# Add dependencies for disabling invariant mode (set in base image)
RUN apk add --no-cache icu-libs \
    && apk add --no-cache tzdata 

#Runs tzdata
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]