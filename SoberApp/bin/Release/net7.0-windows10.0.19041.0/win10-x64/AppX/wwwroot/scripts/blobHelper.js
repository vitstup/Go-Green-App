window.createBlobUrl = function (data, mimeType) {
    const blob = new Blob([new Uint8Array(data)], { type: mimeType });
    return URL.createObjectURL(blob);
}