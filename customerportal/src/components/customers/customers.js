import React, {useContext} from 'react';
import PropTypes from 'prop-types';
import './customers.css';

import {Route, useLocation} from "react-router-dom";
import {UserContext} from "../dashboard/dashboard";
import Dashboardmenu from "../dashboardmenu/dashboardmenu";
import {useSelector} from "react-redux";


const Customers = () => {
// const name=sessionStorage.getItem("firstName");
   // const location = useLocation();
    const customers = useSelector(state => state.topSlicer.dueSlicer.customers);
    const isLoading = useSelector(state => state.topSlicer.dueSlicer.isLoading);
    return (
        <div className="customers">

            <Dashboardmenu />
            {
                (isLoading)?
                    <>
                        {
                            customers.map((customer)=>{
                                return (
                                    <>
                                    <h4>{customer.firstName}</h4>
                                    <h4>{customer.firstName}</h4>
                                    </>
                                )
                            })
                        }
                    </> :
                    <>
                    <h1>Customers Not Available</h1>
                    </>

            }

        </div>
    )
};

Customers.propTypes = {};

Customers.defaultProps = {};

export default Customers;
