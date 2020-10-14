import React, { useState } from "react";
import { connect } from "react-redux";
import { getProducts } from "../../redux/actions/productsActionCreator";

import { Button, CircularProgress, Grid } from "@material-ui/core";
import { useEffect } from "react";
import ProductCard from "./productCard";

const Products = (props) => {
  useEffect(() => {
    console.log("hook");
    props.getProducts();
  }, []);

  return (
    <>
      <h1>Products </h1>
      <Button color="primary" onClick={() => props.getProducts()}>
        Get
      </Button>
      <Button color="secondary" onClick={() => props.getProducts()}>
        Get
      </Button>
      <Grid container spacing={2}>
        <Grid item xs={4}>
          <ProductCard />
        </Grid>
        <Grid item xs={4}>
          <ProductCard />
        </Grid>
        <Grid item xs={4}>
          <ProductCard />
        </Grid>
      </Grid>
      {props.products.length === 0 && <CircularProgress />}
      <div>
        {props.products.map((item) => (
          <p key={item.id}>
            Name: {item.name}, id: {item.id}
          </p>
        ))}
      </div>
    </>
  );
};

const mapStateToProps = (state) => {
  return { products: state.productsReducer.products };
};

export default connect(mapStateToProps, { getProducts })(Products);
