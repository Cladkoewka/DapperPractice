# Dapper Practice Project

## Description

This project is a learning application where I practiced using Dapper—a simple and efficient ORM for .NET. In this project, I implemented a RESTful API for managing products, including operations for creating and retrieving data.

## Technologies

- **.NET 8**: Used for developing the server-side of the application.
- **Dapper**: A lightweight ORM for database interaction.
- **Posgresql**: The database used for storing product data.

## Endpoints

1. **POST /api/products**
   - Creates a new product.
   - Expects a `Product` object in the request body.

2. **GET /api/products/{id}**
   - Retrieves a product by the specified ID.
   - Returns a 404 status if the product is not found.
