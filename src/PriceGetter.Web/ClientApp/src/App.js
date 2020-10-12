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
import List from "./app/components/list/list";
import Form from "./app/components/form/form";
import Tmp from "./app/components/tmp/tmp";

function App() {
  return (
    <Router>
      <div>
        <div>
          <Link to="/tmp">tmp</Link>
        </div>
        <div>
          <Link to="/list">list</Link>
        </div>
      </div>
      <Switch>
        <Route exact path={["/clientapp", "/home"]} component={Home} />
        <Route exact path={["/list"]} component={List} />
        <Route exact path="/form" component={Form} />
        <Route exact path={["/", "/tmp"]} component={Tmp} />
        <Route component={PageNotFound} />
      </Switch>
    </Router>
  );
}

export default App;
