import React from "react";
import { Grid } from "@material-ui/core";
const PageContent = (props) => {
  return (
    <Grid container direction="column">
      <Grid item container xs={12}>
        <Grid item xs={0} sm={1} />
        <Grid item container xs={12} sm={10}>
          {props.children}
        </Grid>
        <Grid item xs={0} sm={1} />
      </Grid>
    </Grid>
  );
};

export default PageContent;
