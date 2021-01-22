import React from 'react';
import {useEffect, useState} from 'react';
import { FormControl, FormHelperText, InputLabel, Input, Card, Button, Grid } from '@material-ui/core';
import {makeStyles} from '@material-ui/core/styles';
import axios from 'axios';
import { Link } from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
    container: {
        paddingLeft: "50vh",
        paddingRight: "50vh",
        paddingTop: "10vh",
        paddingBottom: "10vh"
    },
}));

export default function Registration(props) {
    const classes = useStyles();
    const [errorMsg, seterrorMsg] = useState();
    const [success, setsuccess] = useState(false);


    const createCart = (userId) => {
        
        axios.post(`https://localhost:44309/api/Cart/new/${userId}`)
    }

    const readResponse = (res, userName) => {
        console.log(res)
        if (res === 160){
            seterrorMsg(null);
            axios(`https://localhost:44309/api/user/first/${userName}`)
            .then(resp => createCart(resp.data));
            setsuccess(true)
        } else if (res === 158) {
            seterrorMsg("Username already exist!");
        } else if (res === 156){
            seterrorMsg("Email already exist!")
        }

    }

    const sendForm = () => {
        let fUsername = document.getElementById('username-input');
        let fPassword = document.getElementById('password-input');
        let fEmail = document.getElementById('email-input');
        axios.post('https://localhost:44309/api/account/register',
        {
            'Username': fUsername.value,
            'Password': fPassword.value,
            'Email': fEmail.value
        }).then(res => readResponse(res.data, fUsername.value))
    }

    return(
    <>
    <div className={classes.container}>
        <Card align="center">
            <Grid container
            spacing={5}>
            <Grid item xs={12}>
                <FormControl>
                    <InputLabel htmlFor="">Your e-mail</InputLabel>
                    <Input id="email-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'></FormHelperText>
                </FormControl>
            </Grid>
            <Grid item xs={12}>
                <FormControl>
                    <InputLabel htmlFor="">Your Username</InputLabel>
                    <Input id="username-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'>Between 6-12</FormHelperText>
                </FormControl>
            </Grid>
            <Grid item xs={12}>
                <FormControl>
                    <InputLabel htmlFor="">Your password</InputLabel>
                    <Input id="password-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'>Between 6-22</FormHelperText>
                </FormControl>
            </Grid>
            </Grid>
            <Button onClick={sendForm}>Submit</Button>
            {errorMsg ? 
            <>
                <h2>{errorMsg}</h2>
            </> : <></>}
            {success ? 
            <>
                <Link to='/login'><h2>You can login here!</h2></Link>
            </> : <></>}

        </Card>
        </div>
    </>)

}
