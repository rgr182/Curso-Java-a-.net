import {getTareasPendientes} from './API.js'

const profile = JSON.parse(localStorage.getItem("profile"));

const userName = document.querySelector("#userName");
const grade = document.querySelector("#grade");
const schoolName = document.querySelector("#schoolName");

const registrosTareasPendientes = document.querySelector('#registros-actividades-pendientes');
const apMensaje= document.querySelector('#actividades-pendientes-body-mensaje');

userName.textContent= profile.displayName;
grade.textContent= profile.grade;
schoolName.textContent= profile.school_name;

const tareasPendientes = await getTareasPendientes();

if(tareasPendientes.length !== 0){
    tareasPendientes.forEach(tarea => {
        const registroTareaPendiente  = document.createElement('div');
        const fecha = new Date(tarea.limit_date);
      
        registroTareaPendiente.classList.add('registro-actividad');
        registroTareaPendiente.innerHTML = `
                            <a href="#">
                                <img class="registro-actividad-img"
                                    src="./assets/misActividades/tiempo-tareaspendientes.png" alt="">
                            </a>
                            <div class="registro-actividad-materia">
                                <h6>${tarea.name}</>
                            </div>
                            <div class="registro-actividad-materia">
                                <h6>${fecha.getDate()}-${ fecha.toLocaleString("en-US", { month: "short" })}</>
                            </div>
        `;
    
        registrosTareasPendientes.appendChild(registroTareaPendiente);
    
    });
    
    apMensaje.remove();
    
}




