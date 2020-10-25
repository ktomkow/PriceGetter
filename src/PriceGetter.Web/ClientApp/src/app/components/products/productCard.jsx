import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";
import { CardHeader, CardMedia, IconButton } from "@material-ui/core";
import LinkIcon from "@material-ui/icons/Link";
import { Link } from "react-router-dom";


import { formatRawDate } from "../../services/dateServices";
import { formatMoneyAndAddPLN } from "../../services/moneyServices";

import strings from "../../localization/strings";
import { mockImage } from "../../mocks/product/image";

const useStyles = makeStyles(theme => ({
  root: {
    transition: ['background', 'color'],
    transitionDuration: 500,
    '&:hover':{
      backgroundColor: theme.palette.primary.light,
      color: theme.palette.secondary.main
    }
  },
  bullet: {
    display: "inline-block",
    margin: "0 2px",
    transform: "scale(0.8)",
  },
  title: {
    fontSize: 14,
  },
  pos: {
    marginBottom: 12,
  },
  media: {
    height: 0,
    paddingTop: "100%", // 56% would be 16:9
  },
}));

const ProductCard = ({ product }) => {
  const classes = useStyles();

  const getLastPrice = () => {
    const price = product.prices.sort((a, b) => {
      return a.at - b.at;
    })[0];

    if (price) {
      return price;
    }

    return { at: "", amount: "" };
  };

  const getLastPriceDate = () => {
    const lastPrice = getLastPrice();

    return formatRawDate(lastPrice.at);
  };

  const getLastPriceAmount = () => {
    const lastPrice = getLastPrice();

    const formattedAmount = formatMoneyAndAddPLN(lastPrice.amount);

    return formattedAmount;
  };

  const getProductImage = () => {
    const imageUrl = product.imageUrl;
    if(imageUrl && imageUrl.startsWith("http")) {
      return imageUrl;
    }

    return mockImage;
  }

  const handlePageChange = () => {
    const url = product.productPage;
    window.open(url);
  };

  return (
    <Card className={classes.root}>
      <CardHeader
        title={product.name}
        subheader={getLastPriceDate()}
        action={
          <IconButton aria-label="settings" onClick={handlePageChange}>
            <LinkIcon  />
          </IconButton>
        }
      ></CardHeader>
      <CardMedia
        className={classes.media}
        image={getProductImage()}
        title="Product image"
        component={Link} to={`/product/${product.id}`}
      />
      <CardContent>
        <Typography
          className={classes.title}
          color="textSecondary"
          gutterBottom
        >
          {strings.CARDS.PRODUCT_CARD.LAST_PRICE}
        </Typography>
        <Typography variant="h5" component="h2">
          {getLastPriceAmount()}
        </Typography>
      </CardContent>
    </Card>
  );
};

export default ProductCard;
