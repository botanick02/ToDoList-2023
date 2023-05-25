export const stringToFormattedDateString = (utcDate: string) => {
    if(!utcDate){
        return "";
    }
    let date = new Date(utcDate);
    let stringDate = date.toLocaleTimeString();
    return stringDate === 'Invalid Date' ? '' : stringDate;
}