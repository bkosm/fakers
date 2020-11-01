import React, { useState } from "react";

import LinksButtons from "../Components/LinksButtons";
import QueryInputWindow from "../Components/QueryInputWindow";
import NavBar from "../Components/NavBar";
import NavItem from "../Components/NavItem";
import { ResultDisplayWindow } from "../Components/ResultDisplayWindow";
import Logo from "../Assets/logo512frs.png";

function Home(props) {
  const [text, setText] = useState("");
  const [isNavBarOpen, setIsNavBarOpen] = useState(false);
  const [isRequestInProgress, setIsRequestInProgress] = useState(false);
  return (
    <div className="row">
      <div className="inputColumn">
        <button
          className="Logo"
          style={{ top: isNavBarOpen ? "85%" : 0, transition: "1s" }}
          onClick={() => setIsNavBarOpen(!isNavBarOpen)}
        >
          <img className="LogoImage" src={Logo} alt="logo" />
        </button>
        <NavBar
          style={{
            opacity: isNavBarOpen ? 1 : 0,
            transition: isNavBarOpen ? 0 : "1s",
          }}
        >
          <li>
            <NavItem
              icon={<img className="navitemicon" src={Logo} alt="logo" />}
              href="https://github.com/bart-kosmala/fakers"
            />
          </li>
          <li>
            <NavItem
              icon={<img className="navitemicon" src={Logo} alt="logo" />}
            />
          </li>
          <li>
            <NavItem
              icon={<img className="navitemicon" src={Logo} alt="logo" />}
            />
          </li>
        </NavBar>
        <QueryInputWindow header={"jakis tytul"} onChange={setText} />
        <button
          className="inputButton"
          onClick={() => {
            setIsRequestInProgress(true);
            setTimeout(() => setIsRequestInProgress(false), 2000);
          }}
        >
          {isRequestInProgress ? "Loading..." : "Execute"}
        </button>
      </div>
      <ResultDisplayWindow result={text} />
    </div>
  );
}

export default Home;
