import React from 'react';
import PropTypes from 'prop-types';
import './customers.css';
import Dashboardmenu from "../dashboardmenu/dashboardmenu";
import { Route } from "react-router-dom";
const Customers = () => {
 const name=sessionStorage.getItem("firstName");
    return (
  <div className="customers">
   <Dashboardmenu name={name}></Dashboardmenu>
  </div>
)};

Customers.propTypes = {};

Customers.defaultProps = {};

export default Customers;
