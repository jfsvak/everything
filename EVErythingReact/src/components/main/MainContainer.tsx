import * as React from 'react';
import { withRouter, Switch, Route } from 'react-router-dom';
import { connect } from 'react-redux';
import CharactersContainer from '../characters/CharactersContainer';
import * as routePaths from '../../models/constants/routePaths';
import Routing from '../Routing';

export interface IMainContainerProps {

}

export interface IMainContainerState {

}

class MainContainer extends React.Component<IMainContainerProps, IMainContainerState> {
    constructor(props: IMainContainerProps) {
        super(props);
    }

    render() {
        return (
            <div className="fullpage-wrapper" style={{backgroundColor: 'red', height: '300px'}}>
                This guy should layout the top bar, side menu, footer etc.
                and then switch the main content with a router depending on the route
                <div className="container" style={{backgroundColor: 'lightblue'}}>
                    <Switch>
                        <Routing path={routePaths.MainRoutes.Characters} component={CharactersContainer} props={null}/>
                    </Switch>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {};
}

export default withRouter(connect(mapStateToProps)(MainContainer));