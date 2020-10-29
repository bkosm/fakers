import React from "react";
import { Route, BrowserRouter as Router, Switch } from "react-router-dom";
import "./App.css";
import Home from "./Pages/Home";
import Info from "./Pages/Info";
import Graph from "./Pages/Graph";

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route exact path="/">
            <Home></Home>
          </Route>
          <Route path="/Info">
            <Info></Info>
          </Route>
          <Route path="/Graph">
            <Graph></Graph>
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
