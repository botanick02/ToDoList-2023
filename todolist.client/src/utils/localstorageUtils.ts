export const writeToLocalStorage = (key: string, value: string) => {
    try {
      localStorage.setItem(key, JSON.stringify(value));
    } catch (error) {
      console.error('Error writing to localStorage:', error);
    }
  };
  
export const readFromLocalStorage = (key: string) => {
    try {
      const storedValue = localStorage.getItem(key);
      return storedValue ? JSON.parse(storedValue) : null;
    } catch (error) {
      console.error('Error reading from localStorage:', error);
      return null;
    }
  };

 export const writeDefaultIfEmptyLocalStorage = (key: string, defaultValue: string) => {
    var data = readFromLocalStorage(key);
    if (data){
        return data;
    }
    else
    {
        writeToLocalStorage(key, defaultValue);
        return defaultValue;
    }
}