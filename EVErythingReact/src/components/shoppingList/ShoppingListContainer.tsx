import * as React from 'react';
import * as selectors from '../../redux/selectors';
import { bindActionCreators } from 'redux';
import * as actions from '../../redux/shoppingLists/actions';
import { connect } from 'react-redux';


interface IShoppingListContainerProps {
    shoppingLists: any;
    getShoppingLists: Function;
}

class ShoppingListContainer extends React.Component<IShoppingListContainerProps> {
    constructor(props: IShoppingListContainerProps) {
        super(props);
    }

    componentDidMount() {
        this.props.getShoppingLists();
    }

    render() {
        return (
            <section className="p-3">
                <h1>Shopping list</h1>
                <p>Here be shopping lists ... coming soon (TM)...</p>
            </section>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {
        shoppingLists: selectors.getAllShoppingLists(state)
    }
}

function mapDispatchToProps(dispatch) {
    return {
        getShoppingLists: bindActionCreators(actions.getShoppingLists as any, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ShoppingListContainer);
