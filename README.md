# Pharmacy OneSource Assessment
Just a few notes about my submission:
* In some places the documentation provides information regarding my reasons for making a descision. I wouldn't ordinarily include those thoughts, but this being an assessment, I thought it might be helpful.
* The product data lives on a 3rd-party database. Even though the example input file is present in its entirety, the product information in it is only used to form a database query--the product data used by the rest of the application is supplied by the server. It's a free host, so it can be a touch slow sometimes.
  * The query is based on price, since it is unique within the example data. In a real-world scenario, the unique product code would be used, but I wanted to avoid altering the input data. (This is also the primary key in the db)
  * The database is also provisioned for basic customer data, and associated classes are provided for using it, but the example application just creates generic customers and addresses, due to the time constraint.
* Also filed under "If I had more time:" I would have liked to revisit certain parts of the classes making up the controller. Mainly, I would like to reduce, if not eliminate, the use of `Product` as the formal parameter and return types. Instead, I would prefer to use the unique ProductCode string. (It isn't actually a string, but changing ProductCode from int to string would also be on the todo list.) It wouldn't really affect anything now, but in the maximizing the degree to which components are decoupled could aid overall extensibility.
* Regarding code and style conventions, I tried to stick with those specified by Microsoft--even the one's I don't care for like using `var` whenever possible. Still, I'm sure my predominantly Java background shows up in a few places.
* I am relatively new to Visual Studio, so just in case something is amiss with dependencies:
  * The project references JSON.Net and Entity Framework.
  * I included the input, JSON (tax rate data) and json schema files as project resources, but they can be found in the /Resources folder if need be.
  * The database login and password are stored in the connection string (Not best practice, I know, but it's a generated pw for a free 5MB MS SQL db, so I decided to take the chance)
  * I had plenty of time to read up on this stuff while waiting for several GB of VS updates to download at Oshkosh internet speeds, so I'm not anticipating any issues.
* In hindsight, I suspect that I may have over-engineered this solution...
