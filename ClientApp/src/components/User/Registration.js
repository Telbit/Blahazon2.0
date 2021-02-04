import React from 'react';
import {useEffect, useState} from 'react';
import { FormControl, FormHelperText, InputLabel, Input, Card, Button, Grid } from '@material-ui/core';
import {makeStyles} from '@material-ui/core/styles';
import axios from 'axios';

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


    const createCart = (userId) => {
        console.log(userId)
        axios.post(`https://localhost:44309/api/Cart/new/${userId}`)
    }

    const readResponse = (res, userName) => {
        console.log(res)
        if (res === 160){
            console.log("in if 160 ")
            axios(`https://localhost:44309/api/user/first/${userName}`)
            .then(resp => createCart(resp.data))
        } else if (res === 158) {

        } else if (res === 156){

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

        </Card>
        </div>
    </>)

}
