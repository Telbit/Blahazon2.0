import {useHistory} from 'react-router-dom';

let Redirect = (path) => {
    let history = useHistory();
    history.push(`/${path}`)
}

export default Redirect;