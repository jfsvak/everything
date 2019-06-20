export function cprFormatter(value: string) {
    let returnValue = value;
    if (value != null && (value.length > 9 && value.length <= 10)) {
        if (value.indexOf("-") == -1)
            returnValue = value.substring(0, 6) + "-" + value.substring(6);
    }
    return returnValue;
}