import React from "react";
import { Route, BrowserRouter as Router, Switch } from "react-router-dom";
import "./App.css";
import Home from "./Pages/Home";
import Info from "./Pages/Info";
import Graph from "./Pages/Graph";
import NavBarContainer from "./Components/NavBarContainer";

function App() {
  return (
    <div className="App">
      <Router>
        <NavBarContainer />
        <Switch>
          <Route exact path="/fakers" component={Home} />
          <Route path="/info" component={Info} />
          <Route path="/graph" component={Graph} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
