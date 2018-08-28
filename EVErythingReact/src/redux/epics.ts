import 'rxjs';
import { combineEpics, ofType } from 'redux-observable';
import { delay, mapTo } from 'rxjs/operators'
// import { Observable } from 'rxjs/Observable';
// import { ajax } from 'rxjs/observable/dom/ajax';
import { GET_FITTINGS, GET_FITTINGS_SUCCESS } from '../models/constants/actionTypes';
import { getFittingsSuccess, getFittingsFailure } from './fittings/actions';
import { getJsonAsData, jsonTypes } from './common/api/mocks/mockService';

const getFittingsEpic = actions$ => actions$.pipe(
    ofType(GET_FITTINGS),
    delay(500),
    mapTo({ type: GET_FITTINGS_SUCCESS, resp: {status: 200, data: getJsonAsData(jsonTypes.GET_FITTINGS_API)}})
);
        
        // .mergeMap(action => 
        //     ajax.getJSON('/api/fittings')
        //         .map(resp => getFittingsSuccess(resp))
        //         .takeUntil(actions$.ofType(GET_FITTINGS))
        //         .retry(2)
        //         .catch(error => Observable.of(getFittingsFailure(error)))
        // );

export const rootEpic = combineEpics(
    getFittingsEpic
);