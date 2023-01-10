export async function autorizacion(){
    let respuesta = false;
    if(localStorage.getItem('jwt_access_token')){
        if(localStorage.getItem('profile')){
            respuesta = true;
        }else{
            const at = await accessToken();
        if(at ){
            respuesta = true;
        }else{
            respuesta = false;
        }
        }
        
    }else{
        respuesta = false;
    }
    return respuesta;
}

async function accessToken() {
    const token = JSON.parse(localStorage.getItem('jwt_access_token'));
    let respuesta = false;
    try {
        await fetch(`http://127.0.0.1:8000/api/access-token`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Authorization": `Bearer ${token.toString()}`
            }
        }).then(response => {
            if (response.status === 200) {
                return response.json();
            }
            return "error";
        }).then(data => {
            if (data !== "error") {
                localStorage.setItem('jwt_access_token', JSON.stringify(data.access_token));
                localStorage.setItem('profile', JSON.stringify(data.user.data));
                respuesta = true;
            }else{
                respuesta = false;
            }
        });

        return respuesta;

    } catch (error) {
        console.log(error);
        respuesta = false;
        return respuesta;
    }
}