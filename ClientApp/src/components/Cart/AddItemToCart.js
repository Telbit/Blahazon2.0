import axios from 'axios';
import {useState, useEffect} from 'react';

const AddToCart = (product) => {

    console.log(product);

    useEffect(() => {
        
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
        
    })

}

export default AddToCart;