# CodeGen

Logiciel Windows permettant de générer des templates de projet en fonction de la technologie utilisée (NodeJS, Arduino, Java, Android, ...) et de paramètres variables selon les projets.

***

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

* Le fichier **README.md** contenant des variables entourées *de < et de >* pour les identifier. Ces variables représentent les paramètres qui seront demandés à l'utilisateur lors de la création du projet.
* Le dossier **docs** contenant toutes les informations pour coder dans ce langage sans devoir apprendre de nouveau cette technologie. Pour certain template *(Android Studio, C#, Java par exemple)* la génération du projet entier nécessite l'utilisation d'un IDE. Le dossier **docs** et le fichier **README.md** seront donc le seul contenu du template.
* Le reste des fichiers et dossiers dépendent du type de template dont il s'agit. Chaque cas sera développé dans le fichier **README.md** pour une utilisation et une compréhension rapide.

***

## Aide

### Le fichier ressources **tokens.json**

Un fichier json dans le dossier */res* est ignoré pour cause de confidentialité. Pour pouvoir tout de même tester et modifier l'application, il faut faire ceci :

1. Créer le fichier **tokens.json** dans le dossier */res*
2. Insérer le code ci-dessous dans le fichier :

    {
        "tokens": {
            "api.github.com": <tokenGitHub>
        },
        "key": <key>
    }

### Comment mettre à l'échelle l'application

Dans le menu démarrer (ou dans le dossier de l'application), faire un clic droit sur l'application puis accéder aux propriétés. Ensuite aller dans l'onglet *"Compatibilé"* puis cliquer sur *"Modifier les paramètres PPP élevés"*. Enfin, cocher la case *"Remplacer le comportement de mise à l’échelle PPP élevée"* et définir la mise à l'échelle pour *"Application"*. Terminer en cliquant sur *"Appliquer"* puis *"Ok"*.

## Infos

### Licence

Copyright ©  2020