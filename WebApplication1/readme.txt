-The Sample app is MVC Net-Core 6 so if the machine doesn't have it, please install .Net Core 6

I only put the list of 3 customers (fed from DB) - Part1 in you 'Panther exercise'
you can click the image or the link and it would take you to the detail, which was part 2 in the 'Panther Exercise'
I didn't do part 3 because it's like part 2 and I spent 8 hours coding today and running out of daylight :)

--------------------------------------------------------------------
- I created the EF classes and added EF migration to the solution
- so all you have to do is to create a DB locally with one simple step:
  - open Package Manager console ( VSStudio > View > Other Windows > Package Manager Console)
  - type/run cmd: update-database
  //that should create you local DB
  //now you should have Panther8854 database on you local SQL server
  
  //when you run the app, I put a line in Program.cs -> DbInitializer.Seed(app);
  // which should put some data in the DB, like 3 customers.. pretty basic

- the app should run, as is but if it doesn't I am sending it with mocked repos as well.
  In  CustomerController constructor, I am injecting dependencies using interfaces:
ICustomerRepository and IOrderRepository, so CustomController has no idea about the implementation DB or a Mock, so you can use either
- in Program.cs 
find lines:
 9: // Mocked data to run app without Entity Framwork + DB support => they are commented out, so if you something is wrong with EF/DB just uncomment those lines, and comment the ones in the next step:
10: //builder.Services.AddScoped<ICustomerRepository, MockCustomerRepository>(); 
11: //builder.Services.AddScoped<IOrderRepository, MockOrderRepository>();
12: //builder.Services.AddScoped<IOrderDetailedTaskRepository, MockOrderDetailedTaskRepository>();

as you can see I am registering these interfaces with mocks, so that the app can run without db support

To run with DB support you will need to comment out mocked registrations on line 10:11,12 and fine the following lines 15,16,17 then uncomment them
14:// Comment 3 lines above and uncomment 3 below to run with DB support
15: builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(); 
16  builder.Services.AddScoped<IOrderRepository, OrderRepository>();
17: builder.Services.AddScoped<IOrderDetailedTaskRepository, OrderDetailedTaskRepository>();

the app should display 3 customers (I didn't do a query for Active as I only populated 3 in the DB/Mock for the lack of time)
clicking on one of them link or image, should take you to the customer order, which was the second part of the assignment
I didn't do the 3rd on the UI because it seemed like repetition of the 2nd part, though I set it up in the DB, Repo, Model
I hooked up basic routing, so the page loads with a list of customers, but you have to hit back on the browse or hit home to get back to the list..


