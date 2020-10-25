import { NOTIFICATIONS } from "../constants/action-types";

export const showSnack = (text) => {
  const key = randomKey();
  const notification = {
    message: text,
    options: {
      variant: "warning",
    },
  };

  return {
    type: NOTIFICATIONS.SHOW_SNACK_NOTIFICATION,
    notification: notification,
    key: key,
  };
};

export const hideSnack = (key) => ({
  type: NOTIFICATIONS.HIDE_SNACK_NOTIFICATION,
  key: key,
});

const randomKey = () => {
  return new Date().getTime() + Math.random();
};
