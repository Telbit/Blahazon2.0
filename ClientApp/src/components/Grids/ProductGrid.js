import React, { useState, useEffect } from 'react';
import { Grid } from '@material-ui/core';
import ProductCard from '../Cards/ProductCard';
import { products } from '../TempImages';
import axios from 'axios';



// const products = [
//     {id:"1", imgsrc:`${testImage}`, name:"testkep", description:"leiras"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2 ez egy szöveg ami valahogy kinéz", description:"leiras2 es ez is kinez valahogy lol de jo lesz"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"},
//     {id:"2", imgsrc:"kep.jpg", name:"testkep2", description:"leiras2"}
// ]


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
                            <ProductCard imageSource={product.imgsrc} name={product.title}
                            description={product.description} id={product.id}/>
                    </Grid>
                ) : <div><h3>Loading</h3></div>
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
