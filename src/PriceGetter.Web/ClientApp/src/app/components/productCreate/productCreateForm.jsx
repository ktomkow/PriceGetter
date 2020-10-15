import React, { useState } from "react";
import { connect } from "react-redux";

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

import { getPreproduct } from "../../redux/actions/preProductActionCreator";

import PreProductCard from "./preProductCard";

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

const ProductCreateForm = (props) => {
  const classes = useStyles();

  const [link, setLink] = useState("");

  const emptyProduct = () => {
    return {
      name: "Name will be here",
      price: "0,0000",
      productPage: "https://google.com",
      imageUrl:
        "https://cdn.pixabay.com/photo/2017/02/16/13/42/box-2071537_960_720.png",
    };
  };

  const handleClick = () => {
    props.getPreproduct(link);
  };

  return (
    <Paper className={classes.root} elevation={3}>
      <Typography variant="h6">
        {strings.CREATE_FORM.PRODUCT_CREATE.TITLE}
      </Typography>
      <PreProductCard props={emptyProduct()} />
      <Paper className={classes.inputContainer} elevation={10}>
        <InputBase
          className={classes.input}
          placeholder={
            strings.CREATE_FORM.PRODUCT_CREATE.LINK_INPUT_PLACEHOLDER
          }
          value={link}
          onChange={(e) => setLink(e.target.value)}
        />
        <IconButton className={classes.iconButton} aria-label="search">
          <SearchIcon onClick={handleClick} />
        </IconButton>
      </Paper>
    </Paper>
  );
};

function mapDispatchToProps(dispatch) {
    return {
        getPreproduct: (link) => getPreproduct(link, dispatch),
    };
  }
  
export default connect(null, mapDispatchToProps)(ProductCreateForm);
