[1mdiff --git a/ClientApp/src/components/Cards/ProductCard.js b/ClientApp/src/components/Cards/ProductCard.js[m
[1mindex ac7e8a5..64b75a2 100644[m
[1m--- a/ClientApp/src/components/Cards/ProductCard.js[m
[1m+++ b/ClientApp/src/components/Cards/ProductCard.js[m
[36m@@ -106,7 +106,7 @@[m [mfunction ProductCard(props) {[m
             image={product.imageSource}/>[m
             </Link>[m
             <CardContent className={classes.content}>[m
[31m-                <h3>{product.name}</h3>[m
[32m+[m[32m                <h3>{product.title}</h3>[m
                 <p>{product.description}</p>[m
             </CardContent>[m
         </CardActionArea>[m
[1mdiff --git a/ClientApp/src/components/Cart/CartCard.js b/ClientApp/src/components/Cart/CartCard.js[m
[1mindex b66a897..08c13ba 100644[m
[1m--- a/ClientApp/src/components/Cart/CartCard.js[m
[1m+++ b/ClientApp/src/components/Cart/CartCard.js[m
[36m@@ -20,23 +20,15 @@[m [mexport default function CartCard(props) {[m
     let classes = useStyles();[m
     console.log(props.lineItem)[m
     const [product, setProduct] = useState(null)[m
[31m-[m
[31m-    let getProduct = () => [m
[31m-        {axios(`https://localhost:44309/api/Products/${props.lineItem.productId}`)[m
[31m-        .then((resp) => {setProduct(resp.data) [m
[31m-            console.log(resp.data)})}[m
[31m-    [m
[31m-    [m
     [m
         useEffect(() => {[m
             if (props.lineItem != null){[m
[31m-            axios(`https://localhost:44309/api/Products/${props.lineItem.productId}`)[m
[31m-            .then((resp) => {setProduct(resp.data) [m
[31m-            console.log(resp.data)})}[m
[32m+[m[32m                axios(`https://localhost:44309/api/Products/${props.lineItem.productId}`)[m
[32m+[m[32m                    .then((resp) => {setProduct(resp.data)[m[41m [m
[32m+[m[32m                console.log(resp.data)})[m
[32m+[m[32m        }[m
         }, [])[m
     [m
[31m-        [m
[31m-    [m
     return ([m
         <div>[m
             <div className={classes.card}>[m
[1mdiff --git a/ClientApp/src/components/Navbar/Navbar.js b/ClientApp/src/components/Navbar/Navbar.js[m
[1mindex 76da07c..4ced2f2 100644[m
[1m--- a/ClientApp/src/components/Navbar/Navbar.js[m
[1m+++ b/ClientApp/src/components/Navbar/Navbar.js[m
[36m@@ -1,5 +1,5 @@[m
 import React from 'react';[m
[31m-import {useEffect} from 'react';[m
[32m+[m[32mimport {useEffect,useState} from 'react';[m
 import {Link} from 'react-router-dom';[m
 import {makeStyles} from '@material-ui/core/styles';[m
 import navImage from '../../resources/buttons/navbar.png';[m
[36m@@ -8,6 +8,8 @@[m [mimport homeBtnImg_ho from '../../resources/buttons/home_ho.png';[m
 import productsBtnImg from '../../resources/buttons/products.png';[m
 import productsBtnImg_ho from '../../resources/buttons/products_ho.png';[m
 import Cart from '../Cart/Cart';[m
[32m+[m[32mimport SessionCheck from '../User/SessionCheck';[m
[32m+[m[32mimport axios from 'axios';[m
 [m
 [m
 const useStyles = makeStyles((theme) => ({[m
[36m@@ -80,7 +82,8 @@[m [mconst useStyles = makeStyles((theme) => ({[m
 function Navbar() {[m
     const classes = useStyles();[m
 [m
[31m-    const[scrolled,setScrolled]=React.useState(false);[m
[32m+[m[32m    const[scrolled,setScrolled] = useState(false);[m
[32m+[m[32m    const [isSession, setSession] = useState();[m
 [m
     const handleScroll=()=>{[m
         const offset=window.scrollY;[m
[36m@@ -95,16 +98,28 @@[m [mfunction Navbar() {[m
         window.addEventListener('scroll', handleScroll)[m
     })[m
 [m
[32m+[m[32m    useEffect(() => {[m
[32m+[m[32m        //axios('https://localhost:44309/api/account/issession')[m
[32m+[m[32m        SessionCheck().then(data => {[m
[32m+[m[32m        setSession(data)[m
[32m+[m[32m        console.log(data)[m
[32m+[m[32m    });[m[41m  [m
[32m+[m[32m    })[m
[32m+[m
 [m
 [m
     return ([m
[32m+[m[41m        [m
         <div className={scrolled ? `${classes.Navbar} ${classes.scrolled}` : `${classes.Navbar}`}>[m
[32m+[m[41m            [m
             <div className={classes.title}><h1>Blahazone</h1></div>[m
             [m
             <Link to="/" ><div className={`${classes.homeBtn} ${classes.buttonStyle}`}></div></Link>[m
[31m-            <Link to="/products" ><div className={`${classes.productsBtn} ${classes.buttonStyle}`}></div>[m
[31m-            </Link><div className={`${classes.buttonStyle} ${classes.cartButton}` }><Cart/></div>[m
[31m-            </div>[m
[32m+[m[32m            <Link to="/products" ><div className={`${classes.productsBtn} ${classes.buttonStyle}`}></div></Link>[m
[32m+[m[32m            {isSession ? <div className={`${classes.buttonStyle} ${classes.cartButton}` }><Cart/></div> : <div/>}[m
[32m+[m[41m            [m
[32m+[m[32m        </div>[m
[32m+[m[41m    [m
     );[m
 }[m
 [m
[1mdiff --git a/ClientApp/src/components/Navbar/index.js b/ClientApp/src/components/SessionContext.js[m
[1msimilarity index 100%[m
[1mrename from ClientApp/src/components/Navbar/index.js[m
[1mrename to ClientApp/src/components/SessionContext.js[m
[1mdiff --git a/ClientApp/src/components/User/SessionCheck.js b/ClientApp/src/components/User/SessionCheck.js[m
[1mindex fe9bf57..95b2cc8 100644[m
[1m--- a/ClientApp/src/components/User/SessionCheck.js[m
[1m+++ b/ClientApp/src/components/User/SessionCheck.js[m
[36m@@ -2,17 +2,14 @@[m [mimport {React,useState,useEffect} from 'react';[m
 import axios from 'axios';[m
 [m
 [m
[31m-let SessionCheck = () => {[m
[32m+[m[32mconst SessionCheck = () => {[m
     [m
[31m-    let isSession = false;[m
[31m-[m
[31m-        axios('https://localhost:44309/api/account/issession')[m
[31m-        .then(resp => {[m
[31m-            console.log(resp)[m
[31m-            resp.data === true ? isSession = true : isSession = false[m
[31m-        });  [m
[32m+[m[32m    axios('https://localhost:44309/api/account/issession')[m
[32m+[m[32m    .then(resp => {[m
[32m+[m[32m        console.log(resp)[m
[32m+[m[32m        return resp.data[m
[32m+[m[32m    });[m[41m  [m
     [m
[31m-    return isSession;[m
 }[m
 [m
 export default SessionCheck;[m
\ No newline at end of file[m
