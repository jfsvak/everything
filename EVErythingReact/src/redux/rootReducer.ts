import { combineReducers } from 'redux';
import ajaxCallsInProgress from './reducers/ajaxStatusReducer';
import accountsReducer from './reducers/accountsReducer';
import charactersReducer from './reducers/charactersReducer';

// we combine all the reducters here. dont forget all newely added reducers should add here
const rootReducer = combineReducers({
    accounts: accountsReducer,
    characters: charactersReducer,
    ajaxCallsInProgress
});

export default rootReducer;
