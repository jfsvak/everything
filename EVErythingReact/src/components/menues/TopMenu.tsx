import * as React from 'react';
import $ from 'jquery';

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
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <button type="button" id="sidebarCollapse" onClick={this.toggleSideBar} className="btn btn-info">
                        <i className="fas fa-align-left"></i>
                        <span>Toggle Sidebar</span>
                    </button>
                    <button className="btn btn-dark d-inline-block d-lg-none ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <i className="fas fa-align-justify"></i>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="nav navbar-nav ml-auto">
                            <li className="nav-item active">
                                <a className="nav-link" href="#">Page</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#">Page</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#">Page</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="#">Page</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}

export default TopMenu;