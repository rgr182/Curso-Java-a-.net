import { getTareasPendientes, getTareasEntregadas, getTareasCalificadas } from './API.js'
import { autorizacion } from './autorizacion.js';
import { logout } from './logout.js';

document.addEventListener('DOMContentLoaded', validacion);

async function validacion() {
    const resAutorizacion = await autorizacion();
    if (!resAutorizacion) {
        location.href = "../login.html";
    } else {

        const profile = JSON.parse(localStorage.getItem("profile"));

        const userName = document.querySelector("#userName");
        const grade = document.querySelector("#grade");
        const schoolName = document.querySelector("#schoolName");

        const registrosTareasPendientes = document.querySelector('#registros-actividades-pendientes');
        const apMensaje = document.querySelector('#actividades-pendientes-body-mensaje');
        const apMensajeText = document.querySelector('#actividades-pendientes-body-mensaje-text');

        const registrosTareasEntregadas = document.querySelector('#registros-actividades-entregadas');
        const aEMensaje = document.querySelector('#actividades-entregadas-body-mensaje');
        const aEMensajeText = document.querySelector('#actividades-entregadas-body-mensaje-text');

        const registrosTareasCalificadas = document.querySelector('#registros-actividades-calificadas');
        const aCMensaje = document.querySelector('#actividades-calificadas-body-mensaje');
        const aCMensajeText = document.querySelector('#actividades-calificadas-body-mensaje-text');

        const btnLogout = document.querySelector("#logout-btn");

        btnLogout.addEventListener('click', logout);

        userName.textContent = profile.displayName;
        grade.textContent = profile.grade;
        schoolName.textContent = profile.school_name;



        const tareas = await Promise.all([
            getTareasPendientes(),
            getTareasEntregadas(),
            getTareasCalificadas()
        ]).then(respuestas => {
            return respuestas
        }
        );


        if (tareas[0].length !== 0) {
            tareas[0].forEach(tarea => {
                const registroTareaPendiente = document.createElement('div');
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
                                <h6>${fecha.getDate()}-${fecha.toLocaleString("en-US", { month: "short" })}</>
                            </div>
        `;

                registrosTareasPendientes.appendChild(registroTareaPendiente);

            });

            apMensaje.remove();

        } else {
            apMensajeText.textContent = 'No hay actividades que mostrar!'
        }

        if (tareas[1].length !== 0) {
            tareas[1].forEach(tarea => {
                const registroTareaEntregada = document.createElement('div');
                const fecha = new Date(tarea.limit_date);

                registroTareaEntregada.classList.add('registro-actividad');
                registroTareaEntregada.innerHTML = `
                            <a href="#">
                                <img class="registro-actividad-img"
                                    src="./assets/misActividades/entregado.png" alt="">
                            </a>
                            <div class="registro-actividad-materia">
                                <h6>${tarea.name}</>
                            </div>
                            <div class="registro-actividad-materia">
                                <h6>${fecha.getDate()}-${fecha.toLocaleString("en-US", { month: "short" })}</>
                            </div>
        `;

                registrosTareasEntregadas.appendChild(registroTareaEntregada);

            });

            aEMensaje.remove();

        } else {
            aEMensajeText.textContent = 'No hay actividades que mostrar!'
        }

        if (tareas[2].length !== 0) {
            tareas[2].forEach(tarea => {
                const registroTareaCalifada = document.createElement('div');
                const fecha = new Date(tarea.limit_date);

                registroTareaCalifada.classList.add('registro-actividad');
                registroTareaCalifada.innerHTML = `
                            <a href="#">
                                <img class="registro-actividad-img"
                                    src="./assets/misActividades/miscalificaciones.png" alt="">
                            </a>
                            <div class="registro-actividad-materia">
                                <h6>${tarea.name}</>
                            </div>
                            <div class="registro-actividad-materia">
                                <h6>${tarea.score}</>
                            </div>
        `;

                registrosTareasCalificadas.appendChild(registroTareaCalifada);

            });

            aCMensaje.remove();

        } else {
            aCMensajeText.textContent = 'No hay actividades que mostrar!'
        }




    }
}
