const redux = require('redux');

const createStore = redux.createStore;
const combineReducers = redux.combineReducers;

const types = {
    ADD_ACCOUNT: "ADD_ACCOUNT",
    ADD_PILOT: "ADD_PILOT"
};

const initialState = {
    accounts: { 
        byId: {
        }, 
        allIds: []
    },
    pilots: { 
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
        case types.ADD_PILOT: 
        {
            // find the account and duplicate it
            // concat the pilot id to pilotIds
            // put the account back in the object array
            const pilotId = action.pilot.id;
            const accountId = action.accountId;
            const account = state[accountId];
            
            return {
                ...state, 
                [accountId]: {
                    ...account,
                    pilotIds: account.pilotIds.concat(pilotId)
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

function pilotsById(state = initialState.pilots.byId, action) {
    // console.log('pilotsReducer: ', action);
    switch(action.type) {
        case types.ADD_PILOT:
            const pilot = {...action.pilot};
            const pilotId = pilot.id;

            return {
                ...state, 
                [pilotId]: pilot
            };
        default:
            return state;
    }
}

function allPilots(state = initialState.pilots.allIds, action) {
    switch(action.type) {
        case types.ADD_PILOT: 
            const pilotId = action.pilot.id;
            return state.concat(pilotId);
        default:
            return state;
    }
}

const accountsReducers = combineReducers({
    byId: accountsById,
    allIds: allAccounts
});

const pilotsReducers = combineReducers({
    byId: pilotsById,
    allIds: allPilots
});

const rootReducer = combineReducers({
    accounts: accountsReducers,
    pilots: pilotsReducers
});

function addPilot(accountId, pilotId, pilotName) {
    return {
        type: types.ADD_PILOT,
        pilot: {
            id: pilotId, 
            name: pilotName},
        accountId: accountId
    }
}

const store = createStore(rootReducer);

console.log('-----------------------');

function printState() {
    console.log('State:', JSON.stringify(store.getState()));
    console.log('Accounts:', store.getState().accounts);
    console.log('Account ASDF:', store.getState().accounts.byId["ASDF"]);
    console.log('Pilots:', store.getState().pilots);
}

store.subscribe(printState);

store.dispatch({type: types.ADD_ACCOUNT, account: {id: "ASDF", displayName: "Main account", pilotIds: [] }});
store.dispatch({type: types.ADD_ACCOUNT, account: {id: "QWER", displayName: "Alt account", pilotIds: [] }});
store.dispatch(addPilot("ASDF", "1", "Pilot 1"));
