var sql = require("seriate")

module.exports = {
    
  // Get all appointments from the database
  index: function (req, res) {
    sql.execute({
        name: "selectFromNode",
        preparedSql: "SELECT TOP(114) * FROM Node",
    }).then( function (data) {       
        res.json(data);
    }, function (err) {
        console.log( err );
    })
  },

  // Create a new node 
  create: function (req, res) {
    sql.execute({
        name: "createOrphanedNode",
        preparedSql: "INSERT INTO Node(ID, Answer, Question)\
                      VALUES (@id, @answer, @question)",
        params: {
            id: {
                type: sql.INT,
                val: req.body.id
            },
            answer: {
                type: sql.VARCHAR,
                val: req.body.answer
            },
            question: {
                type: sql.VARCHAR,
                val: req.body.question
            }
        }
    })
  },

  // Update information about a node
  update: function (req, res) {
      sql.execute({
          // need to implement
          //
          params: {
              id: {
                  type: sql.INT,
                  val: req.params.id
              }
          } 
      })
  },

  // Delete node and all references to it if it's a leaf node
  delete: function (req, res) {
      sql.execute({
          procedure: "DeleteNode",
          params: {
              id: {
                  type: sql.INT,
                  val: req.params.id
              }
          }
      })
  },

  // Get all connected nodes to display as children
  showAllChildren: function (req, res) {
      sql.execute({
          procedure: "GetAllConnectedNodes",
          params: {
              PreviousID: {
                  type: sql.INT,
                  val: req.params.id
              }
          }
      }).then( function (data) {       
        res.json(data);
    }, function (err) {
        console.log( err );
    });
  }
}