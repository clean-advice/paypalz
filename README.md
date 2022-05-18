# PayPalz


## Getting Started

Requires Visual Studio 2022 with .net 6

To run the application, ensure you have set up the startup projects as follows:
![image](https://user-images.githubusercontent.com/105444450/168965177-518be6f6-6a04-4e7d-9c33-a1224d23ea45.png)

## Solution Architecture

![Clean Architecture](https://i0.wp.com/jasontaylor.dev/wp-content/uploads/2020/01/Figure-01-2.png?w=531&ssl=1)

The approach taken is one of building the application using a mixture of several paradigms.

* DDD is used to model the domain entities and value objects with guards in their constructors and encapsulated by aggregates.
* Use cases (from Clean Architecture) are used to orchestrate inter-aggregate business logic in a comprehensible and a targeted way.
* An approach borrowed from CQRS allows for the efficient use of ORM for CRUD operations from “command” type use cases, while EntityFramework queries (defined in the specifications) are used with “query” type use cases requiring access to several related aggregates.
* Domain events are fired from the aggregates and handled by handlers wired in using MediatR.

This results in architecture and design that is:

- Independent of frameworks it does not require the existence of some tool or framework.
- Testable – Core has no dependencies on anything external, so writing automated tests is much easier.
- Independent of UI logic because this logic is kept out of the UI so it is easy to change to another technology – Angular, Vue, even Blazor.
- Independent of the database and data-access concerns because they are cleanly separated so moving from SQL Server to CosmosDB or another DB is more trivial than in cases where these concerns are not separated.
- Independent of anything external, Core is completely isolated from the outside – the difference between a system that will last 3 years, and one that will last 20 years

> The progressive Tax Calculation is based on the following: [Progressive Tax](https://www.educba.com/progressive-tax-examples/)
