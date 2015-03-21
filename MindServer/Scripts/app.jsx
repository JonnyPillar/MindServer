var React = require('react');
var Router = require('react-router');
var Route = Router.Route;
var	RouteHandler = Router.RouteHandler;
var	Link = Router.Link;
var	State = Router;

var HomePage = require('./Pages/HomePage');
var MediaPage = require('./Pages/MediaPage');

var App = React.createClass({

	render: function() {
		return (
			<div>
				<ul>
					<li><Link to="home">Home</Link></li>
					<li><Link to="mediaPage">Media</Link></li>
				</ul>
				<RouteHandler/>
			</div>
		);
	}

});

var routes = (
	<Route handler={App}>
	  <Route name="home" handler={HomePage}/>
	  <Route name="mediaPage" handler={MediaPage}>
	  	<Route name="createMedia" handler={MediaPage}/>
	  	<Route name="editMedia" handler={MediaPage}/>
	  	<Route name="deleteMedia" handler={MediaPage}/>
	  </Route>
	</Route>
)

Router.run(routes, function (Handler) {
  React.render(<Handler/>, document.getElementById('react-div'));
});