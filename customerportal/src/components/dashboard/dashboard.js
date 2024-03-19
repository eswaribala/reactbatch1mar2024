import React from 'react';
import PropTypes from 'prop-types';
import './dashboard.css';
import EmailIcon from "@mui/icons-material/Email";
import PhoneIcon from '@mui/icons-material/Phone';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Logo from "../Logo/Logo";
const Dashboard = () => {
    const firstName=sessionStorage.getItem("firstName");
    const lastName=sessionStorage.getItem("lastName");
    const email=sessionStorage.getItem("email");
    const phone=sessionStorage.getItem("phone")
    return (
        <div>
            <header className="header">
                <Logo/>
              
                <div className="welcome">
                    <h4>Hi&nbsp;&nbsp;{firstName}</h4>
                    <span className="pi pi-user"></span>
                </div>
            </header>
            <article className="article">
                <div className="Account">
                    <AccountCircleIcon color="primary" sx={{fontSize: 110}}
                                       className="AccountCircle"></AccountCircleIcon>
                </div>
                <div className="center">

                    <div>
                        <h1>Welcome, {firstName} &nbsp;&nbsp;{lastName} </h1>
                        <div className="Dashboard">

                            <PhoneIcon fontSize="small" color="success"></PhoneIcon><h4>{phone} </h4>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<EmailIcon fontSize="small"
                                                                            color="warning"></EmailIcon> <h4
                            className="AccountCircle">{email} </h4>
                        </div>
                    </div>

                </div>

            </article>
        </div>

    )
};

Dashboard.propTypes = {};

Dashboard.defaultProps = {};

export default Dashboard;
