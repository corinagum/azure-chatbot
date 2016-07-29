var node = require("../controllers/Nodes.js");
var reference = require("../controllers/References.js"); 

module.exports = function(app) { 
	// Node Routes
	app.get('/api/nodes', function (req, res) { 
 		node.index(req, res);
 	}); 
	app.get('/api/nodes/children/:id', function (req, res) {
		node.showAllChildren(req, res);
	})
	app.post('/api/nodes', function (req, res) {
		node.create(req, res);
	});
	app.put('/api/nodes/:id', function (req, res) {
		node.update(req, res);
	})
	app.delete('/api/nodes/:id', function (req, res) {
		node.delete(req, res);
	});

	// Reference Routes
	app.get('/api/references', function (req, res) {
		reference.index(req, res);
	});
	app.post('/api/references', function (req, res) {
		reference.create(req, res);
	});
	app.delete('/api/references/:id', function (req, res) {
		reference.delete(req, res);
	});
 } 
