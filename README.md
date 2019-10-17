# Freelancer
Freelancer accounting application for TeamSystem

Here are summarized the most relevant design decision taken for the development phase:

1) Placed Project and AllocationTime under the same Service class since within the scope of the assignment they are strictly related.
2) Used dependency injection for the database context as suggested by Marcello in order to better conform with SOLID principles.
3) Delegated exception handling to the the controller class.
4) Similarly to exception handling to which is also related, logging it is done at controller level. This way just the controller has this responsibility and other components are not coupled to the ILogger interface 
5) I limited the call methods within the same service class in order not to create coupling inside the very class and to take advantage of LINQ's deferred execution.
6) I use HTTP 404 - NotFound when the result given by the controller for that resource is empty or null. I could've used HTTP 204 - NoContent as well for some specific case but given the time I preferredded to keep everything under the KISS guidelines. 
7) I didn't use async controller methods because within the scope of the assignment there are not long-runnign or I/O intensive operations.
8) I kept the controllers lightweight and delegate all the business logic to the services.
9) I created integrity constrains for the entities at application level and not at database level because I was lacking time, indeed they must be done at DB level as well in order to prevent other applications not to respect them.
10) I return anonymous type from the controller instead of a named type since the data are sent to any client in JSON format

