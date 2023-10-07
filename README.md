# RoofStacks.Auth-Guard

## Project Description

The `RoofStacks.Auth-Guard` project is designed to secure Employee and Company APIs using IdentityServer4. Each API has its own `client_id` and `client_secret` information, providing secure access.

## Features

- Authentication and authorization using OAuth 2.0 and OpenID Connect protocols through IdentityServer4.
- Predefined ApiResource, ApiScope, and Client information through seed data.
- Secure access to Employee and Company APIs.

## Installation Instructions

1. **ConnectionString Settings**: To set up the `DbContext` in the project, make sure your ConnectionString points to your local environment.
   
2. **Database Update**: Run the following command via the command line or Package Manager Console: update-database
  
This command will update the database and create the seed data.

## Usage
1. **Projects Ports**:
   RoofStacks.Auth-Guard -> port https://localhost:5002
   RoofStacks.CompanyAPI -> port https://localhost:5004
   RoofStacks.EmployeeAPI -> port https://localhost:5006
   
3. **Obtaining AccessToken**: You can get an AccessToken using the CURL command below.

    ```bash
    curl --location 'https://localhost:5002/connect/token' \
    --header 'Content-Type: application/x-www-form-urlencoded' \
    --data-urlencode 'client_id={}' \
    --data-urlencode 'client_secret={}' \
    --data-urlencode 'grant_type=client_credentials'
    ```

    Replace `{}` with the corresponding `client_id` and `client_secret` information.

4. **API Access**: You can access the APIs within the scope of the permissions granted by the obtained AccessToken.
