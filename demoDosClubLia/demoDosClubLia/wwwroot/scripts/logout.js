export function logout(){
    localStorage.removeItem('jwt_access_token');
    localStorage.removeItem('profile');

    location.href = "../";
}