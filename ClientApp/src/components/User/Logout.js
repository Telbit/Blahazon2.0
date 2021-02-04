import axios from 'axios';
import {React, useState, useEffect} from 'react';
import { Redirect } from 'react-router-dom';


let Logout = () => {
        axios.get("https://localhost:44309/api/Account/logout")
    return(<><Redirect to="/"/></>)
}

export default Logout;