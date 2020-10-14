import React from "react";
import {
  AppBar,
  Toolbar,
  IconButton,
  Typography,
  Button,
} from "@material-ui/core";

import strings from "../../localization/strings";

const TopBar = () => {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6">{strings.TOP_BAR.TITLE}</Typography>
      </Toolbar>
    </AppBar>
  );
};

export default TopBar;
