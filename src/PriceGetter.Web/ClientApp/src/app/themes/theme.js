import { createMuiTheme } from "@material-ui/core/styles";
import indigo from "@material-ui/core/colors/indigo";
import orange from "@material-ui/core/colors/orange";

const theme = createMuiTheme({
  palette: {
    primary: indigo,
    secondary: orange
  },
  status: {
    danger: "orange",
  },
});

export default theme;