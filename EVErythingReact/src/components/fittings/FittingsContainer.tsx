import * as React from 'react';
import { connect } from 'react-redux';
import * as selectors from '../../redux/selectors';
import { bindActionCreators } from 'redux';
import * as fittingsActions from '../../redux/fittings/actions';

interface IFittingsContainerProps {
    fittings: any;
    getFittings: Function;
}

class FittingsContainer extends React.Component<IFittingsContainerProps> {
    constructor(props: IFittingsContainerProps) {
        super(props);
    }

    componentWillMount() {
        this.props.getFittings();
    }
    
    render() {
        return (
            <section className="p-3">
            <h1>
                Fittings
            </h1>
            <p>
                Here be fittings...coming soon...
            </p>
        </section>
        );
    }
}


function mapStateToProps(state, ownProps) {
    return {
        fittings: selectors.getAllFittings(state)
    }
}

function mapDispatchToProps(dispatch) {
    return {
        getFittings: bindActionCreators(fittingsActions.getFittings as any, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(FittingsContainer);