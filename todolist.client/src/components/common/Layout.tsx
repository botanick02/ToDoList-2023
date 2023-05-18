import { Outlet } from "react-router-dom";
import NavigationBar from "./NavigationBar";

const Layout = () => {
  return (
    <>
      <div className="vh-100 h-100 content">
        <NavigationBar />
        <div className="m-4">
          <Outlet />
        </div>
      </div>
    </>
  );
};

export default Layout;
