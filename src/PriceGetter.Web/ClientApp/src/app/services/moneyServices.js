export const formatMoneyAndAddPLN = (money) => {
  const formattedMoney = formatMoney(money);

  const moneyWithCurrency = formattedMoney + " zł";

  return moneyWithCurrency;
};

export const formatMoney = (money) => {
  const roundedAmount = parseFloat(money).toFixed(2);
  const roundedAmountWithComa = roundedAmount.replace('.',',');
  return roundedAmountWithComa;
};

export const round = money => {
  const roundedAmount = Math.round(money * 100) / 100
  return roundedAmount;
}