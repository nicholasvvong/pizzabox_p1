"use strict"

const uri = document.documentURI;

const form = document.querySelector(".login")
accountLogInForm();

form.addEventListener("click", (event) => {
    event.preventDefault();
    if(event.target.tagName.toLowerCase() === 'button') {
        if(event.target.classList.contains('create')) {
            console.log("create");
            accountCreateForm();
        }
        if(event.target.classList.contains('login')) {
            console.log("login");
            logIn();
        }
        if(event.target.classList.contains('creating')) {
            createAccount();
        }
    }
})

form.addEventListener("keyup", (event) => {
    event.preventDefault();
    if(event.keyCode === 13) {
        console.log("pressed enter");
        //logIn();
    }
})

function accountLogInForm() {
    const changeHTML = `
    <span class="formItem">
        <label for="email">Email: </label>
        <input type="email" class="textinput" name="email" autocomplete="off">
    </span>
    <span class="formItem">
        <label for="password">Password: </label>
        <input type="password" class="textinput" name="password">
    </span>
    <span class="formitem">
        <span><button type="submit" class="create">Create New Account</button></span>
        <span><button type="submit" class="login" default>Login</button></span>
    </span>
    `
    //window.history.pushState({}, "Login Page", uri + "/login");
    form.innerHTML = changeHTML;
}

function accountCreateForm() {
    const changeHTML = `
    <span class="formItem">
        <label for="email">Email: </label>
        <input type="email" class="textinput" name="email" autocomplete="off" required>
    </span>
    <span class="formItem">
        <label for="password">Password: </label>
        <input type="password" class="textinput" name="password" required>
    </span>
    <span class="formItem">
        <label for="fname">First Name: </label>
        <input type="text" class="textinput" name="fname" autocomplete="off" required>
    </span>
    <span class="formItem">
        <label for="lname">Last Name: </label>
        <input type="text" class="textinput" name="lname" autocomplete="off" required>
    </span>
    <button type="submit" class="creating">Create</button>
    `

    //window.history.pushState({}, "Create Page", uri + "/create");
    form.innerHTML = changeHTML;
}

function createAccount() {
    let reg = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if(!reg.test(form.email.value))
    {
        //console.log("failed");
        let invalid = document.querySelector("#invalidEmail");
        if(!invalid) {
            let incorrectText = document.createElement("span");
            incorrectText.classList.add("formItem");
            incorrectText.classList.add("incorrect");
            incorrectText.setAttribute("id", "invalidEmail");
            
            incorrectText.innerText = "Invalid email format";

            form.insertBefore(incorrectText, form.lastElementChild);
        }
        else {
            invalid.innerText = "Invalid email format";
        }
        return;
    }
    
    const Customer = {
        Email: form.email.value.trim(),
        Password: form.password.value,
        Fname: form.fname.value.trim(),
        Lname: form.lname.value.trim()
    }
    let success = true;
    fetch('api/Customer/create',
    {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(Customer),
    })       
    .then(response => {
        if(response.status == 450) {
            success = false;
            return response.json();
        }
        else if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else {
            return response.json();
        }
    })
    .then((jsonReponse) => {
        console.log(jsonReponse);
        if(!success) {
            let findValid = document.querySelector("#invalidEmail");
            if(!findValid) {
                let incorrectText = document.createElement("span");
                incorrectText.classList.add("formItem");
                incorrectText.classList.add("incorrect");
                incorrectText.setAttribute("id", "invalidEmail");
                
                incorrectText.innerText = "Email already exists";

                form.insertBefore(incorrectText, form.lastElementChild);
            }
            else {
                findValid.innerText = "Email already exists";
            }
        }
        else {
            console.log("Account Created");
            accountLogInForm();
        }
    })
}

function logIn() {
    const loginInfo = {
        email: form.email.value.trim(),
        password: form.password.value
    };

    let success = true;
    fetch('api/Customer/login',
    {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json'
        },
        body: JSON.stringify(loginInfo),
    })       
    .then(response => {
        if(response.status == 450) {
            success = false;
            return response.json();
        }
        else if(!response.ok) {
            throw new Error(`Network reponse was not ok (${reponse.status})`);
        }
        else {
            return response.json();
        }
    })
    .then((jsonReponse) => {
        console.log(jsonReponse);
        if(!success) {
            let findValid = document.querySelector("#invalidLogin");
            if(!findValid) {
                let incorrectText = document.createElement("span");
                incorrectText.classList.add("formItem");
                incorrectText.classList.add("incorrect");
                incorrectText.setAttribute("id", "invalidLogin");
                incorrectText.innerText = "Incorrect email and/or password";   

                form.insertBefore(incorrectText, form.lastElementChild);
            }
        }
        else {
            console.log("Logging in");
            localStorage.setItem("customerInfo", jsonReponse);
            window.location.replace("customer.html");
            //window.history.pushState(jsonReponse, "PizzaHub!", "customer.html");
        }
    })
}

// fetch('api/Customer/init',
//     {
//         method: 'POST',
//         headers: {
//             'Accept': 'application/json',
//             'Content-Type':'application/json'
//         },
//         body: JSON.stringify(),
//     })       
//     .then(response => {
//         if(!response.ok) {
//             throw new Error(`Network reponse was not ok (${reponse.status})`);
//         }
//         else {
//             return response.json();
//         }
//     })
//     .then((jsonReponse) => {
//         console.log(jsonReponse);
//         if(jsonReponse == 'null') {
//             let findValid = document.querySelector("#invalidEmail");
//             if(!findValid) {
//                 let incorrectText = document.createElement("span");
//                 incorrectText.classList.add("formItem");
//                 incorrectText.classList.add("incorrect");
//                 incorrectText.setAttribute("id", "invalidEmail");
                
//                 incorrectText.innerText = "Email already exists";

//                 form.insertBefore(incorrectText, form.lastElementChild);
//             }
//         }
//         else {
//             console.log("Account Created");
//             accountLogInForm();
//         }
//     })