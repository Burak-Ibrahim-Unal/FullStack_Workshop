# Cognizant FullStack Coding Challenge Web App Codes 2022

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
This project is made with Net Core and React.
	
## Technologies
Project is created with:
* React: 17.0.2
* Net Core: 6.0.2 (Net Core Sdk 6)
* Nodejs : 16.14.0
* Sqlite
* Visual Studio Code

## FrontEnd Technologies
  Project is created with:
  *  "@testing-library/jest-dom": "^5.16.2",
  *  "@testing-library/react": "^12.1.3",
  *  "@testing-library/user-event": "^13.5.0",
  *  "@types/jest": "^27.4.0",
  *  "@types/node": "^16.11.25",
  *  "@types/react": "^17.0.39",
  *  "@types/react-calendar": "^3.4.5",
  *  "@types/react-dom": "^17.0.11",
  *  "@types/react-router-dom": "^5.3.2",
  *  "axios": "^0.26.0",
  *  "mobx": "^6.4.1",
  *  "mobx-react-lite": "^3.3.0",
  *  "react": "^17.0.2",
  *  "react-calendar": "^3.7.0",
  *  "react-dom": "^17.0.2",
  *  "react-router-dom": "^5.3.0",
  *  "react-scripts": "5.0.0",
  *  "semantic-ui-css": "^2.4.1",
  *  "semantic-ui-react": "^2.1.2",
  *  "typescript": "^4.5.5",
  *  "uuid": "^8.3.2",
  *  "web-vitals": "^2.1.4"



## BackEnd Technologies
  Project is created with:
  *  CQRS - MediatR Pattern
  *  AutoMapper
  *  FluentValidation
  *  Microsoft.DependencyInjection
  *  Microsoft.EntityFrameworkCore
  *  Microsoft.EntityFrameworkCore.Relational
  *  Microsoft.EntityFrameworkCore.Sqlite
  *  Microsoft.EntityFrameworkCore.Tools
  *  Microsoft.EntityFrameworkCore.Design
  *  Microsoft.Extensions.Configuration.Abstractions
  *  Newtonsoft.Json

To run this project's frontend side, install it locally using:

```
$ cd client
$ npm install
$ npm start
```

To run this project's backend side, firstly install dotnet sdk 6 and than open Api folder with your ide's terminal:
Mssql Database will be create automaticaly...
```
$ dotnet run

```


## Next Version's Upgrades 
1- Cloudinary will be implemented

To run this project's,first create your free Cloudinary account from [here](https://cloudinary.com/console/c-409de846ac7abee975808cc197afe7/)
Than add your informations in appsettings.json file:

```
  "CloudinarySettings": {
    "CloudName": "xxxxx",
    "ApiKey" : "xxxxx",
    "ApiSecret" : "xxxxx"
  },
```

2- Mssql Version will be done