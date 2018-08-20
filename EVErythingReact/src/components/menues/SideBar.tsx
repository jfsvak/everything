import * as React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import * as selectors from '../../redux/selectors';
import * as routePaths from '../../models/constants/routePaths';

export interface ISideBarProps {
    active: Boolean;
    characters: any;
}

class SideBar extends React.Component<ISideBarProps> {

    constructor(props: ISideBarProps) {
        super(props);
    }

    render() {
        const { characters } = this.props;
        console.log('characters: ', characters);
        return (
            
            <nav id="sidebar">
                <div className="sidebar-header">
                    <h3>EVErything</h3>
                </div>

                <ul className="list-unstyled components">
                    <li>
                        {/*style={{display: "inline", padding: "0px"}
                        <Link to={routePaths.MainRoutes.Characters}>
                        </Link>
                        */}
                        <a href="#charactersSubMenu" data-toggle="collapse" aria-expanded="false" className="dropdown-toggle">
                            <i className="fas fa-address-card"></i>
                            Characters
                        </a>
                        {characters &&
                            <ul className="collapse list-unstyled" id="charactersSubMenu">
                                {characters.map((c, idx) => 
                                    <li key={idx}>
                                        <a href="#">{c.name}</a>
                                    </li>
                                )}
                            </ul>
                        }
                    </li>
                    <li>
                        <a href="#accountsSubMenu" data-toggle="collapse" aria-expanded="false" className="dropdown-toggle">
                            <i className="fas fa-folder"></i>
                            Accounts
                        </a>
                        {/*<a href="#accountsSubMenu" data-toggle="collapse" aria-expanded="false" className="dropdown-toggle">
                        {routePaths.MainRoutes.Accounts}
                        </a>*/}
                        <ul className="collapse list-unstyled" id="accountsSubMenu">
                            <li>
                                <a href="#">Main</a>
                            </li>
                            <li>
                                <a href="#">Spai 1</a>
                            </li>
                            <li>
                                <a href="#">Titan alt</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="/">
                            <i className="fas fa-tachometer-alt"></i>
                            Dashboard
                        </a>
                    </li>
                    <li>
                        <a href="/Account/Logout">
                            <i className="fas fa-sign-out-alt"></i>
                            Sign out
                        </a>
                    </li>
                </ul>
            </nav>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {
        characters: selectors.getAllCharacters(state)
    };
}

export default connect(mapStateToProps)(SideBar);