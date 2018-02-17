export default {
    login(user, pass, cb) {
        cb = arguments[arguments.length - 1];
        if (localStorage.tokenBinding) {
            if (cb) cb(true);
            this.onChange(true);
            return;
        }
    }
}