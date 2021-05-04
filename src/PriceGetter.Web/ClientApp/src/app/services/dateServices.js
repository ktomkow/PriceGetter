export const formatRawDate = (date) => {
  const newDate = new Date(date);
  const formattedDate = newDate.toLocaleDateString();
  return formattedDate;
};

export const formatDate = (month, year) => {
  if(month < 10) {
      month = '0' + month;
  }

  return `${month}.${year}`;
};
