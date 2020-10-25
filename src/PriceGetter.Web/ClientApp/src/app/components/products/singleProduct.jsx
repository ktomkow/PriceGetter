import React, { useEffect } from "react";
import { connect } from "react-redux";
import {
    getProduct
} from "../../redux/actions/productsActionCreator";
import { Link, useParams } from "react-router-dom";

import { makeStyles } from "@material-ui/core/styles";
import { Grid, Paper, Button, List, ListItem } from "@material-ui/core";

import strings from "../../localization/strings";

const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
    marginTop: "1em",
  },
  paper: {
    marginBottom: "0.2em",
    padding: theme.spacing(2),
    // textAlign: "center",
  },
}));

const SingleProduct = (props) => {
  const classes = useStyles();
  const { id } = useParams();

  useEffect(() => {
    // on mount
    props.getProduct(id);
  }, []);

  return (
    <>
      <Grid container className={classes.root} spacing={3}>
        <Grid item xs={2}>
          <Paper className={classes.paper}>
              <Button component={Link} to="/products">{strings.SINGLE_PRODUCT.GO_BACK_BUTTON}</Button>
          </Paper>
          <Paper className={classes.paper}></Paper>
          <Paper className={classes.paper}></Paper>
          <Paper className={classes.paper}>
              <List>
                  <ListItem>props.productsReducer.singleProduct.id {props.productsReducer.singleProduct.id} </ListItem>
                  <ListItem>props.productsReducer.singleProduct.name {props.productsReducer.singleProduct.id}</ListItem>
                  <ListItem>props.productsReducer.singleProduct.imageUrl {props.productsReducer.singleProduct.id}</ListItem>
                  <ListItem>props.productsReducer.singleProduct.productPage {props.productsReducer.singleProduct.id}</ListItem>
                  <ListItem>props.productsReducer.singleProduct.lastPrice {props.productsReducer.singleProduct.id}</ListItem>
              </List>
          </Paper>
        </Grid>
        <Grid item xs={8}>
          <Paper className={classes.paper}></Paper>
        </Grid>
        <Grid item xs={2}>
          <Paper className={classes.paper}></Paper>
        </Grid>
      </Grid>
    </>
  );
};


function mapDispatchToProps(dispatch) {
    return {
      getProduct: (id) => getProduct(id, dispatch)
    };
  }

const mapStateToProps = (state) => {
  return { productsReducer: state.productsReducer };
};

export default connect(mapStateToProps, mapDispatchToProps)(
  SingleProduct
);
