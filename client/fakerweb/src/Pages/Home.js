import React, { useState } from "react";

import NavBar from "../Components/NavBar";
import NavItem from "../Components/NavItem";
import Logo from "../Assets/logo512frs.png";
import GitHub from "../Assets/github512.png";
import Sign from "../Assets/sign512.png";
import DataBase from "../Assets/data512.png";
//import Info from "../Assets/info512.png";
import GraphiQL from "graphiql";
import "graphiql/graphiql.min.css";

function Home() {
  const [isNavBarOpen, setIsNavBarOpen] = useState(false);
  const [isRotating, setIsRotating] = useState(false);
  return (
    <>
      <button
        className={`Logo${isRotating ? " rotate" : ""}`}
        onAnimationEnd={() => setIsRotating(false)}
        style={{ top: isNavBarOpen ? "85%" : 0, transition: "1s" }}
        onClick={() => {
          setIsNavBarOpen(!isNavBarOpen);
          setIsRotating(true);
        }}
      >
        <img className="LogoImage" src={Logo} alt="logo" />
      </button>
      <NavBar
        style={{
          height: isNavBarOpen ? 250 : 0,
        }}
      >
        <NavItem
          icon={<img className="navitemicon" src={GitHub} alt="logo" />}
          href="https://github.com/bart-kosmala/fakers"
        />
        <NavItem
          icon={<img className="navitemicon" src={DataBase} alt="logo" />}
        />
        <NavItem icon={<img className="navitemicon" src={Sign} alt="logo" />} />
      </NavBar>
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
    </>
  );
}

export default Home;
