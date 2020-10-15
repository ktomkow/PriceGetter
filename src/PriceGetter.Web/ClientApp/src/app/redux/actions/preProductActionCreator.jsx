import { PRE_PRODUCTS_ACTIONS } from "../constants/action-types";

import { toBase64 } from "../../services/encodingService";

import axios from "axios";

export const getPreproduct = (link, dispatch) => {
    const encodedUrl = toBase64(link);
    dispatch({ type: PRE_PRODUCTS_ACTIONS.GET, payload: encodedUrl });
}
