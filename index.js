"use strict"

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

function accountLogInForm() {
    const changeHTML = `
    <label for="email">Email: </label>
    <input type="text" class="textinput" name="email">
    <br>
    <label for="password">Password: </label>
    <input type="text" class="textinput" name="username">
    <button type="submit" class="create">Create New Account</button>
    <button type="submit" class="login">Login</button>
    `

    form.innerHTML = changeHTML;
}

function accountCreateForm() {
    const changeHTML = `
    <label for="email">Email: </label>
    <input type="text" class="textinput" name="email">
    <br>
    <label for="password">Password: </label>
    <input type="text" class="textinput" name="username">
    <label for="fname">First Name: </label>
    <input type="text" class="textinput" name="fname">
    <br>
    <label for="lname">Last Name: </label>
    <input type="text" class="textinput" name="lname">
    <button type="submit" class="creating">Create</button>
    `
    form.innerHTML = changeHTML;
}

function createAccount() {
    console.log("creating account");
    accountLogInForm();
}

function logIn() {
    window.location.replace("customer.html");
}