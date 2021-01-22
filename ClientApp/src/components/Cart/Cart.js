import React, {useState, useEffect} from 'react';
import Modal from 'react-awesome-modal';
import { Grid } from '@material-ui/core';
import CartCard from './CartCard';
import { makeStyles } from '@material-ui/core/styles';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import axios from 'axios';
import { CircularProgress } from '@material-ui/core';
import { Link } from 'react-router-dom';

const useStyles = makeStyles({
    title: {
        textAlign: "center",
        color: "black"
    },
    main: {
        padding: 10
    },
    buttonContainer: {
        textAlign: "right",
        padding: 5
    },
    icon: {
        marginTop: 20,
        fontSize: 40
    }
})

//localhoststb: szamok / api / Cart
//localhoststb: szamok / api / Cart / (id)

export default function Cart(props) {
    let classes = useStyles();

    const [loading, setLoading] = useState();
    const [visible, setVisible] = useState(false);
    const [items, setItems] = useState([]);

    //{Id: 1, Quantity: 2, Title: "Black Race Tshirt", Type: "Tshirt", Price: 30, ImagePath: "https://i.pinimg.com/originals/4e/be/50/4ebe50e2495b17a79c31e48a0e54883f.png"}
                    //, { Id: 2, Quantity: 1, Title: "Big Black Nigga Shirt", Type: "Tshirt", Price: 20, ImagePath: "https://i.pinimg.com/originals/4e/be/50/4ebe50e2495b17a79c31e48a0e54883f.png" }
                    //, { Id: 3, Quantity: 1, Title: "White Tshirt", Type: "Tshirt", Price: 10, ImagePath: "https://i.pinimg.com/originals/4e/be/50/4ebe50e2495b17a79c31e48a0e54883f.png" },

    const calculateQuantity = (itemsList) => {
        let tmpProducts = {}
        for (let itm in itemsList) {
            if (itm.id in tmpProducts){
                
            }
        }
    }
                                            
    const openModal = () => {
        setLoading(true)
        axios('https://localhost:44309/api/Cart')
            .then((res) => {
                let products = calculateQuantity(res.data);
                setItems(res.data);
                setLoading(false);
            });
        setVisible(true);
    }

    const closeModal = () => {
        setVisible(false);
    }

    return (
        <>
            <ShoppingCartIcon className={classes.icon} onClick={() => openModal()} />
            {loading ? <div><CircularProgress /></div> : (
            <Modal
                visible={visible}
                width="500"
                height="500"
                effect="fadeInUp"
                onClickAway={() => closeModal()}
            >
                <div className={classes.main}>
                    <div className={classes.buttonContainer}><button onClick={() => closeModal()}>Close</button></div>
                    <div id="grid">
                        <Grid container
                            spacing={3}
                            direction="row"
                            alignItems="center">
                            {/* to component TitleList*/}
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
                            </Grid>
                            {/* /to component */}
                            {/* to component ProductList */}
                            {items.map((product) =>
                                <Grid item xs={12}>
                                    <CartCard product={product} />
                                </Grid>)
                            }
                            {/* /to component*/}
                        </Grid>
                    </div>
                    <div className={classes.buttonContainer}><Link to='/checkout'><button>Checkout</button></Link></div>
                </div>
            </Modal>)}
                        
        </>
    )
}
