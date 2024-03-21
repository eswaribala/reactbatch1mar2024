import React, {useEffect, useState} from 'react';
import PropTypes from 'prop-types';
import './dashboard.css';
import EmailIcon from "@mui/icons-material/Email";
import PhoneIcon from '@mui/icons-material/Phone';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Logo from "../Logo/Logo";
import {Menubar} from "primereact/menubar";
import {items} from "../../models/Items";
import {getChitsByCustomerId} from "../../services/ChitService";
import axios from "axios";
import { Card } from 'primereact/card';
import { Avatar } from 'primereact/avatar';
import { Button } from 'primereact/button';
import Dialog from '@mui/material/Dialog';
import {Url} from "../../configurations/configuration";
import {InputText} from "primereact/inputtext";
import {Box, DialogActions, DialogContent, DialogTitle, Modal, TextField, Typography} from "@mui/material";
import * as yup from "yup";
import {useFormik} from "formik";
import DashboardDialog from "../DashboardDialog/DashboardDialog";

const RestAPIUrl=Url+"filter/"

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

const Dashboard = () => {
    const firstName=sessionStorage.getItem("firstName");
    const lastName=sessionStorage.getItem("lastName");
    const email=sessionStorage.getItem("email");
    const phone=sessionStorage.getItem("phone")
    const isSubmit=sessionStorage.getItem("isSubmit");
    const customerId=sessionStorage.getItem("customerId");
    const[response,setResponse]=useState([]);
    const [open, setOpen] = React.useState(false);



    useEffect(() => {
      console.log(response);
    }, [response]);

    function handleLoad(){
        axios.get(RestAPIUrl+customerId).then(res=>{
            //alert(JSON.stringify(res.data))
            console.log(JSON.stringify(res.data));
            setResponse(res.data)

        })
    }


    const handleClickOpen = () => {
        setOpen(true);
    };

     function handleClose(value){
         setOpen(value);
     }


    if(isSubmit){


        return (
      <div onLoad={handleLoad}>
        <div>
            <header className="header">
                <Logo/>
                <Menubar key={items.label} model={items}></Menubar>
                <div className="welcome">
                    <h4>Hi&nbsp;&nbsp;{firstName}</h4>
                    &nbsp;&nbsp;<span className="pi pi-user"></span>
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
          {(response.length>0) &&(
            <section>
                {
                   response.map((chit)=>{
                       return(
                         <div className="card">
                           <Card title={"ChitId=" + chit.chitId}
                                 pt={{
                               body: { className: 'bg-primary border-round-lg' }
                           }}>


                               <div className="card-header">
                                   <Avatar icon="pi pi-megaphone" className="p-logo" size="large"
                                           style={{ backgroundColor: '#9c27b0', color: '#ffffff', padding:'inherit' }} shape="circle" />

                                   <Avatar label="Chit Value" size="normal"
                                           style={{ backgroundColor: '#2196F3',
                                               color: '#ffffff' }} />
                                   <Avatar label="Installment Amount" size="normal"
                                           style={{ backgroundColor: '#2196F3',
                                               color: '#ffffff' }} />
                                   <Avatar label="Total Duration" size="normal"
                                           style={{ backgroundColor: '#2196F3',
                                               color: '#ffffff' }} />
                                   <Button label="Pay Now" severity="help" onClick={handleClickOpen} />
                                   {(open) &&(
                                   <DashboardDialog openData={open} change={handleClose}/>
                                     )}
                               </div>
                               <div className="card-header">
                                   <Avatar label={chit.chitValue} size="normal"
                                           style={{
                                               backgroundColor: 'white',
                                               color: 'black'
                                           }}/>
                                   <Avatar label={chit.installmentAmount} size="normal"
                                           style={{
                                               backgroundColor: 'white',
                                               color: 'black'
                                           }}/>
                                   <Avatar label={chit.totalDuration} size="normal"
                                           style={{
                                               backgroundColor: 'white',
                                               color: 'black'
                                           }}/>

                               </div>
                           </Card>
                         </div>
                       )
                   })
                }
            </section>
          )
          }

      </div>
        )
    }
};


export default Dashboard;
