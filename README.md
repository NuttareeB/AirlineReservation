# Airline Reservation System

## Overview:

I built this program from scratch with no experience on WCF and WPF before. It took me almost 2 weeks to finish it.

The program serves the basic functions of airline flight booking system, but it is easy to extend more as I separate the client/server. On the server side, I have separated the Data Provider and Business logic layer, so the code is clean and can be easy to understand. The responsibility of each layer is obviously separated.

The WCF service is self-host not IIS so it is easy to run by itself without setting IIS needed. 

### Technology Overview:

The program is developed in WPF and WCF using .NET Framework. The database for this project is Microsoft SQL server. The database backup file is also included in this directory. When you want to use the application, please restore it to your server. You might also need to change the connection string in the App.config file in the AirlineReservationLib project.

## Features:

-    User login/logout or guest user access (which is considered as a user role)
-    See all flight details. Each row can expand to see the detail of each flight such as plane type and flight capacity. 
    -    You can also see the seat info for the flight here. Occupied seats will be shown as X and the available seat will be shown as O.
    -    You can also make a booking here from selected flight.
-    Add new flight (Only available when you login as an administrator)
-    Make a booking and select the seat from the seat availability page. You can either choose seat from the chart or manually put it to the textbox.
    -    Both user and admin have a permission to make a booking as admin can also make a booking for their user.
    -    When the booking is made, if a user is already in the database, I will get that user data and book with that user. Otherwise, I will create a new user and create the booking with a new user account. (The created user has their first name as a username and the role is normal user)

## Test User:

**Username:** Intel
**Password:** Intel
**Role:** Admin

**Username:** Bob
**Password:** <leave it blank>
**Role:** Admin, User

**Username:** Anita
**Password:** <leave it blank>
**Role:** User

## Running the application:

After building the solution, you should be able to run the project from Visual Studio. (I am using Visual Studio 2019)
1. Select the AirlineReservationApp on the top menu bar in order to run the project.
2. Click Start next to the project selection.

You should see the application as shown below:
 
![Login page](/ApplicationImages/LoginPage.png)

## In progress:

-    The UI design to make it more user friendly.
-    The validation including the UI validation.
-    Using WPF user control for the sake of reusability.
-    This application can improve the role-based access control as we should separate user, user group, user role, role permission, permission. As I want to keep this program simple, I have combined all these to one table.
-    We can enhance the booking feature to track the people who make a particular booking (Admin, User, etc.).
-    We can create store procedure for database to manage multiple queries at the same time and more complex tasks.

For simplicity, username will be First name. I also set the FirstName column to not allow duplicate value. When we use username, we can create this constraint to username instead. However, we can have email as a customer’s username.

Password is Nullable in the database for the booking that is booked by an administrator and guest user.

I am using hash function (Sha256 with salt) to keep password for the customer.

## Self-host:

Basically, you do not need to run host for this program. However, I have created an example of a self-host project exporting FlightService, which is included in this solution.

### Running self-host:

1. Run the wcf service.

2. Run the below command in the solution directory:
AirlineReservationHost\bin\Debug\AirlineReservationHost.exe

You can also test it by using the url:
http://localhost:8000/AirlineReservation/FlightService

After this step: you should be able to see:
 
 ![Host page](/ApplicationImages/HostPage.png)

