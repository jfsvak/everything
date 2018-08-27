import { combineReducers } from 'redux';
import ajaxCallsInProgress from './common/reducers/ajaxStatusReducer';
import accountsReducer from './accounts/reducer';
import charactersReducer from './characters/reducer';
import fittingsReducer from './fittings/reducer';
import shoppingListsReducer from './shoppingLists/reducer';

// we combine all the reducters here. dont forget all newely added reducers should add here
const rootReducer = combineReducers({
    accounts: accountsReducer,
    characters: charactersReducer,
    fittings: fittingsReducer,
    shoppingLists: shoppingListsReducer,
    ajaxCallsInProgress
});

export default rootReducer;
