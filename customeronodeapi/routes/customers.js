var express = require('express');
const {Add, findAllCustomers} = require("../services/customerservice");
var router = express.Router();

/* GET users listing. */
router.post('/customers', function(req, res, next) {
    console.log("Testing...")
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST');
    res.header("Access-Control-Allow-Headers", "X-Requested-With, Content-Type");
    res.setHeader('Access-Control-Allow-Credentials', true);
    console.log(req.body);
    //console.log(request);
   Add(req.body);

    res.end("Object received successfully");
});

router.get('/customers',function(req,res){

   return (findAllCustomers(req,res))


})

module.exports = router;