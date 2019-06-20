const redux = require('redux');

const createStore = redux.createStore;
const combineReducers = redux.combineReducers;

const types = {
    ADD_ACCOUNT: "ADD_ACCOUNT",
    ADD_CHARACTER: "ADD_CHARACTER",
    GET_CHARACTERS_SUCCESS: "GET_CHARACTERS_SUCCESS"
};

const initialState = {
    accounts: { 
        byId: {
        }, 
        allIds: []
    },
    characters: { 
        byId: {
        }, 
        allIds: []
    }
}

function accountsById(state = initialState.accounts.byId, action) {
    // console.log('accountsReducer: ', action);
    switch(action.type) {
        case types.ADD_ACCOUNT: 
        {
            // console.log('adding account');
            const account = {...action.account};
            const accountId = action.account.id;
            return {
                ...state, 
                [accountId]: account
            };
        }
        case types.ADD_CHARACTER: 
        {
            // find the account and duplicate it
            // concat the character id to characterIds
            // put the account back in the object array
            const characterId = action.character.id;
            const accountId = action.accountId;
            const account = state[accountId];
            
            return {
                ...state, 
                [accountId]: {
                    ...account,
                    characterIds: account.characterIds.concat(characterId)
                }
            };
        }
        default:
            return state;
    }
}

function allAccounts(state = initialState.accounts.allIds, action) {
    switch(action.type) {
        case types.ADD_ACCOUNT:
            const accountId = action.account.id;
            return state.concat(accountId);
        default:
            return state;
    }
}

function charactersById(state = initialState.characters.byId, action) {
    // console.log('charactersReducer: ', action);
    switch(action.type) {
        case types.GET_CHARACTERS_SUCCESS:
        {
            return action.resp.reduce(
                (acc, character) => ({ ...acc, [character.id]: character }),
                {}
            );
        }
        case types.ADD_CHARACTER:
            const character = {...action.character};
            const characterId = character.id;

            return {
                ...state, 
                [characterId]: character
            };
        default:
            return state;
    }
}

function allCharacters(state = initialState.characters.allIds, action) {
    switch(action.type) {
        case types.ADD_CHARACTER: 
            const characterId = action.character.id;
            return state.concat(characterId);
        default:
            return state;
    }
}

const accountsReducers = combineReducers({
    byId: accountsById,
    allIds: allAccounts
});

const charactersReducers = combineReducers({
    byId: charactersById,
    allIds: allCharacters
});

const rootReducer = combineReducers({
    accounts: accountsReducers,
    characters: charactersReducers
});

function addcharacter(accountId, characterId, characterName) {
    return {
        type: types.ADD_CHARACTER,
        character: {
            id: characterId, 
            name: characterName},
        accountId: accountId
    }
}

const getAccounts = state => {
    return state.accounts.byId
}

const store = createStore(rootReducer);

console.log('-----------------------');

function printState() {
    // console.log('State:', JSON.stringify(store.getState()));
    // console.log('Accounts:', store.getState().accounts);
    // console.log('Account ASDF:', store.getState().accounts.byId["ASDF"]);
    console.log('Characters:', store.getState().characters);
}

store.subscribe(printState);
store.dispatch({ type: types.GET_CHARACTERS_SUCCESS, resp: [{id: "ASDF", displayName: "Main account" }, {id: "QWERT", displayName: "Titan account" }, {id: "POIU", displayName: "Spai account" }] })
// store.dispatch({type: types.ADD_ACCOUNT, account: {id: "ASDF", displayName: "Main account", characterIds: [] }});
// store.dispatch({type: types.ADD_ACCOUNT, account: {id: "QWER", displayName: "Alt account", characterIds: [] }});
// store.dispatch(addcharacter("ASDF", "1", "Character"));
