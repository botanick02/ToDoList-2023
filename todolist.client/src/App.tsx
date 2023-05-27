import { Route, Routes } from "react-router-dom";
import Layout from "./components/common/Layout";
import ToDoTasks from "./pages/ToDoTasks";
import NotFound from "./pages/NotFound";
import Categories from "./pages/Categories";
import { useAppDispatch, useAppSelector } from "./redux/hooks";
import { useEffect } from "react";
import { fetchStorageSources } from "./redux/reducers/storageSource-slice";
import { fetchCategories } from "./redux/reducers/categories-slice";
import { fetchTasks } from "./redux/reducers/tasks-slice";

function App() {
  const dispatch = useAppDispatch();
  const source = useAppSelector((state) => state.storageSources.currentStorage);

  useEffect(() => {
    dispatch(fetchStorageSources());
  }, [dispatch]);

  useEffect(() => {
    if (source) {
      dispatch(fetchCategories());
      dispatch(fetchTasks());
    }
  }, [source, dispatch]);

  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<ToDoTasks />} />
          <Route path="categories" element={<Categories />} />
          <Route path="*" element={<NotFound />} />
        </Route>
      </Routes>
    </div>
  );
}

export default App;
