var azurechatbot = require("../controllers/AzureChatBotQueries.js");

module.exports = function(app) { 
 	app.get('/Nodes', function(req, res) { 
 		azurechatbot.index(req, res);
 	}); 
 } 
