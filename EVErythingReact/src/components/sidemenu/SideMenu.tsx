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
            <div className="h-100 float-left" style={{backgroundColor: '#5F5', width: '100px'}}>
                Side menu<br/>
                <ul>
                    <li><Link to="/accounts">Accounts</Link></li>
                    <li><Link to={routePaths.MainRoutes.Pilots}>Pilots</Link></li>
                </ul>

            </div>
        );
    }
}

export default SideMenu;