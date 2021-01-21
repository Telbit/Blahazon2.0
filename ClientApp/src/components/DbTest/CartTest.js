import React from 'react';
import {useEffect, useState} from 'react';
import axios from 'axios';




function CartTest(props) {

    const [product, setProduct] = useState(null);

    let getProduct = () => { axios('https://localhost:44309/api/Cart/1')
                                    .then(res => setProduct(res))
                                }
    useEffect(() => {
        axios.post('https://localhost:44309/api/Cart/1',
        {
            "Id":2,
            "Title":"pol",
            "Type":"t-shirt",
            "ShortDescription":"rovid leiras",
            "Description":"Leiras",
            "Price":6500,
            "InStock":1,
            "ImagePath":"imagesrc"
        }
        )
        .then(getProduct)
        
    }, [])




    return (
        <div>
            <p>{product == null ? "Loading" : product.Title}</p>
        </div>
    )
}


export default CartTest;

