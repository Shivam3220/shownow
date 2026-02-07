# ShopNow E-Commerce Application

## Overview
This is a full-stack e-commerce application consisting of both frontend and backend components.

## Backend Setup

### Prerequisites
- Docker installed
- .NET Core 8 installed

### Installation Steps
1. Navigate to `src/services/Shopnow/ShopNow.Api`
2. Start SQL Server in Docker:
    ```bash
    docker compose up -d
    ```
3. Start the backend server:
    ```bash
    dotnet run
    ```
4. Access the Swagger documentation at `https://localhost:7084/swagger/index.html`

## Frontend Setup

### Prerequisites
- Node.js installed
- npm installed

### Installation Steps
1. Navigate to `src/clients`
2. Install dependencies:
    ```bash
    npm i
    ```
3. Start the development server:
    ```bash
    npm run start
    ```
4. Access the application at `http://localhost:3000/`

## Technology Stack
- **Backend**: .NET Core 8
- **Database**: SQL Server (Docker)
- **Frontend**: React with TypeScript
This application is ecomerse app.
consts of front and backend.

TO start a backend end make sure you have docker installed and have a dotent core 8 intstalled
navigate to the src/services/Shopnow/ShopNow.Api
and run docker compose up -d to run the sql server in docker
start a backend server powered by the dotnet core 8 in the same folder run command dotnet run. it will start you backend server and you can have navigate to browser at https://localhost:7084/swagger/index.html to access swagger.

how to run frontend make sure you have node and npm installed in your system
Frontend is the react application powder by the typescript
navigate to the src/clients
run npm i to installed the dependency
and then run npm run start to start the fe.
navigate to the http://localhost:3000/ to aceess the app and run through the app