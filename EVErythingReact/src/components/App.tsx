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
    constructor(props: any) {
        super(props);

        this.state = {
            propExample: 'Parent props',
            language: getLanguage()
        }

        this.changeLang = this.changeLang.bind(this);
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
            <div className="app-container" style={{border: 'solid', backgroundColor: 'black'}}>

                <Loader callsInProgress={this.props.progress} />

                <Switch>
                    <Routing path="/" exact component={MainContainer} props={propsToSend} />
                    <Routing path="*" component={NotFound} props={null} />
                </Switch>
                <div className="fixed-bottom">{this.state.language.shared.title} and number of ajax in progress: {this.props.progress}</div>
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
