FROM microsoft/dotnet-framework:4.6.2-sdk AS Build

COPY ./install_docker.ps1 c:/
CMD Set-ExecutionPolicy Bypass

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
WORKDIR C:/
RUN ./install_docker.ps1

RUN git clone https://704eae07c4c95a7dce081472b09394c1020cd2ef:x-ouath-basic@github.com/Ferrandoseh/VuelingSchool.git

WORKDIR C:/VuelingSchool/
RUN nuget restore ./VuelingSchool.sln

RUN ./Build.ps1

ENTRYPOINT ["./VuelingSchool.Presentation.Console/bin/Release/VuelingSchool.Presentation.Console.exe"]
