import React from "react";
import {
  AppBar,
  Toolbar,
  Typography,
  IconButton,
  Button,
  Tabs,
  Tab
} from "@material-ui/core";

import { makeStyles } from "@material-ui/styles";

import strings from "../../localization/strings";
import { Link } from "react-router-dom";

const useStyles = makeStyles(() => ({
  typographyStyles: {
    flex: 1,
  },
  topBarNavButton: {
    paddingRight: "2em",
    paddingLeft: "2em"
  }
}));

const TopBar = () => {
  const classes = useStyles();
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography className={classes.typographyStyles} variant="h4">
          {strings.LAYOUT.TOP_BAR.TITLE}
        </Typography>
        <Button component={Link} to="/createProduct" color="secondary" className={classes.topBarNavButton}>
          Create Product
        </Button>
        <Button component={Link} to="/products" color="secondary" className={classes.topBarNavButton}>
          products
        </Button>
      </Toolbar>
    </AppBar>
  );
};

export default TopBar;
