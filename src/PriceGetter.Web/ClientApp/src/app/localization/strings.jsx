import LocalizedStrings from 'react-localization';

let strings = new LocalizedStrings({
    en: {
        HOME: {
            HELLO: "Hello, World!"
        },
        NOT_FOUND: {
            MESSAGE: "Sorry, the page you are looking for was not found :("
        }
    },
    pl: {
        HOME: {
            HELLO: "Witaj, Świecie!"
        }
    }
});

export default strings;