import { NOTIFICATIONS } from "../constants/action-types";

export const showInfoSnack = (text) => {
  const notification = createNotification(text, "info");
  return notification;
};


export const showWarningSnack = (text) => {
  const notification = createNotification(text, "warning");
  return notification;
};

export const createNotification = (text, option) => {
  const key = randomKey();
  const notification = {
    message: text,
    options: {
      variant: option,
      autoHideDuration: 2000,
    }
  };

  const pack = {
    type: NOTIFICATIONS.SHOW_SNACK_NOTIFICATION,
    notification: notification,
    key: key,
  };

  return pack;
};

export const hideSnack = (key) => ({
  type: NOTIFICATIONS.HIDE_SNACK_NOTIFICATION,
  key: key,
});

const randomKey = () => {
  return new Date().getTime() + Math.random();
};
