    import {login} from './API.js'
    
    const formulario = document.querySelector("#login");
    const alertPlaceholder = document.getElementById('liveAlertPlaceholder')

    const alertaError = (message, type) => {
        const wrapper = document.createElement('div')
        wrapper.innerHTML = [
            `<div class="alert alert-${type} alert-dismissible" role="alert">`,
            `   <div>${message}</div>`,
            '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
            '</div>'
        ].join('')

        alertPlaceholder.append(wrapper);

        setTimeout(() => {
            wrapper.remove();
        }, 3000)
    }

    formulario.addEventListener('submit', async (e) => {
        e.preventDefault();

        const username = document.querySelector("#user").value;
        const password = document.querySelector("#password").value;



        if (password === '' || username === '') {
            alertaError('Todos los campos son obligatorios')
            return;
        }
        
        const respuesta = await login(username, password);

        //Validacion de los errores de la respuesta
        if(respuesta.error){
            alertaError(respuesta.error, 'danger');
            return;
        }

        if(respuesta.user.data.role === 'preescolar'){
            location.href = "../home.html";
        }

        if((respuesta.user.data.role === 'alumno') && (respuesta.user.data.grade < 4 ) ){
            location.href = "../homePB.html";
        }

        if((respuesta.user.data.role === 'alumno') && (respuesta.user.data.grade > 3 )){
            location.href = "../homePA.html";
        }

        if(respuesta.user.data.role === 'alumno_secundaria'){
            location.href = "../homeS.html";
        }
        
    });









