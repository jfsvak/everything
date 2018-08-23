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
            <nav id="topbar" className="navbar navbar-expand-md">
                <button className="btn btn-dark d-inline-block d-md-none ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    {/* Burger menu on small screens */}
                    <i className="fas fa-align-justify"></i>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="nav navbar-nav mr-auto">
                        <li className="nav-item d-none">    
                            <button className="nav-link btn btn-info" type="button" id="sidebarCollapse" onClick={this.toggleSideBar}>
                                {/* Sidebar Toggle  */}
                                <i className="fas fa-align-justify"></i>
                            </button>
                        </li>
                        <li className="nav-item active">
                            <Link to={routePaths.MainRoutes.Characters}>
                                <i className="fa fa-address-card"></i>
                                Characters
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to={routePaths.MainRoutes.Accounts} >
                                <i className="fas fa-address-book"></i>
                                Accounts
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to={routePaths.MainRoutes.Fittings} >
                                <i className="fas fa-ambulance"></i>
                                My Fittings
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to={routePaths.MainRoutes.ShoppingList} >
                                <i className="fas fa-shopping-cart"></i>
                                Shopping Lists
                            </Link>
                        </li>
                    </ul>
                    <ul className="nav navbar-nav">
                        <li className="nav-item">    
                            <a href="/Account/Logout" className="nav-link pr-0">
                                <i className="fas fa-sign-out-alt mr-0"></i>
                                <span className="d-md-none">Sign Out</span>
                            </a>
                        </li>
                    </ul>
                </div>
            </nav>
        );
    }
}

export default TopMenu;