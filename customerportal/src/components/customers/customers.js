import React, {useContext} from 'react';
import PropTypes from 'prop-types';
import './customers.css';

import {Route, useLocation} from "react-router-dom";
import {UserContext} from "../dashboard/dashboard";
import Dashboardmenu from "../dashboardmenu/dashboardmenu";


const Customers = () => {
 const name=sessionStorage.getItem("firstName");
    const location = useLocation();

    return (
        <div className="customers">

            <Dashboardmenu name={location.state.name}></Dashboardmenu>
        </div>
    )
};

Customers.propTypes = {};

Customers.defaultProps = {};

export default Customers;
