import React from "react";
import {
  CircularProgress,
  Grid,
  InputBase,
  Paper,
  IconButton,
  Typography,
} from "@material-ui/core";
import SearchIcon from "@material-ui/icons/Search";

import { makeStyles } from "@material-ui/core/styles";

import strings from "../../localization/strings";

import PreProductCard from './preProductCard';

const useStyles = makeStyles({
  root: {
    padding: "3em",
  },
  inputContainer: {
    padding: "2px 4px",
    minWidth: 400,
    display: "flex",
  },
  input: {
    flex: 1,
  },
  iconButton: {
    padding: 10,
  },
});

const ProductCreateForm = () => {
  const classes = useStyles();

  const emptyProduct = () => {
      return {
          name: "Name will be here",
          price: "0,0000",
          productPage: "https://google.com",
          imageUrl: "https://cdn.pixabay.com/photo/2017/02/16/13/42/box-2071537_960_720.png"
      }
  }

  return (
    <Paper className={classes.root} elevation={3}>
      <Typography variant="h6">{strings.CREATE_FORM.PRODUCT_CREATE.TITLE}</Typography>
      <PreProductCard props={emptyProduct()}/>
      <Paper className={classes.inputContainer} elevation={10}>
        <InputBase
          className={classes.input}
          placeholder={
            strings.CREATE_FORM.PRODUCT_CREATE.LINK_INPUT_PLACEHOLDER
          }
        />
        <IconButton className={classes.iconButton} aria-label="search">
          <SearchIcon />
        </IconButton>
      </Paper>
    </Paper>
  );
};

export default ProductCreateForm;
