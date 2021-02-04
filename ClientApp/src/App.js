import {React, useState} from 'react';
import Navbar from './components/Navbar/Navbar';
import {Product} from './components/Product';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import {ProductList} from './components/ProductList';
import ProductGrid from './components/Grids/ProductGrid';
import './App.css'
import Customize from './components/Customization/Customize';
import Checkout from './components/Checkout/Checkout';
import {ThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import Registration from './components/User/Registration';
import Login from './components/User/Login';
import Logout from './components/User/Logout';

function App() {

  const [isSession, setIssession] = useState(false);

  const THEME = createMuiTheme({
    typography: {"fontFamily": "Blahafont"}
  });

  return (
    <ThemeProvider theme={THEME}>
      <Router>
        <div>
          <Navbar isSession={isSession} setIssession={setIssession}/>
          <Switch>
            <Route path="/" exact component={ProductList} />
            <Route path="/products" exact component={ProductGrid} />
            <Route path="/product/:id" component={Product} />
            <Route path="/customize/:id" exact component={Customize} />
            <Route path="/checkout" exact component={Checkout} />
            <Route path="/registration" exact component={Registration}/>
            <Route path="/login" exact component={Login} isSess={isSession} setIssess={setIssession}/>
            <Route path="/logout" exact component={Logout}/>
          </Switch>
        </div>
      </Router>
    </ThemeProvider>
  );
}

export default App;
