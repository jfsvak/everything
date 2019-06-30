//API CALL TYPE
const TYPE_LOCAL = "LOCAL";
const TYPE_REST = "REST";

//LANGUAGES
export const LANG_EN = "en", LANG_DK = "dk", LANG_SW = "sw";

//resources
const SOCKET_URL = "http://lasdfocalhost:5001";

//CONFIG DATA (Please change here only)
const configs = {
    delay: 500,
    socket: SOCKET_URL,
    toastDelay: 5000,
    type: TYPE_REST,
    lang: LANG_EN,
    activateSW: false,
    verNo: 0.1
}

export function isLocal() {
    return configs.type === TYPE_LOCAL;
};

export default configs;