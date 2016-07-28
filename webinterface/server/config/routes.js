var node = require("../controllers/Nodes.js");
var reference = require("../controllers/References.js"); 

module.exports = function(app) { 
	app.get('/Nodes', function(req, res) { 
 		node.index(req, res);
 	}); 
	app.get("/References", function(req, res) {
		reference.index(req, res);
	}) 
 } 
