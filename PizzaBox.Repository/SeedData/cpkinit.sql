INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.75, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'chicken' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.66, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'beef' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.50, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'ham' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.40, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'mushroom' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.25, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'olive' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.30, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'peppers' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.70, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'pepperoni' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.80, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'pineapple' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.75, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'salami' AND S.Name = 'CPK'
INSERT INTO Toppings(ToppingID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 0.75, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'sausage' AND S.Name = 'CPK'

INSERT INTO Crusts(CrustID, PizzaTypeCompID, StoreID, Price, Inventory, CheeseStuffed, StuffedPrice)
SELECT newid(), c.CompID, s.StoreID, 1.00, 100, 0, 1.50
FROM Comps as C, Stores as S
WHERE C.Name = 'regular' AND S.Name = 'CPK'

INSERT INTO Crusts(CrustID, PizzaTypeCompID, StoreID, Price, Inventory, CheeseStuffed, StuffedPrice)
SELECT newid(), c.CompID, s.StoreID, 1.50, 100, 0, 1.50
FROM Comps as C, Stores as S
WHERE C.Name = 'hand-tossed' AND S.Name = 'CPK'

INSERT INTO Crusts(CrustID, PizzaTypeCompID, StoreID, Price, Inventory, CheeseStuffed, StuffedPrice)
SELECT newid(), c.CompID, s.StoreID, 1.00, 100, 0, 1.50
FROM Comps as C, Stores as S
WHERE C.Name = 'thin' AND S.Name = 'CPK'

INSERT INTO Sizes(SizeID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 3.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'small' AND S.Name = 'CPK'

INSERT INTO Sizes(SizeID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 4.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'medium' AND S.Name = 'CPK'

INSERT INTO Sizes(SizeID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 5.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'large' AND S.Name = 'CPK'

INSERT INTO Sizes(SizeID, PizzaTypeCompID, StoreID, Price, Inventory)
SELECT newid(), c.CompID, s.StoreID, 6.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'extra large' AND S.Name = 'CPK'



INSERT INTO BasicPizza(PresetID, Type, CrustID, AStoreStoreID, PizzaPrice)
SELECT newid(), 'Meat Pizza', crust.CrustID, s.StoreID, 0
FROM Stores as s, Crusts as crust
WHERE s.Name = 'CPK' AND Crust.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'regular') AND Crust.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')

INSERT INTO BasicPizza(PresetID, Type, CrustID, AStoreStoreID, PizzaPrice)
SELECT newid(), 'Hawaiian Pizza', crust.CrustID, s.StoreID, 0
FROM Stores as s, Crusts as crust
WHERE s.Name = 'CPK' AND Crust.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'regular') AND Crust.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')


INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Meat Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'beef') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')

INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Meat Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name ='chicken') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')

INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Meat Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'ham') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')

INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Meat Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'salami') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')

INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Meat Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'pepperoni') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')


INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Hawaiian Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'ham') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')

INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Hawaiian Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'peppers') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')

INSERT INTO PresetPizza(BasicPizzaID, ToppingID)
SELECT p.PresetID, t.ToppingID
FROM BasicPizza as p, Toppings as t
WHERE p.Type = 'Hawaiian Pizza' AND T.PizzaTypeCompID = (SELECT Comps.CompID FROM Comps WHERE Comps.Name = 'pineapple') AND T.StoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK') AND p.AStoreStoreID = (SELECT StoreID FROM Stores WHERE Name = 'CPK')