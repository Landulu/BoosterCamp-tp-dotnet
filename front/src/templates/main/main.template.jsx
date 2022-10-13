import './main.template.scss';

import Header from "../../components/header/header";

import { Outlet } from 'react-router-dom';


const MainTemplate = () => {
    return (
        <div className="main-template">
            <Header />
            <div className="container">
                <Outlet />
            </div>
        </div>
    )
}


export default MainTemplate;