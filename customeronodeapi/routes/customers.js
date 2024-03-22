var express = require('express');
var router = express.Router();

/* GET users listing. */
router.post('/customers', function(req, res, next) {
    console.log("Testing...")
    res.setHeader('Access-Control-Allow-Origin', '*');
    res.setHeader('Access-Control-Allow-Methods', 'GET, POST');
    res.header("Access-Control-Allow-Headers", "X-Requested-With, Content-Type");
    res.setHeader('Access-Control-Allow-Credentials', true);
    console.log(request.query);
    //console.log(request);
   // refAddState.Add(request.query.ID,request.query.Name);

    response.end("Object received successfully");
});



module.exports = router;