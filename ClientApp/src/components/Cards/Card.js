import React from 'react';
import Grid from '@material-ui/core/Grid';
import {makeStyles} from '@material-ui/core/styles'
import { Typography } from '@material-ui/core';
import Image from 'material-ui-image';
import imageOne from '../../resources/mainpage/first.png';
import imageTwo from '../../resources/mainpage/second.png';

const useStyles = makeStyles((theme) => ({
    container: {
        background: "lightgrey"
    },
    root: {
        paddingLeft: '60px',
        paddingRight: '60px',
        paddingTop: '50px',
        paddinBottom: '50px'
    }
}));


function Card(props) {
    let card;
    if (!props.reverse) {
        card = 
        <>
            <Grid item container xs={6} 
                    justify="center" 
                    spacing={3}>
                        <Grid item xs={6}>
                            <Typography variant="p">
                            Blahazon is your one-stop online shop for today's most daring, exciting and edgy fashion apparel. Our affordable collections are all about redefining trends, design excellence and exceptional quality to satisfy the needs of every aspiring fashionista. Furthermore you can make your own design on any product!
                            </Typography>
                        </Grid>
                </Grid>

                <Grid item xs={6}>
                    <Image
                        src={imageTwo}
                        aspectRatio={(4/3)}
                        />
                </Grid>
        </>

    } else {
        card = 
        <>
            <Grid item xs={6}>
                <Image
                    src={imageOne}
                    aspectRatio={(4/3)}
                    />
            </Grid>
        <Grid item container xs={6} 
                justify="center" 
                spacing={3}>
                    <Grid item xs={6}>
                        <Typography variant="p">
                        For BlahaEntertainment, being a brand that symbolises fashion and luxury means knowing how to create unique products, combining aesthetics, quality and innovation with a strong system of values. Not only is the Group known for the inimitable hallmark style of its products, but also for the principles guiding its actions, which are laid down in its Code of Ethics. These principles are inspired by the concept of substance and the conviction that sustainability means, first and foremost, creating a system capable of enduring through time, with respect for all the resources that the Group draws on and with the awareness that the future of generations to come depends on the choices of today.
                        </Typography>
                    </Grid>
            </Grid>
        </>
    }

    const classes = useStyles();
    return (
        <div className={classes.root}>
        <Grid container className={classes.container}
            justify="space-evely"
            alignItems="center"
            spacing={3}>
            
            {card}
            
        </Grid> 
        </div>
    );
}



export default Card;