"use strict"

const topbar = document.querySelector('.topbar');
const main = document.querySelector('.maincontent');
var storeID = "";


(function storeManager() {
    if(true)
    {
        const storemangerelement = document.createElement("li");
        const storemanagerspan = document.createElement("span");
        storemanagerspan.innerText = "Manage Store";
        let last = topbar.lastElementChild.previousElementSibling;

        storemangerelement.appendChild(storemanagerspan);
        storemangerelement.setAttribute('class', "topbar-item")

        last.parentNode.insertBefore(storemangerelement, last.nextSibling);
    }
})();

(function initOption() {
    showOrderHistory();
})();

topbar.addEventListener("click", (event) => {
    if(event.target.parentNode.id == "name") {
        console.log("name");
        return;
    }
    if(event.target.id == "logout") {
        logOut();
    }
    if(event.target.id == 'selected') {
        console.log("selected1");
    }
    else {
        switchSelected(event.target);
    }
})

function initOrderButtons() {
    const orderhistory = document.querySelector('.allorders');

    orderhistory.addEventListener("click", (event) => {
        if(event.target.classList.contains("information")) {
            if(!event.target.classList.contains("expanded")) {
                console.log(event.target.innerText);
                
                event.target.classList.add("expanded");
                const additionalInformation = document.createElement("ol");
                additionalInformation.setAttribute('class', "moreinfo");
                for(let i = 1; i <= 10; i++) {
                    const additionaListItem = document.createElement("li");
                    additionaListItem.innerText = "Some " + i;
                    additionalInformation.appendChild(additionaListItem);
                }
                event.target.parentNode.insertBefore(additionalInformation, event.target.nextSibling);
            }
            else {
                event.target.classList.remove("expanded");
                event.target.nextSibling.remove();
            }
        }
    
    })
}

function initStoreButtons() {
    const storebuttons = document.querySelector('.orderNow');

    storebuttons.addEventListener("click", (event) => {

        if(event.target.classList.contains("storebtn"))
        {
            console.log(event.target.id);
            storeID = event.target.id;
            startOrder();
        }
    })
}

function initPizzaButtons() {
    const pizzaButtons = document.querySelector('.pizzaOptions')

    pizzaButtons.addEventListener("click",(event) => {

        if(!event.target.classList.contains("sizeselect")) {

            if(event.target.classList.contains("placeorder")) {
                addToOrder(event.target);
            }

            if(event.target.classList.contains("customPizza")) {
                startCustomPizza();
            }
        }
    })
}

function initAddPizza() {
    const addPizza = document.querySelector('.addbtn');
    
    addPizza.addEventListener("click", (event) => {

        let customPizza = {
            crust: "",
            size: "",
            toppings: new Array()
        }

        if(checkCrust(customPizza)) {
            if(checkSize(customPizza)) {
                if(checkTopping(customPizza)) {
                    addCustomPizza(customPizza);
                    showPizzaOptions();
                }
            }
        }

        //showPizzaOptions();
    })
}

function switchSelected(target) {
    document.getElementById('selected').removeAttribute('id');
    target.id = "selected";
    if(target.innerText == "Order History"){
        console.log("order history");
        showOrderHistory();
    }
    if(target.innerText == "Order Now"){
        console.log("order now");
        orderNowSwitch();
    }
}

function addToOrder(target) {
    const sizevalue = target.previousElementSibling.value;

    if(sizevalue == "none")
    {
        return;
    }
    else {
        
        const pizzaType = target.previousElementSibling.previousElementSibling.innerText

        const curOrder = document.querySelector(".currentList");
        const newString = pizzaType + " - " + sizevalue;
        const listItem = document.createElement("li");
        listItem.classList.add("currentItem");
        listItem.innerText = newString;

        curOrder.appendChild(listItem);

        target.previousElementSibling.selectedIndex = 0;
    }
}

function addCustomPizza(customPizza) {
    const curOrder = document.querySelector(".currentList");
    let newString = "Custom Pizza - " + customPizza.crust + " - " + customPizza.size + " - " + customPizza.toppings;
    const listItem = document.createElement("li");
    listItem.classList.add("currentItem");
    listItem.innerText = newString;

    curOrder.appendChild(listItem);
}

function checkCrust(customPizza) {
    const crustRadio = document.querySelector('input[name="crust"]:checked');

    if(crustRadio == null) {
        console.log('nothing selected')
        return false;
    }
    else {
        console.log(crustRadio.value);
        customPizza.crust = crustRadio.value;
        return true;
    }
}

function checkSize(customPizza) {
    const sizeRadio = document.querySelector('input[name="size"]:checked');

    if(sizeRadio == null) {
        console.log('nothing selected')
        return false;
    }
    else {
        console.log(sizeRadio.value);
        customPizza.size = sizeRadio.value;
        return true;
    }
}

function checkTopping(customPizza) {
    const toppingRadio = document.querySelectorAll('input[name="topping"]:checked');

    if(toppingRadio == null) {
        console.log('nothing selected')
        return false;
    }
    else {
        console.log(toppingRadio);
        toppingRadio.forEach(element => customPizza.toppings.push(element.value));
        console.log(customPizza.toppings.length)
        return true;
    }
}

function logOut() {
    window.location.replace("index.html");
}

function startCustomPizza() {
    const customHTML = `
        <h1>Order Pizza</h1>
        <div class="customOptions">
            <span class="comp"><h3>Crust</h3>
                <div class="compOptions">
                    <label for="crust1">Crust1</label>
                    <input type="radio" id="Crust1" name="crust" value="crust1">
                </div>
                <div class="compOptions">
                    <label for="crust2">Crust2</label>
                    <input type="radio" id="Crust2" name="crust" value="crust2">
                </div>
                <div class="compOptions">
                    <label for="crust3">Crust3</label>
                    <input type="radio" id="Crust3" name="crust" value="crust3">
                </div>
            </span>
            <span class="comp"><h3>Size</h3>
                <div class="compOptions">
                    <label for="Size1">Size1</label>
                    <input type="radio" id="Size1" name="size" value="Size1">
                </div>
                <div class="compOptions">
                    <label for="Size2">Size2</label>
                    <input type="radio" id="Size1" name="size" value="Size2">
                </div>
                <div class="compOptions">
                    <label for="Size3">Size3</label>
                    <input type="radio" id="Size1" name="size" value="Size3">
                </div>
                <div class="compOptions">    
                    <label for="Size4">Size4</label>
                    <input type="radio" id="Size1" name="size" value="Size4">
                </div>   
            </span>
            <span class="comp"><h3>Toppings</h3>
                <div class="compOptions">
                    <label for="Topping1">Topping1</label>
                    <input type="checkbox" id="Topping1" name="topping" value="Topping1">
                </div>
                <div class="compOptions">
                    <label for="Topping2">Topping2</label>
                    <input type="checkbox" id="Topping2" name="topping" value="Topping2">
                </div>
                <div class="compOptions">
                    <label for="Topping3">Topping3</label>
                    <input type="checkbox" id="Topping3" name="topping" value="Topping3">
                </div>
                <div class="compOptions">
                    <label for="Topping4">Topping4</label>
                    <input type="checkbox" id="Topping4" name="topping" value="Topping4">
                </div>
                <div class="compOptions">
                    <label for="Topping5">Topping5</label>
                    <input type="checkbox" id="Topping5" name="topping" value="Topping5">
                </div>
            </span>
        </div>
        <div class="addpizza">
            <button type="submit" class="addbtn">Add Pizza</button>
        </div>
    </div>
    `

    main.firstElementChild.lastElementChild.innerHTML = customHTML;
    initAddPizza();``
}

function startOrder() {
    const currentOrderHTML = `
        <div class="currentorder">
            <h1>Current Order</h1>
            <h2>${storeID}</h2>
            <ul class="currentList">
                <li class="currentitem">Toppings</li>
                <li class="currentitem">Toppings1</li>
                <li class="currentitem">Toppings2</li>
                <li class="currentitem">Toppings3</li>
                <li class="currentitem">Toppings4</li>
                <li class="currentitem">Toppings5</li>
            </ul>
            <div class="priceOrder">
                <span class="totalprice">Total: $190.39</span>
                <span class="orderbutton"><button type="submit">Place Order</button></span>
            </div>
        </div>
    `
    const insideOrder = main.firstElementChild;  
    insideOrder.lastElementChild.setAttribute("id", "storeselected");
    insideOrder.innerHTML = currentOrderHTML + insideOrder.innerHTML;
    showPizzaOptions();
}

function showPizzaOptions() {
    const orderNowHTML = `
        <h1>Order Pizza</h1>
        <ul class="pizzaOptions">
            <li class="pizza preset"><span class="pizzaName">Meat Store</span>
                <select name=size class="sizeselect">
                    <option value="none" selected disabled> Select Size</option>
                    <option value="small">Small</option>
                    <option value="medium">Medium</option>
                    <option value="large">Large</option>
                </select>
                <span class="placeorder">Add Pizza</span>
            </li>
            <li class="pizza preset"><span class="pizzaName">Meat1 Store</span>
                <select name=size class="sizeselect">
                    <option value="none" selected disabled> Select Size</option>
                    <option value="small">Small</option>
                    <option value="medium">Medium</option>
                    <option value="large">Large</option>
                </select>
                <span class="placeorder">Add Pizza</span>
            </li>
            <li class="pizza preset"><span class="pizzaName">Meat2's Store</span>
                <select name=size class="sizeselect">
                    <option value="none" selected disabled> Select Size</option>
                    <option value="small">Small</option>
                    <option value="medium">Medium</option>
                    <option value="large">Large</option>
                </select>
                <span class="placeorder">Add Pizza</span>
            </li>
            <li class="pizza preset"><span class="pizzaName">Meat3 Store</span>
                <select name=size class="sizeselect">
                    <option value="none" selected disabled> Select Size</option>
                    <option value="small">Small</option>
                    <option value="medium">Medium</option>
                    <option value="large">Large</option>
                </select>
                <span class="placeorder">Add Pizza</span>
            </li>
            <li class="pizza custom"><span class="pizzaName customPizza">Some Other Store</span>

            </li>
        </ul>
    `
    const rightMenu = main.firstElementChild.lastElementChild;
    rightMenu.innerHTML = orderNowHTML;
    initPizzaButtons();
}

function showOrderHistory() {
    const htmlOrderHistory = `
    <div class="orderhistory">
        <h1>Order History</h1>
        <ul class="allorders">
            <li class="order"><span class='information'>Something</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something2</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something3</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something4</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something5</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something6</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something7</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something8</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something9</span><button class='orderagain'>Order Again</button></li>
            <li class="order"><span class='information'>Something10</span><button class='orderagain'>Order Again</button></li>
        </ul>
    </div>
    `
    main.innerHTML = htmlOrderHistory;
    initOrderButtons();
}

function orderNowSwitch() {
    const orderNowHTML = `
        <div class="ordering">
            <div class="orderselect">
                <h1>Order Pizza</h1>
                <ul class="orderNow">
                    <li class="storeOption"><button class="storebtn" id="cpk">California Store</button></li>
                    <li class="storeOption"><button class="storebtn" id="chicago">Chicago Store</button></li>
                    <li class="storeOption"><button class="storebtn" id="freddy">Freddy's Store</button></li>
                    <li class="storeOption"><button class="storebtn" id="ny">NewYork Store</button></li>
                    <li class="storeOption"><button class="storebtn" id="other">Some Other Store</button></li>
                </ul>
            </div>
        </div>
    `
    main.innerHTML = orderNowHTML;
    initStoreButtons();
}