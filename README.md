![alt tag](https://nsa39.casimages.com/img/2018/12/18/18121811411058877.png)
## The project
RobotMan is a project developed by the first year students of MASTER. It consists of creating a bot for the fashionable discussion software: Discord. It is developed in C # .NET. 
## API used
* [DEVELOPER PORTAL](https://discordapp.com/developers/applications/) - For Discord
* [Football-Data.org](https://www.football-data.org/) - For data
## Package NuGet
* [Discord.NET](https://www.nuget.org/packages/Discord.Net/)
* [Discord.Net.Commands](https://www.nuget.org/packages/Discord.Net.Commands/)
* [Discord.Net.WebSocket](https://www.nuget.org/packages/Discord.Net.WebSocket/)
* [Libsodium](https://www.nuget.org/packages/dpm-libsodium-net/)
## Project Architecture
* Classes : Contains all classes to use objects in projects.  
* Modules : Contains all modules, ie the features and commands of the bot.  
* Services : Contains all the useful services at the back of the bot. 
## Commands
### AudioModule.cs
``` 
### Bot join the tchat
!join
```
``` 
### Bot leave the tchat
!leave
```
``` 
### Bot plays music
!play
```
### FootballModule.cs
``` 
### Indicates championships that can be set to parameters
!infofoot
```
``` 
### Get the list of games already played
!matchplayed
```
``` 
### Get the top 10 scorers of each championship
!scorers
```
``` 
### Get matches of the day
!matchday
```
### GamePSRModule.cs
``` 
### Play, compare bot value and user value
!start-psr
```
### HangmanModule.cs
``` 
### See all the commands to play Hangman Game
!info-hangman  
```
``` 
### Initialize the game
!start  
```
``` 
### Give the number of letters to find
!indice 
```
``` 
### Give the number of luck remaining
!chance
```
``` 
### Give the letters find
!find
```
``` 
### Compare letter with letters in mystery word
### Give the results
!letter
```
``` 
### The user agrees to lose and wants to know the correct answer
!forfeit
```
### HelpModule.cs
``` 
### Show all available commands according to a module
!help 
```
## Authors
* Hakim MAKHTOUR
* Aude PONS
