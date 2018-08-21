import * as React from 'react';
import * as routePaths from '../../models/constants/routePaths';
import { Link } from 'react-router-dom';

export interface ITopMenuProps {

}

class TopMenu extends React.Component<ITopMenuProps> {

    constructor(props: ITopMenuProps) {
        super(props);
    }

    toggleSideBar(event) {
        //console.log('toggle sidebar');
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    }

    render() {
        return (
            <nav id="topbar" className="navbar navbar-expand-sm navbar-light bg-light">
                <button className="btn btn-dark d-inline-block d-sm-none ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    {/* <span className="navbar-toggler-icon"></span> */}
                    <i className="fas fa-align-justify"></i>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="nav navbar-nav">
                        <li className="nav-item">    
                            <button type="button" id="sidebarCollapse" onClick={this.toggleSideBar} className="btn btn-info">
                                <i className="far fa-align-left"></i>
                                {/* <span>Toggle Sidebar</span> */}
                            </button>
                        </li>
                        <li className="nav-item active">
                            <Link to={routePaths.MainRoutes.Characters} >
                                <i className="fa fa-address-card"></i>
                                Characters
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to={routePaths.MainRoutes.Accounts} >
                                <i className="far fa-address-card"></i>
                                Accounts
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to="#" >
                                <i className="far fa-address-card"></i>
                                My Fittings
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to={routePaths.MainRoutes.Characters} >
                                <i className="far fa-shopping-cart"></i>
                                Shopping Lists
                            </Link>
                        </li>
                        <li>
                            <a href="/Account/Logout">
                                <i className="fas fa-sign-out-alt"></i>
                                Sign out
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>
        );
    }
}

export default TopMenu;