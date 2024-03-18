import React, {useState} from 'react';
import './registration.css';
import {Button, TextField} from "@mui/material";
import * as yup from 'yup'
import {useFormik} from "formik";
import RegisterLogoPath from '../../assets/register.jpg'
import Captcha from "../captcha/captcha";

const validationSchema=yup.object({
    firstName:yup
        .string("Enter First Name")
        .required("First Name Required")
        .matches(
            /[A-Za-z]{5,25}/,
            "First Name must contain minimum 5 characters and maximum 25 characters"
        ),
     lastName: yup
         .string("Enter Last Name")
         .required("Last Name Required")
         .matches(
             /[A-Za-z]{5,25}/,
             "Last Name must contain minimum 5 characters and maximum 25 characters"
         ),
    dob: yup
        .string("Enter DOB")
        .required("DOB Required"),
   mobileNo: yup
        .string("Enter Mobile No")
        .required("Mobile No Required")
        .matches(
            /^([+]\d{2}[ ])?\d{10}$/,
            "Mobile No should be in 10 digits"
        ),
    }
)

const Registration = () => {

    const[captchaText,setCaptchaText]=useState('');
    const[userText,setUserText]=useState('');

    function handleChange(value1,value2){
        setCaptchaText(value1);
        setUserText(value2);
    }


    const formik=useFormik({
        initialValues:{
            "firstName":"Parameswari",
            "lastName":"Ettiappan",
            "dob":"1970-12-02",
            "mobileNo":9952032876
        },
        validationSchema:validationSchema,
        onSubmit:(values)=>{
            alert(JSON.stringify(values))
        }

    })

    return(
       <div>
       <img src={RegisterLogoPath} className="Image"/>
  <form onSubmit={formik.handleSubmit}>
      <TextField id="firstName"
                 label="First Name"
                 value={formik.values.firstName}
                 onChange={formik.handleChange}
                 onBlur={formik.handleBlur}
                 error={formik.errors.firstName && Boolean(formik.errors.firstName)}
                 helperText={formik.touched.firstName && formik.errors.firstName}
                 fullWidth
                 margin="dense"
                 variant="outlined">

      </TextField>
      <TextField
          id="lastName"
          label="Last Name"
          fullWidth
          margin="dense"
          variant="outlined"
          value={formik.values.lastName}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          error={formik.errors.lastName && Boolean(formik.errors.lastName)}
          helperText={ formik.touched.lastName && formik.errors.lastName}>

      </TextField>
      <TextField
          id="dob"
          label="DOB"
          type="date"
          fullWidth
          margin="dense"
          value={formik.values.dob}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          error={formik.errors.dob && Boolean(formik.errors.dob)}
          helperText={formik.touched.dob && formik.errors.dob}
          variant="outlined">

      </TextField>
      <TextField
          id="mobileNo"
          label="Mobile No"
          type="number"
          fullWidth
          margin="dense"
          value={formik.values.mobileNo}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          error={formik.errors.mobileNo && Boolean(formik.errors.mobileNo)}
          helperText={formik.touched.mobileNo && formik.errors.mobileNo}
          variant="outlined">

      </TextField>
      <Captcha change={handleChange}/>
      <Button type="submit" color="success" variant="contained">
         Continue To Register
      </Button>
  </form>
       </div>
)};


export default Registration;
