functionality

    place orders at store locations
    add a new customer
    search customers by name
    display details of an order
    display all order history of a store location
    display all order history of a customer
    client-side validation (in HTML/JS)
    exception handling
    persistent data (no prices, customers, order history, store locations, etc. hardcoded in C# or JS)
    logging where appropriate
    (optional: order history can be sorted by earliest, latest, cheapest, most expensive, etc)
    (optional: get a suggested order for a customer based on his order history)
    (optional: display statistics based on order history)
    (optional: asynchronous network & file I/O)

design

    use EF Core (either database-first approach or code-first approach)
    use a SQL DB in third normal form (3NF)
    Use the most restricted access possible. (i.e. don't use public fields, instead use protected fields (etc) or public properties with private fields)
    define and use at least one interface
    (optional: Deploy to publicly available Azure App Service website)

core / domain and business logic

    is .NET class library
    contains all business logic
    contains domain classes (customer, order, store, product, etc.)
    documentation with 
     XML comments on all public types and members

customer

    has first name, last name, etc.
    (optional: has a default store location to order from)

order details

    has a store location
    has a customer
    has order completion time
    can contain multiple types and quantities of product in the same order
    rejects orders with unreasonably high product quantities (or more than is available)
    (optional: some additional business rules, like special deals, bundles)

location

    has an inventory
    inventory decreases when orders are accepted
    rejects orders that cannot be fulfilled with remaining inventory
    (optional: for a product, more than one inventory item decrements when ordering that product)

product

    has a description, price, quantity available, etc.

user interface

    HTML, CSS, and JavaScript pages that utilize a ASP.NET Core WebAPI
    separate request processing and presentation concerns with MVC pattern
    customize the styling using stylesheets
    keep CodeNamesLikeThis out of the visible UI.

data access

    contained in separate class library project
    use Dependency Injection for database context
    contains EF Core DbContext and entity classes
    contains data access logic but no business logic
    use Repository Pattern for Separation of Concerns

test

    at least 20 test methods
    focus on unit testing business logic
