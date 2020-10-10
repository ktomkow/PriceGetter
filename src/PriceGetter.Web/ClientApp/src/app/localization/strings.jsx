import LocalizedStrings from 'react-localization';

let strings = new LocalizedStrings({
    en: {
        HOME: {
            HELLO: "Hello, World!"
        }
    },
    pl: {
        HOME: {
            HELLO: "Witaj, Świecie!"
        }
    }
});

export default strings;