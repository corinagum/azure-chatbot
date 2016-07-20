*Markdown file that explains database design and stored procedures for future use*

#Database Design

###Tables

Node
* id (Primary Key)
* question (TEXT)
* answer (TEXT)
* intent (Foreign Key referencing Intent table)
* error_id (Foreign Key referencing Error table)

Intent
* id (Primary Key)
* content (TEXT)

Error
* id (Primary Key)
* content (TEXT)

Reference
* start_id (Foreign Key referencing Node table parent node)
* end_id (Foreign Key referencing Node table child node)

###Notes
* Reference table defines parent-child relationships between nodes. 

#Procedures

1. AddNodeWithContent
 * *Used to insert a new node*
 * Saves Parent Node as a variable, creates a new node, saves that node's id as a different variable, and adds a row in the Reference table with these ids as start_id(parent) and end_id(new child node). 
  * **Procedure**

2. AddReference
 * *Used to add a different parent-child relationship between nodes; when a node already exists, but needs to be a child node of a different parent as well. Creates a new avenue in our graph structure.*
 * Saves Parent Node as a variable, saves Child Node as a different variable, and adds a row in the Reference table with these ids as start_id(parent) and end_id(new child node).
  * **Procedure**

3. FindChildren
 * *When a user selects an option from the dialog box, run FindChildren to query the database for that specific node's children. Returns the information from those nodes in JSON format*
  * Saves Parent Node as a variable, queries Reference table for all rows with a start_id of that variable, then joins the Node table on the end_id from Reference and the id from Node, returning the child nodes as JSON.
  * **Procedure**