import * as React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { HashRouter } from 'react-router-dom';
import configureStore from './store/configureStore';
import configs from './configs';
import App from './components/App';
import './favicon.ico';
import './styles/main.less';
import './styles/custom2.css';

// Configure the store and pass it to provider to wrap it
const store = configureStore();

//Use browserHistory if your are going to use URL without hash
render(
    <Provider store={store} >
        <HashRouter>
            <App />
        </HashRouter>
    </Provider>, document.getElementById('app') as HTMLElement
);

//Here we try to register our service worker to catch static resources
(function () {

    if ('serviceWorker' in navigator && configs.activateSW && configs.type === 'REST') {
        console.log('Service worker is available in navigator');
        navigator.serviceWorker.register('service-worker.js').then(function (reg) {
            console.log('registering service worker', reg);

            reg.onupdatefound = function () {

                var installingWorker = reg.installing;

                installingWorker.onstatechange = function () {
                    switch (installingWorker.state) {
                        case 'installed':
                            if (navigator.serviceWorker.controller) {
                                // At this point, the old content will have been purged and the fresh content will have been added to the cache.
                                // It's the perfect time to display a "New content is available; please refresh."
                                console.log('New or updated content is available.');
                            } else {
                                // At this point, everything has been precached.
                                // It's the perfect time to display a "Content is cached for offline use." message.
                                console.log('Content is now available offline!');
                            }
                            break;

                        case 'redundant':
                            console.error('The installing service worker became redundant.');
                            break;
                    }
                };
            };
        }).catch(function (e) {
            console.error('Error during service worker registration:', e);
        });
    }
})();
