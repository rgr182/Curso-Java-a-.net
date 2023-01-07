export async function login(username, password) {
    let info = {}
    try {

        const dataLogin = {
            username,
            password
        }

        await fetch(`http://127.0.0.1:8000/api/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataLogin)
        }).then(response => {
            if (response.status === 200) {
                return response.json();
            }
            return "error";
        }).then(data => {
            if (data !== "error") {
                localStorage.setItem('jwt_access_token', JSON.stringify(data.access_token));
                localStorage.setItem('profile', JSON.stringify(data.user.data));
                info = JSON.parse(JSON.stringify(data))

            } else {
                info = {
                    error: 'Datos incorrectos!!!'
                }
            }

        });
        return info;

    } catch (error) {
        info = {
            error: 'Error al consultar los datos!!!'
        }
        return info;
    }
}

export async function getAvatars() {
    const token = JSON.parse(localStorage.getItem('jwt_access_token'));

    try {

        const resultado = await fetch(`http://127.0.0.1:8000/api/avatar`, {
            headers: {
                "Authorization": `Bearer ${token.toString()}`
            }
        }).then(response => {
            if (response.status === 200) {
                return response.json();
            }
            return "error";
        }).then(data => {
            if (data !== "error") {
                //En espera de hacer algo
               
            } 
        });

    } catch (error) {
        console.log(error)
    }
}

export async function getTareasPendientes() {
    const token = JSON.parse(localStorage.getItem('jwt_access_token'));

    try {

        const resultado = await fetch(`http://127.0.0.1:8000/api/tareas?status=No+entregado&today=2023-01-05+22:45`, {
            headers: {
                "Authorization": `Bearer ${token.toString()}`
            }
        }).then(response => {
            if (response.status === 200) {
                return response.json();
            }
            return "error";
        }).then(data => {
            if (data !== "error") {
                //En espera de hacer algo
                return data.data;
               
            } 
            return 'error';
        });

        return resultado;

    } catch (error) {
        return 'error';
    }
}