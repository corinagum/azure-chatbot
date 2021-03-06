
var width  = 900,
    height = 600,
    colors = d3.scale.category10();

var zoom = d3.behavior.zoom()
    .translate([0, 0])
    .scale(1)
    .scaleExtent([1 / 2, 8])
    .on("zoom", zoomed);

var svg = d3.select('#svg_div')
  .append('svg')
  .attr('oncontextmenu', 'return false;')
  .attr('width', width)
  .attr('height', height)
  .append("g")
  .call(zoom);

var rect = svg.append("rect")
  .attr("width", width)
  .attr("height", height)
  .style("fill", "#fff")
  ;

function zoomed(){
    console.log("translate: ",d3.event.translate);
    console.log("scale: ", d3.event.scale);
    svg.attr("transform", "translate(" + d3.event.translate + ")scale(" + d3.event.scale + ")");
}

var nodes = [];
var links = [];
var lastNodeId = 0;
var didSelectNode = false;

d3.json("http://localhost:8000/api/nodes", function(data) {
    for (var idx in data) {
        var row = data[idx];
        var newNode = { id: row.ID, reflexive: true, question: row.Question, answer: row.Answer }
        nodes.push(newNode);
    }
    lastNodeId = nodes[nodes.length - 1].id;
    restart();
});

d3.json("http://localhost:8000/api/references", function(data) {  
  createLinks(data);
  restart();
});

// Create all links between nodes based on ids from references table
function createLinks(refs) {
  for (var i = 0; i < refs.length; i++) {
    var newLink = { left: false, right: true };
    newLink.source = findNodeWithID(refs[i].ParentID);
    newLink.target = findNodeWithID(refs[i].ChildID);
    links.push(newLink)
  }
}

function findNodeWithID(id) {
  for (var k = 0; k < nodes.length; k++) {
    if (nodes[k].id === id) {
      return nodes[k];
    }
  }
}

// init D3 force layout
var force = d3.layout.force()
    .nodes(nodes)
    .links(links)
    .size([width, height])
    .linkDistance(150)
    .charge(-150)
    .on('tick', tick)

// define arrow markers for graph links
svg.append('svg:defs').append('svg:marker')
    .attr('id', 'end-arrow')
    .attr('viewBox', '0 -5 10 10')
    .attr('refX', 6)
    .attr('markerWidth', 3)
    .attr('markerHeight', 3)
    .attr('orient', 'auto')
  .append('svg:path')
    .attr('d', 'M0,-5L10,0L0,5')
    .attr('fill', '#000');

svg.append('svg:defs').append('svg:marker')
    .attr('id', 'start-arrow')
    .attr('viewBox', '0 -5 10 10')
    .attr('refX', 4)
    .attr('markerWidth', 3)
    .attr('markerHeight', 3)
    .attr('orient', 'auto')
  .append('svg:path')
    .attr('d', 'M10,-5L0,0L10,5')
    .attr('fill', '#000');

// line displayed when dragging new nodes
var drag_line = svg.append('svg:path')
  .attr('class', 'link dragline hidden')
  .attr('d', 'M0,0L0,0');

// handles to link and node element groups
var path = svg.append('svg:g').selectAll('path'),
    circle = svg.append('svg:g').selectAll('g');

// mouse event vars
var selected_node = null,
    selected_link = null,
    mousedown_link = null,
    mousedown_node = null,
    mouseup_node = null;



function resetMouseVars() {
  mousedown_node = null;
  mouseup_node = null;
  mousedown_link = null;
}

// update force layout (called automatically each iteration)
function tick() {
  // draw directed edges with proper padding from node centers
  path.attr('d', function(d) {
    var deltaX = d.target.x - d.source.x,
        deltaY = d.target.y - d.source.y,
        dist = Math.sqrt(deltaX * deltaX + deltaY * deltaY),
        normX = deltaX / dist,
        normY = deltaY / dist,
        sourcePadding = d.left ? 17 : 12,
        targetPadding = d.right ? 17 : 12,
        sourceX = d.source.x + (sourcePadding * normX),
        sourceY = d.source.y + (sourcePadding * normY),
        targetX = d.target.x - (targetPadding * normX),
        targetY = d.target.y - (targetPadding * normY);
    return 'M' + sourceX + ',' + sourceY + 'L' + targetX + ',' + targetY;
  });

  circle.attr('transform', function(d) {
    return 'translate(' + d.x + ',' + d.y + ')';
  });
}

// update graph (called when needed)
function restart() {
  // path (link) group
  path = path.data(links);

  // update existing links
  path.classed('selected', function(d) { return d === selected_link; })
    .style('marker-start', function(d) { return d.left ? 'url(#start-arrow)' : ''; })
    .style('marker-end', function(d) { return d.right ? 'url(#end-arrow)' : ''; });


  // add new links
  path.enter().append('svg:path')
    .attr('class', 'link')
    .classed('selected', function(d) { return d === selected_link; })
    .style('marker-start', function(d) { return d.left ? 'url(#start-arrow)' : ''; })
    .style('marker-end', function(d) { return d.right ? 'url(#end-arrow)' : ''; })
    .on('mousedown', function(d) {
      if(d3.event.ctrlKey) return;

      // select link
      mousedown_link = d;
      if(mousedown_link === selected_link) selected_link = null;
      else selected_link = mousedown_link;
      selected_node = null;
      restart();
    });

  // remove old links
  path.exit().remove();


  // circle (node) group
  // NB: the function arg is crucial here! nodes are known by id, not by index!
  circle = circle.data(nodes, function(d) { return d.id; });

  // update existing nodes (reflexive & selected visual states)
  circle.selectAll('circle')
    .style('fill', function(d) { return (d === selected_node) ? d3.rgb(colors(d.id)).brighter().toString() : colors(d.id); })
    .classed('reflexive', function(d) { return d.reflexive; });

  // add new nodes
  var g = circle.enter().append('svg:g');
  g.append('svg:circle')
    .attr('class', 'node')
    .attr('r', 12)
    .style('fill', function(d) { return (d === selected_node) ? d3.rgb(colors(d.id)).brighter().toString() : colors(d.id); })
    .style('stroke', function(d) { return d3.rgb(colors(d.id)).darker().toString(); })
    .classed('reflexive', function(d) { return d.reflexive; })
    .on('mouseover', function(d) {
      if(!mousedown_node || d === mousedown_node) return;
      // enlarge target node
      d3.select(this).attr('transform', 'scale(1.1)');
    })
    .on('mouseout', function(d) {
      if(!mousedown_node || d === mousedown_node) return;
      // unenlarge target node
      d3.select(this).attr('transform', '');
    })
    .on('mousedown', function(d) {
      didSelectNode = true;
      if (d3.event.ctrlKey) return;
      // select node
      mousedown_node = d;
      if(mousedown_node === selected_node) selected_node = null;
      else selected_node = mousedown_node;
      selected_link = null;
      openInfo();
      // reposition drag line
      drag_line
        .style('marker-end', 'url(#end-arrow)')
        .classed('hidden', false)
        .attr('d', 'M' + mousedown_node.x + ',' + mousedown_node.y + 'L' + mousedown_node.x + ',' + mousedown_node.y);

      restart();
    })
    .on('mouseup', function(d) {
      if(!mousedown_node) return;

      // needed by FF
      drag_line
        .classed('hidden', true)
        .style('marker-end', '');

      // check for drag-to-self
      mouseup_node = d;
      if(mouseup_node === mousedown_node) { resetMouseVars(); return; }

      // unenlarge target node
      d3.select(this).attr('transform', '');

      // add link to graph (update if exists)
      // NB: links are strictly source < target; arrows separately specified by booleans
      var source, target, direction;
      if (mousedown_node.id < mouseup_node.id) {
        source = mousedown_node;
        target = mouseup_node;
        direction = 'right';
      } else {
        source = mouseup_node;
        target = mousedown_node;
        direction = 'left';
      }

      var link;
      link = links.filter(function(l) {
        return (l.source === source && l.target === target);
      })[0];

      if (link) {
        link[direction] = true;
      } else {
        link = {source: source, target: target, left: false, right: false};
        link[direction] = true;


        console.log(link);

        //
        postNewLink(link);
        links.push(link);
        
      }

      // select new link
      selected_link = link;
      selected_node = null;
      restart();
    });

  // show node IDs
  g.append('svg:text')
      .attr('x', 0)
      .attr('y', 4)
      .attr('class', 'id')
      .text(function(d) { return d.id; });

  // remove old nodes
  circle.exit().remove();

  // set the graph in motion
  force.start();
}

function mousedown() {
  // prevent I-bar on drag
  //d3.event.preventDefault();
  // because :active only works in WebKit?
  if (didSelectNode == false) {
    var id = lastNodeId + 1;
    $('#id_value').attr('value', id);
    $('#id_label').html("ID: " + id + '\n')
    // var idLabel = document.getElementById('id_label');
    // idLabel.innerHTML = ;    
    $('#myModal').modal('show');
    modal_is_displayed = true;
  }
  didSelectNode = false;
  svg.classed('active', true);

  if(d3.event.ctrlKey || mousedown_node || mousedown_link) return;

  // insert new node at point
  var point = d3.mouse(this),
      node = {id: ++lastNodeId, reflexive: false, question:"Question " + lastNodeId, answer:"Answer " + lastNodeId};
  node.x = point[0];
  node.y = point[1];
  nodes.push(node);

  restart();

}

function mousemove() {
  if(!mousedown_node) return;

  // update drag line
  drag_line.attr('d', 'M' + mousedown_node.x + ',' + mousedown_node.y + 'L' + d3.mouse(this)[0] + ',' + d3.mouse(this)[1]);

  restart();
}

function mouseup() {
  if(mousedown_node) {
    // hide drag line
    drag_line
      .classed('hidden', true)
      .style('marker-end', '');
  }

  // because :active only works in WebKit?
  svg.classed('active', false);

  // clear mouse event vars
  resetMouseVars();
}

function spliceLinksForNode(node) {
  var toSplice = links.filter(function(l) {
    return (l.source === node || l.target === node);
  });
  toSplice.map(function(l) {
    links.splice(links.indexOf(l), 1);
  });
}

// only respond once per keydown
var lastKeyDown = -1;

function keydown() {
 // d3.event.preventDefault();

  if(lastKeyDown !== -1) return;
  lastKeyDown = d3.event.keyCode;

  // ctrl
  if(d3.event.keyCode === 17) {
    circle.call(force.drag);
    svg.classed('ctrl', true);
  }

  if(!selected_node && !selected_link) return;
  switch(d3.event.keyCode) {
    case 8: // backspace
    case 46: // delete
      if(selected_node) {
        nodes.splice(nodes.indexOf(selected_node), 1);
        spliceLinksForNode(selected_node);
      } else if(selected_link) {
        links.splice(links.indexOf(selected_link), 1);
      }
      selected_link = null;
      selected_node = null;
      restart();
      break;
    case 66: // B
      if(selected_link) {
        // set link direction to both left and right
        selected_link.left = true;
        selected_link.right = true;
      }
      restart();
      break;
    case 76: // L
      if(selected_link) {
        // set link direction to left only
        selected_link.left = true;
        selected_link.right = false;
      }
      restart();
      break;
    case 82: // R
      if(selected_node) {
        // toggle node reflexivity
        selected_node.reflexive = !selected_node.reflexive;
      } else if(selected_link) {
        // set link direction to right only
        selected_link.left = false;
        selected_link.right = true;
      }
      restart();
      break;
  }
}

function keyup() {
  lastKeyDown = -1;

  // ctrl
  if(d3.event.keyCode === 17) {
    circle
      .on('mousedown.drag', null)
      .on('touchstart.drag', null);
    svg.classed('ctrl', false);
  }
}

// Removes added node if user doesn't complete setup
function removeNodeAfterModalClose() {
  selected_node = nodes[lastNodeId-1];
  nodes.splice(nodes.indexOf(selected_node), 1);
  spliceLinksForNode(selected_node);
  selected_node = null;
  restart();
  lastNodeId = nodes[nodes.length - 1].id;
}

// Opens sidebar with node info
function openInfo() {
  var infodiv = document.getElementById('info_div');
  infodiv.innerHTML = "<div id='panel' class='panel panel-default'><div id='panel_heading' class='panel-heading'></div><div id='panel_body'class='panel-body'></div><div id='panel_footer' class='panel-footer'></div></div>";
  var panelheader = document.getElementById('panel_heading');
  var panelbody = document.getElementById('panel_body');
  var panelfooter = document.getElementById('panel_footer');
  panelheader.innerHTML = "<h2> Node " + mousedown_node.id + "</h3>";
  panelbody.innerHTML += "<h3>Question</h3><div class='well'><p>" + mousedown_node.question + "</p></div>";
  panelbody.innerHTML += "<h3>Child Answers </br></h3>";
  panelbody.innerHTML += "<ul id='children_list' class='list-group'></ul>";
  var childrenlist = document.getElementById('children_list'); 
  var currentID = mousedown_node.id
  getChildNodes(currentID);
  // panelbody.innerHTML += "<h3>Parent Question</h3><div class='well'><p>Sample Parent Question</p></div>";
  panelbody.innerHTML += "<h3>Answer</h3><div class='well'><p>" + mousedown_node.answer + "</p></div>";
  panelfooter.innerHTML += "<button id='edit_button' type='button' onClick='editPanel()'class='btn btn-block btn-info'>Edit</button>";
  infodiv.style.visibility = "visible";
}

// Get child nodes to display in info sidebar
function getChildNodes(id) {
  var children = [];
  $.get("/api/nodes/children/" + id, function(data) {
    var returned_children = data[0][0];
    for(var i = 0; i < returned_children.length; i++) {
      children.push(returned_children[i]);
    }
    console.log(children);
    var childrenlist = document.getElementById('children_list');
    for (var i = 0; i < children.length; i++) {
      childrenlist.innerHTML += "<li class='list-group-item'>ID(" +  children[i].ID + ") : " + children[i].Answer + "</li>"
    }
  });
}

function postNewLink(link) {
  $.post('/api/references', { parentID: link.source.id, childID: link.target.id })
}

// app starts here
svg.on('mousedown', mousedown)
  .on('mousemove', mousemove)
  .on('mouseup', mouseup);
d3.select(window)
  .on('keydown', keydown)
  .on('keyup', keyup);
restart();