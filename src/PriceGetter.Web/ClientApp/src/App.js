import React from "react";
import PageNotFound from "./app/components/pageNotFound/pageNotFound";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  NavLink,
} from "react-router-dom";

import Home from "./app/components/home/home";

function App() {
  return (
    <Router>
      <Route exact path={["/clientapp", "/"]}>
        <Home />
      </Route>
      <Route component={PageNotFound} />
    </Router>
  );
}

export default App;
