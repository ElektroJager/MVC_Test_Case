# MVC_Test_Case
ASP.net MVC 5 and MSSQL.

Register & Login pages with ASP.net and MSSQL.

## How to establish database connection.

Use restore database to add the database to your own server using BlueprintCaseDB.bak file.

![image](https://user-images.githubusercontent.com/48105864/134813064-3e39eaad-4d97-4c0a-bb91-b4e141a3fa5c.png)

Change the connection string in the Web.config file with the connection string of your own database.

```
  <connectionStrings>
    <add name="UserDBContext" connectionString="${your-connection-string}";Initial Catalog=BlueprintCaseDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

## Login

Go to login page and enter your user information.

![image](https://user-images.githubusercontent.com/48105864/134769066-2f6c00b3-8a80-4f71-bb0a-43a9ba4f7be5.png)

If you have not registered before, go to the registration page to register.

## Register

Enter your user information
- Name
- Surname
- Password

![image](https://user-images.githubusercontent.com/48105864/134769724-060857b5-11f2-498d-80e6-c64a821aad1f.png)

You cannot view the homepage without logging in.

![image](https://user-images.githubusercontent.com/48105864/134769031-866a9dd6-f317-4815-9f56-36f0ce44e3f3.png)

## Home Page

You will be redirected to the home page after successfully logging in. 

![image](https://user-images.githubusercontent.com/48105864/134769279-f23dc658-9b57-4fd2-a6d0-1af7766b87a7.png)
