import React from 'react';
import { Card } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import CardActionArea from '@material-ui/core/CardActionArea';
import {Link} from 'react-router-dom';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import backgroundImage from '../../resources/productBackground/pdbg.png';
import backgroundImageHover from '../../resources/productBackground/pdbg_ho.png';
import axios from 'axios';
import {useHistory} from 'react-router-dom';

const useStyles = makeStyles({
    root: {
      maxWidth: 300,
      
    },
    media: {
      height: 200,
    },
    content: {
        textAlign: 'center'
    },
    button: {
        alignItems: 'center',
        color:'black',
        backgroundColor: 'rgb(255 255 255 )',
        width: '130px',
        backgroundImage: `url("${backgroundImage}")`,
        backgroundSize: '100% 100%',
        
        '&:hover':{
            transition: 'all 0.5s ease 0s',
            backgroundImage:  `url("${backgroundImageHover}")`,
            boxShadow: '2px 10px 32px 8px rgba(0, 0, 0, 0.1)',
            transform: 'scale(1.1,1.1)',
            color:'#ffeb3b'
            
        }
    },

    actionsContainer: {
       alignItems: 'center',
       textAlign: 'center',
       justifyContent: 'center' 
    }

  });

   

function ProductCard(props) {
    const classes = useStyles();
    const product = props.product;
    const stringProduct = JSON.stringify(product);
    let history = useHistory();
    let isSession = false;

    const SessionCheck = () => {
        axios('https://localhost:44309/api/account/issession')
        .then(resp => {
            console.log(resp)
            resp.data == true ? isSession = true : isSession = false
            HandleClick()
        });
        console.log(isSession)
        return isSession;  
    }

    const Redirect = () => {
        history.push(`/login`)
    }

    const AddToCart = () => {
        axios.post('https://localhost:44309/api/Cart/add',
                {
                    "id": product.id,
                    "title": product.title,
                    "type": product.type,
                    "shortDescription": product.shortDescription,
                    "description": product.description,
                    "price": product.price,
                    "inStock": product.inStock  ,
                    "imagePath":product.imagePath
                }) ;
    }

    const HandleClick = () => {
        if (isSession){
            AddToCart()
        }else{
            Redirect()
        }
    }


    return (
        <Card className={classes.root}>
        <CardActionArea>
            <Link to={`/product/${product.id}`}>
            <CardMedia
            className={classes.media}
            image={product.imageSource}/>
            </Link>
            <CardContent className={classes.content}>
                <h3>{product.title}</h3>
                <p>{product.description}</p>
            </CardContent>
        </CardActionArea>
        <CardActions className={classes.actionsContainer}>
            <Button onClick={SessionCheck} size="medium" productId={product.id} className={classes.button}>
                Buy
            </Button>
        </CardActions>
        </Card>
    )
}

export default ProductCard
