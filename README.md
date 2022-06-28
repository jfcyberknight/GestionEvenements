# Gestion d'evenements

Requis Windows
 - Microsoft Visual Studio 2022
 - Docker Desktop

Demarrer le projet en localhost
 - Dans un terminal
	- Naviguer jusqu'au folder "Backend" de la solution
 - Executer les commandes
	- docker-compose up
		- Un database MariaDb sera cree
		- Un utilitaire de visualisation de database sera disposible "Adminer"
	- dotnet ef database update (roule la migration) 
 - Demarrer la solution
	- Le backend et le frontend vont demarrer en meme temps, il ne reste plus qu'a utiliser l'application
 
