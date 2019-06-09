import { combineReducers } from 'redux';
import * as types from '../../models/constants/actionTypes';
import initialState from './initialState';

function charactersById(state = initialState.byId, action) {
    switch(action.type) {
        case types.GET_CHARACTERS_SUCCESS: 
        {
            return action.resp.data.reduce(
                (accumulator, character) => ({ ...accumulator, [character.id]: character }),
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
        case types.REMOVE_CHARACTER_SUCCESS:
            // Reduce the object array only including the keys with key !== action.characterId 
            return Object.keys(state).reduce((newState, characterId) => {
                if (characterId !== action.id) {
                    newState[characterId] = state[characterId];
                }
                return newState;
            }, {});
        default:
            return state;
    }
}

function allCharacters(state = initialState.allIds, action) {
    switch(action.type) {
        case types.GET_CHARACTERS_SUCCESS: 
        {
            return action.resp.data.reduce(
                (acc, character) => [...acc, character.id],
                []
            );
        }
        case types.ADD_CHARACTER_SUCCESS: 
            const characterId = action.character.id;
            return state.concat(characterId);
        case types.REMOVE_CHARACTER_SUCCESS:
            // slice the list of ids to exclude (remove) the action.characterId
            return state.filter(id => id !== action.id);
        default:
            return state;
    }
}

export default combineReducers({
    byId: charactersById,
    allIds: allCharacters
});