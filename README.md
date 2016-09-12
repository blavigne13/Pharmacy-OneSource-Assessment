# Pharmacy OneSource Assessment
Just a few notes about my submission:
* In some places the documentation provides information regarding my reasons for making a descision. I wouldn't ordinarily include those thoughts, but this being an assessment, I thought it might be helpful.
* The product data lives on a 3rd-party database. Even though the example input file is present in its entirety, the product information in it is only used to form a database query--the product data used by the rest of the application is supplied by the server. It's a free host, so it can be a touch slow sometimes. Also, the query is based on price, since it is unique within the example data. In a real-world scenario, the unique product code would be used, but I wanted to avoid altering the input data. (This is also the primary key in the db)
* The database is also provisioned for basic customer data, and associated classes are provided for using it, but the example application just creates generic customers and addresses, due to the time constraint.
* Also under filed under "If I had more time:" I would have liked to revisit certain parts of the classes making up the controller. Mainly, I would like to reduce, if not eliminate, the use of `Product` as the formal parameter and return types. Instead, I would prefer to use the unique ProductCode string. (It isn't actually a string, but changing ProductCode from int to string would also be on the todo list.) It wouldn't really affect anything now, but in the maximizing the degree to which components are decoupled could aid overall extensibility.
