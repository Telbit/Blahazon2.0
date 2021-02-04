import {React,useState,useEffect} from 'react';
import axios from 'axios';


let SessionCheck = () => {

        let session = axios('https://localhost:44309/api/account/issession')
        .then(resp => resp);  
        return session
}

export default SessionCheck;