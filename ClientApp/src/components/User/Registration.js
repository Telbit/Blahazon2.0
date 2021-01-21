import React from 'react';
import {useEffect, useState} from 'react';
import { FormControl, FormHelperText, InputLabel, Input, Card } from '@material-ui/core';

export default function Registration(props) {
    return(
    <>
        <Card>
            <FormControl>
                <InputLabel htmlFor="">Your e-mail</InputLabel>
                <Input id="email-input" aria-describedby="helper-text"></Input>
                <FormHelperText id='helper-text'>Never share your credentials</FormHelperText>
            </FormControl>
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
    </>)

}
