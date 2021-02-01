import {React, useState, useEffect} from 'react'
import {makeStyles} from '@material-ui/core/styles';
import { Grid } from '@material-ui/core';
import axios from 'axios';

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



export default function CartCard(props) {
    let classes = useStyles();
    console.log(props.lineItem)
    const [product, setProduct] = useState(null)

    let getProduct = () => 
        {axios(`https://localhost:44309/api/Products/${props.lineItem.productId}`)
        .then((resp) => {setProduct(resp.data) 
            console.log(resp.data)})}
    
    
    if (props.lineItem != null){
        getProduct()
        console.log(product)
    }
    return (
        <div>
            <div className={classes.card}>
            <Grid
                container 
                direction="row" 
                alignItems="center"
                justify="space-around">
                <Grid item xs={4} className={classes.cardData}><>{product != null ? product.title : ""}</></Grid>
                <Grid item xs={4} className={classes.cardData}><>{product != null ? props.lineItem.quantity : ""}</></Grid>
                <Grid item xs={4} className={classes.cardData}><>{product != null ? product.price : ""}</></Grid>
            </Grid>
            </div>""
        </div>
    )
}
