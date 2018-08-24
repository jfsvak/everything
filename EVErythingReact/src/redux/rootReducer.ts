import { combineReducers } from 'redux';
import ajaxCallsInProgress from './common/reducers/ajaxStatusReducer';
import accountsReducer from './accounts/reducer';
import charactersReducer from './characters/reducer';

// we combine all the reducters here. dont forget all newely added reducers should add here
const rootReducer = combineReducers({
    accounts: accountsReducer,
    characters: charactersReducer,
    ajaxCallsInProgress
});

export default rootReducer;
