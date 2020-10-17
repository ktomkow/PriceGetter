import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import {
  CardHeader,
  CardMedia,
  CircularProgress,
  Container,
  IconButton,
} from "@material-ui/core";
import LinkIcon from "@material-ui/icons/Link";

import { formatRawDate } from "../../services/dateServices";
import { formatMoneyAndAddPLN } from "../../services/moneyServices";

import strings from "../../localization/strings";

const useStyles = makeStyles({
  root: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  title: {
    fontSize: 14,
  },
  mediaContainer: {
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
    width: "14em",
    height: "14em",
  },
  media: {
    padding: "0",
  },
});

const PreProductCard = (props) => {
  const { name, price, productPage, imageUrl } = props.preproduct;
  const { inProgress } = props;

  const classes = useStyles();

  const getPrice = () => {
    const formattedAmount = formatMoneyAndAddPLN(price);
    return formattedAmount;
  };

  const handlePageChange = () => {
    const url = productPage;
    window.open(url);
  };

  const getProductImage = () => {
    if(imageUrl && imageUrl.startsWith("http")) {
      return imageUrl;
    }

    return "https://cdn.pixabay.com/photo/2017/02/16/13/42/box-2071537_960_720.png";
  }

  return (
    <Card className={classes.root}>
      <CardHeader
        title={name}
        action={
          <IconButton aria-label="settings" onClick={handlePageChange}>
            <LinkIcon />
          </IconButton>
        }
      />

      <Container className={classes.mediaContainer}>
        {inProgress && <CircularProgress />}
        {!inProgress && (
          <CardMedia
            className={classes.media}
            image={getProductImage()}
            title="Product image"
            component="img"
          />
        )}
      </Container>
      <CardContent>
        <Typography variant="h5" component="h2">
          {getPrice()}
        </Typography>
      </CardContent>
    </Card>
  );
};

export default PreProductCard;
