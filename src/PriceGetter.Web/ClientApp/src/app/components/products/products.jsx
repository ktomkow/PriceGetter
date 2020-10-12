import React, { useState } from "react";
import { connect } from "react-redux";
import { getProducts } from "../../redux/actions/productsActionCreator";

import { Button } from "@material-ui/core";

const Products = (props) => {
  return (
    <div>
      <h1>Products </h1>
      <Button onClick={() => props.getProducts()}>Get</Button>
      <div>
        {props.products.map((item) => (
          <p key={item.id}>
            {item.name} : {item.price} : {item.id}
          </p>
        ))}
      </div>
    </div>
  );
};

const mapStateToProps = (state) => {
  return { products: state.productsReducer.products };
};

function mapDispatchToProps(dispatch) {
  return {
    getProducts: () => dispatch(getProducts()),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Products);
