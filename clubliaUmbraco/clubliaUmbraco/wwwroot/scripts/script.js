const formElement = document.getElementById("login");
formElement.addEventListener("submit",(event)=>{
    event.preventDefault();
    let user = document.getElementById("user").value;
    let password = document.getElementById("password").value;

    let transaction= {
        user: user,
        password: password,
    }
    let transactionJson = JSON.stringify(transaction)
    console.log(transactionJson);
});

