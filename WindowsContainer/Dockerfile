FROM microsoft/dotnet:2.2-sdk-nanoserver-sac2016 AS publish
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o /publish


FROM microsoft/iis AS runner
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'Continue'; $verbosePreference='Continue';"]

ADD https://download.visualstudio.microsoft.com/download/pr/a46ea5ce-a13f-47ff-8728-46cb92eb7ae3/1834ef35031f8ab84312bcc0eceb12af/dotnet-hosting-2.2.3-win.exe "C:/setup/dotnet-hosting.exe"

RUN start-process -Filepath "C:/setup/dotnet-hosting.exe" -ArgumentList @('/install', '/quiet', '/norestart') -Wait 

WORKDIR /inetpub/wwwroot/dotnetWeb

## Create Web Site and Web Application
RUN Import-Module WebAdministration; \
    Remove-Website -Name 'Default Web Site'; \
    New-WebAppPool -Name 'dotnetWeb'; \
    Set-ItemProperty IIS:\AppPools\dotnetWeb -Name managedRuntimeVersion -Value ''; \
    Set-ItemProperty IIS:\AppPools\dotnetWeb -Name enable32BitAppOnWin64 -Value 0; \
    Set-ItemProperty IIS:\AppPools\dotnetWeb -Name processModel.identityType -Value Service; \
    New-Website -Name 'dotnetWeb' \
                -Port 80 -PhysicalPath 'C:\inetpub\wwwroot\dotnetWeb' \
                -ApplicationPool 'dotnetWeb' -force
COPY --from=publish /publish .
EXPOSE 80