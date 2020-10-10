import { preProducts } from "../constants/action-types";

export function addArticle(payload) {
  return { type: preProducts.SET_PREPRODDUCT, payload };
};

