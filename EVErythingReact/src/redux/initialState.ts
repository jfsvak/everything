import charactersInitialState from './characters/initialState';
import accountsInitialState from './accounts/initialState';
import fittingsInitialState from './fittings/initialState';
import shoppingListsInitialState from './shoppingLists/initialState';

export default {
    accounts: accountsInitialState,
    characters: charactersInitialState,
    fittings: fittingsInitialState,
    shoppingLists: shoppingListsInitialState,
    ajaxCallsInProgress: 0
};
