let storeID = localStorage.getItem("storeID");

const topbar = document.querySelector('.topbar');
const main = document.querySelector('.maincontent');
let currentorderhistory;
let crusts = [];
let sizes = [];
let toppings = [];

async function FetchOrderHistory() {
    await fetch(`api/Order/history/store/${storeID}`)
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

async function FetchAllComps() {
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
        //storeObj.toppingsList = jsonReponse;
        //console.log(jsonReponse);
        convertComps(jsonReponse, toppings);
        jsonReponse.forEach((value, index) => {
            toppings[index].id = value.toppingID;
        })
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
        //storeObj.crustList = jsonReponse;
        convertComps(jsonReponse, crusts);
        jsonReponse.forEach((value, index) => {
            crusts[index].id = value.crustID;
        })
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
        //storeObj.sizeList = jsonReponse;
        convertComps(jsonReponse, sizes);
        jsonReponse.forEach((value, index) => {
            sizes[index].id = value.sizeID;
        })
        
    })
    .catch(function(err) {
        console.log("Failed to fetch page: ", err);
    });
}

//------------------------------------------------------------------//
function createComp(cName, cPrice, cInv) {
    return {
        name: cName,
        price: cPrice,
        inventory: cInv
    }
}

topbar.addEventListener("click", (event) => {
    if(event.target.id == "logout") {
        localStorage.removeItem("customerInfo")
        localStorage.removeItem("storeID")
        logOut();
    }
    if(event.target.id == 'selected') {

    }
    else {
        switchSelected(event.target);
    }
})

showOrderHistory();

function initAddToppingsBtn() {
    let btn = document.querySelector("#addtopping");

    btn.addEventListener("click", () => addNewPizzaTopping());
}

function initOrderButtons() {
    const orderhistory = document.querySelector('.allorders');

    orderhistory.addEventListener("click", (event) => {
        if(event.target.parentNode.classList.contains("information")) {
            if(!event.target.parentNode.classList.contains("expanded")) {
                
                event.target.parentNode.classList.add("expanded");
                const additionalInformation = document.createElement("ol");
                additionalInformation.setAttribute('class', "moreinfo");
                
                let orderIndex = event.target.parentNode.parentNode.value;
                let pizzaorder = JSON.parse(currentorderhistory.jsonPizzaOrders[orderIndex]);
                
                pizzaorder.forEach(value => {
                    const additionaListItem = document.createElement("li");
                    additionaListItem.innerText = `${value.Size} ${value.Name} - ${value.Crust} - ${value.Toppings.join(' ')} - ${value.Price.toFixed(2)}`;
                    additionalInformation.appendChild(additionaListItem);
                })
                // for(let i = 0; i < 10; i++) {
                //     const additionaListItem = document.createElement("li");
                //     additionaListItem.innerText = `Some random information`;
                //     additionalInformation.appendChild(additionaListItem);
                // }

                event.target.parentNode.parentNode.insertBefore(additionalInformation, event.target.parentNode.nextSibling);
            }
            else {
                event.target.parentNode.classList.remove("expanded");
                event.target.parentNode.nextSibling.remove();
            }
        }
    
    })
}

function switchSelected(target) {
    document.getElementById('selected').removeAttribute('id');
    target.id = "selected";
    if(target.innerText == "Order History"){
        showOrderHistory();
    }
    if(target.innerText == "Update Inventory"){
        showUpdateInventory();
    }
    if(target.innerText == "Add New Component") {
        showAddComp();
    }
    if(target.innerText == "Add New Preset Pizza") {
        showAddPizza();
    }
}

function convertComps(dbComps, jsComps) {
    dbComps.forEach(value => {
        jsComps.push(createComp(value.pizzaType.name, value.price, value.inventory));
    })
}

async function showOrderHistory() {
    await FetchOrderHistory();
    const htmlOrderHistory = `
    <div class="orderhistory">
        <h1>Order History</h1>
        <div class="ordertabs">
            <span class='nametab'>Customer's Name</span>
            <span class='timetab'>Order Time</span>
            <span class='pricetab'>Total Price</span>
        </div>
        <ul class="allorders">

        </ul>
    </div>
    `

    main.innerHTML = htmlOrderHistory;
    
    let allordersInside = document.querySelector(".allorders");

    for(let i = 0; i < currentorderhistory.storeName.length; i++) {
        let date = new Date(currentorderhistory.orderTimes[i]);
        let listOrderItemHTML = `
             <li class="order" value=${i}>
                <div class="information">
                    <span class='name'>${currentorderhistory.storeName[i]}</span>
                    <span class='time'>${date.toDateString()}</span>
                    <span class='total'>$${currentorderhistory.totals[i]}</span>
                </div>
             </li>
         `
         allordersInside.innerHTML += listOrderItemHTML;
    }
    
    initOrderButtons();
}

function showUpdateInventory() {
    FetchAllComps();
    const htmlOrderHistory = `
    <div class="inventory">
        <h1>Update Inventory</h1>
        <div class="ordertabs">
            <span class='nametab'>Component Name</span>
            <span class='timetab'>Inventory</span>
            <span class='pricetab'>Price</span>
        </div>
        <ul class="allitems">

        </ul>
    </div>
    `

    main.innerHTML = htmlOrderHistory;
    
    let allordersInside = document.querySelector(".allitems");

    for(let i = 0; i < 10; i++) {
        let listOrderItemHTML = `
             <li class="item">
                <span class="itemname">Some Dumb Information</span>
                <span class="iteminv"><input type="number" placeholder="100" min="0"></span>
            </li>
         `
         let listItem = document.createElement("li");
         listItem.classList.add("item");
         listItem.setAttribute("value", i);

         let listSpanName = document.createElement("span");
         listSpanName.classList.add("itemname");
         listSpanName.innerText = "Some dumb information";

         let listSpanInv = document.createElement("span");
         listSpanInv.classList.add("iteminv");

         let invInput = document.createElement("input");
         invInput.type = "number";
         invInput.name= "inventory"
         invInput.min = 0;
         invInput.defaultValue = 100;
         invInput.classList.add("invinput");

         let invPriceInput = document.createElement("input");
         invPriceInput.type = "number";
         invPriceInput.name = "price";
         invPriceInput.step = "0.01";
         invPriceInput.min = 0;
         invPriceInput.defaultValue = 100.00.toFixed(2);
         invPriceInput.classList.add("invinput");

         listSpanInv.appendChild(invInput);
         listSpanInv.appendChild(invPriceInput);
         listItem.appendChild(listSpanName);
         listItem.appendChild(listSpanInv);
         allordersInside.appendChild(listItem);
         //allordersInside.innerHTML += listOrderItemHTML;
    }
    let updateDiv = document.createElement("div");
    updateDiv.classList.add("update")
    let updateButton = document.createElement("button");
    updateButton.setAttribute("id", "updatebtn");
    updateButton.innerText = "Update";

    updateDiv.appendChild(updateButton)
    allordersInside.parentNode.appendChild(updateDiv);
}

function showAddComp() {
    const htmlOrderHistory = `
    <div class="newcomp">
        <h1>Adding New Comp</h1>
        <div class="addcomp">

        </div>
    </div>
    `
    main.innerHTML = htmlOrderHistory;
    let addCompDiv = document.querySelector(".addcomp");
    let compDiv = document.createElement("div");
    compDiv.classList.add("addcompC");

    let compLabel = document.createElement("label");
    compLabel.setAttribute("for", "comps");
    compLabel.innerText = "Select component type: "

    let selectBox = document.createElement("select");
    selectBox.setAttribute("name", "comps");
    selectBox.setAttribute("id", "comps");
    selectBox.setAttribute("class", "userinput");
    selectBox.required = true;

    for(let i = 0; i < 5; i++) {
        let selectOption = document.createElement("option");
        selectOption.setAttribute("value", i);
        selectOption.innerText = i;

        selectBox.appendChild(selectOption);
    }
    compDiv.appendChild(compLabel);
    compDiv.appendChild(selectBox);
    addCompDiv.appendChild(compDiv);

    let nameDiv = document.createElement("div");
    nameDiv.classList.add("addcompC");

    let nameLabel = document.createElement("label");
    nameLabel.setAttribute("for", "name");
    nameLabel.innerText = "Name of new component: "

    let nameBox = document.createElement("input");
    nameBox.type = "input";
    nameBox.setAttribute("name", "name");
    nameBox.setAttribute("id", "name");
    nameBox.setAttribute("class", "userinput");
    nameBox.required = true;

    nameDiv.appendChild(nameLabel);
    nameDiv.appendChild(nameBox);
    addCompDiv.appendChild(nameDiv);


    let priceDiv = document.createElement("div");
    priceDiv.classList.add("addcompC");

    let priceLabel = document.createElement("label");
    priceLabel.setAttribute("for", "price");
    priceLabel.innerText = "Price of new component: "

    let priceBox = document.createElement("input");
    priceBox.type = "number";
    priceBox.step = "0.01";
    priceBox.defaultValue = 0;
    priceBox.setAttribute("name", "price");
    priceBox.setAttribute("id", "price");
    priceBox.setAttribute("class", "userinput");
    priceBox.required = true;

    priceDiv.appendChild(priceLabel);
    priceDiv.appendChild(priceBox);
    addCompDiv.appendChild(priceDiv);

    let addDiv = document.createElement("div");
    addDiv.classList.add("updatecomp")
    let submitCompButton = document.createElement("button");
    submitCompButton.setAttribute("id", "submitcompbtn");
    submitCompButton.innerText = "Add New Component";

    addDiv.appendChild(submitCompButton)
    addCompDiv.parentNode.appendChild(addDiv);
}

function showAddPizza() {
    const htmlOrderHistory = `
    <div class="newcomp">
        <h1>Adding New Preest Pizza</h1>
        <div class="addcomp">

        </div>
    </div>
    `
    main.innerHTML = htmlOrderHistory;
    let addCompDiv = document.querySelector(".addcomp");
    let compDiv = document.createElement("div");
    compDiv.classList.add("addcompC");

    let nameLabel = document.createElement("label");
    nameLabel.setAttribute("for", "name");
    nameLabel.innerText = "Name of new pizza: "

    let nameBox = document.createElement("input");
    nameBox.type = "input";
    nameBox.setAttribute("name", "name");
    nameBox.setAttribute("id", "name");
    nameBox.setAttribute("class", "userinput");
    nameBox.required = true;

    compDiv.appendChild(nameLabel);
    compDiv.appendChild(nameBox);
    addCompDiv.appendChild(compDiv);

    let crustDiv = document.createElement("div");
    crustDiv.classList.add("addcompC");
    let compLabel = document.createElement("label");
    compLabel.setAttribute("for", "crust");
    compLabel.innerText = "Select crust type: "

    let selectBox = document.createElement("select");
    selectBox.setAttribute("name", "crust");
    selectBox.setAttribute("id", "crust");
    selectBox.setAttribute("class", "userinput");
    selectBox.required = true;

    for(let i = 0; i < 5; i++) {
        let selectOption = document.createElement("option");
        selectOption.setAttribute("value", i);
        selectOption.innerText = i;

        selectBox.appendChild(selectOption);
    }
    crustDiv.appendChild(compLabel);
    crustDiv.appendChild(selectBox);
    addCompDiv.append(crustDiv);

    let toppingsDiv = document.createElement("div");
    toppingsDiv.classList.add("addtoppings");

    let addDiv = document.createElement("div");
    addDiv.classList.add("addcompC");
    toppingsDiv.appendChild(addDiv);

    let addToppings = document.createElement("button");
    addToppings.setAttribute("id", "addtopping");
    addToppings.innerText = "Add Another Toppings";

    addDiv.appendChild(addToppings)
    addCompDiv.appendChild(toppingsDiv);

    addNewPizzaTopping();
    addNewPizzaTopping();

    let addPizzaDiv = document.createElement("div");
    addPizzaDiv.classList.add("updatecomp")
    let submitPizzaButton = document.createElement("button");
    submitPizzaButton.setAttribute("id", "submitcompbtn");
    submitPizzaButton.innerText = "Add New Pizza";

    addPizzaDiv.appendChild(submitPizzaButton)
    addCompDiv.parentNode.appendChild(addPizzaDiv);
    
    initAddToppingsBtn();
}

function addNewPizzaTopping() {
    let addCompDiv = document.querySelector(".addtoppings");

    let toppingDiv = document.createElement("div");
    toppingDiv.classList.add("addcompC");
    let toppingLabel = document.createElement("label");
    toppingLabel.setAttribute("for", "topping");
    toppingLabel.innerText = "Select a topping: "

    let toppingSelect = document.createElement("select");
    toppingSelect.setAttribute("name", "topping");
    toppingSelect.setAttribute("id", "topping");
    toppingSelect.setAttribute("class", "userinput");
    toppingSelect.required = true;

    for(let i = 0; i < 5; i++) {
        let selectOption = document.createElement("option");
        selectOption.setAttribute("value", i);
        selectOption.innerText = i;

        toppingSelect.appendChild(selectOption);
    }
    toppingDiv.appendChild(toppingLabel);
    toppingDiv.appendChild(toppingSelect);
    addCompDiv.insertBefore(toppingDiv, addCompDiv.lastElementChild);
}

function logOut() {
    window.location.replace("index.html");
}