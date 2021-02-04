import {React, useState, useEffect} from 'react';
import { FormControl, FormHelperText, InputLabel, Input, Card, Button, Grid } from '@material-ui/core';
import {makeStyles} from '@material-ui/core/styles';
import axios from 'axios';
import { Link, Redirect } from 'react-router-dom';



const useStyles = makeStyles((theme) => ({
    container: {
        paddingLeft: "50vh",
        paddingRight: "50vh",
        paddingTop: "10vh",
        paddingBottom: "10vh"
    },
}));

export default function Login()
{
    const [errorMsg, seterrorMsg] = useState();
    const [success, setsuccess] = useState(false);
    const classes = useStyles();

    const readResponse = (res) => {
        if (res){
            seterrorMsg(null);
            setsuccess(true);
        } else {
            seterrorMsg("Incorrect username password combination!");
        }
    }

    const formAction = () => {
        let fUsername = document.getElementById('username-input');
        let fPassword = document.getElementById('password-input');
        axios.post('https://localhost:44309/api/Account/login', {
            'Username': fUsername.value,
            'Password': fPassword.value,
        }).then(res => readResponse(res.data))
    }

    useEffect(() => {
    }, [errorMsg, success]);

    return( success ? <Redirect to='/'/> :
    <>
    <div className={classes.container}>
        <Card align="center">
            <Grid container 
            spacing={5} 
            >
            <Grid item xs={12}>
                <FormControl>
                    <InputLabel htmlFor="">Your Username</InputLabel>
                    <Input id="username-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'></FormHelperText>
                </FormControl>
            </Grid>
            <Grid item xs={12}>
                <FormControl>
                    <InputLabel htmlFor="">Your password</InputLabel>
                    <Input id="password-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'></FormHelperText>
                </FormControl>
            </Grid>
            </Grid>
            <Button onClick={formAction}>Sign in</Button>
            {errorMsg ? 
            <>
                <h2>{errorMsg}</h2>
            </> : <></>}
        </Card>
    </div>
    </>
    )
}