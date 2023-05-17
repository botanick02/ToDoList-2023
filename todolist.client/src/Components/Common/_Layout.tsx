import { Outlet } from "react-router-dom";

const _Layout = () => {
    return(
        <>
        <div className="vh-100 h-100">
            <Outlet />
        </div>
        </>
    )
}

export default _Layout;