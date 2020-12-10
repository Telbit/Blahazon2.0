import React from 'react';
import Grid from '@material-ui/core/Grid';
import Card from './Cards/Card';

export const ProductList = () => {
    return (
        <div>
            <Grid>
                <Card></Card>
                <Card reverse={true}></Card>
            </Grid>
        </div>
    )
}
