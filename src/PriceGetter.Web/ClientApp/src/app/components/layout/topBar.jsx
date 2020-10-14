import React from "react";
import {
  AppBar,
  Toolbar,
  Typography,
  IconButton,
  Button,
} from "@material-ui/core";

import { makeStyles } from "@material-ui/styles";

import FavoriteRoundedIcon from "@material-ui/icons/FavoriteRounded";
import MenuBookIcon from "@material-ui/icons/MenuBook";
import strings from "../../localization/strings";
import { Link } from "react-router-dom";

const useStyles = makeStyles(() => ({
  typographyStyles: {
    flex: 1,
  },
}));

const TopBar = () => {
  const classes = useStyles();
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography className={classes.typographyStyles} variant="h6">
          {strings.LAYOUT.TOP_BAR.TITLE}
        </Typography>
        <Button component={Link} to="/list">
          list
        </Button>{" "}
        <Button component={Link} to="/tmp">
          tmp
        </Button>
        <Button component={Link} to="/products">
          products
        </Button>
        <IconButton>
          <FavoriteRoundedIcon />
        </IconButton>
      </Toolbar>
    </AppBar>
  );
};

export default TopBar;
