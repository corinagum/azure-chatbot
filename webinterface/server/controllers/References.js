var sql = require("seriate")

module.exports = {
    
  // Get all references from database 
  index: function(req, res) {
    sql.execute( {
        name: "selectFromReference",
        preparedSql: "SELECT ParentID, ChildID FROM Reference",
<<<<<<< HEAD
    }).then( function( data ) { 
=======
    }).then( function( data ) {
        console.log("Got It!");
        console.log(data);
>>>>>>> ced17249e05315dec40650f00c6c9f955c1c267c
        res.json(data);
    }, function( err ) {
        console.log( err );
    });
  },

  // Create a new reference between two nodes
  create: function(req, res) {
      sql.execute({
          procedure: "AddReference",
          params: {
              PreviousID: {
                  type: sql.INT,
                  val: req.body.parentID
              },
              NewID: {
                  type: sql.INT,
                  val: req.body.childID
              } 
          }
      }).then( function (data) {       
        res.redirect('/');
      }, function (err) {
        console.log( err );
      });
  },
  
  // Remove a reference
  delete: function(req, res) {
      sql.execute({
          procedure: "DeleteReference",
          params: {
              parentID: {
                  type: sql.INT,
                  val: req.params.parentID
              },
              chileID: {
                  type: sql.INT,
                  val: req.params.childID
              }        
          }
      }).then( function (data) {       
        res.redirect('/');
      }, function (err) {
        console.log( err );
      });
  }
}