import React from "react";

import { IconButton } from "@material-ui/core";
import LinkIcon from "@material-ui/icons/Link";

import { isUrlValid } from "../../services/urlService";

const IconLink = ({ link, disabled = false }) => {
  const handleOnClick = () => {
    const url = link;
    window.open(url);
  };

  return (
    <IconButton
      aria-label="settings"
      onClick={handleOnClick}
      disabled={!isUrlValid(link) || disabled}
    >
      <LinkIcon />
    </IconButton>
  );
};

export default IconLink;
