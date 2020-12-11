import React, { useState } from 'react';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import axios from 'axios';
import Checkbox from '@material-ui/core/Checkbox';

export default function AddressForm() {
  
  const [FirstName, setFirstName] = useState();
  const [LastName, setLastName] = useState();
  const [Address1, setAddress1] = useState();
  const [Address2, setAddress2] = useState();
  const [City, setCity] = useState();
  const [Zip, setZip] = useState();
  const [Country, setCountry] = useState();

  const saveChanges = async(ev, callback) => {
    callback(ev.target.value);
    await axios.post('https://localhost:44309/api/Payment/address',
      {
          "FirstName": FirstName,
          "LastName": LastName,
          "Address1": Address1,
          "Address2": Address2,
          "City": City,
          "Zip": Zip,
          "Country": Country
      });
  }
  
  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom style={{fontFamily: 'BlahaFont'}}>
        Shipping address
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={6}>
          <TextField
            required
            id="firstName"
            name="firstName"
            label="First name"
            fullWidth
            autoComplete="given-name"
            onBlur={(ev) => {saveChanges(ev, setFirstName)}}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            required
            id="lastName"
            name="lastName"
            label="Last name"
            fullWidth
            autoComplete="family-name"
            onBlur={(ev) => {saveChanges(ev, setLastName)}}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            required
            id="address1"
            name="address1"
            label="Address line 1"
            fullWidth
            autoComplete="shipping address-line1"
            onBlur={(ev) => {saveChanges(ev, setAddress1)}}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            id="address2"
            name="address2"
            label="Address line 2"
            fullWidth
            autoComplete="shipping address-line2"
            onBlur={(ev) => {saveChanges(ev, setAddress2)}}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            required
            id="city"
            name="city"
            label="City"
            fullWidth
            autoComplete="shipping address-level2"
            onBlur={(ev) => {saveChanges(ev, setCity)}}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField id="state" name="state" label="State/Province/Region" fullWidth />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            required
            id="zip"
            name="zip"
            label="Zip / Postal code"
            fullWidth
            autoComplete="shipping postal-code"
            onBlur={(ev) => {saveChanges(ev, setZip)}}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            required
            id="country"
            name="country"
            label="Country"
            fullWidth
            autoComplete="shipping country"
            onBlur={(ev) => {saveChanges(ev, setCountry)}}
          />
        </Grid>
        <Grid item xs={12}>
          <FormControlLabel
            control={<Checkbox color="secondary" name="saveAddress" value="yes" />}
            label="Use this address for payment details"
          />
        </Grid>
      </Grid>
    </React.Fragment>
  );
}