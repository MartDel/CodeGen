# CodeGen

Logiciel Windows permettant de générer des templates de projet en fonction de la technologie utilisée (NodeJS, Arduino, Java, Android, ...) et de paramètres variables selon les projets.

***

## Liste des templates disponibles

Les templates déjà disponibles sont :

* Arduino
* Web - HTML/CSS/JS/PHP/MySQL (en cours de developpement)

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

## Télécharger et installer le logiciel

Lien du **téléchargement** : [CodeGen_setup.exe](https://github.com/MartDel/CodeGen/raw/master/Setup/CodeGen_setup.exe)

L'installation est guidée par le setup. **Suivez les instructions** et le logiciel sera installé sur votre machine.

***

## Aide

### Le fichier ressources **tokens.json**

Un fichier json dans le dossier */res* est ignoré pour cause de confidentialité. Pour pouvoir tout de même tester et modifier l'application, il faut faire ceci :

1. Créer le fichier **tokens.json** dans le dossier */res*;
2. Insérer le code ci-dessous dans le fichier :


    {
        "tokens": {
            "api.github.com": <tokenGitHub>
        },
        "key": <key>
    }

3. Se rendre dans les *paramètre GitHub*, puis dans l'onglet *Developer settings*;
4. Cliquer sur *Personal access tokens*, puis *Generate new token*;
5. Ecrire dans le champ *Note*, "**CodeGen**". Cocher **repo** puis cliquer sur *Generate token*;
6. Copier le token généré et l'insérer dans le fichier *json* à la place de *<tokenGitHub>*;
7. Enfin, remplacer *<key>* par un mot de passe compliqué de **8 charactères précisement**. Le mieux étant de le générer automatiquement avec un gestionnaire de mot de passe;
8. Pour finir, dans l'IDE Visual Studio, importer le fichier *token.json* dans les ressources du projet.

### Comment mettre à l'échelle l'application

Dans le menu démarrer (ou dans le dossier de l'application), faire un clic droit sur l'application puis accéder aux propriétés. Ensuite aller dans l'onglet *"Compatibilité"* puis cliquer sur *"Modifier les paramètres PPP élevés"*. Enfin, cocher la case *"Remplacer le comportement de mise à l’échelle PPP élevée"* et définir la mise à l'échelle pour *"Application"*. Terminer en cliquant sur *"Appliquer"* puis *"Ok"*.

## Infos

### Créateur

Nom : **Martin Delebecque**
Pseudo GitHub : **MartDel**
Age à la publication de la v1.0 : **17ans**

### Licence

Copyright © 2020