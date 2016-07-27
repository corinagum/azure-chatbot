var sql = require("seriate")

module.exports = {

  // Get all appointments from the database
  index: function(req, res) {
    sql.execute( {
        name: "selectFromNode",
        preparedSql: "SELECT ID, StartID, EndID FROM Node n LEFT JOIN Reference r ON n.ID = r.EndID",
    }).then( function( data ) {
        console.log("Got It!");
        console.log(data);
        res.json(data);
    }, function( err ) {
        console.log( err );
    });
  }
}

