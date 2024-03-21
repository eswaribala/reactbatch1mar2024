import React from 'react';
import PropTypes from 'prop-types';
import './DashboardDialog.css';
import Dialog from "@mui/material/Dialog";
import {DialogActions, DialogContent, DialogTitle, TextField} from "@mui/material";
import {Button} from "primereact/button";
import * as yup from "yup";
import {useFormik} from "formik";
import axios from "axios";
import {Url} from "../../configurations/configuration";
const validationSchema=yup.object({
        chitId:yup
            .string("Enter Chit Id")
            .required("Chit Id Required")
            .matches(
                /^\d{1,10}$/,
                "Chit Id Should be in Numbers"
            ),
        dueAmount: yup
            .string("Enter Due Amount")
            .required("Due Amount Required")
            .matches(
                /^\d{1,10}$/,
                "Due Amount Should be in Numbers"
            ),
        nextAuctionDate: yup
            .string("Enter Next Auction Date")
            .required("Next Auction Date Required"),
        duration: yup
            .string("Enter Current Month Count")
            .required("Due Current Month Count Required")
            .matches(
                /^\d{1,10}$/,
                "Current Month Count Should be in Numbers"
            )
    }
)
const DashboardDialog = () => {
    const [open, setOpen] = React.useState(false);
    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const formik=useFormik({
        initialValues:{
            "chitId": 0,
            "dueAmount":0,
            "nextAuctionDate":"",
            "duration": 0,

        },
        validationSchema:validationSchema,



    })
    function handleClick(event){
        event.preventDefault();
        alert(JSON.stringify(formik.values))
        const data={
            "transactionId": 0,
            "dueAmount": formik.values.dueAmount,
            "nextAuctionDate": formik.values.nextAuctionDate,
            "duration": formik.values.duration,
            "chitId": 0,
            "chit": {
                "chitId": 0,
                "chitValue": 0,
                "totalDuration": 0,
                "installmentAmount": 0,
                "customerId": 0,
                "customer": {
                    "id": 0,
                    "name": {
                        "firstName": "XtvqOAxRpRrt",
                        "lastName": "VLMqIwUZjJeR",
                        "middleName": "vzgmJvgiVDs"
                    },
                    "email": "string",
                    "password": "string",
                    "phone": 0
                }
            }
        }
        axios.post(Url+"api/v1/ChitTransactions?Id="+formik.values.chitId, data).then(res => {
            alert(JSON.stringify(res));


        }).catch(error => {
            throw(error);
        });

    }
    return(
  <div className="DashboardDialog">
      <Dialog
          open={open}
          onClose={handleClose}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
      >

          <DialogTitle>
              Payment Information
          </DialogTitle>
          <DialogContent>
              <form>

                  <TextField id="chitId"
                             label="Chit Id"
                             value={formik.values.chitId}
                             onChange={formik.handleChange}
                             onBlur={formik.handleBlur}
                             error={formik.errors.chitId && Boolean(formik.errors.chitId)}
                             helperText={formik.touched.chitId && formik.errors.chitId}
                             fullWidth
                             margin="dense"
                             variant="outlined">

                  </TextField>
                  <TextField id="dueAmount"
                             label="Due Amount"
                             value={formik.values.dueAmount}
                             onChange={formik.handleChange}
                             onBlur={formik.handleBlur}
                             error={formik.errors.dueAmount && Boolean(formik.errors.dueAmount)}
                             helperText={formik.touched.dueAmount && formik.errors.dueAmount}
                             fullWidth
                             margin="dense"
                             variant="outlined">

                  </TextField>
                  <TextField
                      id="nextAuctionDate"
                      label="Next Auction Date"
                      type="date"
                      fullWidth
                      margin="dense"
                      variant="outlined"
                      value={formik.values.nextAuctionDate}
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                      error={formik.errors.nextAuctionDate && Boolean(formik.errors.nextAuctionDate)}
                      helperText={formik.touched.nextAuctionDate && formik.errors.nextAuctionDate}>

                  </TextField>
                  <TextField
                      id="duration"
                      label="Duration"
                      type="number"
                      fullWidth
                      margin="dense"
                      value={formik.values.duration}
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                      error={formik.errors.duration && Boolean(formik.errors.duration)}
                      helperText={formik.touched.duration && formik.errors.duration}
                      variant="outlined">

                  </TextField>


              </form>
          </DialogContent>
          <DialogActions>
              <Button onClick={handleClose}>Cancel</Button>
              <Button onClick={handleClick} color="success" variant="contained">
                  Confirm Payment
              </Button>
          </DialogActions>


      </Dialog>
  </div>
)};

DashboardDialog.propTypes = {};

DashboardDialog.defaultProps = {};

export default DashboardDialog;
