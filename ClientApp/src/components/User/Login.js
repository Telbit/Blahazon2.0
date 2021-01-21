import {React, useState, useEffect} from 'react';
import { FormControl, FormHelperText, InputLabel, Input, Card, Button, Grid } from '@material-ui/core';
import {makeStyles} from '@material-ui/core/styles'



const useStyles = makeStyles((theme) => ({
    container: {
        padding: 50
    },
}));

export default function Login()
{
    const classes = useStyles();
    return(
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
                    <FormHelperText id='helper-text'>Never share your credentials</FormHelperText>
                </FormControl>
            </Grid>
            <Grid item xs={12}>
                <FormControl>
                    <InputLabel htmlFor="">Your password</InputLabel>
                    <Input id="password-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'>Never share your credentials</FormHelperText>
                </FormControl>
            </Grid>
            </Grid>
            <Button>Sign in</Button>
        </Card>
    </div>
    </>
    )
}