import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import axios from 'axios';
import Grid from '@material-ui/core/Grid';

const payments = [
  { name: 'Card type', detail: 'Visa' },
  { name: 'Card holder', detail: 'card name' },
  { name: 'Card number', detail: 'xxxx-xxxx-xxxx-1234' },
  { name: 'Expiry date', detail: '04/2024' },
];

const useStyles = makeStyles((theme) => ({
  listItem: {
    padding: theme.spacing(1, 0),
  },
  total: {
    fontWeight: 700,
  },
  title: {
    marginTop: theme.spacing(2),
  },
}));

export default function Review() {
  const classes = useStyles();

  const [Cart, setCart] = useState([]);
  const [Address, setAddress] = useState({});

  useEffect(() => {
    axios('https://localhost:44309/api/Cart')
      .then((res) => {setCart(res.data);})
      .then(
        axios('https://localhost:44309/api/Payment/address')
          .then((res) => {setAddress(res.data);})
      )
}, []);

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Order summary
      </Typography>
      <List disablePadding>
        {Cart.map((product) => (
          <ListItem className={classes.listItem} key={product.title}>
            <ListItemText primary={product.title} secondary={product.shortDescription} />
            <Typography variant="body2">{product.price}</Typography>
          </ListItem>
        ))}
        <ListItem className={classes.listItem}>
          <ListItemText primary="Total" />
          <Typography variant="subtitle1" className={classes.total}>
            $4000
          </Typography>
        </ListItem>
      </List>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6}>
          <Typography variant="h6" gutterBottom className={classes.title}>
            Shipping
          </Typography>
          <Typography gutterBottom>{Address.FirstName+" "+Address.LastName+","}</Typography>
          <Typography gutterBottom>{Address.Address1+", "+Address.City+", "+Address.Zip+", "+Address.Country}</Typography>
        </Grid>
        <Grid item container direction="column" xs={12} sm={6}>
          <Typography variant="h6" gutterBottom className={classes.title}>
            Payment details
          </Typography>
          <Grid container>
            {payments.map((payment) => (
              <React.Fragment key={payment.name}>
                <Grid item xs={6}>
                  <Typography gutterBottom>{payment.name}</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography gutterBottom>{payment.detail}</Typography>
                </Grid>
              </React.Fragment>
            ))}
          </Grid>
        </Grid>
      </Grid>
    </React.Fragment>
  );
}