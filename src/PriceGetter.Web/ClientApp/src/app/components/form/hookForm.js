import React, { useState } from "react";
import { connect } from "react-redux";
import { addArticle } from "../../redux/actions/index";

const HookForm = (props) => {
  const [title, setTitle] = useState("");

  const handleTitleChange = (event) => {
    console.log(event.target.value);
    setTitle(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    props.addArticle({ title });
    setTitle("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <h1>Hook form</h1>
        <label htmlFor="title">Title</label>
        <input
          type="text"
          id="title"
          value={title}
          onChange={handleTitleChange}
        />
      </div>
      <button type="submit">SAVE</button>
    </form>
  );
};
function mapDispatchToProps(dispatch) {
  return {
    addArticle: (article) => dispatch(addArticle(article)),
  };
}

export default connect(null, mapDispatchToProps)(HookForm);
