import { PRODUCTS_ACTIONS } from "../constants/action-types";

import axios from "axios";

export function getProducts() {
  console.log("Dupa");
  const payload = { name: "dupa", price: "10.99", id: Math.random()};
  return { type: PRODUCTS_ACTIONS.GET_ALL_PRODUCTS, payload: payload };
}
