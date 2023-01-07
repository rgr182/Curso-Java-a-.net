import { getAvatars } from './API.js';

document.addEventListener('DOMContentLoaded', getAvts);

async function getAvts(){
    await getAvatars();
}