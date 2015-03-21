var React = require('react');
var MediaFileRow = require('./MediaFileRow');

var MediaFileList = React.createClass({

	getDefaultProps: function() {
		return {
			mediaFiles: []
		};
	},

	render: function() {
		return (
			<table>
				<tr>
					<th>Title</th>
					<th>Duration</th>
					<th></th> //Edit
					<th></th> //Delete
				</tr>
				{
					this.props.mediaFiles.map(function(mediaFile){
						return <MediaFileRow key={ mediaFile.Id } mediaFile={ mediaFile } />
					})
				}
				<tr>
					<td>No Of Items: { this.props.mediaFiles.length }</td>
				</tr>
			</table>
		);
	}
});

module.exports = MediaFileList;