import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getProducts, clearProducts } from "../../redux/actions/productsActionCreator";

import { CircularProgress, Grid, Typography } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";

import ProductCard from "./productCard";

const useStyles = makeStyles({
  spinner: {
    position: "relative",
    marginLeft: "50%",
    marginTop: "10%",
  }
});

const Products = (props) => {
  const classes = useStyles();

  useEffect(() => {
    console.log("hook");
    props.clearProducts();
    props.getProducts();
  }, []);

  return (
    <>
      <Typography variant="h3">Products </Typography>
      {props.products.length === 0 && (
        <Grid container spacing={0} alignItems="center" justify="center">
          <Grid item xs={12}>
            <CircularProgress
              className={classes.spinner}
              size="8rem"
              thickness={1.0}
            />
          </Grid>
        </Grid>
      )}
      <Grid container spacing={2}>
        {props.products.map((item) => (
          <Grid item xs={12} sm={4} lg={3} key={item.id}>
            <ProductCard product={item} />
          </Grid>
        ))}
      </Grid>
    </>
  );
};

const mapStateToProps = (state) => {
  return { products: state.productsReducer.products };
};

export default connect(mapStateToProps, { getProducts, clearProducts })(Products);
