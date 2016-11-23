var React = require('react');
var ReactDOM = require('react-dom');
window.$ = window.jQuery = require('jquery');

var FriendsBox = React.createClass({
    'getInitialState': function () {
        return {data: []};
    },
    'loadFriendsFromServer': function () {
        $.ajax({
            'url': this.props.url,
            'dataType': 'json',
            'cache': false,
            'success': function (data) {
                this.setState({'data': data});
            }.bind(this),
            'error': function (xhr, status, error) {
                console.error(this.proprs.url, stats, error.toString());
            }.bind(this)
        });
    },
    'componentDidMount': function () {
        this.loadFriendsFromServer();
    },
    'render': function () {
        return (
            <div className="friendsBox">
                <h1>Friends</h1>
                <FriendsList data={this.state.data} />
            </div>
        );
    }
});

var FriendsList = React.createClass({
    render: function() {
        var friendNodes = this.props.data.map(function (friend) {
            return (<li key={friend}>{friend}</li>);
        });
        return (
            <ul className="friendList">
                {friendNodes}
            </ul>
        );
    }
});

ReactDOM.render(
    <FriendsBox url='/api/values' />, document.getElementById('friends')
);
