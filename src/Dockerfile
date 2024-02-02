# Stage 0 (prepare image base)
FROM hapvidacorp.azurecr.io/hap/golden-image/dotnet-6-aspnet AS base

# Stage 1 (copy && restore layers from app)
FROM hapvidacorp.azurecr.io/hap/golden-image/dotnet-6-sdk AS build

ARG NUGET_USER
ARG NUGET_KEY
ARG SONAR_TOKEN
ARG SONAR_URL

WORKDIR /src
COPY *.sln ./
COPY *.config ./
COPY *.sonarqube ./.sonarqube/
COPY *.runsettings ./
COPY Hapvida.Digital.Beneficiary.Admin.Api/Hapvida.Digital.Beneficiary.Admin.Api.csproj/ Hapvida.Digital.Beneficiary.Admin.Api/
COPY Hapvida.Digital.Beneficiary.Admin.Domain/Hapvida.Digital.Beneficiary.Admin.Domain.csproj/ Hapvida.Digital.Beneficiary.Admin.Domain/
COPY Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries/Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries.csproj/ Hapvida.Digital.Beneficiary.Admin.Infra.Data.Queries/
COPY Hapvida.Digital.Beneficiary.Admin.UnitTests/Hapvida.Digital.Beneficiary.Admin.UnitTests.csproj/ Hapvida.Digital.Beneficiary.Admin.UnitTests/

RUN rm nuget.config && mv nuget-production.config nuget.config
RUN sed -i 's,___NUGET_USER___,'$NUGET_USER',g' nuget.config
RUN sed -i 's,___NUGET_KEY___,'$NUGET_KEY',g' nuget.config
RUN dotnet tool restore && dotnet restore

COPY . .

# Stage 2 (run unit tests && code coverage)
LABEL test=true
RUN dotnet tool install dotnet-reportgenerator-globaltool  --tool-path /tools && \ 
    dotnet test --configuration Release  --nologo --results-directory /testresults --logger "trx;LogFileName=test_results.xml" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=/testresults/coverage/ /p:Include="[*.Domain?]*"; exit 0 && \
    /tools/reportgenerator "-reports:/testresults/coverage/coverage.cobertura.xml" "-targetdir:/testresults/coverage/reports" "-reporttypes:HTMLInline;HTMLChart" 

# Stage 3 (build app)
WORKDIR /src/Hapvida.Digital.Beneficiary.Admin.Api
RUN dotnet sonarscanner begin  \
    /k:"Hapvida.Digital.Beneficiary.Admin.Api"  \ 
    /d:sonar.host.url=${SONAR_URL} \ 
    /d:sonar.login=${SONAR_TOKEN} \
    /d:sonar.scm.disabled=true && \
    dotnet build --configuration Release --nologo --no-restore && \
    dotnet sonarscanner end	/d:sonar.login=${SONAR_TOKEN}

# Stage 4 (publish release version)
FROM build AS publish
WORKDIR /src/Hapvida.Digital.Beneficiary.Admin.Api
RUN dotnet publish --configuration Release --nologo --no-build -o /app/publish

# Stage 5 (generate final imagem)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hapvida.Digital.Beneficiary.Admin.Api.dll"]