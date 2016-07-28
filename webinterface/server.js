var express = require("express"); 
var app = express(); 
var bodyParser = require("body-parser"); 
var path = require("path"); 
app.use(bodyParser.json()); 
app.use(express.static(path.join(__dirname,  "./static"))); 
var route_setter = require("./server/config/routes.js"); 
route_setter(app); 
app.listen(8000, function(){ 
 	console.log("running on port 8000"); 
}); 
