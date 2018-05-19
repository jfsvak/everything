import { combineReducers } from 'redux';
//common
import ajaxCallsInProgress from './shared/ajaxStatusReducer';
//dummy
import dummyResponse from './dummy/dummyReducer';

// we combine all the reducters here. dont forget all newely added reducers should add here
const rootReducer = combineReducers({
    ajaxCallsInProgress,
    dummyResponse
});

export default rootReducer;
