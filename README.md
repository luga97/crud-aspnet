# .NET Server Readme

This is a .NET server application that serves a CRUD and also work as the backend for an mobile app .

## Prerequisites

Before running the server, make sure you have the following:

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- Access to the database and the necessary permissions to connect to it.

## Configuration

To configure the server, follow these steps:

1. Open the `appconfig.json` file in the server project.
2. Locate the `DatabaseSettings` section.
3. Update the `ConnectionString` value with the appropriate connection string to connect to your database.

```json
// appconfig.json
{
  "DatabaseSettings": {
    "ConnectionString": "your_connection_string"
  }
}
```

Replace `"your_connection_string"` with the actual connection string for your database.

## Applying Migrations

Before running the server, apply the necessary migrations to set up the database schema.

1. Open a terminal or command prompt.
2. Navigate to the server project directory.
3. Run the following command to apply the migrations:

```shell
dotnet ef database update
```

This will execute the migrations and create the required tables in the database.

## Running the Server

To run the server, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the server project directory.
3. Run the following command to start the server:

```shell
dotnet run
```

The server will start running and listen for incoming requests.

## Configuring LAN Access

To allow the mobile app to access the server over the LAN, follow these steps:

1. Make sure the server machine has its port opened in the firewall. You may need to configure your firewall settings to allow incoming connections on the specified port.
2. Obtain the IP address of the server machine. You can use the command `ipconfig` on Windows or `ifconfig` on Linux/macOS to find the IP address.
3. Update the `baseUrl` variable in the mobile app's `./src/common/constants.ts` file with the server machine's IP address.

```typescript
// ./src/common/constants.ts
export const baseUrl = "http://server_ip_address"
```

Replace `'http://server_ip_address'` with the actual IP address of the server machine.

## Deployment

For production deployment, it is recommended to use a more secure setup, such as configuring HTTPS and a reverse proxy like IIS. You can refer to the documentation for your specific deployment scenario.
