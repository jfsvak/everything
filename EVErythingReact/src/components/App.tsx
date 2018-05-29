import * as React from 'react';
import { Switch, Route, withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as Loadable from 'react-loadable';
import Routing from "./Routing";
import * as routePaths from '../models/constants/routePaths';
import Loader from './common/Loader';
import { getLanguage, changeLanguage } from '../utils/languageUtil';
import { AppLanguageText } from '../models/languageModel';
//import SideMenu from './sidemenu/SideMenu';

//Here we are asynchronous loading our components based on their path
const MainContainer = Loadable({ loader: () => import('./main/MainContainer'), loading: () => null});
const PilotsContainer = Loadable({ loader: () => import('./pilots/PilotsContainer'), loading: () => null });
const NotFound = Loadable({ loader: () => import('./common/NotFound'), loading: () => null });

export interface IAppProps {
    progress: number;
}

export interface IAppState {
    propExample: string;
    language: AppLanguageText;
}

class App extends React.Component<IAppProps, IAppState>  {
    private wrapperDiv: React.RefObject<HTMLDivElement>;

    constructor(props: any) {
        super(props);

        this.state = {
            propExample: 'Parent props',
            language: getLanguage()
        }

        this.changeLang = this.changeLang.bind(this);
        this.toggleMenu = this.toggleMenu.bind(this);

        this.wrapperDiv = React.createRef();
    }

    changeLang(code: string): void {
        changeLanguage(code, (newLanguage): void => {
            this.setState({ language: newLanguage })
        })
    }

    toggleMenu(event) {
        const wrap = this.wrapperDiv.current;
        wrap.classList.toggle("toggled");
    }

    render() {
        const propsToSend = {
            example: this.state.propExample,
            language: this.state.language,
            changeLanguage: this.changeLang
        }
        return (
            <div id="wrapper" ref={this.wrapperDiv}>
                <div id="sidebar-wrapper">
                    <ul className="sidebar-nav">
                        <li className="sidebar-brand">
                            <a href="#">
                                Start Bootstrap
                            </a>
                        </li>
                        <li>
                            <a href="#">Dashboard</a>
                        </li>
                        <li>
                            <a href="#">Shortcuts</a>
                        </li>
                        <li>
                            <a href="#">Overview</a>
                        </li>
                        <li>
                            <a href="#">Events</a>
                        </li>
                        <li>
                            <a href="#">About</a>
                        </li>
                        <li>
                            <a href="#">Services</a>
                        </li>
                        <li>
                            <a href="#">Contact</a>
                        </li>
                    </ul>
                </div>

                
                <div id="page-content-wrapper">
                    <div className="container-fluid">
                        <h1>Simple Sidebar</h1>
                        <p>This template has a responsive menu toggling system. The menu will appear collapsed on smaller screens, and will appear non-collapsed on larger screens. When toggled using the button below, the menu will appear/disappear. On small screens, the page content will be pushed off canvas.</p>
                        <p>Make sure to keep all page content within the <code>#page-content-wrapper</code>.</p>
                        <a href="#menu-toggle" onClick={this.toggleMenu} className="btn btn-secondary" id="menu-toggle">Toggle Menu</a>
                    </div>
                </div>

            </div>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {
        progress: state.ajaxCallsInProgress
    };
}

export default withRouter(connect(mapStateToProps)(App));
