import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import * as characterActions from '../../actions/characterActions';
import { bindActionCreators } from 'redux';
import * as selectors from '../../reducers/selectors';
import CharacterOverviewBar from './CharacterOverviewBar';

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
            <section>
                <h1>Characters</h1>
                <ul className="list-group">
                    {characters && characters.map((c, idx) =>
                        <li className="list-group-item"><CharacterOverviewBar key={idx} character={c}/></li>
                    )}
                </ul>
                <div className="float-right">
                    <button type="button" className="btn btn-primary">Add</button>
                </div>
            </section>
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