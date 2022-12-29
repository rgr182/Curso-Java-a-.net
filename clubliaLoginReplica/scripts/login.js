(function ()
{
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

        const user = document.querySelector("#user").value;
        const password = document.querySelector("#password").value;

        if (password === '' || user === '') {
            mostrarError('Todos los campos son obligatorios')
            return;
        }

        const resultado = await fetch(`http://clubliaback-dev.eba-usrmkstp.us-east-1.elasticbeanstalk.com/Login?user=${user.toString()}&password=${password.toString()}`, {
            method: 'POST',
        }).then(response => {
            if (response.status === 200) {
                return response.json();
            }
            return "error";
        }).then(data => {
            if (data === "error") {
                alertaError('Datos Incorrectos!!', 'danger');
            } else {
                localStorage.setItem('perfil', JSON.stringify(data));
                location.href = "../home.html";
            }


        });


    });


}
    
    )();




