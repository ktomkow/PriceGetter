import React from "react";
import PageNotFound from "./app/components/pageNotFound/pageNotFound";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  NavLink,
} from "react-router-dom";
import { Button, Grid } from "@material-ui/core";

import TopBar from "./app/components/layout/topBar";

import Home from "./app/components/home/home";
import List from "./app/components/list/list";
import Form from "./app/components/form/form";
import Tmp from "./app/components/tmp/tmp";
import Products from "./app/components/products/products";

import PageContent from "./app/components/layout/pageContent";

function App() {
  return (
    <Router>
      <TopBar />
      <PageContent>
        <Switch>
          <Route exact path={["/clientapp", "/home"]} component={Home} />
          <Route exact path="/products" component={Products} />
          <Route exact path={["/list"]} component={List} />
          <Route exact path="/form" component={Form} />
          <Route exact path={["/", "/tmp"]} component={Tmp} />
          <Route component={PageNotFound} />
        </Switch>
      </PageContent>
    </Router>
  );
}

export default App;
