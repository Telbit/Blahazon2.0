import React from 'react';
import {useEffect,useState, useLayoutEffect} from 'react';
import {Link} from 'react-router-dom';
import {makeStyles} from '@material-ui/core/styles';
import navImage from '../../resources/buttons/navbar.png';
import homeBtnImg from '../../resources/buttons/home.png';
import homeBtnImg_ho from '../../resources/buttons/home_ho.png';
import productsBtnImg from '../../resources/buttons/products.png';
import productsBtnImg_ho from '../../resources/buttons/products_ho.png';
import Cart from '../Cart/Cart';
import axios from 'axios';


const useStyles = makeStyles((theme) => ({
    title: {
        margin: theme.spacing(2)
    },

    Navbar:{
        width: '100%',
        height: '80px',
        backgroundImage: `url(${navImage})`,
        backgroundSize: '100% 100%',
        backgroundRepeat: 'no-repeat',
        backgroundColor: 'rgba(200, 0, 0, 0)',
        boxShadow: 'none',
        color: 'yellow',
        alignItems: 'center',
        zIndex: 50,
        //transition: '1s ease 0.5s',
        transition: 'opacity 1s'
        
    },

    scrolled: {
        position: 'fixed',
        top: 0,
        left: 0,
        opacity: 0.75
    },

    buttonStyle: {
        width: '80px',
        height: '50px',
        backgroundSize: '100% 100%',
        float: 'right',
        marginRight: '40px',
        marginLeft: '10px'
        

    },

    cartButton: {
        textAlign: "center"
    },

    title:{
        float:'left',
        marginLeft: '20px'
    },

    homeBtn: {
        backgroundImage: `url(${homeBtnImg})`,
        '&:hover':{
            transition: 'all 0.5s ease 0s',
            transform: 'translate(0px,5px)',
            backgroundImage: `url(${homeBtnImg_ho})`,
        }
    },

    productsBtn: {
        backgroundImage: `url(${productsBtnImg})`,
        '&:hover':{
            transition: 'all 0.5s ease 0s',
            transform: 'translate(0px,5px)',
            backgroundImage: `url(${productsBtnImg_ho})`,
        }
    },

    loginBtn: {
        zIndex: 999999,
        position:'absolute',
        marginLeft:'15%',
        decoration: 'none',
        color: 'yellow',

        '&:hover':{
            transition: 'all 6s ease 0s',
            marginLeft: '30%' ,
            color: 'black',
            textShadow: 'yellow 2px 2px 5px'
        }
    }
}));

function Navbar() {
    const classes = useStyles();

    const[scrolled,setScrolled] = useState(false);
    const [isSession, setSesssion] = useState();

    const handleScroll = () => {
        const offset = window.scrollY;
        if (offset > 0) {
            setScrolled(true);
        } else {
            setScrolled(false);
        }
    }


    useEffect(() => {
        window.addEventListener('scroll', handleScroll)
    })
    
    useEffect(() => {
        axios('https://localhost:44309/api/account/issession')
        .then(resp=> {
            setSesssion(resp.data)
            console.log(isSession)
        })
    })


    useEffect(() => {
        setloading(true)
        axios('https://localhost:44309/api/account/issession')
        .then(resp => {
            setIssession(resp.data);
            setloading(false);
        }); 
        setloading(false);
        console.log(issession)
    }, [issession])


    return ( 
        <div className={scrolled ? `${classes.Navbar} ${classes.scrolled}` : `${classes.Navbar}`}>
            <div className={classes.title}><h1>Blahazone</h1></div>
            <Link to="/" ><div className={`${classes.homeBtn} ${classes.buttonStyle}`}></div></Link>
            <Link to="/products" ><div className={`${classes.productsBtn} ${classes.buttonStyle}`}></div></Link>
            { isSession ? <div className={`${classes.buttonStyle} ${classes.cartButton}` }><Cart/></div> : <div/> }
            { isSession ? <Link to="/logout"><h1 className={`${classes.loginBtn}`}>Logout</h1 ></Link> : <Link to="/login"><h1 className={classes.loginBtn}>Login</h1></Link> }

            </div>
    );
}



export default Navbar;