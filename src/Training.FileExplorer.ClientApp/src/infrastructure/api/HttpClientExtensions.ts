export {}

declare global {
    interface Object {
        toUrlSearchParams(): URLSearchParams;
    }
}

Object.defineProperty(Object.prototype, 'toUrlSearchParams', {
    value: function () {
        const params = new URLSearchParams();

        for (const [key, value] of Object.entries(this)) {
            if (Array.isArray(value)) {
                for (const item of value) {
                    params.append(key, item);
                }
            } else {
                params.set(key, (value as any).toString());
            }
        }

        return params;
    },
    writable: true,
    configurable: true,
});