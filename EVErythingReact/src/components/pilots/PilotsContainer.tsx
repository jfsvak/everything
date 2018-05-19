import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';


export interface IPilotsProps {

}

export interface IPilotsState {

}

class PilotsContainer extends React.Component<IPilotsProps, IPilotsState> {
    constructor(props: any) {
        super(props);
    }

    render() {
        return (
            <div>
                Here be Pilots
            </div>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {

    }
}

export default withRouter(connect(mapStateToProps)(PilotsContainer));