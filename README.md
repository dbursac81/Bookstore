# Bookstore Management System

## Overview
Simple Bookstore Web API built with .NET and EF Core.

## Features
- CRUD for Books
- GET returns Title, Author Names, Genre Names, Average Review Rating
- GET top-10 by average rating (raw SQL)
- JWT authentication with roles: Read, ReadWrite
- Scheduled import simulating 100k books/hour (BackgroundService)
- Swagger
- Unit test examples

## Requirements
- .NET 8.0 SDK
- MS SQL 

## Setup
1. Configure `appsettings.Development.json` with DB connection and JWT settings (if needed)
2. Run EF Core migrations on database with 'update-database' command using Package Manager Console