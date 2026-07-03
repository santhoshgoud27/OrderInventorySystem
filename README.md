# Order Processing & Inventory Management API

A RESTful API built with **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server** 
for managing products and processing customer orders with real-time stock validation.

## Features
- Product management (Create, Read)
- Order placement with stock validation
- Automatic stock reduction on order creation
- Order status tracking (Pending → Processing → Shipped → Delivered)
- Atomic database operations — order creation and stock reduction succeed or fail together

## Tech Stack
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core 10 (Code-First Migrations)
- SQL Server
- C#
- Git

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/products | Get all products |
| GET | /api/products/{id} | Get product by ID |
| POST | /api/products | Create a new product |
| GET | /api/orders | Get all orders |
| POST | /api/orders | Place a new order (with stock validation) |
| PUT | /api/orders/{id}/status | Update order status |
| GET | /api/orders/by-product/{productId} | Get orders for a specific product |

## Business Logic
When an order is placed:
1. Checks if product exists → returns 404 if not found
2. Checks if sufficient stock available → returns 400 if insufficient
3. Creates order with locked-in unit price (prevents price change issues)
4. Atomically reduces product stock
5. Returns created order with 200 OK

## Setup
1. Clone the repository
2. Update connection string in `appsettings.json`
3. Run `Update-Database` in Package Manager Console
4. Run the application
5. Test endpoints using Postman
