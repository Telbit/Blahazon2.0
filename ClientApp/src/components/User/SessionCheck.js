import {React,useState,useEffect} from 'react';
import axios from 'axios';


let SessionCheck = () => {
    
    let isSession = false;

        axios('https://localhost:44309/api/account/issession')
        .then(resp => {
            console.log(resp)
            resp.data === true ? isSession = true : isSession = false
        });  
    
    return isSession;
}

export default SessionCheck;