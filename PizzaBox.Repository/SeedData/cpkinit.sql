INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.75, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'chicken' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.66, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'beef' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.50, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'ham' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.40, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'mushroom' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.25, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'olive' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.30, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'peppers' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.70, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'pepporoni' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.80, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'pineapple' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.75, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'salami' AND S.Name = 'CPK'
INSERT INTO Toppings(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 0.75, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'sausage' AND S.Name = 'CPK'

INSERT INTO Crusts(CompID, StoreID, Price, Inventory, CheeseStuffed, StuffedPrice)
SELECT c.CompID, s.StoreID, 1.00, 100, 0, 1.50
FROM Comps as C, Stores as S
WHERE C.Name = 'regular' AND S.Name = 'CPK'

INSERT INTO Crusts(CompID, StoreID, Price, Inventory, CheeseStuffed, StuffedPrice)
SELECT c.CompID, s.StoreID, 1.50, 100, 0, 1.50
FROM Comps as C, Stores as S
WHERE C.Name = 'hand-tossed' AND S.Name = 'CPK'

INSERT INTO Crusts(CompID, StoreID, Price, Inventory, CheeseStuffed, StuffedPrice)
SELECT c.CompID, s.StoreID, 1.00, 100, 0, 1.50
FROM Comps as C, Stores as S
WHERE C.Name = 'thin' AND S.Name = 'CPK'

INSERT INTO Sizes(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 3.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'small' AND S.Name = 'CPK'

INSERT INTO Sizes(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 4.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'medium' AND S.Name = 'CPK'

INSERT INTO Sizes(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 5.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'large' AND S.Name = 'CPK'

INSERT INTO Sizes(CompID, StoreID, Price, Inventory)
SELECT c.CompID, s.StoreID, 6.00, 100
FROM Comps as C, Stores as S
WHERE C.Name = 'extra large' AND S.Name = 'CPK'



INSERT INTO BasicPizza(PresetID, Type, CrustCompID, SizeCompID, AStoreStoreID, PizzaPrice)
SELECT newid(), 'Meat Pizza', c.CompID, ci.CompID, s.StoreID, 0
FROM Comps as c, Stores as s, Comps as ci
WHERE c.Name = 'regular' AND s.Name = 'CPK' AND ci.Name = 'medium'

INSERT INTO BasicPizza(PresetID, Type, CrustCompID, SizeCompID, AStoreStoreID, PizzaPrice)
SELECT newid(), 'Hawaiian Pizza', c.CompID, ci.CompID, s.StoreID, 0
FROM Comps as c, Stores as s, Comps as ci
WHERE c.Name = 'regular' AND s.Name = 'CPK' AND ci.Name = 'medium'

INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Meat Pizza' AND t.Name = 'beef'

INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Meat Pizza' AND t.Name = 'chicken'

INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Meat Pizza' AND t.Name = 'ham'

INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Meat Pizza' AND t.Name = 'salami'

INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Meat Pizza' AND t.Name = 'pepporoni'


INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Hawaiian Pizza' AND t.Name = 'ham'

INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Hawaiian Pizza' AND t.Name = 'peppers'

INSERT INTO PTJunc(PresetPizzaID, ToppingID)
SELECT p.PresetID, t.CompID
FROM BasicPizza as p, Comps as t
WHERE p.Type = 'Hawaiian Pizza' AND t.Name = 'pineapple'