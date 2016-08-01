var express = require("express");
var app = express(); 

var sql = require("seriate")

var bodyParser = require("body-parser"); 
var path = require("path"); 

app.use(bodyParser.json()); 
app.use(bodyParser.urlencoded({ extended: false }));

app.use(express.static(path.join(__dirname,  "./client"))); 
var route_setter = require("./server/config/routes.js"); 
route_setter(app); 
app.listen(8000, function() {
    console.log("running on 8000");
	// setup default connection to database on app load 
 	sql.setDefault({
        user: "leaper",
        password: "SecAu!h2123",
        host: "leapchatbot.database.windows.net",
        database: "LeapChatBotDB",
        options: {
            encrypt: true  
        }
    }); 
    // sql.setDefault({
    //     user: "kabirkhan",
    //     password: "azurechatbot123!",
    //     host: "azurechatbot.database.windows.net",
    //     database: "Test",
    //     options: {
    //         encrypt: true  
    //     }
    // });
}); 
 


