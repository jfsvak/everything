//Type is in and out for within or new tab
export function navigate(history: any, url: string, replace?: boolean, newPage?: boolean): void {
    if (newPage)
        window.open(url, "_blank");
    else {
        if (location.hash.substr(1) !== url) {
            if (replace)
                history.replace(url);
            else
                history.push(url)
        }
    }
}
