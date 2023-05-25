import { Route, Routes } from "react-router-dom";
import Layout from "./components/common/Layout";
import ToDoTasks from "./pages/ToDoTasks";
import NotFound from "./pages/NotFound";
import Categories from "./pages/Categories";
import { useAppDispatch } from "./redux/hooks";
import { useEffect } from "react";
import { fetchTasks } from "./redux/reducers/tasks-slice";
import { fetchCategories } from "./redux/reducers/categories-slice";
import { stringToFormattedDateString } from "./utils/dateUtils";

function App() {
  const dispatch = useAppDispatch();
  
  useEffect(() => {
    dispatch(fetchTasks());
    dispatch(fetchCategories());
  });

  console.log(stringToFormattedDateString("2023-04-15T13:34:00Z"));
  
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
