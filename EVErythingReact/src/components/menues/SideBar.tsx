import * as React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as selectors from '../../redux/selectors';
import * as characterActions from '../../actions/characterActions';
import * as routePaths from '../../models/constants/routePaths';

export interface ISideBarProps {
    active: Boolean;
    characters: any;
    getCharacters: Function;
}

class SideBar extends React.Component<ISideBarProps> {

    constructor(props: ISideBarProps) {
        super(props);

        this.characterSubMenuHandler = this.characterSubMenuHandler.bind(this);
    }

    characterSubMenuHandler(event) {
        this.props.getCharacters();
    }

    render() {
        const { characters } = this.props;
        console.log('characters: ', characters);
        return (
            
            <nav id="sidebar" className="active">
                <div className="sidebar-header">
                    <h3>EVErything</h3>
                </div>

                <ul className="list-unstyled components" id="SideMenuGroup">
                    <li>
                        {/*style={{display: "inline", padding: "0px"}
                        <Link to={routePaths.MainRoutes.Characters}>
                        </Link>
                        */}
                        <Link to={routePaths.MainRoutes.Characters} >
                            <i className="fas fa-address-card"></i>
                            Characters
                        </Link>
                        {/* <a href="" onClick={this.characterSubMenuHandler} data-target="#charactersSubMenu" data-toggle="collapse" aria-expanded="false" className="dropdown-toggle">
                            <i className="fas fa-address-card"></i>
                            Characters
                        </a> 
                        <ul className="collapse list-unstyled" id="charactersSubMenu" data-parent="#SideMenuGroup">
                            {!characters && 
                                <li><a>{"<no chars>"}</a></li>
                            }
                            {characters && characters.map((c, idx) => 
                                <li key={idx}>
                                    <a href={"/characters/" + c.id}>{c.name}</a>
                                </li>
                            )}
                        </ul>
                        */}
                    </li>
                    <li>
                        <Link to={routePaths.MainRoutes.Accounts} >
                            <i className="fas fa-folder"></i>
                            Accounts
                        </Link>
                        {/* <a href="" data-target="#accountsSubMenu" data-toggle="collapse" aria-haspopup="true" aria-expanded="false" className="dropdown-toggle">
                            <i className="fas fa-folder"></i>
                            Accounts
                        </a> 
                        <ul className="collapse list-unstyled" id="accountsSubMenu" data-parent="#SideMenuGroup">
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
                        */}
                    </li>
                    {/* <li>
                        <a href="/">
                            <i className="fas fa-tachometer-alt"></i>
                            Dashboard
                        </a>
                    </li> */}
                    <li>
                        <a href="#">
                            <i className="fas fa-sign-out-alt"></i>
                            Fittings
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <i className="fas fa-sign-out-alt"></i>
                            Shopping List
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

function mapDispatchToProps(dispatch) {
    return {
        getCharacters: bindActionCreators(characterActions.getCharacters as any, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(SideBar);