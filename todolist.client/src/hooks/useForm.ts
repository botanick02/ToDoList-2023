import { useState } from "react";

interface FormValues {
  [key: string]: any;
}

const useForm = <T extends FormValues>(initialValues: T) => {
  const [formData, setFormData] = useState<T>(initialValues);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement> | React.ChangeEvent<HTMLSelectElement>) => {
    const { name, value } = event.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
  };

  return { formData, handleInputChange };
};

export default useForm;
