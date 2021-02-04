import {React,useState,useEffect} from 'react';
import axios from 'axios';


let SessionCheck = () => {    

        return axios('https://localhost:44309/api/account/issession')
        .then(resp => {
            return resp.data
        });  
    

}

export default SessionCheck;