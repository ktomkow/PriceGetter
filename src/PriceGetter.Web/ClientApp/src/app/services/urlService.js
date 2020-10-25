export const isUrlValid = (url) => {
  // looks a little stupid but works
  try {
    new URL(url);
  } catch (_) {
    return false;
  }

  return true;
};
