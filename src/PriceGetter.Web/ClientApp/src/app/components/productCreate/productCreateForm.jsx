import React, { useState } from "react";
import { connect } from "react-redux";

import {
  CircularProgress,
  Grid,
  InputBase,
  Paper,
  IconButton,
  Typography,
  Container,
} from "@material-ui/core";
import SearchIcon from "@material-ui/icons/Search";

import { makeStyles } from "@material-ui/core/styles";

import strings from "../../localization/strings";

import { getPreproduct } from "../../redux/actions/preProductActionCreator";

import PreProductCard from "./preProductCard";

const useStyles = makeStyles({
  root: {
    padding: "3em",
    marginTop: "2em",
  },
  container: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  containerItem: {
    margin: "1em",
    width: "100%",
  },
  inputContainer: {
    padding: "2px 4px",
    display: "flex",
    alignItems: "center",
  },
  input: {
    flex: 1,
    padding: "5px",
    minWidth: 400,
  },
  iconButton: {
    padding: 10,
    float: "right",
  },
});

const ProductCreateForm = (props) => {
  const classes = useStyles();

  const [link, setLink] = useState("");

  const emptyPreProduct = () => {
    return {
      name: "Name will be here",
      price: "0,0000",
      productPage: "https://google.com",
      imageUrl:
        "https://cdn.pixabay.com/photo/2017/02/16/13/42/box-2071537_960_720.png",
    };
  };

  const getPreProduct = () => {
    let preProduct = props.preProductReducer.preProduct;
    if (preProduct) {
      return preProduct;
    }

    return emptyPreProduct();
  };

  const handleClick = () => {
    props.getPreproduct(link);
  };

  return (
    <Grid container justify="center">
      <Grid item>
        <Paper className={classes.root} elevation={10}>
          <Container className={classes.container}>
            <Typography variant="h6" className={classes.containerItem}>
              {strings.CREATE_FORM.PRODUCT_CREATE.TITLE}
            </Typography>
            <PreProductCard
              className={classes.containerItem}
              inProgress={props.preProductReducer.gettingDataInProgress}
              preproduct={getPreProduct()}
            />
            <Paper
              className={(classes.inputContainer, classes.containerItem)}
              variant="outlined"
            >
              <InputBase
                className={classes.input}
                placeholder={
                  strings.CREATE_FORM.PRODUCT_CREATE.LINK_INPUT_PLACEHOLDER
                }
                value={link}
                onChange={(e) => setLink(e.target.value)}
              />
              <IconButton
                className={classes.iconButton}
                aria-label="search"
                onClick={handleClick}
                disabled={props.preProductReducer.gettingDataInProgress}
              >
                <SearchIcon />
              </IconButton>
            </Paper>
          </Container>
        </Paper>
      </Grid>
    </Grid>
  );
};

function mapDispatchToProps(dispatch) {
  return {
    getPreproduct: (link) => getPreproduct(link, dispatch),
  };
}

const mapStateToProps = (state) => {
  return { preProductReducer: state.preProductReducer };
};

export default connect(mapStateToProps, mapDispatchToProps)(ProductCreateForm);
