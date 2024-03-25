var customerRouter=require('./routes/customers')
const express = require("express");
const {json, urlencoded} = require("body-parser");
const cors=require('cors')
var app = express();

app.use(json());
app.use(urlencoded({extended:true}));
app.use(cors());


app.use('/api', customerRouter)





app.set('port',4000);
app.listen(app.get('port'), function(){
  console.log('The server is running, ' +
      ' please open your browser at http://localhost:%s',
      app.get('port'));
});
