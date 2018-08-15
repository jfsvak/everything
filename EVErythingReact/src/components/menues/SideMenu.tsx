import * as React from 'react';
import { Link } from 'react-router-dom';
import * as routePaths from '../../models/constants/routePaths';

export interface ISideMenuProps {

}

class SideMenu extends React.Component<ISideMenuProps> {
    formRef: any;

    constructor(props: ISideMenuProps) {
        super(props);

        this.logout = this.logout.bind(this);
        this.formRef = React.createRef();
    }

    logout() {
        this.formRef.current.submit();
    }

    render() {
        return (
            <nav id="sidebar-wrapper">
                <ul className="sidebar-nav list-group">
                    <li className="sidebar-brand">
                        <a href="#">EVErything</a>
                    </li>
                    <li>
                        <Link to={routePaths.MainRoutes.Characters}>Characters</Link>
                    </li>
                    <li>
                        <Link to={routePaths.MainRoutes.Accounts}>Accounts</Link>
                    </li>
                    <li>
                        <a href="#">Dashboard</a>
                    </li>
                    <li>
                        <a href="/Account/Logout">Sign out</a>
                    </li>
                </ul>
            </nav>
        );
    }
}

export default SideMenu;