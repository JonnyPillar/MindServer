var React = require('react');

var MediaFileRow = React.createClass({

	getDefaultProps: function() {
		return {
			mediaFile: {
				Id: '',
	            FileName: '',
	            FileUrl: '',
	            Title: '',
	            Duration: '',
	            Description: '',
	            ThumbnailUrl: '',
	            ImageUrl: '',
	            BaseColour: '',
	            MediaType: ''
			}
		};
	},

	render: function() {
		return (
			<tr>
				<td>{ this.props.mediaFile.Title }</td>
				<td>{ this.props.mediaFile.Duration }</td>
				<td>Edit</td>
				<td>Delete</td>
			</tr>
		);
	}

});

module.exports = MediaFileRow;