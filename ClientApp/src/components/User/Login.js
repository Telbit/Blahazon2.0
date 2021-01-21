import {React, useState, useEffect} from 'react';
import { FormControl, FormHelperText, InputLabel, Input, Card, Button } from '@material-ui/core';


export default function Login()
{
    return(
    <>
        <Card>
            <FormControl>
                    <InputLabel htmlFor="">Your Username</InputLabel>
                    <Input id="username-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'>Never share your credentials</FormHelperText>
                </FormControl>
            <FormControl>
                    <InputLabel htmlFor="">Your password</InputLabel>
                    <Input id="password-input" aria-describedby="helper-text"></Input>
                    <FormHelperText id='helper-text'>Never share your credentials</FormHelperText>
            </FormControl>
        </Card>

        <Button>Sign in</Button>
    </>)
}