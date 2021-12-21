# Friendship Web App Codes

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This project is made with Net Core and Angular.
	
## Technologies
Project is created with: (Net Core 6 - Angular 13 version will be publish)
* Angular CLI: 12.2.13
* Net Core: 5.0.13
* Nodejs : 16.13.1
* Mssql Management Studio : 15.0
	
## Setup 
To run this project's,first create your free Cloudinary account from [here](https://cloudinary.com/console/c-409de846ac7abee975808cc197afe7/)
Than add your informations in appsettings.json file:

```
  "CloudinarySettings": {
    "CloudName": "xxxxx",
    "ApiKey" : "xxxxx",
    "ApiSecret" : "xxxxx"
  },
```

To run this project's frontend side, install it locally using:

```
$ cd client
$ npm install
$ ng serve
```

To run this project's backend side, firstly install dotnet sdk 5 and than open Api folder with your ide's terminal:
Mssql Database will be create automaticaly...
```
$ dotnet run

```
