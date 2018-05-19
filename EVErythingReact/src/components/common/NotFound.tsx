import * as React from 'react';
import { NavLink } from 'react-router-dom';

const NotFound: React.StatelessComponent = () => {
    return (
        <div>
            <h1>404</h1>
            <h4>Page Not Found Page Sample. Later Style it</h4>
            <NavLink to="/"> Go back to homepage </NavLink>
        </div>
    );
};

export default NotFound;
