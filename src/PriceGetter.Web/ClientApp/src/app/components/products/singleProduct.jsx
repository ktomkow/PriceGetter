import React, { useEffect } from "react";
import { connect } from "react-redux";
import { getProduct } from "../../redux/actions/productsActionCreator";
import { Link, useParams } from "react-router-dom";

import { makeStyles } from "@material-ui/core/styles";
import { Grid, Paper, Button, List, ListItem, Box } from "@material-ui/core";
import { DataGrid } from "@material-ui/data-grid";

import strings from "../../localization/strings";

import IconLink from "./../common/iconLink";

import { mockImage } from "../../mocks/product/image";
import { isUrlValid } from "../../services/urlService";
import { formatRawDate } from "../../services/dateServices";

import { useSnackbar } from "notistack";

import { showSnack } from "../../redux/actions/notificationsActionCreator";

const rows = [
  {
    id: 1,
    username: "defunkt",
    age: 38,
  },
];

const prices = [
  { id: 1, at: new Date(), amount: 1 },
  { id: 2, at: new Date(), amount: 2 },
  { id: 3, at: new Date(), amount: 3 },
];

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    marginTop: "1em",
  },
  paper: {
    marginBottom: "0.2em",
    padding: theme.spacing(1),
    // textAlign: "center",
  },
  imageContainer: {
    width: "8em",
    height: "8em",
    padding: "0",
    margin: "0",
  },
  image: {
    width: "100%",
    height: "auto",
    margin: "0",
    padding: "0",
  },
  dataGridContainer: {
    height: 600,
    width: "100%",
  },
}));

const SingleProduct = (props) => {
  const classes = useStyles();
  const { enqueueSnackbar, closeSnackbar } = useSnackbar();
  const { id } = useParams();
  const imageUrl = props.productsReducer.singleProduct.imageUrl;

  const productPrices = props.productsReducer.singleProduct.prices;

  useEffect(() => {
    // on mount
    props.getProduct(id);
  }, []);

  const formattedPrices = () => {
    if (!productPrices) {
      return [];
    }

    const prices = productPrices.map((x) => ({
      id: x.amount + x.at,
      amount: x.amount,
      at: formatRawDate(x.at),
    }));

    return prices;
  };

  const gridLegend = {
    amountHeader: strings.SINGLE_PRODUCT.DATA_GRID.AMOUNT_HEADER,
    amountDescription: strings.SINGLE_PRODUCT.DATA_GRID.AMOUNT_DESCRIPTION,
    dateHeader: strings.SINGLE_PRODUCT.DATA_GRID.DATE_HEADER,
    dateDescription: strings.SINGLE_PRODUCT.DATA_GRID.DATE_DESCRIPTION,
  };

  const snack = () => {
    enqueueSnackbar("I love hooks", {
      variant: "error",
      autoHideDuration: 2000,
    });
  };

  const snackRedux = () => {
    props.showSnack("I love snacks and redux!");
  }

  const getProductImage = () => {
    if (isUrlValid(imageUrl)) {
      return imageUrl;
    }

    return mockImage;
  };

  return (
    <>
      <Grid container className={classes.root} spacing={3}>
        <Grid item xs={2}>
          <Paper className={classes.paper}>
            <Box className={classes.imageContainer}>
              <img
                src={getProductImage()}
                alt="product image"
                className={classes.image}
              />
            </Box>
          </Paper>
          <Paper className={classes.paper}>
            <Button component={Link} to="/products">
              {strings.SINGLE_PRODUCT.GO_BACK_BUTTON}
            </Button>
          </Paper>
          <Paper className={classes.paper}>
            <Button onClick={snack}>SNACK</Button>
          </Paper>
          <Paper className={classes.paper}>
            <Button onClick={snackRedux}>SNACK REDUX</Button>
          </Paper>
          <Paper className={classes.paper}>
            <IconLink link={props.productsReducer.singleProduct.productPage} />
          </Paper>

          <Paper className={classes.paper}>
            <List>
              <ListItem>
                props.productsReducer.singleProduct.id :{" "}
                {props.productsReducer.singleProduct.id}{" "}
              </ListItem>
              <ListItem>
                props.productsReducer.singleProduct.name :{" "}
                {props.productsReducer.singleProduct.name}
              </ListItem>
              <ListItem>
                props.productsReducer.singleProduct.imageUrl :{" "}
                {props.productsReducer.singleProduct.imageUrl}
              </ListItem>
              <ListItem>
                props.productsReducer.singleProduct.productPage :{" "}
                {props.productsReducer.singleProduct.productPage}
              </ListItem>
              <ListItem>
                props.productsReducer.singleProduct.lastPrice :{" "}
                {props.productsReducer.singleProduct.lastPrice}
              </ListItem>
            </List>
          </Paper>
        </Grid>
        <Grid item xs={8}>
          <Paper className={classes.paper}>
            <div className={classes.dataGridContainer}>
              <DataGrid
                columns={[
                  { field: "id", hide: true },
                  {
                    field: "amount",
                    headerName: strings.SINGLE_PRODUCT.DATA_GRID.AMOUNT_HEADER,
                    description:
                      strings.SINGLE_PRODUCT.DATA_GRID.AMOUNT_DESCRIPTION,
                    width: 200,
                  },
                  {
                    field: "at",
                    headerName: strings.SINGLE_PRODUCT.DATA_GRID.DATE_HEADER,
                    description:
                      strings.SINGLE_PRODUCT.DATA_GRID.DATE_DESCRIPTION,
                    width: 400,
                  },
                ]}
                rows={formattedPrices()}
              />
            </div>
          </Paper>
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
    getProduct: (id) => getProduct(id, dispatch),
    showSnack: (text) => dispatch(showSnack(text)),
  };
}

const mapStateToProps = (state) => {
  return { productsReducer: state.productsReducer };
};

export default connect(mapStateToProps, mapDispatchToProps)(SingleProduct);
