import React, { useState } from "react";

import LinksButtons from "../Components/LinksButtons";
import QueryInputWindow from "../Components/QueryInputWindow";
import { ResultDisplayWindow } from "../Components/ResultDisplayWindow";

function Home(props) {
  const [text, setText] = useState("");

  const [isRequestInProgress, setIsRequestInProgress] = useState(false);
  return (
    <div className="row">
      <div className="inputColumn">
        <QueryInputWindow header={"jakis tytul"} onChange={setText} />
        <button
          className="inputButton"
          onClick={() => {
            setIsRequestInProgress(true);
            setTimeout(() => setIsRequestInProgress(false), 2000);
          }}
        >
          {isRequestInProgress ? "Loading..." : "Start"}
        </button>
        <LinksButtons />
      </div>
      <ResultDisplayWindow result={text} />
    </div>
  );
}

export default Home;
