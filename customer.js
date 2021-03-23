"use strict"

let storeList = ["California Store", "Chicago Store", "Freddy's Store", "New York Store", "Some Other Store", "Another One", "Just to see how long"];
let pizzaList = ["Meat Pizza", "Hawaiin Pizza", "Deluxe Pizza", "Some Other Pizza"];
let possibleSizes = ["Small", "Medium", "Large"];
let possibleCrust = ["Crust1", "Crust2", "Crust3", "Crust4"];
let possibleToppings = ["Topping1", "Topping2", "Topping3", "Topping4", "Topping5", "Topping6"];
let toppingLimit = 5;

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

function initToppingLimit() {
    let clickOptions = document.querySelectorAll(".toppings");
    
    clickOptions.forEach(value => value.addEventListener("click", (event) => {
        
        if(enoughToppings())
        {
            console.log("click");
        }
        
    }))
}

function enoughToppings() {
    let totalSelectedTopping = document.querySelectorAll('input[name="topping"]:checked');

    if(totalSelectedTopping.length >= 5) {
        let unCheckedTopping = document.querySelectorAll('input[name="topping"]');
        unCheckedTopping.forEach(value => {
            if(!value.checked) {
                value.disabled=true;
            }
        })
    }
    else {
        let allTopping = document.querySelectorAll('input[name="topping"]');
        allTopping.forEach(value => {
            if((!value.checked) && value.disabled) {
                value.disabled = false;
            }
        })
    }

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
        
        const pizzaType = target.parentNode.firstElementChild.innerHTML;
        const pizzaValue = target.parentNode.firstElementChild.nextSibling.innerHTML;

        const curOrder = document.querySelector(".currentList");
        const newString = pizzaType + " - " + sizevalue;
        const listItem = document.createElement("li");
        listItem.classList.add("currentItem");
        
        const insideHtml = `
            <span class="currentitemtext">${sizevalue.charAt(0).toUpperCase() + sizevalue.slice(1)} ${pizzaType}</span><spa class="price">${pizzaValue}</span>
        `

        listItem.innerHTML = insideHtml;

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

    if(toppingRadio == null || toppingRadio.length == 0) {
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
            
        </div>
        <div class="addpizza">
            <button type="submit" class="addbtn">Add Custom Pizza</button>
        </div>
    </div>
    `
    main.firstElementChild.lastElementChild.innerHTML = customHTML;

    let crustCompHtml = getCrustHtml();
    let sizeCompHtml = getSizeCustHtml();
    let toppingHtml = getToppingsHtml();

    let options = document.querySelector(".customOptions");
    options.innerHTML = crustCompHtml + sizeCompHtml + toppingHtml;

    initToppingLimit();
    initAddPizza();
}

function startOrder() {
    const currentOrderHTML = `
        <div class="currentorder">
            <h1>Current Order</h1>
            <h2>${storeID}</h2>
            <ul class="currentList">
                <li class="currentitem"><span class="currentitemtext">Toppings</span><spa class="price">$10</span></li>
                <li class="currentitem"><span class="currentitemtext">Toppings</span><span class="price">$10</span></li>
                <li class="currentitem"><span class="currentitemtext">Toppings</span><span class="price">$10</span></li>
                <li class="currentitem"><span class="currentitemtext">Toppings</span><span class="price">$10</span></li>
                <li class="currentitem"><span class="currentitemtext">Toppings</span><span class="price">$10</span></li>
                <li class="currentitem"><span class="currentitemtext">Toppings</span><span class="price">$10</span></li>
            </ul>
            <div class="priceOrder">
                <div class="totalprice">Total: $190.39</div>
                <div class="orderbutton"><button type="submit" name="submitbtn">Place Order</button></div>
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
            

        </ul>
    `
    const rightMenu = main.firstElementChild.lastElementChild;
    rightMenu.innerHTML = orderNowHTML;

    let menuList = document.querySelector(".pizzaOptions");
    let sizeSelectHtml = getSizeHTML();

    sizeSelectHtml += `<span class="placeorder">Add Pizza</span>`;

    pizzaList.forEach(value => {
        let listItem = document.createElement("li");
        listItem.classList.add("pizza");
        listItem.classList.add("preset");

        let pizzaName = document.createElement("span");
        pizzaName.classList.add("pizzaName");
        pizzaName.innerText = value;

        let pizzaPrice = document.createElement("span");
        pizzaPrice.classList.add("pizzaName");
        pizzaPrice.classList.add("price");
        pizzaPrice.innerText = "$10";

        listItem.appendChild(pizzaName);
        listItem.appendChild(pizzaPrice);
        listItem.innerHTML += sizeSelectHtml;
        menuList.appendChild(listItem);
    })

    menuList.innerHTML += `<li class="pizza custom"><span class="pizzaName customPizza">Custom Pizza</span></li>`;
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
                    
                </ul>
            </div>
        </div>
    `
    main.innerHTML = orderNowHTML;
    let insideList = document.querySelector(".orderNow");
    storeList.forEach(value => {
        let listItem = document.createElement("li");
        listItem.classList.add("storeOption");

        let storeButton = document.createElement("button");
        storeButton.classList.add("storebtn");
        storeButton.setAttribute("id", value);
        storeButton.textContent = value;

        listItem.appendChild(storeButton);
        insideList.appendChild(listItem);
    })

    initStoreButtons();
}


function getSizeHTML() {
    let sizeHtml = `
        <select name=size class="sizeselect">
        <option value="none" selected disabled> Select Size</option>
    `
    
    possibleSizes.forEach(value => {
        sizeHtml += `<option value="${value.toLowerCase()}">${value}</option>`
    })

    sizeHtml += `</select>`;

    return sizeHtml;
}

function getCrustHtml() {
    let crustHtml = `
    <span class="comp"><h3>Crust</h3>
    `

    possibleCrust.forEach(value => {
        crustHtml += `
        <div class="compOptions">
            <input type="radio" id="${value.toLowerCase()}" name="crust" value="${value.toLowerCase()}">
            <label for="${value.toLowerCase()}">${value}</label><span class="price">$1</span>
        </div>
        `
    })

    crustHtml += `</span>`;

    return crustHtml;
}

function getSizeCustHtml() {
    let sizeHtml = `
    <span class="comp"><h3>Size</h3>
    `

    possibleSizes.forEach(value => {
        sizeHtml += `
        <div class="compOptions">
            <input type="radio" id="${value.toLowerCase()}" name="size" value="${value.toLowerCase()}">
            <label for="${value.toLowerCase()}" name="lsize">${value}</label><span class="price">$1</span>
        </div>
        `
    })

    sizeHtml += `</span>`;

    return sizeHtml;
}

function getToppingsHtml() {
    let toppingsHtml = `
    <span class="comp"><h3>Toppings(Max ${toppingLimit})</h3>
    `

    possibleToppings.forEach((value, index) => {
        toppingsHtml += `
        <div class="compOptions toppings">
            <input type="checkbox" id="${value.toLowerCase()}" name="topping" value="${value.toLowerCase()}">
            <label for="${value.toLowerCase()}">${value}</label><span class="price">$1</span>
        </div>
        `
    })

    toppingsHtml += `</span>`;

    return toppingsHtml;
}