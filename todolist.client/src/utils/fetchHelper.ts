import { fetchCategories } from "../redux/reducers/categories-slice";
import { fetchTasks } from "../redux/reducers/tasks-slice";
import { store } from "../redux/store"

export const fetchTasksPaged = () => {
    const currentPage = store.getState().tasks.currentPage;
    store.dispatch(fetchTasks({pageNumber: currentPage, pageSize: 5}))
}

export const fetchCategoriesPaged = () => {
    const currentPage = store.getState().categories.currentPage;
    store.dispatch(fetchCategories({pageNumber: currentPage, pageSize: 5}))
}