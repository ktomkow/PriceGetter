import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import { CardHeader, CardMedia, IconButton } from "@material-ui/core";
import LinkIcon from "@material-ui/icons/Link";

import { formatRawDate } from "../../services/dateServices";
import { formatMoneyAndAddPLN } from "../../services/moneyServices";

import strings from "../../localization/strings";

const useStyles = makeStyles({
  title: {
    fontSize: 14,
  },
  media: {
    height: 0,
    paddingTop: "100%", // 56% would be 16:9
  },
});

const PreProductCard = ({ props }) => {
  const { name, price, productPage, imageUrl } = props;

  const classes = useStyles();

  const getPrice = () => {
    const formattedAmount = formatMoneyAndAddPLN(price);

    return formattedAmount;
  };

  const handlePageChange = () => {
    const url = productPage;
    window.open(url);
  };

  return (
    <Card>
      <CardHeader
        title={name}
        action={
          <IconButton aria-label="settings">
            <LinkIcon onClick={handlePageChange} />
          </IconButton>
        }
      ></CardHeader>
      <CardMedia
        className={classes.media}
        image={imageUrl}
        title="Product image"
      />
      <CardContent>
        <Typography variant="h5" component="h2">
          {getPrice()}
        </Typography>
      </CardContent>
    </Card>
  );
};

export default PreProductCard;
