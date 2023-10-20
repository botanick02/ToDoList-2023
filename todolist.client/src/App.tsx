import { Route, Routes } from "react-router-dom";
import Layout from "./components/common/Layout";
import { useAppDispatch } from "./redux/hooks";
import { useEffect } from "react";
import { fetchStorageSources } from "./redux/reducers/storageSource-slice";
import ToDoTasks from "./Pages/ToDoTasks";
import Categories from "./Pages/Categories";
import NotFound from "./Pages/NotFound";

function App() {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchStorageSources());
  }, [dispatch]);

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
