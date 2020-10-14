import React from "react";
import { AppBar, Toolbar, Typography } from "@material-ui/core";

import { makeStyles } from "@material-ui/styles";

import FavoriteRoundedIcon from "@material-ui/icons/FavoriteRounded";
import strings from "../../localization/strings";
import { Link } from "react-router-dom";

const useStyles = makeStyles(() => ({
  typographyStyles: {
    flex: 1,
  }
}));

const TopBar = () => {
  const classes = useStyles();
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography className={classes.typographyStyles} variant="h6">
          {strings.LAYOUT.TOP_BAR.TITLE}
        </Typography>
        <Link to="/tmp">tmp</Link>
        <Link to="/list">list</Link>
        <Link to="/products">products</Link>
        <FavoriteRoundedIcon />
      </Toolbar>
    </AppBar>
  );
};

export default TopBar;
