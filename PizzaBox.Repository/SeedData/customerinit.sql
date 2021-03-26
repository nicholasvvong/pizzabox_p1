INSERT INTO Customers(CustomerID, Fname, Lname, LastStoreStoreID, LastTimeOrdered, StoreMangerStoreID)
SELECT newid(), 'Nick', 'Wong', s.StoreID, GETUTCDATE(), sm.StoreId
FROM Stores as s, Stores as sm
WHERE s.Name = 'CPK' AND sm.Name = 'CPK'