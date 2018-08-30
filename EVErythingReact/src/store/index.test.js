import configureStore from './configureStore.ts';

const store = configureStore();

test('Store exists', () => {
    expect(store.getState()).not.toBeNull();
});