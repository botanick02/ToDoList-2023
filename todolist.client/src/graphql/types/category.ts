import { ICategory } from "../../redux/types";

export interface ICategoriesFetchData {
  data: ICategoriesFetch;
}
interface ICategoriesFetch {
  categories: IGetCategories;
}
interface IGetCategories {
  getCategories: ICategory[];
}
