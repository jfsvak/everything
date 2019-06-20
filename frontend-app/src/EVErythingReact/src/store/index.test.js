import configureStore from './configureStore.ts';
import * as actionTypes from '../models/constants/actionTypes';
import * as fittingsActions from '../redux/fittings/actions';
import { ActionsObservable } from 'redux-observable';
import { getFittingsEpic } from '../redux/epics';

const store = configureStore();

test('Store exists', () => {
    expect(store.getState()).not.toBeNull();
});

describe('get_fittings epic', () => {
    it('should have the fittings from the json mock loaded into state', () => {
        const action$ = ActionsObservable.of(fittingsActions.getFittings());
        return getFittingsEpic(action$).toPromise()
            .then((actionReceived) => {
                expect(actionReceived.type).toBe(actionTypes.GET_FITTINGS_SUCCESS)
            });
    });
});
// test('Dispatch getFittings', () => {
//     store.dispatch(fittingsActions.getFittings()).then(() => {
//         console.log(store.getState());
//     });

//     //expect(store.getState()).not.toBeNull();
// });