import { combineReducers } from 'redux';
import ajaxCallsInProgress from './shared/ajaxStatusReducer';
import dummyResponse from './dummy/dummyReducer';
import accountsReducer from './shared/accountsReducer';

// we combine all the reducters here. dont forget all newely added reducers should add here
const rootReducer = combineReducers({
    accounts: accountsReducer,
    ajaxCallsInProgress,
    dummyResponse
});

export default rootReducer;
