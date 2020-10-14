import LocalizedStrings from "react-localization";

const strings = new LocalizedStrings({
  en: {
    HOME: {
      HELLO: "Hello, World!",
    },
    NOT_FOUND: {
      MESSAGE: "Sorry, the page you are looking for was not found :(",
    },
    LAYOUT: {
      TOP_BAR: {
        TITLE: "Price Getter",
      }
    },
    CARDS: {
      PRODUCT_CARD: {
        LAST_PRICE: "Last price: "
      }
    }
  },
  pl: {
    HOME: {
      HELLO: "Witaj, Świecie!",
    },
  },
});

export default strings;
