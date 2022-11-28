# Business changes
The business needs has changed! 

Now we need to make sure our application can handle the SampleMessageV2 instead of SampleMessage.

The only thing changed here is the added XML field "Description" - However this is enough that we need to refactor our application.

## Validation

- The field 'description' should have a length between 20 and 200.

## Sample Message

With the new 'description' field we need to add this to our code. Update the models with the new property and remember to add the changes to the converter aswell

## Migrations

Since we added a new property to our SampleMessage and therefore our database model, we need to update this using migrations.

[Check out the Getting started on what migrations are](GettingStarted.md#migrations))

## Add new tests

Whenever we add new functionality to our code we want to make sure we have tests that cover this case.

Add some tests that cover the new description property.

