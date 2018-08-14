import * as React from 'react';

function TopMenu(props) {
    return (
        <nav className="topnav">
            <a className="topnav-brand" href="#">EVErything</a>
            <div className="collapse topnav-collapse" id="topnavNav">
                <ul className="topnav-nav">
                <li className="nav-item active">
                    <a className="nav-link" href="#">Home <span className="sr-only">(current)</span></a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="#">Features</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="#">Pricing</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link disabled" href="#">Disabled</a>
                </li>
                </ul>
            </div>
        </nav>
    );
}

export default TopMenu;