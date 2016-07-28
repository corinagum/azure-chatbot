var sql = require("seriate")

module.exports = {
    
  // Get all references from database 
  index: function(req, res) {
    sql.execute( {
        name: "selectFromReference",
        preparedSql: "SELECT StartID, EndID FROM Reference",
    }).then( function( data ) {
        console.log("Got It!");
        console.log(data);
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
              parentID: {
                  type: sql.INT,
                  val: req.params.parentID
              },
              chileID: {
                  type: sql.INT,
                  val: req.params.childID
              } 
          }
      })
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
      })
  }
}