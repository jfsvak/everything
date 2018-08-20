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
            <section style={{border: "solid 1px", borderColor: "black"}}>
                <h1>Characters</h1><a href="/Home/EVESSoRedirect" className="btn btn-primary mb-3">Add</a>
                
                {characters && characters.map((c, idx) =>
                    <CharacterOverviewBar key={idx} character={c}/>
                )}
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