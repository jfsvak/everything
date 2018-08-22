import * as React from 'react';
import { Switch, Route, withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import * as Loadable from 'react-loadable';
import Routing from "./Routing";
import * as routePaths from '../models/constants/routePaths';
import Loader from './common/Loader';
import { getLanguage, changeLanguage } from '../utils/languageUtil';
import { AppLanguageText } from '../models/languageModel';
import SideBar from './menues/SideBar';
import TopMenu from './menues/TopMenu';
import * as accountsActions from '../actions/accountsActions';

//Here we are asynchronous loading our components based on their path
const MainContainer = Loadable({ loader: () => import('./main/MainContainer'), loading: () => null});
const AccountsContainer = Loadable({ loader: () => import('./accounts/AccountsContainer'), loading: () => null });
const CharactersContainer = Loadable({ loader: () => import('./characters/CharactersContainer'), loading: () => null });
const NotFound = Loadable({ loader: () => import('./common/NotFound'), loading: () => null });

export interface IAppProps {
    progress: number;
    dispatch: Function;
}

export interface IAppState {
    propExample: string;
    language: AppLanguageText;
}

class App extends React.Component<IAppProps, IAppState>  {
    constructor(props: any) {
        super(props);

        this.state = {
            propExample: 'Parent props',
            language: getLanguage()
        }

        this.changeLang = this.changeLang.bind(this);
    }

    componentDidMount(): void {
        const { dispatch } = this.props;
        dispatch(accountsActions.getAccounts());
    }

    changeLang(code: string): void {
        changeLanguage(code, (newLanguage): void => {
            this.setState({ language: newLanguage })
        })
    }

    render() {
        const propsToSend = {
            example: this.state.propExample,
            language: this.state.language,
            changeLanguage: this.changeLang
        }
        return (
            <div className="wrapper" style={{backgroundColor: "lightGreen"}}>
                <SideBar />

                <div id="content" className="active">
                    <TopMenu />
                    <div className="container-fluid">
                        <Switch>
                            <Routing path="/" exact component={MainContainer} props={propsToSend}/>
                            <Routing path={routePaths.MainRoutes.Accounts} component={AccountsContainer} props={propsToSend}/>
                            <Routing path={routePaths.MainRoutes.Characters} component={CharactersContainer} props={propsToSend}/>
                        </Switch>
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
