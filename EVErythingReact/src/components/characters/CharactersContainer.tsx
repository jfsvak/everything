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
            <section className="p-2">
                <h2 className="d-flex justify-content-between m-3">
                    <span className="font-weight-bold text-light">Characters</span>
                    <a href="/Home/EVESSoRedirect" className="text-light"><i className="fas fa-user-plus"></i></a>
                </h2>
                <div id="characterCards" className="accordion">
                    {characters && characters.map((c, idx) =>
                        <CharacterOverviewBar key={idx} character={c}/>
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
    };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(CharactersContainer));