import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import rootReducer from '../redux/rootReducer';
import { composeWithDevTools } from 'redux-devtools-extension';
import { createEpicMiddleware } from 'redux-observable';
import { rootEpic } from '../redux/epics';

const epicMiddleware = createEpicMiddleware();

// Be sure to ONLY add this middleware in development!
const middleware = process.env.NODE_ENV !== 'production' ?
  [require('redux-immutable-state-invariant').default(), thunk] :
  [thunk];

function configureStore(initialState?: any) {
    const store = createStore(
        rootReducer,
        initialState,
        composeWithDevTools(applyMiddleware(...middleware, epicMiddleware))
    );

    epicMiddleware.run(rootEpic);
    
    return store;
}

export default configureStore;
