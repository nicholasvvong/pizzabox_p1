"use strict"

const topbar = document.querySelector('.topbar');
const main = document.querySelector('.maincontent');


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
    //showOrderHistory();
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
            startOrder(event.target.id);
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
        }
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

function logOut() {
    window.location.replace("index.html");
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
        listItem.innerText = newString;

        curOrder.appendChild(listItem);

        target.previousElementSibling.selectedIndex = 0;
    }
}

function startOrder(storeID) {
    const currentOrderHTML = `
        <div class="currentorder">
            <h1>Current Order</h1>
            <h2>${storeID}</h2>
            <ul class="currentList">
                <li>Toppings</li>
                <li>Toppings1</li>
                <li>Toppings2</li>
                <li>Toppings3</li>
                <li>Toppings4</li>
                <li>Toppings5</li>
            </ul>
        </div>
    `
    const insideOrder = main.firstElementChild;  
    insideOrder.lastElementChild.setAttribute("id", "storeselected");
    insideOrder.innerHTML = currentOrderHTML + insideOrder.innerHTML;
    showPizzaOptions(storeID, insideOrder.lastElementChild);
}

function showPizzaOptions(storeID, rightMenu) {
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
            <li class="pizza custom"><span class="pizzaName">Some Other Store</span>

            </li>
        </ul>
    `
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