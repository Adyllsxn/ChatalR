import axios from 'axios';

const apiservice = axios.create({
    baseURL: "http://localhost:5232",
});

export default apiservice;
