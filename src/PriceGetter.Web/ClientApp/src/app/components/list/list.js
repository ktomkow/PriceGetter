import React from "react";
import { connect } from "react-redux";

const ConnectedList = (props) => {
  return (
    <div>
      <h1>Articles</h1>
      <ul>
        {props.articles.map((el) => (
          <li key={el.id}>{el.title}</li>
        ))}
      </ul>
    </div>
  );
};

const mapStateToProps = (state) => {
  return { articles: state.articles };
};


// option 1
const List = connect(mapStateToProps)(ConnectedList);
export default List;


// option 2
// export default connect(mapStateToProps, {})(ConnectedList)