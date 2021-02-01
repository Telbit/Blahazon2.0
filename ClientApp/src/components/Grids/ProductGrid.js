import React, { useState, useEffect } from 'react';
import { Grid } from '@material-ui/core';
import { CircularProgress } from '@material-ui/core';
import ProductCard from '../Cards/ProductCard';
import { products } from '../TempImages';
import axios from 'axios';


function ProductGrid(props) {
    //console.log(props);
    const [products, setProducts] = useState();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios('https://localhost:44309/api/Products')
            .then((res) => {
                console.log(res)
                setProducts(res.data)
                setLoading(false);
            })
    }, []);

    return (
        <div className="grid-container" style={gridContainerStyle}>
            <Grid 
            container 
            spacing={5}
            direction="row"
            justify="space-around"
            alignItems="center"> 
            {
                !loading ? products.map(
                    (product)=> 
                    <Grid xs={4} item>
                            <ProductCard product={product} />
                    </Grid>
                    ) : <div><h3>Loading</h3><CircularProgress/></div>
            }
            
            </Grid>
        </div>
    )
}       

const gridContainerStyle = {
    paddingTop: '10%',
    paddingLeft: '5%'
    
}

export default ProductGrid
