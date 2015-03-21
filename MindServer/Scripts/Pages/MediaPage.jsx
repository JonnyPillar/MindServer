var React = require('react');
var AddMediaFileButton = require('../Components/MediaFile/AddMediaFileButton');
var MediaFileList = require('../Components/MediaFile/MediaFileList');

var MediaPage = React.createClass({

	getInitialState: function() {
		return {
			mediaFiles: [] 
		};
	},

	getMediaFiles:function(){
		$.get('https://mind-1.apphb.com/api/audio', function(result) {
	      if (this.isMounted()) {
	        this.setState({
	          mediaFiles: result
	        });
	      }
	    }.bind(this));
	},

	render: function() {
		return (
			<div>
				<h2>Media Page</h2>
				<AddMediaFileButton />
				<MediaFileList mediaFiles={ this.state.mediaFiles } />
			</div>
		);
	}
});

module.exports = MediaPage;