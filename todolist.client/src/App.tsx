import { Route, Routes } from "react-router-dom";
import Layout from "./components/common/Layout";
import ToDoTasks from "./pages/ToDoTasks";
import NotFound from "./pages/NotFound";
import Categories from "./pages/Categories";
import { useAppDispatch } from "./redux/hooks";
import { useEffect } from "react";
import { fetchTasks } from "./redux/slices/tasks-slice";
import { fetchCategories } from "./redux/slices/categories-slice";

function App() {
  const dispatch = useAppDispatch();
  
  useEffect(() => {
    dispatch(fetchTasks());
    dispatch(fetchCategories());
  });
  
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
