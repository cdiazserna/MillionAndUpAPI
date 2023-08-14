# API
This is the document where I will explain in detail the construction of the API and I will explain topics about: 

1.  [Tools and Technologies used](#tools-and-Technologies-used)
2. Repository and environment configuration to execute the API.
3.	Entity Relationship Diagram
4.	Software Architecture
5.	Solution Structure
6.	Layer Responsibilities
7.	API Security
8.	Unit Tests
9.	Performance

### Property API

This API is in charge of performing all the transactions related to the Real Estate company's property management. Different services were implemented for this administration, such as the creation of a new property in the database, the obtaining of different properties either with all their information or by defined filters, the updating of information and even the elimination of properties (CRUD). In addition to this, the functionality of uploading images for each property was also implemented.

Transversal to this main implementation of the API, security was also applied to the application, in order to maintain and persist the integrity of our data.
Next, I will detail each of the sections mentioned at the beginning of this document for clarity:

###**1.** ### **Tools and Technologies used**

| Tools               |
| ------------------- |
| Visual Studio 2022  |
| SQL Server v19      |
| GitHub              |

| Technologies   |
| -------------- |
| .Net 6         |
| C# 10          |
| EF Core 7.0.7  |
| JWT 6.0.16     |
| NUnit 3.13.3   |

### **2.	Setting up the environment to run the API**

Basically I built the API locally, creating a repository from GitHub for code management.

**First:** Clone the repository in your VS https://github.com/cdiazserna/MillionAndUpAPI.git. Once cloned, you will find the solution with a series of projects that later I will explain what each of them is about.

**Second:** This API was created with the ORM Entity Framework Core under the Code First model, therefore, you must change the parameters "Server", "User ID" and "Password" of the connection string to allow the local connection to your SQL Server. This connection string is located in the `MillionAndUp.WebAPI/appsettings.json/appsettings.Development.json project`.

**Third:** Run the EF update-database command from the Package Manger Console to run the existing migrations and create your local database.

**Fourth:** Make sure that only the MillionAndUp.WebAPI project is enabled by right clicking on the solution and clicking on `Configure Startup Projects...`.

**Fifth:** We have finished! Execute the API and you will be able to see from the browser the documentation through Swagger to facilitate the understanding of each one of the Endpoints and the execution of them.

### **3. Entity Relationship Diagram**

Some fields that all tables will have in common are added: Id, InsertedDate, UpdatedDate, in order to store each of the records with their respective transaction dates, either because a new record was created or an existing record was modified. Additionally, the Users table was created for everything related to API Security.

You can download the diagram with the next URL:
https://github.com/cdiazserna/MillionAndUpAPI/blob/MillionAndUpAPI/MillionAndUp.WebAPI/FileDownloaded/DER.png

### **4. The Software Architecture**

I worked and built this API under the Repository architecture, also called repository structural pattern. I considered this way of developing the API because it allows me to separate data access responsibilities. With this architecture, each of the components are independent and are not aware of the existence of other components. Additionally, it provides greater security in different access layers until reaching the data layer, which is responsible for connecting to the database and perform each of the transactions issued from the API request. Hand in hand with this pattern, we have another behavior pattern called Unit Of Work, which allows me to centralize the connections to the Repository layer, keeping track of everything that happens during the transaction and will revert the transaction if there are exceptions or errors.

### **5. The Structure of the solution**

### My Multi Word Header
Knowing the implemented architecture, I will explain the structure that this solution has. Let's see the following image:
https://github.com/cdiazserna/MillionAndUpAPI/blob/MillionAndUpAPI/MillionAndUp.WebAPI/FileDownloaded/StructureSolution.png

As you can see, within the solution we have 6 projects, each one created for a single purpose and interconnected with each other. We have the Data layer, Domain, Helpers, Models, NUnitTests and WebAPI, thus generating a clean solution, with highly decoupled code and making use of good development practices.

### **6. Layer Responsibilities**

**MillionAndUp.WebAPI:** This is the presentation layer, where we will find the controllers with their respective EndPoints. There we also have the class program.cs, which is in charge of starting the application and the initial configuration of the web API. In the program we encapsulate resources such as the registry, the dependency injections, etc. Additionally we also have the appsettings.json. This layer has direct communication with the business layer.

**MillionAndUp.Domain:** This is the business layer, where we will find the interfaces, repositories and work units. The Interfaces folder is in charge of exposing the signature of the methods that will be implemented in the other classes, allowing code decoupling. The UnitOfWork folder is in charge of hosting all the logic of the Web API and it is the one who has direct communication with the Repositories folder, which is in charge of the database transactions. Here I implemented a very generic way to perform the CRUD in any entity. In the code you can see the GenericUnitOfWork class, which works with a restrictive generic to be only one class (entity), in order to have the 5 main transactions available.

**MillionAndUp.Data:** This is the data layer, which creates the database context to be used as a dependency in the business layer. It is the one that hosts all the migrations. It has direct communication with the business layer and with the models layer, since it requires them to map the entities and fields in the database.

**MillionAndUp.Models:** This is the layer of entities and models. It hosts the main entities that are created as DBSet in the database, in addition to different models such as Payloads or DTO for the representation of some data needed in the requests and responses. It has direct communication with the data layer.

**MillionAndUp.Helpers:** This is a utility layer that allows me to store classes and methods that can be reusable in any part of the solution, avoiding code redundancy.

**MillionAndUp.NUnitTest:** Finally, this is the layer of unit tests with the NUnit framework. There we can find several tests performed to the business layer, in order to evaluate the API logic and give a minimum coverage of 80% to this layer.

### **7. API Security**

I worked the API security with the JWT standard, to define a secure and compact way to transmit information between two entities in JSON format. The authentication and authorization of each of the endpoints was implemented so that they are only accessible with a token that is generated from the `Security/getToken` endpoint.

The way you can authenticate in the Web API is as follows:

**First:** You create the user with the User Post using any email and using the following encrypted password: `HksfVyavGSjdtWtCByBdmazmIJ5eh+P/PVEeBeTwLNDAcSdLmdjH9BwKa/3RJnvF`

**Second:** Go to Post endpoint Security/getToken and there you must enter your login or user which is the email with which you created the user and the following decrypted password: `no3vXZw3Da.\_2Qe=4p/&R7348Cp12aY`

**Third:** Click on Execute and you will get the new token.

**Fourth:** In the top right side part of Swagger, you must click on the Authorize button, paste the token and Authorize, with this you will have access to any endpoint of the API.

### **8. Unit Tests**

The unit tests were performed according to the requirements with the NUnit framework. The architecture used and the creation of dependencies from the DI container of the progra.cs, greatly facilitate the creation of unit tests. 

The code coverage tested was the Business layer, the UnitOfWork folder, since this is where all the logic of the web API is centered. Both happy and unhappy paths were evaluated for each of the existing methods.

### **9. Performance**

The performance of the application goes hand in hand, initially, with the architecture used, since responsibilities are separated, giving value to the first SOLID principle: Single Responsibility Principle.

Additionally, different dependencies are registered in the Dependency Injection container of program.cs, in order to make use of this design pattern to improve the performance of the application, using the Inversion of Control paradigm, which goes hand in hand with the fifth SOLID principle: Principle of Dependency Inversion.

To filter the properties with some fields, I created a Stored Procedure, this in order to have some logic directly in my SQL and not create so much code inside the business layer. Thius is the Store Procedure that I have created:

```sql
CREATE OR ALTER PROCEDURE getPropertiesByFilter
						@CodeInternal varchar(max) ,
						@Address varchar(max) ,
						@MinPrice decimal(18,2),
						@MaxPrice decimal(18,2)
					AS
					BEGIN 

						SELECT p.[Name] ,
								p.[Address],
								p.[Price],
								p.[CodeInternal],
								p.[Year],
								O.[Name] Owner,
								O.Address OwnerAddress,
								t.[Name] PropertyTracesName,
								t.Value,
								t.Tax
						FROM [dbo].[Properties] P
								LEFT JOIN [dbo].[Owners] O ON P.OwnerId = O.Id
								LEFT JOIN [dbo].[PropertyTraces] t ON p.id = t.PropertyId

						WHERE (isnull(@CodeInternal,'') = '' OR [CodeInternal] = @CodeInternal)
							AND (isnull(@Address,'') = '' OR P.[Address] LIKE '%'+@Address+'%')
							AND (@MinPrice = 0 OR P.[Price] >=  @MinPrice)
							AND (@MaxPrice = 0 OR P.[Price] <= @MaxPrice)
					END		 
```

Finally, I made use of Generics to receive any class you want and manage the basic CRUD of an entity (add, get all, get by ID, update and delete). With the generics I improve the performance of the Web API since I avoid Boxing and Unboxing.
