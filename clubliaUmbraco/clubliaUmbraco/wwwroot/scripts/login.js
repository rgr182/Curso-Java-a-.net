let urlLuis = "http://clubliaback-dev.eba-usrmkstp.us-east-1.elasticbeanstalk.com/Login?user=clublia&password=clublia2022";
let api = 'https://test.clublia.com/api/api/login';

const data = {
    user: "",
    password: ""
}

const formulario = document.querySelector("#login");
const user = document.querySelector("#user");
const password = document.querySelector("#password");

user.addEventListener('input', leerTexto);
password.addEventListener('input', leerTexto);

formulario.addEventListener('submit', async (e) => {
    e.preventDefault();

    const { user, password } = data;

    if (password === '' || user === '') {
        mostrarError('Todos los campos son obligatorios')
        return;
    }
    const resultado = await fetch(`http://clubliaback-dev.eba-usrmkstp.us-east-1.elasticbeanstalk.com/Login?user=${data.user.toString()}&password=${data.password.toString()}`, {
        method: 'POST',
    }).then(response => response.json())
    .then(data =>{ 
        localStorage.setItem('perfil', JSON.stringify(data));
        location.href ="../homepage/";

});

    

});



function leerTexto(e) {
    data[e.target.id] = e.target.value;
}

