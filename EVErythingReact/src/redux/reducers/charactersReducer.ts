import { combineReducers } from 'redux';
import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';

function charactersById(state = initialState.characters.byId, action) {
    switch(action.type) {
        case types.GET_CHARACTERS_SUCCESS: 
        {
            //[{id:"123", name:"Spai 1"}, {id:"123", name:"Spai 1"}]
            return action.resp.data.reduce(
                (acc, character) => ({ ...acc, [character.id]: character }),
                {}
            );
        }
        case types.ADD_CHARACTER_SUCCESS: 
        {
            const character = {...action.character};
            const characterId = character.id;
            
            return {
                ...state, 
                [characterId]: character
            };
        }
        case types.ADD_CHARACTER_FAILURE:
            return state;
        default:
            return state;
    }
}

function allCharacters(state = initialState.characters.allIds, action) {
    switch(action.type) {
        case types.ADD_CHARACTER_SUCCESS: 
            const characterId = action.character.id;
            return state.concat(characterId);
        default:
            return state;
    }
}

export default combineReducers({
    byId: charactersById,
    allIds: allCharacters
});