import React, { useState } from "react";
import { connect } from "react-redux";

import {
  Divider,
  Grid,
  InputBase,
  Paper,
  IconButton,
  Typography,
  Container,
} from "@material-ui/core";
import SearchIcon from "@material-ui/icons/Search";
import AddIcon from "@material-ui/icons/Add";

import { makeStyles } from "@material-ui/core/styles";

import strings from "../../localization/strings";

import {
  getPreproduct,
  createProduct,
} from "../../redux/actions/preProductActionCreator";

import { isUrlValid } from "../../services/urlService";

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

  const loadingInProgress = props.preProductReducer.apiCommunicationInProgress;

  const handleSearch = () => {
    props.getPreproduct(link);
  };

  const handleAdd = () => {
    props.createProduct(props.preProductReducer.preProduct);
  };

  const isInputValid = () => {
    return isUrlValid(link);
  };

  const preProductLoaded = () => {
    // TODO
    return isUrlValid(link); // just for a while
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
              inProgress={loadingInProgress}
              preproduct={props.preProductReducer.preProduct}
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
                disabled={loadingInProgress}
              />
              <IconButton
                className={classes.iconButton}
                aria-label="add"
                onClick={handleAdd}
                disabled={loadingInProgress || !preProductLoaded()}
              >
                <AddIcon />
              </IconButton>
              <IconButton
                className={classes.iconButton}
                aria-label="search"
                onClick={handleSearch}
                disabled={loadingInProgress || !isInputValid()}
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
    createProduct: (preProduct) => createProduct(preProduct, dispatch),
  };
}

const mapStateToProps = (state) => {
  return { preProductReducer: state.preProductReducer };
};

export default connect(mapStateToProps, mapDispatchToProps)(ProductCreateForm);
