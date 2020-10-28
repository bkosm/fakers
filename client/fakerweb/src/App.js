import { useState } from "react";
import "./App.css";
import QueryInputWindow from "./Components/QueryInputWindow";
import { ResultDisplayWindow } from "./Components/ResultDisplayWindow";

function App() {
  const [text, setText] = useState("");

  const [isRequestInProgress, setIsRequestInProgress] = useState(false);
  return (
    <div className="App">
      <div className="row">
        <QueryInputWindow header={"jakis tytul"} onChange={setText} />
        <ResultDisplayWindow result={text} />
      </div>

      <button
        style={{ width: 200, height: 75 }}
        onClick={() => {
          setIsRequestInProgress(true);
          setTimeout(() => setIsRequestInProgress(false), 2000);
        }}
      >
        {isRequestInProgress ? "Loading..." : "Start"}
      </button>
    </div>
  );
}

export default App;
