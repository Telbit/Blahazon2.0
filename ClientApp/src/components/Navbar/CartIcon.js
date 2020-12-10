import React, {useState, useEffect} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import {Link} from 'react-router-dom';
import axios from 'axios';

const useStyle = makeStyles({
    counter: {
        fontSize: '12px',
        background: '#ff0000',
        color: 'yellow',
        paddingTop: '10px',
        padding: '1 4'
    },
    cart: {
        verticalAlign: 'center',
        paddingTop: '25px',
        color: 'yellow'
    }
}); 


    function CartIcon(props) {
    const style = useStyle();
    const[productCount, setProductCount] = useState([]);
    
    useEffect(() => {
        axios('https://localhost:44309/api/Cart')
        .then(res => {
            console.log(res.data)
            setProductCount(res.data)
            
        })
    }, [productCount.length])


    return (
        <div>
            <li>
                <Link to="/">
                <ShoppingCartIcon className={style.cart}/>
                    <label for="counter" className={style.counter}>{productCount.length}</label>
                </Link>
            </li>
        </div>
    )
}

export default CartIcon