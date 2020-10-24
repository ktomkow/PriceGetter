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

import { formatMoneyAndAddPLN } from "../../services/moneyServices";

import { mockImage } from "../../mocks/product/image";

const useStyles = makeStyles({
  root: {
    width: "100%",
    display: "flex",
    flexDirection: "column",
    alignItems: "center"
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

    return mockImage;
  }

  return (
    <Card className={classes.root} variant="outlined" >
      <CardHeader
        title={name}
        action={
          <IconButton aria-label="settings" onClick={handlePageChange}>
            <LinkIcon />
          </IconButton>
        }
      />

      <Container className={classes.mediaContainer}>
        {inProgress && <CircularProgress size="6rem" thickness={2.0}/>}
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
