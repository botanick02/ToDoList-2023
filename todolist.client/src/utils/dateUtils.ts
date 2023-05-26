export const stringToFormattedDateString = (utcDate: string) => {
    if(!utcDate){
        return "";
    }
    let date = new Date(utcDate);
    let stringDate = date.toLocaleString();
    return stringDate === 'Invalid Date' ? '' : stringDate;
}