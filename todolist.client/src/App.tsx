import React from 'react';
import { Route, Routes } from 'react-router-dom';
import _Layout from './Components/Common/_Layout';
import ToDoTasks from './Pages/ToDoTasks';
import { NOTFOUND } from 'dns';
import NotFound from './Pages/NotFound';
import Categories from './Pages/Categories';
  

function App() {
  return (
    <div className="App">
      <Routes>
          <Route path="/" element={<_Layout />}>
            <Route index element={<ToDoTasks />} />
            <Route path="categories" element={<Categories />} />
            <Route path="*" element={<NotFound />} />
          </Route>
      </Routes>
    </div>
  );
}

export default App;
