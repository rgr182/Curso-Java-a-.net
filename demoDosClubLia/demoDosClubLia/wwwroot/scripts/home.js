import { getAvatars } from './API.js';
import { logout } from './logout.js';
import { autorizacion } from './autorizacion.js';

document.addEventListener('DOMContentLoaded', getAvts);

const btnLogout = document.querySelector("#logout-btn");

btnLogout.addEventListener('click', close_sesion);

async function getAvts(){
    const resAutorizacion = await autorizacion();
    if(!resAutorizacion){
        location.href = "../login.html";
    }else{
        await getAvatars();
    }

    
}

function close_sesion() {
    logout();
}

