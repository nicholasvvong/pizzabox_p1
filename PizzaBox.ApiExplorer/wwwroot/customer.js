"use strict"

//console.log(localStorage.getItem("customerInfo"));
let customerObj = JSON.parse(localStorage.getItem("customerInfo"));
document.querySelector('#name').firstElementChild.innerText = "Welcome " + customerObj.Fname + " " + customerObj.Lname;

let storeObjList = [];
let storeList = [];
let pizzaList = [];
let possibleSizes = [];
let possibleCrust = [];
let possibleToppings = [];
let currentTotal = 0;

let orderstarted = false;
let countdown = false;

let currentOrder = [];
let currentorderhistory;

const topbar = document.querySelector('.topbar');
const main = document.querySelector('.maincontent');
var storeName = "";
var storeID = "";
var storeIndex = 0;
var storeObj;

fetch('api/Store', {
    method: 'GET',
    headers: {
        'Accept': 'application/json',
        'Content-Type':'application/json'
    },})
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        const storeObjects = Object.entries(jsonReponse)
        for(const store of storeObjects)
        {
            storeObjList.push(store);
        }

        for(const [key, value] of Object.entries(jsonReponse)) {
            storeList.push(key);
        }
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });

async function FetchStoreObject()
{
    await fetch('api/Store/StoreInfo', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(storeID),
    })
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        storeObj = jsonReponse;
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });
    
 
    await fetch('api/Store/Toppings', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(storeID),
    })
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        storeObj.toppingsList = jsonReponse;
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });
 
    await fetch('api/Store/Crusts', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(storeID),
    })
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        storeObj.crustList = jsonReponse;
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });

 
    await fetch('api/Store/Sizes', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(storeID),
    })
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        storeObj.sizeList = jsonReponse;
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });


    await fetch('api/Store/Presets', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(storeID),
    })
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        storeObj.presetPizzas = jsonReponse;
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });
}

async function FetchSubmitOrder() {
    let orderInfo = {
        PizzaList: currentOrder,
        StoreID: storeID,
        CustomerID: customerObj.CustomerID,
        Total: currentTotal
    }

    return await fetch('api/Order/submit', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(orderInfo)
    })
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        //console.log(jsonReponse);
        if(jsonReponse == null) {
            return false;
        }
        return true;
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });
}

async function FetchOrderHistory() {
    await fetch(`api/Order/history/customer/${customerObj.CustomerID}`)
    .then(response => {
        if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else
            return response.json();
    })
    .then((jsonReponse) => {
        //console.log(jsonReponse);
        //console.log(JSON.parse(jsonReponse.jsonPizzaOrders[0]));
        currentorderhistory = jsonReponse;
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });
}



//-------------------------------------------------------------------//

function createCustomPizza(cName, cSize, cCrust, cToppings)  {
    return {
        name: cName,
        size: cSize,
        crust: cCrust,
        toppings: cToppings,
        price: 0.0
    }
}

function createComp(cName, cPrice, cInv) {
    return {
        name: cName,
        price: cPrice,
        inventory: cInv
    }
}

(function storeManager() {
    if(customerObj.StoreManger != '00000000-0000-0000-0000-000000000000')
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
    //showDumbOrderCountdown(1);
    showOrderHistory();
})();

topbar.addEventListener("click", (event) => {
    if(event.target.parentNode.id == "name") {
        return;
    }
    if(event.target.id == "logout") {
        localStorage.removeItem("customerInfo")
        logOut();
    }
    if(event.target.id == 'selected') {

    }
    else {
        let cancel = true;
        if(orderstarted) {
            if(confirm("Are you sure you want to cancel your order?")) {
                orderstarted = false;
                cancel = true;
            }
            else {
                cancel = false;
            }
        }
        if(cancel) {
            switchSelected(event.target);
        }
    }
})

function initSubmitOrder() {
    let submitbtn = document.querySelector(".orderbutton");
    submitbtn.addEventListener("click", async (event) => {
            if(currentOrder.length < 1) {
            alert("No items added to order");
        }
        else {
            let submitted = await FetchSubmitOrder();
            switchSelected(topbar.firstElementChild.nextElementSibling.firstElementChild);
            orderstarted = false;
            if(submitted) {
                showDumbOrderCountdown(40);
            }
            else {
                alert("Something went wrong with your order");
            }
            showOrderHistory();
        }
    })
}

function initStoreInfo() {
    possibleCrust = [];
    possibleSizes = [];
    possibleToppings = [];
    pizzaList = [];
    currentOrder = [];
    currentTotal = 0.00;

    //console.log(storeObj);

    storeObj.toppingsList.forEach(value => {
        possibleToppings.push(createComp(value.pizzaType.name, value.price, value.inventory));
    })

    storeObj.sizeList.forEach(value => {
        possibleSizes.push(createComp(value.pizzaType.name, value.price, value.inventory));
    })

    storeObj.crustList.forEach(value => {
        possibleCrust.push(createComp(value.pizzaType.name, value.price, value.inventory));
    })

    storeObj.presetPizzas.forEach(value => {
        let toppings = [];
        value.toppings.forEach(tValue => {
            toppings.push(createComp(tValue.pizzaType.name, tValue.price, tValue.inventory));
        })

        let presetP = createCustomPizza(value.type, "", createComp(value.crust.pizzaType.name, value.crust.price, value.crust.inventory), toppings);
        presetP.price = value.pizzaPrice;
        pizzaList.push(presetP);
    })

    // console.log(possibleCrust);
    // console.log(possibleSizes);
    // console.log(possibleToppings);
    // console.log(storeObj);
}

function initOrderButtons() {
    const orderhistory = document.querySelector('.allorders');

    orderhistory.addEventListener("click", (event) => {
        if(event.target.classList.contains("information")) {
            if(!event.target.classList.contains("expanded")) {
                
                event.target.classList.add("expanded");
                const additionalInformation = document.createElement("ol");
                additionalInformation.setAttribute('class', "moreinfo");

                let orderIndex = event.target.parentNode.value;
                let pizzaorder = JSON.parse(currentorderhistory.jsonPizzaOrders[orderIndex]);
                //console.log(pizzaorder);

                pizzaorder.forEach(value => {
                    const additionaListItem = document.createElement("li");
                    additionaListItem.innerText = `${value.Size} ${value.Name} - ${value.Crust} - ${value.Toppings.join(' ')} - ${value.Price.toFixed(2)}`;
                    additionalInformation.appendChild(additionaListItem);
                })

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
            storeName = event.target.id;
            storeIndex = storeList.indexOf(storeName);
            storeID = storeObjList[storeIndex][1];
            orderstarted = true;
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

        let customPizza = createCustomPizza("Custom Pizza", "","",new Array())

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

        }
        
    }))
}

function initDeleteButton() {
    let allDeleteBtns = document.querySelectorAll(".delbtn");
    let lastDeleBtn = allDeleteBtns[allDeleteBtns.length - 1];

    lastDeleBtn.addEventListener("click", (event) =>{  
        let deletePrice = event.target.parentNode.querySelector(".price").innerText.slice(1);
        currentTotal = parseFloat(currentTotal) - parseFloat(deletePrice);
        updateInvetoryIncrease(currentOrder[event.target.parentNode.value]);
        currentOrder.splice(event.target.parentNode.value, 1);
        event.target.parentNode.remove();

        updateOrderListValues();
        updatePrice();
    }) 
}

function enoughToppings() {
    let totalSelectedTopping = document.querySelectorAll('input[name="topping"]:checked');

    if(totalSelectedTopping.length >= storeObj.maxToppings) {
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
    if(target.innerText == "Order History"){
        document.getElementById('selected').removeAttribute('id');
        target.id = "selected";
        showOrderHistory();
    }
    if(target.innerText == "Order Now"){
        if(!countdown) {
            document.getElementById('selected').removeAttribute('id');
            target.id = "selected";
            orderNowSwitch();
        }
    }
    if(target.innerText == "Manage Store") {
        //console.log(customerObj);
        localStorage.setItem("storeID", customerObj.StoreManger)
        location = "store.html";
        //showStoreOptions();
    }
}

function addToOrder(target) {
    const sizevalue = target.previousElementSibling.value;

    if(sizevalue == "none")
    {
        return;
    }
    else {
        
        const parentList = target.parentNode;
        const pizzaType = target.parentNode.firstElementChild.innerHTML;
        const pizzaValue = target.parentNode.firstElementChild.nextSibling.innerHTML;

        const curOrder = document.querySelector(".currentList");
        
        const listItem = document.createElement("li");
        listItem.classList.add("currentItem");

        let pizzaName = parentList.querySelector(".presetName");
        let pizzaCrust = parentList.querySelector(".crustInfo").innerText;
        let pizzaToppings = parentList.querySelector(".toppingInfo").innerText;
        let sizeIndex = 0;
        for(sizeIndex; sizeIndex < possibleSizes.length; sizeIndex++) {
            if(possibleSizes[sizeIndex].name == sizevalue) {
                break;
            }
        }
        
        let newPresetPizza = createCustomPizza(pizzaName.innerText, sizevalue, pizzaCrust, pizzaToppings.split(" "));
        newPresetPizza.price = (parseFloat(pizzaValue.slice(1)) + possibleSizes[sizeIndex].price).toFixed(2);

        if(parseFloat(newPresetPizza.price) + parseFloat(currentTotal) > parseFloat(storeObj.maxPrice)) {
            alert(`Cannot add more. Max order price of $${storeObj.maxPrice.toFixed(2)}`)
            return;
        }
        if(currentOrder.length + 1 > storeObj.maxPizzas) {
            alert(`Cannot add more. Max pizza limit of ${storeObj.maxPizzas}`);
            return;
        }
        if(!updateInventoryDecrease(newPresetPizza)) {
            return;
        }

        const insideHtml = `
        <span class="pizzaInfoList">
            <div class="currentitemtext">${sizevalue.charAt(0).toUpperCase() + sizevalue.slice(1)} ${target.parentNode.querySelector(".presetName").innerText}</div>
            <div class="currentitemtext">${pizzaCrust} - ${pizzaToppings}</div>
        </span>
        <span class="price">$${newPresetPizza.price}</span>
        `

        let deleteButton = document.createElement("span");
        deleteButton.classList.add("delbtn");
        deleteButton.innerText = "(R)";

        listItem.appendChild(deleteButton);

        listItem.innerHTML += insideHtml;

        curOrder.appendChild(listItem);

        target.previousElementSibling.selectedIndex = 0;

        currentOrder.push(newPresetPizza);
        
        updateOrderListValues();
        initDeleteButton();
        calculateNewTotal(newPresetPizza.price);
    }
}

function calculateNewTotal(newPrice) {
    currentTotal = parseFloat(currentTotal) + parseFloat(newPrice);
    updatePrice();
}

function addCustomPizza(customPizza) {
    
    // let newCustomPizza = createCustomPizza(customPizza.size, customPizza.crust, customPizza.topping);
    // currentOrder.add(newCustomPizza);
    let index = 0;
    for(index; index < possibleCrust.length; index++) {
        if(possibleCrust[index].name == customPizza.crust) {
            break;
        }
    }
    customPizza.price = 0;
    customPizza.price += parseFloat(possibleCrust[index].price);

    index = 0;
    for(index; index < possibleSizes.length; index++) {
        if(possibleSizes[index].name == customPizza.size) {
            break;
        }
    }
    customPizza.price += parseFloat(possibleSizes[index].price);

    customPizza.toppings.forEach(value => {
        index = 0;
        for(index; index < possibleToppings.length; index++) {
            if(possibleToppings[index].name == value) {
                break;
            }
        }
        customPizza.price += parseFloat(possibleToppings[index].price);
    });

    if(parseFloat(customPizza.price) + parseFloat(currentTotal) > parseFloat(storeObj.maxPrice)) {
        alert(`Cannot add more. Max order price of $${storeObj.maxPrice.toFixed(2)}`)
        return;
    }
    if(currentOrder.length + 1 > storeObj.maxPizzas) {
        alert(`Cannot add more. Max pizza limit of ${storeObj.maxPizzas}`);
        return;
    }
    if(!updateInventoryDecrease(customPizza)) {
        return;
    }
    
    updateCurrentOrderList(customPizza);
}

function updateCurrentOrderList(newPizza) {

    const curOrder = document.querySelector(".currentList");

    let deleteButton = document.createElement("span");
    deleteButton.classList.add("delbtn");
    deleteButton.innerText = "(R)";


    let custompizza = `
        <span class="pizzaInfoList">
            <div class="currentitemtext">${newPizza.size.charAt(0).toUpperCase() + newPizza.size.slice(1)} ${newPizza.name.charAt(0).toUpperCase() + newPizza.name.slice(1)}</div>
            <div class="currentitemtext">${newPizza.crust} - ${newPizza.toppings}</div>
        </span>
        <span class="price">$${newPizza.price.toFixed(2)}</span>
    `

    const listItem = document.createElement("li");
    listItem.classList.add("currentItem");
    listItem.appendChild(deleteButton);
    listItem.innerHTML += custompizza;

    curOrder.appendChild(listItem);

    currentOrder.push(newPizza);
    updateOrderListValues();
    calculateNewTotal(newPizza.price);
    updatePrice();
    initDeleteButton();
}

function updateOrderListValues() {
    let curOrderList = document.querySelector(".currentList").firstElementChild;
    let index = 0;
    while(curOrderList != null) {
        curOrderList.setAttribute("value", index);
        curOrderList = curOrderList.nextElementSibling;
        index++;
    }
}
function updateInvetoryIncrease(oldPizza) {
    for(let i = 0; i < possibleCrust.length; i++) {
        if(possibleCrust[i].name == oldPizza.crust) {
            possibleCrust[i].inventory++;
            break;
        }
    }
    for(let i = 0; i < possibleSizes.length; i++) {
        if(possibleSizes[i].name == oldPizza.size) {
            possibleSizes[i].inventory++;
            break;
        }
    }
    oldPizza.toppings.forEach(value => {
        for(let i = 0; i < possibleToppings.length; i++) {
            if(possibleToppings[i].name == value) {
                possibleToppings[i].inventory++;
                break;
            }
        }
    })
}

function updateInventoryDecrease(newPizza) {
    let returnValue = true;
    for(let i = 0; i < possibleCrust.length; i++) {
        if(possibleCrust[i].name == newPizza.crust) {
            if(possibleCrust[i].inventory <= 0) {
                alert("Sorry. We're out of that crust.");
                returnValue = false;
                return false;
            }
            else {
                possibleCrust[i].inventory--;
                break;
            }
        }
    }
    for(let i = 0; i < possibleSizes.length; i++) {
        if(possibleSizes[i].name == newPizza.size) {
            if(possibleSizes[i].inventory <= 0) {
                alert("Sorry. We're out of dough to make that size");
                returnValue = false;
                return false;
            }
            else {
                possibleSizes[i].inventory--;
                break;
            }
        }
    }
    newPizza.toppings.forEach(value => {
        for(let i = 0; i < possibleToppings.length; i++) {
            if(possibleToppings[i].name == value) {
                if(possibleToppings[i].inventory <= 0) {
                    alert("Sorry. We're out of " + value);
                    returnValue = false;
                    return false;
                }
                else {
                    possibleToppings[i].inventory--;
                    break;
                }
            }
        }
    })
    return returnValue;
}

function checkCrust(customPizza) {
    const crustRadio = document.querySelector('input[name="crust"]:checked');

    if(crustRadio == null) {
        return false;
    }
    else {
        customPizza.crust = crustRadio.value;
        return true;
    }
}

function checkSize(customPizza) {
    const sizeRadio = document.querySelector('input[name="size"]:checked');

    if(sizeRadio == null) {
        return false;
    }
    else {
        customPizza.size = sizeRadio.value;
        return true;
    }
}

function checkTopping(customPizza) {
    const toppingRadio = document.querySelectorAll('input[name="topping"]:checked');

    if(toppingRadio == null || toppingRadio.length == 0) {
        return false;
    }
    else {
        toppingRadio.forEach(element => customPizza.toppings.push(element.value));
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
    let mainInfo = main.querySelector(".mainstuff");
    mainInfo.firstElementChild.lastElementChild.innerHTML = customHTML;

    let crustCompHtml = getCrustHtml();
    let sizeCompHtml = getSizeCustHtml();
    let toppingHtml = getToppingsHtml();

    let options = document.querySelector(".customOptions");
    options.innerHTML = crustCompHtml + sizeCompHtml + toppingHtml;

    initToppingLimit();
    initAddPizza();
}

async function startOrder() {
    await FetchStoreObject();
 
    const currentOrderHTML = `
        <div class="currentorder">
            <h1>Current Order</h1>
            <h2>${storeName}</h2>
            <ul class="currentList">
                
            </ul>
            <div class="priceOrder">
                <div class="totalprice">Total: $0.00</div>
                <div class="orderbutton"><button type="submit" name="submitbtn" class="submitorder">Place Order</button></div>
            </div>
        </div>
    `
    let mainInfo = main.querySelector(".mainstuff");
    const insideOrder = mainInfo.firstElementChild;
    insideOrder.lastElementChild.setAttribute("id", "storeselected");
    insideOrder.innerHTML = currentOrderHTML + insideOrder.innerHTML;

    initStoreInfo();
    initSubmitOrder();
    //initDeleteButton();
    showPizzaOptions();
}

function updatePrice() {
    let curPriceInfo = document.querySelector(".totalprice");
    curPriceInfo.innerText = "Total: $" + parseFloat(currentTotal).toFixed(2);
}

function showPizzaOptions() {
    const orderNowHTML = `
        <h1>Order Pizza</h1>
        <ul class="pizzaOptions">
            

        </ul>
    `
    let mainInfo = main.querySelector(".mainstuff");
    const rightMenu = mainInfo.firstElementChild.lastElementChild;
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

        let toppingsStrings = "";
        value.toppings.forEach(value => {
            toppingsStrings += value.name + " ";
        })

        pizzaName.innerHTML = `
            <div class="pizzaInfo">
                <div class="presetName">${value.name}</div>
                <div class="presetInfo"><span class="crustInfo">${value.crust.name}</span> - <span class="toppingInfo">${toppingsStrings}</span></div>
            </div>
        `

        let pizzaPrice = document.createElement("span");
        pizzaPrice.classList.add("pizzaName");
        pizzaPrice.classList.add("price");
        pizzaPrice.innerText = '$' + value.price.toFixed(2);

        listItem.appendChild(pizzaName);
        listItem.appendChild(pizzaPrice);
        listItem.innerHTML += sizeSelectHtml;
        menuList.appendChild(listItem);
    })

    menuList.innerHTML += `<li class="pizza custom"><span class="pizzaName customPizza">Custom Pizza</span></li>`;
    initPizzaButtons();
}

async function showOrderHistory() {
    await FetchOrderHistory();
    const htmlOrderHistory = `
    <div class="orderhistory">
        <h1>Order History</h1>
        <ul class="allorders">

        </ul>
    </div>
    `

    let mainInfo = main.querySelector(".mainstuff");
    mainInfo.innerHTML = htmlOrderHistory;
    
    let allordersInside = document.querySelector(".allorders");

    currentorderhistory.storeName.forEach((value,index) => {
        let date = new Date(currentorderhistory.orderTimes[index]);
        let listOrderItemHTML = `
            <li class="order" value="${index}"><span class='information'>${value} - ${date.toDateString()} - $${currentorderhistory.totals[index].toFixed(2)}</span><button class='orderagain'>Order Again</button></li>
        `
        allordersInside.innerHTML += listOrderItemHTML;
    })
    
    initOrderButtons();
}

function showDumbOrderCountdown(minutes) {
    let countdownDiv = document.createElement("div");
    countdownDiv.classList.add("countdown");
    main.insertBefore(countdownDiv, main.lastElementChild);

    let countdownBox = main.querySelector(".countdown");
    
    countdown = true;
    let title = document.createElement("div");
    title.classList.add("countdowntitle")
    title.innerText = "Order arrives in "
    countdownBox.appendChild(title);

    let countdowntimer = document.createElement("div");
    countdowntimer.classList.add("cdtimer");
    countdownBox.appendChild(countdowntimer);

    let actualTimer = countdownBox.querySelector(".cdtimer");
    let endTime = new Date(Date.now() + minutes * 60000);
    let setTimer = setInterval(function() {
        let distance = endTime - Date.now();
        let hrs = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        let mins = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        let secs = Math.floor((distance % (1000 * 60)) / 1000);

        actualTimer.innerText = `${hrs.toLocaleString(undefined, {minimumIntegerDigits: 2})}:${mins.toLocaleString(undefined, {minimumIntegerDigits: 2})}:${secs.toLocaleString(undefined, {minimumIntegerDigits: 2})}`;

        if(distance < 1) {
            console.log("done");
            clearInterval(setTimer);
            countdown = false;
            countdownBox.remove();
        }
    }, 1000);
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
    let mainInfo = main.querySelector(".mainstuff");
    mainInfo.innerHTML = orderNowHTML;
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
        sizeHtml += `<option value="${value.name.toLowerCase()}">$${value.price} ${value.name.charAt(0).toUpperCase() + value.name.slice(1)}</option>`
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
            <input type="radio" id="${value.name.toLowerCase()}" name="crust" value="${value.name.toLowerCase()}">
            <label for="${value.name.toLowerCase()}">${value.name.charAt(0).toUpperCase() + value.name.slice(1)}</label><span class="price">$${value.price}</span>
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
            <input type="radio" id="${value.name.toLowerCase()}" name="size" value="${value.name.toLowerCase()}">
            <label for="${value.name.toLowerCase()}" name="lsize">${value.name.charAt(0).toUpperCase() + value.name.slice(1)}</label><span class="price">$${value.price}</span>
        </div>
        `
    })

    sizeHtml += `</span>`;

    return sizeHtml;
}

function getToppingsHtml() {
    let toppingsHtml = `
    <span class="comp"><h3>Toppings(Max ${storeObj.maxToppings})</h3>
    `

    possibleToppings.forEach((value, index) => {
        toppingsHtml += `
        <div class="compOptions toppings">
            <input type="checkbox" id="${value.name.toLowerCase()}" name="topping" value="${value.name.toLowerCase()}">
            <label for="${value.name.toLowerCase()}">${value.name.charAt(0).toUpperCase() + value.name.slice(1)}</label><span class="price">$${value.price.toFixed(2)}</span>
        </div>
        `
    })

    toppingsHtml += `</span>`;

    return toppingsHtml;
}