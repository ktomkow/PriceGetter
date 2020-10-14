export const formatRawDate = date => {
    const newDate = new Date(date);
    const formattedDate = newDate.toLocaleDateString();
    return formattedDate;
}