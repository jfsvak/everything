import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import * as characterActions from '../../actions/characterActions';
import { bindActionCreators } from 'redux';
import * as selectors from '../../redux/selectors';
import CharacterOverviewBar from './CharacterOverviewBar';

export interface ICharactersState {
    
}

export interface ICharactersProps {
    getCharacters: Function;
    removeCharacter: Function;
    characters: any;
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
            <section className="p-3">
                    <h1>Characters</h1>
                <div className="d-flex justify-content-end mt-2 mb-2 align-items-baseline">
                    <a href="/Home/EVESSoRedirect" className="text-light d-inline"><i className="fas fa-user-plus"></i></a>
                </div>
                <div id="characterCards" className="accordion">
                    {characters && characters.map((c, idx) =>
                        <CharacterOverviewBar key={idx} character={c} removeCharacter={this.props.removeCharacter}/>
                    )}
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
        getCharacters: bindActionCreators(characterActions.getCharacters as any, dispatch),
        removeCharacter: bindActionCreators(characterActions.removeCharacter as any, dispatch)
    };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(CharactersContainer));