var mongoose = require('mongoose');
var CustomerModel= require('../schemas/customerschema').CustomerModel;

mongoose.connect('mongodb://localhost:27017/batch1chitdb?directConnection=true');


//mongoose.connect(config.url, config.mongodb, config.mongoport);
module.exports.Add=function(obj)
{
    var db = mongoose.connection;
    db.once('open', function() {
    });

    var obj = new CustomerModel(
        {
            customerId:0,
            firstName:obj.name.firstName,
            lastName:obj.name.lastName,
            middleName:"",
            email:obj.email,
            password:obj.password,
            phone:obj.mobileNo

        });
    obj.save().then(function(){
        console.log("object saved")
    })

}


module.exports.findAllCustomers=(req,res)=>{
    CustomerModel.find().then(data=>{
        res.send(data);
    }).catch(err=>{
        res.status(500).send({
            message:
                err.message || 'Some error occurred while reading customer data'
        });
    });
}





