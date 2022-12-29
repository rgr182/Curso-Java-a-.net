const perfil = JSON.parse(localStorage.getItem("perfil"));

const nameUser = document.querySelector("#nameUser");
nameUser.textContent= perfil.name;

const ageUser = document.querySelector("#ageUser");
ageUser.textContent= perfil.age;

const emailUser = document.querySelector("#emailUser");
emailUser.textContent= perfil.email;

const registersAP = document.querySelector(".registers");
const numeroRAP= registersAP.children.length;

if( numeroRAP > 5){
    console.log('Tienes mas actividades pendientess')
}
