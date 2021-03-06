//API CALL TYPE
const TYPE_LOCAL = "LOCAL";
const TYPE_REST = "REST";

//LANGUAGES
const LANG_EN = "en";
const LANG_DK = "dk";
const LANG_SW = "sw";

//resources
const SOCKET_URL = "http://localhost:5001";

//CONFIG DATA (Please change here only)
const configs = {
    delay: 500,
    socket: SOCKET_URL,
    toastDelay: 5000,
    type: TYPE_LOCAL,
    lang: LANG_EN,
    activateSW: false,
    verNo: 0.1
}
export default configs;
