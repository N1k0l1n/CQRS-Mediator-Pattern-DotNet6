![CQRS-Diagram-e1598922649719](https://github.com/N1k0l1n/Cqrs/assets/97979235/ead0d403-79d0-4383-9d23-44a438d2fd97)
CQRS and the Mediator Pattern
The MediatR library was built to facilitate two primary software architecture patterns: CQRS and the Mediator pattern. Whilst similar, let’s spend a moment understanding the principles behind each pattern.

CQRS
CQRS stands for “Command Query Responsibility Segregation”. As the acronym suggests, it’s all about splitting the responsibility of commands (saves) and queries (reads) into different models.

If we think about the commonly used CRUD pattern (Create-Read-Update-Delete), usually we have the user interface interacting with a datastore responsible for all four operations. CQRS would instead have us split these operations into two models, one for the queries (aka “R”), and another for the commands (aka “CUD”).

The following image illustrates how this works:

#CQRS Diagram#

As we can see, the Application simply separates the query and command models. The CQRS pattern makes no formal requirements of how this separation occurs. It could be as simple as a separate class in the same application (as we’ll see shortly with MediatR), all the way up to separate physical applications on different servers. That decision would be based on factors such as scaling requirements and infrastructure, so we won’t go into that decision path today.

The key point being is that to create a CQRS system, we just need to split the reads from the writes.

What problem is this trying to solve?
Well, a common reason is often when we design a system, we start with the data storage. We perform database normalization, add primary and foreign keys to enforce referential integrity, add indexes, and generally ensure the “write system” is optimized. This is a common setup for a relational database such as SQL Server or MySQL. Other times, we think about the read use cases first, then try and add that into a database, worrying less about duplication or other relational DB concerns (often “document databases” are used for these patterns).

Neither approach is wrong. But the issue is that it’s a constant balancing act between reads and writes, and eventually one side will “win out”. All further development means both sides need to be analyzed and often one is compromised.

CQRS allows us to “break free” from these considerations, and give each system the equal design and consideration it deserves, without worrying about the impact of the other system. This has tremendous benefits on both performance and agility, especially if separate teams are working on these systems.
