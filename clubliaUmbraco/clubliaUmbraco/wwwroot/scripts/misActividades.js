const perfil = JSON.parse(localStorage.getItem("perfil"));

const nameUser = document.querySelector("#nameUser");
nameUser.textContent= perfil.name;

const ageUser = document.querySelector("#ageUser");
ageUser.textContent= perfil.age;

const emailUser = document.querySelector("#emailUser");
emailUser.textContent= perfil.email;

console.log(perfil.name)
