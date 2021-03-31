console.log("store js")

let storeID = localStorage.getItem("storeID");
console.log(storeID);

const topbar = document.querySelector('.topbar');
const main = document.querySelector('.maincontent');

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

function initOrderButtons() {
    const orderhistory = document.querySelector('.allorders');

    orderhistory.addEventListener("click", (event) => {
        if(event.target.classList.contains("information")) {
            if(!event.target.classList.contains("expanded")) {
                
                event.target.classList.add("expanded");
                const additionalInformation = document.createElement("ol");
                additionalInformation.setAttribute('class', "moreinfo");

                let orderIndex = event.target.parentNode.value;
                //let pizzaorder = JSON.parse(currentorderhistory.jsonPizzaOrders[orderIndex]);
                //console.log(pizzaorder);

                // pizzaorder.forEach(value => {
                //     const additionaListItem = document.createElement("li");
                //     additionaListItem.innerText = `${value.Size} ${value.Name} - ${value.Crust} - ${value.Toppings.join(' ')} - ${value.Price.toFixed(2)}`;
                //     additionalInformation.appendChild(additionaListItem);
                // })
                for(let i = 0; i < 10; i++) {
                    const additionaListItem = document.createElement("li");
                    additionaListItem.innerText = `Some random information`;
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

    }
    if(target.innerText == "Add New Preset Pizza") {

    }
}

async function showOrderHistory() {
    //await FetchOrderHistory();
    const htmlOrderHistory = `
    <div class="orderhistory">
        <h1>Order History</h1>
        <ul class="allorders">

        </ul>
    </div>
    `
    console.log("showing history");
    main.innerHTML = htmlOrderHistory;
    
    let allordersInside = document.querySelector(".allorders");

    for(let i = 0; i < 10; i++) {
        let listOrderItemHTML = `
             <li class="order"><span class='information'>Some Dumb Information</span></li>
         `
         allordersInside.innerHTML += listOrderItemHTML;
    }
    // currentorderhistory.storeName.forEach((value,index) => {
    //     let date = new Date(currentorderhistory.orderTimes[index]);
    //     let listOrderItemHTML = `
    //         <li class="order""><span class='information'>Some Dumb Information</span></li>
    //     `
    //     allordersInside.innerHTML += listOrderItemHTML;
    // })
    
    initOrderButtons();
}

function showUpdateInventory() {
    const htmlOrderHistory = `
    <div class="inventory">
        <h1>Update Inventory</h1>
        <ul class="allitems">

        </ul>
    </div>
    `

    main.innerHTML = htmlOrderHistory;
    
    let allordersInside = document.querySelector(".allitems");

    for(let i = 0; i < 10; i++) {
        let listOrderItemHTML = `
             <li class="item"><span class="itemname">Some Dumb Information</span><span class="iteminv"><input type="number"></span></li>
         `
         allordersInside.innerHTML += listOrderItemHTML;
    }
}

function logOut() {
    window.location.replace("index.html");
}