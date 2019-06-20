import configs from '../../../../configs';

export const enum jsonTypes {
    dummyAPI = "dummyAPI",
    GET_ACCOUNTS_API = "GET_ACCOUNTS_API",
    GET_CHARACTERS_API = "GET_CHARACTERS_API",
    GET_SHOPPINGLISTS_API = "GET_SHOPPINGLISTS_API",
    GET_FITTINGS_API = "GET_FITTINGS_API"
}

export function getJsonAsData(type: jsonTypes): any {
    let data: any;
    if (process.env.NODE_ENV !== 'production') {
        switch (type) {
            case jsonTypes.dummyAPI: 
                return require('./jsons/dummy.json');
            case jsonTypes.GET_ACCOUNTS_API: 
                return require('./jsons/accounts.json');
            case jsonTypes.GET_CHARACTERS_API: 
                return require('./jsons/characters.json');
            case jsonTypes.GET_SHOPPINGLISTS_API: 
                return require('./jsons/shoppingLists.json');
            case jsonTypes.GET_FITTINGS_API: 
                return require('./jsons/fittings.json');
        }
    }
    return data;
}

//This method will return the json data based on their types above
export function getJsonAsPromise(type: jsonTypes): any {
    return new Promise((resolve, reject) => { simulateDelayedData(resolve, getJsonAsData(type), 200, configs.delay) });
}

export function getPromise(data: any): any {
    return new Promise((resolve, reject) => { simulateDelayedData(resolve, data, 200, configs.delay) });
}

function simulateDelayedData(resolve: any, data: any, status: number, timeout: number): any {
    return setTimeout(() => { resolve(Object.assign({}, { status: status, data: data })); }, timeout);
}

