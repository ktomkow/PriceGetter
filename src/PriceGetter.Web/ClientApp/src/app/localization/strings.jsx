import LocalizedStrings from 'react-localization';

const strings = new LocalizedStrings({
    en: {
        HOME: {
            HELLO: "Hello, World!"
        },
        NOT_FOUND: {
            MESSAGE: "Sorry, the page you are looking for was not found :("
        },
        TOP_BAR: {
            TITLE: "Price Getter"
        }
    },
    pl: {
        HOME: {
            HELLO: "Witaj, Świecie!"
        }
    }
});

export default strings;