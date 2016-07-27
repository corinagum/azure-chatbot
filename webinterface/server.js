var express = require("express");
var app = express(); 

var sql = require("seriate")

var bodyParser = require("body-parser"); 
var path = require("path"); 

app.use(bodyParser.json()); 
app.use(express.static(path.join(__dirname,  "./client"))); 
var route_setter = require("./server/config/routes.js"); 
route_setter(app); 
app.listen(8000, function() {
	// setup default connection to database on app load 
 	sql.setDefault({
        user: "kabirkhan",
        password: "azurechatbot123!",
        host: "azurechatbot.database.windows.net",
        database: "Test",
        options: {
            encrypt: true // Use this if you're on Windows Azure 
        }
    }); 
}); 
 


