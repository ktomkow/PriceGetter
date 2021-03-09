import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import {
  getProducts,
  clearProducts,
  updateSearchBox,
} from '../../redux/actions/productsActionCreator';

import {
  Button,
  CircularProgress,
  Grid,
  TextField,
  Typography,
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

import ProductCard from './productCard';
import { Paper } from '@material-ui/core';

const useStyles = makeStyles({
  spinner: {
    position: 'relative',
    marginLeft: '50%',
    marginTop: '10%',
  },
  nonProduct: {
    marginTop: '0.5rem',
    marginBottom: '0.5rem',
    padding: '1rem',
  },
searchBoxInputContainer: {
    width: "100%"
  }
});

const Products = (props) => {
  const classes = useStyles();

  useEffect(() => {
    if (!props.products.some((x) => true)) {
      refresh();
    }
  }, []);

  const refresh = () => {
    props.clearProducts();
    props.getProducts();
  };

  const handleSearchboxInput = (e) => {
    props.updateSearchBox(e.target.value);
  };

  return (
    <>
      <Grid
        container
        direction='row'
        justify='space-between'
        alignItems='center'
        spacing={2}
      >
        <Grid item>
          <Paper className={[classes.nonProduct,  classes.searchBoxInputContainer]}>
            <TextField
              variant='outlined'
              label='Search'
              value={props.searchExpression}
              onChange={handleSearchboxInput}
              fullWidth
            ></TextField>
          </Paper>
        </Grid>
        <Grid item>
          <Paper className={classes.nonProduct}>
            <Button onClick={refresh}>Refresh</Button>
          </Paper>
        </Grid>
      </Grid>
      {props.products.length === 0 && (
        <Grid container spacing={0} alignItems='center' justify='center'>
          <Grid item xs={12}>
            <CircularProgress
              className={classes.spinner}
              size='8rem'
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
  return {
    products: state.productsReducer.filteredProducts,
    searchExpression: state.productsReducer.searchExpression,
  };
};

export default connect(mapStateToProps, {
  getProducts,
  clearProducts,
  updateSearchBox,
})(Products);
