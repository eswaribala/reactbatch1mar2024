import React from 'react';
import PropTypes from 'prop-types';
import './dashboard.css';
import EmailIcon from "@mui/icons-material/Email";
import PhoneIcon from '@mui/icons-material/Phone';
const Dashboard = () => {
    const firstName=sessionStorage.getItem("firstName");
    const lastName=sessionStorage.getItem("lastName");
    const email=sessionStorage.getItem("email");
    const phone=sessionStorage.getItem("phone")
    return(
        <div className="App-header">
            <h4>Welcome {firstName}&nbsp;&nbsp;{lastName}</h4>
            <div className="Customer-Detail">
            <EmailIcon fontSize="small" /><h6>{email}</h6>
            <PhoneIcon fontSize="small" /><h6>{phone}</h6>
            </div>
        </div>
    )
};

Dashboard.propTypes = {};

Dashboard.defaultProps = {};

export default Dashboard;
