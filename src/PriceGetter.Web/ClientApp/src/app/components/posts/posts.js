import React, { Component } from "react";
import { connect } from "react-redux";
import { getData } from "../../redux/actions/index";

export class Post extends Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.getData();
  }

  render() {
    return (
      <ul>
        {this.props.remoteArticles.map(el => (
          <li key={el.id}>{el.title}</li>
        ))}
      </ul>
    );
  }
}

function mapStateToProps(state) {
  return {
    remoteArticles: state.remoteArticles.slice(0, 100)
  };
}

export default connect(
  mapStateToProps,
  { getData }
)(Post);