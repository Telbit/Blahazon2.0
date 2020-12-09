import React from 'react';
import {useEffect} from 'react';
import {Link} from 'react-router-dom';
import {makeStyles} from '@material-ui/core/styles';
import navImage from '../../resources/buttons/navbar.png';
import homeBtnImg from '../../resources/buttons/home.png';
import homeBtnImg_ho from '../../resources/buttons/home_ho.png';
import productsBtnImg from '../../resources/buttons/products.png';
import productsBtnImg_ho from '../../resources/buttons/products_ho.png';


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
    }
}));

function Navbar() {
    const classes = useStyles();

    const[scrolled,setScrolled]=React.useState(false);

    const handleScroll=()=>{
        const offset=window.scrollY;
        if(offset > 100){
            setScrolled(true);
        }else{
            setScrolled(false);
        }
    }

    useEffect(() => {
        window.addEventListener('scroll', handleScroll)
    })



    return (
        <div className={scrolled ? `${classes.Navbar} ${classes.scrolled}` : `${classes.Navbar}`}>
            <div className={classes.title}><h1>Blahazone</h1></div>
            <Link to="/" ><div className={`${classes.homeBtn} ${classes.buttonStyle}`}></div></Link>
            <Link to="/products" ><div className={`${classes.productsBtn} ${classes.buttonStyle}`}></div></Link>
        </div>
    );
}



export default Navbar;