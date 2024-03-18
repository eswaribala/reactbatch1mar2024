import React from 'react';
import PropTypes from 'prop-types';
import './dashboard.css';

const Dashboard = () => {
    const firstName=sessionStorage.getItem("firstName");
    const lastName=sessionStorage.getItem("lastName");
    const email=sessionStorage.getItem("email");
    const phone=sessionStorage.getItem("phone")
    return(
        <div className="App-header">
            <h4>{firstName}</h4>
            <h4>{lastName}</h4>
            <h4>{email}</h4>
            <h4>{phone}</h4>
        </div>
    )
};

Dashboard.propTypes = {};

Dashboard.defaultProps = {};

export default Dashboard;
