import React from 'react';
// import productImage from '../resources/Tshirts/retard.png';
import Button from '../resources/buttons/button.png';
import {makeStyles} from '@material-ui/core/styles';
import {Link} from 'react-router-dom';
import {products} from '../components/TempImages';

const useStyles = makeStyles({
    productImage:{
        // backgroundImage: `url(${productImage})`,
        backgroundSize: '100% 100%',
        backgroundRepeat: 'no-repeat',
    },

    productDetails:{
        height: '100%',
        fontWeight: '500'
    },

    container:{
        padding: '50px 20vw',
        display: 'grid',
        gridTemplateColumns: '20vw auto',
        gridTemplateRows: '30vw auto',
        gap: '10px',
    },

    dropbtn:{
        position: 'relative',
        display: 'inline-block',
        backgroundColor: 'rgba(255, 0, 0, 0)'
    },

    dropdownContent:{
        position: 'absolute',
        minWidth: '160px',
    },

    displayNone:{
        display: 'none',
    },

    buttonImage:{
        backgroundImage: `url(${Button})`,
        backgroundSize: '100% 100%',
        backgroundRepeat: 'no-repeat',
        border: 'none',
        padding: '15px',
        color: 'yellow',
        fontWeight: '700',
        margin: '10px 10px 10px 0',
        backgroundColor: 'rgba(255, 0, 0, 0)'
    }

})

export const Product = ({match}) => {
    const classes = useStyles();
    getImage();
    return (
        <div>
            <div className={classes.container}>
                <div className={classes.productImage} style={{backgroundImage: `url(${getImage()})`}}>
                </div>
                <div className={classes.productDetails}>
                    <p>Emporio Armani Loungewear logo lounge t-shirt in black</p>
                    <h2>49.99 EUR</h2>
                    <h3>colour:</h3>
                    <p>white</p>
                    <h3>size: </h3>
                    <p id='selectdedSize'>XL</p>
                    <Link to={`/customize/${match.params.id}`} >
                        <button className={classes.buttonImage}>Customize</button>
                    </Link>
                    <div className={classes.dropdown}>
                        <button className={`${classes.dropbtn} ${classes.buttonImage}`} onClick={ChooseSizeButtonClickHandler}>Choose size</button>
                        <div className={`${classes.dropdownContent} ${classes.displayNone}`}>
                            <button className={classes.buttonImage} onClick={(event) => SelectButtonClickHandler(event)}>XS</button>
                            <button className={classes.buttonImage} onClick={(event) => SelectButtonClickHandler(event)}>S</button>
                            <button className={classes.buttonImage} onClick={(event) => SelectButtonClickHandler(event)}>M</button>
                            <button className={classes.buttonImage} onClick={(event) => SelectButtonClickHandler(event)}>L</button>
                            <button className={classes.buttonImage} onClick={(event) => SelectButtonClickHandler(event)}>XL</button>
                        </div>
                    </div>
                </div>
                <div>
                    <h3>PRODUCT DETAILS</h3>
                    <p>Extreme muscle fit T-shirt pack by Emporio Armani</p>
                    <ul>
                        <li>Super stretch cotton jersey</li>
                        <li>Crew neck</li>
                        <li>Skinny-cut sleeves</li>
                        <li>Emporio Armani logo</li>
                        <li>Tightest fit to the body</li>
                        <li>Spray-on look</li>
                        <li>Super skinny fit – cut closest to the body</li>
                    </ul>
                </div>
                <div>
                    <h3>BRAND</h3>
                    <p>A diffusion line from iconic fashion house Armani, 
                        Emporio Armani offers timeless style with their 
                        collections of wearable classics. Emporio Armani 
                        pieces range from loungewear and underwear to watches, 
                        all of which channel the effortless style Emporio Armani is famed for.</p>
                </div>
            </div>
        </div>
    )

    function ChooseSizeButtonClickHandler() {
        document.querySelector(`.${classes.dropdownContent}`).classList.remove(`${classes.displayNone}`);
    }

    function SelectButtonClickHandler(event) {
        document.querySelector("#selectdedSize").innerText = event.target.innerText;
        document.querySelector(`.${classes.dropdownContent}`).classList.add(`${classes.displayNone}`);
    }

    function getImage() {
        const product = products.find(item => item.id === match.params.id).imgsrc;
        console.log(product);
        return product;
    }
}

