import React, {useEffect, useRef, useState} from 'react';
import PropTypes from 'prop-types';
import './LoginForm.css';
import {Button, InputAdornment, TextField} from "@mui/material";
import LoginImagePath from '../../assets/login.jpg';
import * as yup from 'yup'
import axios from 'axios';
import {useFormik} from "formik";
import Captcha from "../captcha/captcha";
import {useNavigate} from "react-router-dom";
import EmailIcon from '@mui/icons-material/Email';
import LockIcon from '@mui/icons-material/Lock';
const RestAPIUrl="http://localhost:5075/api/v1/customers/"

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


const LoginForm = ({registerStatus,submitStatus}) => {

    const navigate=useNavigate();

    const formik =useFormik({
        initialValues:{
            "email":"sample@gmail.com",
            "password":"********"
        },
        validationSchema:validationSchema,
        onSubmit:(values)=>{
          //alert(JSON.stringify(values))
            alert(userInput+" "+captchaText);
            if (userInput === captchaText) {
                alert('Success');
                axios.get(RestAPIUrl+values.email+"/"+values.password)
                    .then(response=>{
                   alert(JSON.stringify(response.data));
                       sessionStorage.setItem("firstName",response.data.name.firstName);
                        sessionStorage.setItem("lastName",response.data.name.lastName);
                        sessionStorage.setItem("email",response.data.email);
                        sessionStorage.setItem("phone",response.data.phone);
                        handleSubmitChange();
                        navigate("/dashboard");
                })



            } else {
                alert('Incorrect');
                //const canvas = canvasRef.current;
               // const ctx = canvas.getContext('2d');
              //  initializeCaptcha(ctx);
            }
        }

    });
    function handleRegisterChange(){
        let value=true;
       setValue(true);
        registerStatus(value)
    }

    function handleSubmitChange(){
        setIsSubmit(true);
        submitStatus(true);

    }
    const [captchaText, setCaptchaText] = useState('');
    const [userInput, setUserInput] = useState('');
    const[isSubmit, setIsSubmit]=useState(false);

    const [value,setValue]=useState(false);

    useEffect(()=>{
        console.log(value);
    },[value])

      function handleChange(value1,value2){
        setCaptchaText(value1);
        setUserInput(value2);
      }


    return (
         <div>
         <img src={LoginImagePath} className="LoginImage"/>
             <form onSubmit={formik.handleSubmit}>
                 <TextField id="email"
                            label="Email"
                            variant="outlined"
                            InputProps={{
                                startAdornment: (
                                    <InputAdornment position="start">
                                        <EmailIcon />
                                    </InputAdornment>
                                ),
                            }}

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
                            InputProps={{
                                startAdornment: (
                                    <InputAdornment position="start">
                                        <LockIcon />
                                    </InputAdornment>
                                ),
                            }}
                            value={formik.values.password}
                            onBlur={formik.handleBlur}
                            onChange={formik.handleChange}
                            error={formik.errors.password && Boolean(formik.errors.password)}
                            helperText={formik.touched.password && formik.errors.password}
                            fullWidth margin="dense">

                 </TextField>
                  <Captcha change={handleChange}/>
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
