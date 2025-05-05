# 🛒 Basket API – ASP.NET Core Clean Architecture

This project implements a **Basket (Shopping Cart)** feature using **ASP.NET Core Web API**, following **Clean Architecture principles**. It uses an **in-memory dictionary** to store user basket data and supports basic cart operations like add, remove, view, and checkout.

---

## 📁 Project Structure

- **Basket.Domain** – Core entities like `BasketItem`
- **Basket.Application** – Interfaces and use case logic
- **Basket.Infrastructure** – In-memory implementation of services
- **Basket.API** – Web API layer with endpoints
- **Basket.Tests** – Unit tests using xUnit
