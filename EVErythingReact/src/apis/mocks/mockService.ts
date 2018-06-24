import configs from '../../configs';

export const enum jsonTypes {
    dummyAPI = "dummyAPI",
    GET_ACCOUNTS_API = "GET_ACCOUNTS_API"
}

function getData(type: jsonTypes): any {
    let data: any;
    if (process.env.NODE_ENV !== 'production') {
        switch (type) {
            case jsonTypes.dummyAPI: return require('./jsons/dummy.json');

            case jsonTypes.GET_ACCOUNTS_API: 
                return require('./jsons/accounts.json');
        }
    }
    return data;
}

//This method will return the json data based on their types above
export function getJson(type: jsonTypes): any {
    return new Promise((resolve, reject) => { simulateData(resolve, getData(type), 200, configs.delay) });
}

function simulateData(resolve: any, data: any, status: number, timeout: number): any {
    return setTimeout(() => { resolve(Object.assign({}, { status: status, data: data })); }, timeout);
}

