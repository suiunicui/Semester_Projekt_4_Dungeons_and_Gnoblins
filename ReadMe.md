# Dungeons and Gnoblin Installeringsinstruktioner
Følgende elementer er nødvendigt at installere inden spillet køres.  

##### Prerequisite:
 - Windows
 - Docker
 - Docker SQL Image

### Instruktioner

  - Installer Docker via nedstående link og følge dockers installeringsguide.  
  - Følg linket til microsofts SQL docker image og følg instruktionerne for  
  at initialiser docker til at køre en SQL database lokalt på din enhed.  
  - Start docker containeren.
  - Åben Backend applikationen appsetting.json og ændre dit password i connection string
  så det matcher passworded til dit docker image.
  - Kør backend applikationen på din enhed.
  - Åben nu Dungeons and Gnoblins på din enhed og spil spillet.

Download Docker: https://www.docker.com/get-started/  
Microsoft SQL Docker Image: https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&preserve-view=true&pivots=cs1-powershell
