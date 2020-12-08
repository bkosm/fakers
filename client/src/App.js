import React from 'react';
import { Route, BrowserRouter as Router, Switch } from 'react-router-dom';
import './App.css';
import Home from './Pages/Home';
import Info from './Pages/Info';
import Graph from './Pages/Graph';
import NavBarContainer from './Components/NavBarContainer';

function App() {
  return (
    <div className='App'>
      <Router>
        <NavBarContainer />
        <Switch>
          <Route exact path='/Fakers' component={Home} />
          <Route path='/Info' component={Info} />
          <Route path='/Graph' component={Graph} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
