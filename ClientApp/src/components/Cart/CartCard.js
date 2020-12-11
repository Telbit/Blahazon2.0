import React from 'react'
import {makeStyles} from '@material-ui/core/styles';
import { Grid } from '@material-ui/core';

const useStyles = makeStyles({
    card: {
        textAlign: "center",
        border: "2px solid red",
        background: "yellow"
    },
    cardData: {
        color: "black"
    },
})


export default function CartCard({product}) {
    let classes = useStyles();
    return (
        <div>
            <div className={classes.card}>
            <Grid
                container 
                direction="row" 
                alignItems="center"
                justify="space-around">
                <Grid item xs={4} className={classes.cardData}><>{product.title}</></Grid>
                <Grid item xs={4} className={classes.cardData}><></></Grid>
                <Grid item xs={4} className={classes.cardData}><>{product.price}</></Grid>
            </Grid>
            </div>
        </div>
    )
}
