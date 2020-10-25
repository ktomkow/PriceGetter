import { NOTIFICATIONS } from "../constants/action-types";

const initialState = {
  notifications: [],
};

function notificationsReducer(state = initialState, action) {
  if (action.type === NOTIFICATIONS.SHOW_SNACK_NOTIFICATION) {
    return Object.assign({}, state, {
      notifications: [
        ...state.notifications,
        {
          key: action.key,
          ...action.notification,
        },
      ],
    });
  }

  if (action.type === NOTIFICATIONS.HIDE_SNACK_NOTIFICATION) {
    const newNotifications = state.notifications.filter(x => x.key !== action.key);
    return Object.assign({}, state, {
      notifications: newNotifications
    });
  }

  return state;
}

export default notificationsReducer;
