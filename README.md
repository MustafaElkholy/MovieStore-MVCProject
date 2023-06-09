# CineVerse Movie Store 
Video Demo: https://youtu.be/ahHnm3qPyGM

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Installation](#installation)
4. [Usage](#usage)
   - [Running the Application](#running-the-application)
   - [Navigating the Application](#navigating-the-application)
5. [Technologies Used](#technologies-used)
6. [Contributing](#contributing)

## Introduction

Welcome to CineVerse, an advanced ASP.NET Core 7 application that brings the magic of movies right to your fingertips. Cineverse offers an immersive user experience that allows users to browse, search, and buy their favorite movies or by category. Whether you're a movie enthusiast or just looking for a fun movie night, Cineverse has got you covered.

## Features

Cineverse offers the following key features:

1. **Browse Movies**: Users can search for movies based on various criteria such as title, genre, actors, and release year. The application provides advanced filtering and sorting options for easy navigation through the movie catalog.
2. **Movie Details**: Each movie has a dedicated page that showcases detailed information, including the plot, cast and crew, ratings, reviews, and trailers.
3. **Search by Name and Genre**: Looking for a specific movie? No worries! Cineverse offers a powerful search feature that lets users quickly find their desired movies by title, genre, actor, director, or any other relevant keyword.
4. **Actors and Directors Details**: Users can view the profile of each director or actor and their movies.
5. **User Authentication**: Cineverse incorporates a secure user authentication system, allowing users to create an account, log in, and manage their profiles.
6. **Shopping Cart**: Users can add movies to their shopping cart, review the cart contents, and proceed to the checkout process to purchase the selected movies.
7. **Order History**: Users can view their order history and track the status of their purchases.
6. **Movies Ratings**: Users can see the review movies they have watched, helping others make informed decisions.
7. **Responsive Design:** Cineverse is designed to be responsive and mobile-friendly, ensuring a seamless user experience across various devices and screen sizes.
8. **Admin Panel:** The application comes with a robust admin panel that allows administrators to manage movies, user accounts, reviews, and other crucial aspects of the platform.

## Getting Started

### Prerequisites

1. Clone the Cineverse repository from the GitHub repository.
2. Ensure you have the latest version of ASP.NET Core 7 and the required dependencies installed.
3. Set up a SQL Server database and update the connection string in the application settings.
4. Seed the database with initial movie data using migrations or database scripts.
5. Run the application locally for testing and debugging.

Before running Cineverse, make sure you have the following prerequisites installed on your machine:

1. [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
2. [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the Cineverse repository from GitHub:

   ```
   git clone https://github.com/your-username/cineverse.git
   ```

2. Open a terminal or command prompt and navigate to the project directory:

   ```
   cd cineverse
   ```

3. Restore the project dependencies by running the following command:

   ```
   dotnet restore
   ```

4. Configure the database connection string in the `appsettings.json` file to point to your SQL Server instance:

   ```json
   "ConnectionStrings": {
    "constr": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieStore;Integrated Security=True;TrustServerCertificate=True"
   }
   ```

5. Apply the database migrations to create the required tables:

   ```
   dotnet ef database update
   ```

## Usage

### Running the Application

To run Cineverse locally, follow these

 steps:

1. Open a terminal or command prompt and navigate to the project directory.

2. Execute the following command:

   ```
   dotnet run
   ```

3. Once the application is running, open a web browser and visit `http://localhost:5000` to access the Cineverse application.

### Navigating the Application

Upon accessing the Cineverse application, users will be greeted with a homepage displaying popular movies. From there, they can navigate through the different sections of the application, such as browsing movies, searching, and managing their profile.

Cineverse provides an intuitive user interface with clear navigation menus and search options. Users can explore movie details, add movies to their shopping cart, review and rate movies, and complete their purchases through the checkout process. The application also offers personalized movie recommendations based on user's preferences.

## Technologies Used

Cineverse is built using the following technologies and frameworks:

- ASP.NET Core 7
- C# programming language
- Entity Framework Core for database management
- HTML, CSS, and JavaScript for frontend development
- SQL Server for data storage
- Bootstrap for responsive design
- FontAwsome

## Contributing

We welcome contributions to Cineverse! If you'd like to contribute, please contact me at https://www.linkedin.com/in/mustafaelkholy74/

Get ready for an unforgettable movie journey with Cineverse! Happy movie browsing and watching!
