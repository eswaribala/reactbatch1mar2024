import React, {useEffect, useRef, useState} from 'react';
import PropTypes from 'prop-types';
import './LoginForm.css';
import {Button, TextField} from "@mui/material";
import LoginImagePath from '../../assets/login.jpg';
import * as yup from 'yup'
import {useFormik} from "formik";
import Captcha from "../captcha/captcha";

const validationSchema=yup.object({
    email:yup
        .string("Enter Email")
        .email("Email Format not Correct")
        .required("Email Required"),
    password: yup
        .string("Enter Password")
        .min(8,"Minimum Length 8")
        .required("Password Required")
})


const LoginForm = ({registerStatus}) => {
    const formik =useFormik({
        initialValues:{
            "email":"sample@gmail.com",
            "password":"********"
        },
        validationSchema:validationSchema,
        onSubmit:(values)=>{
          alert(JSON.stringify(values))

        }

    });
    function handleRegisterChange(){
        let value=true;
       setValue(true);
        registerStatus(value)
    }

    const [value,setValue]=useState(false);

    useEffect(()=>{
        console.log(value);
    },[value])




    return (
         <div>
         <img src={LoginImagePath} className="LoginImage"/>
             <form onSubmit={formik.handleSubmit}>
                 <TextField id="email"
                            label="Email"
                            variant="outlined"
                            fullWidth
                            value={formik.values.email}
                            onBlur={formik.handleBlur}
                            onChange={formik.handleChange}
                            error={formik.errors.email && Boolean(formik.errors.email)}
                            helperText={formik.touched.email && formik.errors.email}
                            margin="dense">

                 </TextField>
                 <TextField id="password"
                            label="Password"
                            type="password"
                            variant="outlined"
                            value={formik.values.password}
                            onBlur={formik.handleBlur}
                            onChange={formik.handleChange}
                            error={formik.errors.password && Boolean(formik.errors.password)}
                            helperText={formik.touched.password && formik.errors.password}
                            fullWidth margin="dense">

                 </TextField>
                  <Captcha/>
                 <Button type="submit" variant="contained">
                     Submit
                 </Button>
             </form>
             <p>New User? <a href="#" onClick={handleRegisterChange}>Create User Account</a></p>
         </div>
    )
};

LoginForm.propTypes = {};

LoginForm.defaultProps = {};

export default LoginForm;
