import * as React from 'react';
import { Link } from 'react-router-dom';
import * as routePaths from '../../models/constants/routePaths';

export interface ISideMenuProps {

}

class SideMenu extends React.Component<ISideMenuProps> {
    constructor(props: ISideMenuProps) {
        super(props);
    }

    render() {
        return (
            <nav className="col-md-3 col-xs-1 p-l-0 p-r-0 collapse in" id="sidebar">
                <div className="sidebar-header">
                    <h3>Side menu</h3>
                </div>
                
                <ul className="list-unstyled components">
                    <li className="active"><a href="#">Home</a></li>

                    <li>
                        <a href="#accountsSubmenu" data-toggle="collapse" aria-expanded="false">Accounts</a>
                        <ul className="collapse list-unstyled" id="accountsSubmenu">
                            <li><a href="#">Account 1</a></li>
                            <li><a href="#">Account 2</a></li>
                        </ul>
                    </li>
                    <li><Link to={routePaths.MainRoutes.Pilots}>Pilots</Link></li>
                </ul>

            </nav>
        );
    }
}

export default SideMenu;