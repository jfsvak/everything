import configureStore from './src/store/configureStore';
import * as types from './src/models/constants/actionTypes';
import * as selectors from './src/redux/selectors';
import * as characterActions from './src/redux/characters/actions';


const store = configureStore();

console.log("---------------------START----------------------");


function printState() {
    // console.log('State:', JSON.stringify(store.getState()));
    // console.log('Accounts:', store.getState().accounts);
    // console.log('Account ASDF:', store.getState().accounts.byId["ASDF"]);
    console.log('Characters:', store.getState().characters);
}

store.subscribe(printState);
store.dispatch(
    {
        type: types.GET_CHARACTERS_SUCCESS, 
        resp: {
            data: [
                {
                    "id": "2113547503",
                    "name": "Iam Outamon2",
                    "characterSetID":"6ae5b6a0-6f6d-4dc4-df3c-08d600e42a24",
                    "accountID":null
                },
                {
                    "id": "2113884986",
                    "name": "Inna Numa",
                    "characterSetID":"6ae5b6a0-6f6d-4dc4-df3c-08d600e42a24",
                    "accountID":null
                },
                {
                    "id": "907836159",
                    "name": "halloway",
                    "characterSetID":"6ae5b6a0-6f6d-4dc4-df3c-08d600e42a24",
                    "accountID":null
                }
            ]
        }
    }
);

//characterActions.addCharacter();
store.dispatch({ type: types.ADD_CHARACTER_SUCCESS, character:
    {
        "id": "1734929785",
        "name": "MissMoney",
        "characterSetID":"6ae5b6a0-6f6d-4dc4-df3c-08d600e42a24",
        "accountID":null
    }
});

let characters = selectors.getAllCharacters(store.getState());
console.log("Characters from Selector:", characters);


store.dispatch({
    type: types.REMOVE_CHARACTER_SUCCESS,
    id: '2113884986'
});

// characters = selectors.getAllCharacters(store.getState());
// console.log("Characters after removal:", characters);

console.log("----------------------END----------------------");