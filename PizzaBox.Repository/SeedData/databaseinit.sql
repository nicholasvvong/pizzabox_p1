INSERT INTO Stores(StoreID, Name, MaxToppings, MaxPrice, MaxPizzas) VALUES
(newid(), 'CPK', 5, 250.00, 50),
(newid(), 'Chicago Pizza Store', 4, 200.00, 50),
(newid(), 'Freddys Pizza Store', 3, 100.00, 20),
(newid(), 'NewYork Pizza Store', 7, 250.00, 50)

INSERT INTO ItemType(TypeID, Name) VALUES
(newid(), 'topping'),
(newid(), 'crust'),
(newid(), 'size')

INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'beef', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'chicken', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'ham', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'mushroom', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'olive', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'peppers', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'pepperoni', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'pineapple', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'salami', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'sausage', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'meat ball', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'anchovies', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'onion', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'tomatoes', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'spinach', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'bacon', TypeID FROM ItemType WHERE ItemType.Name = 'topping'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'small', TypeID FROM ItemType WHERE ItemType.Name = 'size'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'medium', TypeID FROM ItemType WHERE ItemType.Name = 'size'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'large', TypeID FROM ItemType WHERE ItemType.Name = 'size'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'extra large', TypeID FROM ItemType WHERE ItemType.Name = 'size'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'regular', TypeID FROM ItemType WHERE ItemType.Name = 'crust'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'hand-tossed', TypeID FROM ItemType WHERE ItemType.Name = 'crust'
INSERT INTO Comps(CompID, Name, ITypeTypeID)
SELECT newid(), 'thin', TypeID FROM ItemType WHERE ItemType.Name = 'crust'

