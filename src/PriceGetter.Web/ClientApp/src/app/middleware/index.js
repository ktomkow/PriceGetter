import { ADD_ARTICLE } from "../redux/constants/action-types";

const forbiddenWords = ["dupa", "kupa"];

export function forbiddenWordsMiddleware({ dispatch }) {
  return function (next) {
    return function (action) {
      if (action.type === ADD_ARTICLE) {
        const foundWord = forbiddenWords.filter((word) =>
          action.payload.title.includes(word)
        );

        if (foundWord.length) {
          alert("Not cool");
            return dispatch({ type: "FOUND_BAD_WORD" });
        }
      }
      return next(action);
    };
  };
}
