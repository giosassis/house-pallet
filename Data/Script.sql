SELECT "Id", "Name", "Description", "Price", "ImageUrl", "CreatedAt", "UpdatedAt", "Material", "Color", "Size", "Stock", "CategoryId"
FROM "Products";

SELECT "Id", "CustomerId", "Street", "City", "State", "PostalCode", "Country"
FROM "DeliveryAddresses";

SELECT "Id", "CustomerId", "TotalPrice", "OrderDate", "DeliveryAddressId", "PaymentMethodId", "OrderItemId"
FROM "Orders";

SELECT "Id", "Name"
FROM "Categories";

SELECT "Id", "Name", "Description", "Price", "ImageUrl", "CreatedAt", "UpdatedAt", "Material", "Color", "Size", "Stock", "CategoryId"
FROM "Products";

SELECT "Id", "PaymentMethodTypeId", "CustomerId", "PaymentDate", "PaymentAmount"
FROM "PaymentMethods";

SELECT "Id", "Cpf", "Email", "FirstName", "LastName", "PhoneNumber", "Password"
FROM "Customers";

SELECT "Id", "Name", "CategoryId"
FROM "Subcategories";