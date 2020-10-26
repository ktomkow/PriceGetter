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
    },
    CREATE_FORM: {
      PRODUCT_CREATE: {
        TITLE: "Create new product",
        LINK_INPUT_PLACEHOLDER: "Paste a link here",
        NAME_WILL_BE_HERE: "Product name will appear here"
      }
    },
    SINGLE_PRODUCT: {
      GO_BACK_BUTTON: "Go back to products",
      CHART: {
        TITLE: "Price ( zł )"
      },
      DATA_GRID: {
        AMOUNT_HEADER: "Amount",
        AMOUNT_DESCRIPTION: "Product price",
        DATE_HEADER: "Date",
        DATE_DESCRIPTION: "Day when the price was checked"
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
