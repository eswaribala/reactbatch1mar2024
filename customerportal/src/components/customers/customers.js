import React, {useContext, useEffect} from 'react';
import PropTypes from 'prop-types';
import './customers.css';

import {Route, useLocation} from "react-router-dom";
import {UserContext} from "../dashboard/dashboard";
import Dashboardmenu from "../dashboardmenu/dashboardmenu";
import {useDispatch, useSelector} from "react-redux";
import {fetchAllCustomers} from "../../reduxsrc/reducers/duepaymentreducer";
import {DataTable} from "primereact/datatable";
import {Column} from "primereact/column";


const Customers = () => {

    const dispatch=useDispatch()
// const name=sessionStorage.getItem("firstName");
   // const location = useLocation();
    const customers = useSelector(state => state.topSlicer.dueSlicer.customers);
    const isLoading = useSelector(state => state.topSlicer.dueSlicer.isLoading);
    useEffect(()=>{
        dispatch(fetchAllCustomers())
    },[dispatch])


    return (
        <div className="customers">

            <Dashboardmenu />
            {
                (isLoading)?
                    <>
                        <DataTable value={customers} paginator rows={3} rowsPerPageOptions={[3, 9, 12, 15]} tableStyle={{ minWidth: '50rem' }}>
                            <Column field="customerId" header="Customer Id" style={{ width: '25%' }}></Column>
                            <Column field="firstName" header="First Name" style={{ width: '25%' }}></Column>
                            <Column field="lastName" header="Last Name" style={{ width: '25%' }}></Column>
                            <Column field="email" header="Email" style={{ width: '25%' }}></Column>

                        </DataTable>
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
