export const toBase64 = (string) => {
  const encoded = btoa(string);

  return encoded;
};
