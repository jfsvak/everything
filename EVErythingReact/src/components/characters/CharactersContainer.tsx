import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import * as characterActions from '../../actions/characterActions';
import { bindActionCreators } from 'redux';
import * as selectors from '../../reducers/selectors';

export interface ICharactersState {
    
}

export interface ICharactersProps {
    getCharacters: Function,
    characters: any
}

class CharactersContainer extends React.Component<ICharactersProps, ICharactersState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount() {
        this.props.getCharacters();
    }

    render() {
        const { characters } = this.props;
        return (
            <div>
                {characters && characters.map((item, idx) =>
                    <div key={idx}>{item.id} - {item.name}</div>
                )}
            </div>
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

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(CharactersContainer));