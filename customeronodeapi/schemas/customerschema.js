const mongoose = require('mongoose')
Schema = mongoose.Schema;

var customerSchema = new mongoose.Schema({
    customerId:Number,
    firstName: String,
    lastName:String,
    middleName: String,
    email:String,
    password:String,
    phone:Number
})

module.exports.CustomerModel = mongoose.model('CustomerModel',customerSchema );