export function empty(value: string) {
    if (value && value.length > 0)
        return false;
    return true;
}

export function zeroValue(value: number) {
    if (value && value >= 0)
        return false;
    return true;
}

export function length(value: string, length: number) {
    if (value && value.length === length)
        return false;
    return true;
}

export function equal(value: string, value2: string) {
    if (value && value2 && value === value2)
        return false;
    return true;
}

export function email(value: string) {
    return !/.+@.+\..+/.test(value);
}

export function cpr(value: string) {
    return !/[0-9]{2}[0,1][0-9][0-9]{2}(-?)[0-9]{4}?[^0-9]*/.test(value);
}
