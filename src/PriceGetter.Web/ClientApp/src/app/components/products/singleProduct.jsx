import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { getProduct, getMonthStatistics } from '../../redux/actions/productsActionCreator';
import { Link, useParams } from 'react-router-dom';

import { makeStyles } from '@material-ui/core/styles';
import { Grid, Paper, Button, Box } from '@material-ui/core';
import { DataGrid } from '@material-ui/data-grid';

import strings from '../../localization/strings';

import IconLink from './../common/iconLink';

import { mockImage } from '../../mocks/product/image';
import { isUrlValid } from '../../services/urlService';
import { formatRawDate } from '../../services/dateServices';

import { useSnackbar } from 'notistack';

import { showInfoSnack } from '../../redux/actions/notificationsActionCreator';
import { round } from '../../services/moneyServices';

import {
  ArgumentAxis,
  ValueAxis,
  Chart,
  LineSeries,
  Title,
  Tooltip,
} from '@devexpress/dx-react-chart-material-ui';
import { EventTracker } from '@devexpress/dx-react-chart';
import { Typography } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    marginTop: '1em',
  },
  paper: {
    marginBottom: '0.2em',
    padding: theme.spacing(1),
  },
  imageContainer: {
    width: '8em',
    height: '8em',
    padding: '0',
    margin: '0',
  },
  image: {
    width: '100%',
    height: 'auto',
    margin: '0',
    padding: '0',
  },
  dataGridContainer: {
    height: 600,
  },
}));

const SingleProduct = (props) => {
  const classes = useStyles();
  const { enqueueSnackbar, closeSnackbar } = useSnackbar();
  const { id } = useParams();
  const imageUrl = props.productsReducer.singleProduct.imageUrl;
  const productName = props.productsReducer.singleProduct.name;

  useEffect(() => {
    // on mount
    props.getProduct(id);
    props.getMonthStatistics(id);
  }, []);

  const formattedPrices = () => {
    if (!props.productsReducer.singleProduct.prices) {
      return [];
    }

    const prices = props.productsReducer.singleProduct.prices
      .sort(function (a, b) {
        return new Date(a.at) - new Date(b.at);
      })
      .map((x) => ({
        id: x.amount + x.at,
        amount: round(x.amount),
        at: formatRawDate(x.at),
      }));

    return prices;
  };

  const snack = () => {
    enqueueSnackbar('I love hooks', {
      variant: 'error',
      autoHideDuration: 2000,
    });
  };

  const snackRedux = () => {
    props.showInfoSnack('I love snacks and redux!');
  };

  const getProductImage = () => {
    if (isUrlValid(imageUrl)) {
      return imageUrl;
    }

    return mockImage;
  };

  return (
    <>
      <Grid container className={classes.root} spacing={3}>
        <Grid container item xs={12} sm={4}>
          <Grid item>
            <Paper className={classes.paper}>
              <Typography variant='h6'>{productName}</Typography>
              <Box className={classes.imageContainer}>
                <img
                  src={getProductImage()}
                  alt='product image'
                  className={classes.image}
                />
              </Box>
            </Paper>
            <Paper className={classes.paper}>
              <Button component={Link} to='/products'>
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
              <IconLink
                link={props.productsReducer.singleProduct.productPage}
              />
            </Paper>
          </Grid>
        </Grid>
        <Grid
          container
          item
          xs={12}
          sm={8}
          direction='column'
          justify='center'
          alignItems='stretch'
          spacing={2}
        >
          <Grid item xs={12}>
            <Paper className={classes.paper}>
              <Chart data={formattedPrices()}>
                <ArgumentAxis />
                <ValueAxis />
                <EventTracker />
                <Tooltip />

                <LineSeries valueField='amount' argumentField='at' />
                <Title text={strings.SINGLE_PRODUCT.CHART.TITLE} />
              </Chart>
            </Paper>
          </Grid>
          <Grid item xs={12}>
            <Paper className={classes.paper}>
              <div className={classes.dataGridContainer}>
                <DataGrid
                  columns={[
                    { field: 'id', hide: true },
                    {
                      field: 'amount',
                      headerName:
                        strings.SINGLE_PRODUCT.DATA_GRID.AMOUNT_HEADER,
                      description:
                        strings.SINGLE_PRODUCT.DATA_GRID.AMOUNT_DESCRIPTION,
                      width: 100,
                    },
                    {
                      field: 'at',
                      headerName: strings.SINGLE_PRODUCT.DATA_GRID.DATE_HEADER,
                      description:
                        strings.SINGLE_PRODUCT.DATA_GRID.DATE_DESCRIPTION,
                      width: 150,
                    },
                  ]}
                  rows={formattedPrices()}
                />
              </div>
            </Paper>
          </Grid>
          <Grid item xs={12}>
            <div>
              {props.productsReducer.statistics.months.map((x) => (
                <ul key={`${x.month}.${x.year}`}>
                  <li>{x.month}.{x.year}: min: {x.minPrice} zł, max: {x.maxPrice} zł</li>
                </ul>
              ))}
            </div>
          </Grid>
        </Grid>
      </Grid>
    </>
  );
};

function mapDispatchToProps(dispatch) {
  return {
    getProduct: (id) => getProduct(id, dispatch),
    getMonthStatistics: (id) => getMonthStatistics(id, dispatch),
    showInfoSnack: (text) => dispatch(showInfoSnack(text)),
  };
}

const mapStateToProps = (state) => {
  return { productsReducer: state.productsReducer };
};

export default connect(mapStateToProps, mapDispatchToProps)(SingleProduct);
