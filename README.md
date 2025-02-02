# OTTApp

OTTApp is a C# API that provides authentication and access to a list of Movies and TV Series. It includes endpoints to generate a Bearer token and retrieve available content.

## Features
- Secure authentication with JWT tokens.
- RESTful API for managing movies and TV series.
- Token-based authorization for protected routes.

## Technologies Used
- C# (.NET Core)
- ASP.NET Web API
- JWT Authentication
- Postman (for API testing)

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/antosujesh/OTT_App.git


## API Endpoints

2. Generate Access Token
Endpoint:
POST /api/ott/login
![image](https://github.com/user-attachments/assets/3c8da8aa-d6a0-455b-8ea2-9cb6c778a67a)
Response Example:

   ```json
    {
      "accessToken": "your-jwt-token"
    }


## 2. Get Movies & TV Series List
Endpoint:
GET /api/ott/getList
![image](https://github.com/user-attachments/assets/60a7447a-a7b0-4336-a46f-d4ac1c3d47df)

Authorization: Bearer your-jwt-token

Response Example:
   ```json
      [
        {
          "id": 1,
          "type": "Movies",
          "name": "The Flash",
          "rating": "8",
          "createdDate": "20/11/2024"
        },
        {
          "id": 2,
          "type": "Movies",
          "name": "Man of Steel",
          "rating": "7",
          "createdDate": "20/11/2024"
        }
      ]
