import React from "react";
import { Route, BrowserRouter as Router, Switch } from "react-router-dom";
import "./App.css";
import Home from "./Pages/Home";
import Info from "./Pages/Info";
import Graph from "./Pages/Graph";
import GraphiQL from "graphiql";
import "graphiql/graphiql.min.css";

function App() {
  return (
    <GraphiQL
      fetcher={async (graphQLParams) => {
        const data = await fetch(
          "https://swapi-graphql.netlify.app/.netlify/functions/index",
          {
            method: "POST",
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(graphQLParams),
            credentials: "same-origin",
          }
        );
        return data.json().catch(() => data.text());
      }}
    />
  );
}

export default App;
