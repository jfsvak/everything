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
            <section className="p-3">
                <h1>Main...coming soon...</h1>
                <div className="container" style={{backgroundColor: 'lightblue'}}>
                    {/* <Switch>
                        <Routing path={routePaths.MainRoutes.Characters} component={CharactersContainer} props={null}/>
                    </Switch> */}
                </div>
            </section>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {};
}

export default withRouter(connect(mapStateToProps)(MainContainer));