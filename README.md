# Quora - Abandoned Planet

Quora is a free open source video game used to teach some basic game development using the Unity Engine, the colaborators of this project are basically students of the Universidad Autónoma de Occidente UAO in Cali Colombia.

## Story Plot

Is the future year 3145 A.D the Homo Sapiens has been vanished from five planets (Earth, Moon, Mars and Europa) in the solar system for unknown reasons, Only Earth 2 and it´s moon Quora it is known as the latest Homo Sapiens Colonies. Earth 2 has lost contact with any Homo Sapiens in Quora (4 years ago),  Quora is at 2 years travel distance from Earth 2 a first mission was sent to the planet looking to solve the mistery but the contact was lost. Earth 2 has send one last mission with no return ticket of one man the Astronaut, Physicist and Soldier Commander Alexandre Bob Martinez Wang.

## Level 1 - The landing

Commander Alexandre is entering on his capsule to the Quora atmosphere to land on the planet, after his landing he will try to reach the nearest known Homo Sapiens base to discover the solitude and dangers of Quora.

## Developers Guide

This guide is to download the repository and colaborate with the game, there are some rules and steps that must be followed before you can commit a change.

### Setup

For Windows users:

1. Download git https://git-scm.com/downloads
2. Create a public github account
3. Go to https://github.com/gislersoft/quoragame and fork the repository.
4. Create a Unity Project in any local folder. Example: c:\\projects\quora
5. Enable External option in Unity → **Preferences** → **Packages** → **Repository** (only if Unity ver < 4.5)
6. Switch to Visible Meta Files in **Edit** → **Project Settings** → **Editor** → **Version Control Mode**
7. Switch to Force Text in **Edit** → **Project Settings** → **Editor** → **Asset Serialization Mode**
8. Save Scene and Project from File menu.
9. Open git bash (From step 1).
10. ``` cd c:\\projects\quora ```
11. ``` git init ```
12. ``` git remote add origin https://github.com/gislersoft/quoragame.git ```
13. ``` git remote add fork https://github.com/<YOUR GIT HUB USER HERE>/quoragame.git ```
14. ``` git pull origin master ```

### Useful commands

Here are some useful GIT commands with their respective explanation in spanish.

- ```git status``` // Verificar los cambios
- ```git remote -v``` // Verificar los apuntadores a los repositorios
- ```git add <file>``` // Agregar el archivo a el cambio
- ```git add .``` // Agregar todos los archivos (Usar con cautela)
- ```git rm <file>``` // Marcar como borrado en el cambio
- ```rm <file>``` //Borrar el archivo del sistema de archivos
- ```git commit -m "bla bla bla"``` // Crear el commit con un mensaje
- ```git push <apuntador> <branch>``` // Enviar los cambios al repositorio y branch apuntados
- ```git pull <apuntador> <branch>``` // Traer los cambios del repositorio y branch apuntados
- ```git remote add <apuntador> <url del repo>``` //Crea un nuevo apuntador para el repositorio dado
- ```git remote remove <apuntador>``` // Borrar el apuntador del repositorio
