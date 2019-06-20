import * as React from 'react';
import { connect } from 'react-redux';
import * as selectors from '../../redux/selectors';
import { getFittings } from '../../redux/fittings/actions';

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
        const { fittings } = this.props;
        return (
            <section className="p-3">
            <h1>
                Fittings
            </h1>
            <p> Here be fittings...coming soon...</p>
            <div>
                {fittings && fittings.map((fitting, idx) =>
                    <div className="card" key={idx}>
                        <p>Fitting id: {fitting.id}</p>
                        <p>Fitting name: {fitting.id}</p>
                    </div>
                )}
            </div>
        </section>
        );
    }
}

const mapStateToProps = (state, ownProps) => ({
    fittings: selectors.getAllFittings(state)
});

const mapDispatchToProps = {
    getFittings: getFittings
};

export default connect(mapStateToProps, mapDispatchToProps)(FittingsContainer);