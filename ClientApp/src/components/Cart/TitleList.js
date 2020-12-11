import React from 'react'
import { Grid } from '@material-ui/core';

export default function TitleList({classes}) {
    return (
        <div>
                  {/* to component */}
                    <Grid item xs={12}>
                                    <Grid
                                    container 
                                    direction="row" 
                                    alignItems="center"
                                    justify="space-around">
                                        <Grid item xs={4}><p className={classes.title}>Name</p></Grid>
                                        <Grid item xs={4}><p className={classes.title}>Quantity</p></Grid>
                                        <Grid item xs={4}><p className={classes.title}>Price</p></Grid>
                                    </Grid> 
                                    {/* /to component */}
                                </Grid>
        </div>
    )
}
