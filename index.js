"use strict"

const form = document.querySelector(".login")
accountLogInForm();

let correctLogin = {
    email: "Nick",
    password: "Nick"
}

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

function accountLogInForm() {
    const changeHTML = `
    <span class="formItem">
        <label for="email">Email: </label>
        <input type="text" class="textinput" name="email">
    </span>
    <span class="formItem">
        <label for="password">Password: </label>
        <input type="text" class="textinput" name="password">
    </span>
    <span class="formitem">
        <span><button type="submit" class="create">Create New Account</button></span>
        <span><button type="submit" class="login">Login</button></span>
    </span>
    `

    form.innerHTML = changeHTML;
}

function accountCreateForm() {
    const changeHTML = `
    <span class="formItem">
        <label for="email">Email: </label>
        <input type="text" class="textinput" name="email">
    </span>
    <span class="formItem">
        <label for="password">Password: </label>
        <input type="text" class="textinput" name="password">
    </span>
    <span class="formItem">
        <label for="fname">First Name: </label>
        <input type="text" class="textinput" name="fname">
    </span>
    <span class="formItem">
        <label for="lname">Last Name: </label>
        <input type="text" class="textinput" name="lname">
    </span>
    <button type="submit" class="creating">Create</button>
    `
    form.innerHTML = changeHTML;
}

function createAccount() {
    
    if(checkAlreadyAccount()) {
        console.log("creating account");
        accountLogInForm();
    }
    else {
        let incorrectText = document.createElement("span");
        incorrectText.classList.add("formItem");
        incorrectText.classList.add("incorrect");
        incorrectText.innerText = "Email already exists";

        form.insertBefore(incorrectText, form.lastElementChild);
    }
}

function logIn() {
    if(checkValidLogin()) {
        window.location.replace("customer.html");
    } 
    else {
        let incorrectText = document.createElement("span");
        incorrectText.classList.add("formItem");
        incorrectText.classList.add("incorrect");
        incorrectText.innerText = "Incorrect email and/or password";

        form.insertBefore(incorrectText, form.lastElementChild);
    }
}

function checkValidLogin() {
    let emailInput = form.email.value;
    let pwInput = form.password.value;

    if(emailInput == correctLogin.email && pwInput === correctLogin.password) {
        return true;
    }
    
    else {
        return false;
    }
}

function checkAlreadyAccount() {
    let emailInput = form.email.value;

    if(correctLogin.email == emailInput) {
        return false;
    }
    else {
        return true;
    }
}