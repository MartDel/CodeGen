# CodeGen
Logiciel Windows permettant de générer des templates de projet en fonction de la technologie utilisée (NodeJS, Arduino, Java, Android, ...) et de paramètre variable selon les projets.

## Liste des templates disponibles

Les templates déjà disponibles sont :

* Arduino *(en cours de dev)*

## Liste des templates prochainement disponibles

Les templates qui seront bientôt développés sont :

* NodeJS
* Java
* Android Studio (Java)
* Logiciel C#
* Service C#
* ...

## Contenu des templates

Les templates sont composés de plusieurs parties :

* Le fichier **README.md** contenant des variables entourées *de < et de >* pour les indentifiées. Ces variables représentent les paramètres qui seront demandés à l'utilisateur lors de la création du template.
* Le dossier **docs** contenant toutes les informations pour coder dans ce langage sans devoir apprendre de nouveau cette technologie. Pour certain template *(Android Studio, C#, Java par exemple)* la génération du projet entier nécesite l'utilisation d'un IDE. Le dossier **docs** et le fichier **README.md** seront donc le seul contenu du template.
* Le reste des fichiers et dossiers dépendent de type de template dont il s'agit. Chaque cas sera développé dans le fichier **README.md** pour une utilisation et une compréhension rapide.

