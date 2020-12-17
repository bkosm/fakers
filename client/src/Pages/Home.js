import React, { useState } from 'react';

import GraphiQL from 'graphiql';
import 'graphiql/graphiql.min.css';
import QueryInputWindow from '../Components/QueryInputWindow';
import Alert from '../Components/Alert';
import useQuery from '../Hooks/useQuery';

const urlRegex = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_+.~#?&//=]*)/;

function Home() {
  const initServerUrl = useQuery('api') ?? '';
  const [serverUrl, setServerUrl] = useState(initServerUrl);

  const [alertVisible, setAlertVisible] = useState(false);
  const [connectionResponse, setConnectionResponse] = useState({
    title: '',
    message: '',
  });

  const onServerSubmit = (value) => {
    let responseMessage = {
      title: '',
      message: '',
    };
    if (value === serverUrl) {
      responseMessage = {
        title: 'Same address',
        message: `Server address is already set to '${value}'`,
      };
    } else if (value && value.length) {
      setServerUrl(value);
      if (!value.match(urlRegex)) {
        responseMessage = {
          title: 'Wrong server url',
          message:
            "Provided server probably isn't valid, queries may not succeed!",
        };
      } else {
        responseMessage = {
          title: 'Changed server address!',
          message: `Changed server address to '${value}'! Execute query to see the results`,
        };
      }
    } else {
      responseMessage = {
        title: 'No address provided',
        message: 'Please provide server address',
      };
    }
    setConnectionResponse(responseMessage);
    setAlertVisible(true);
  };

  const errorMessage = `
    Please provide valid server address!
    If you are sure that provided address is correct please check your query syntax
  `;

  return (
    <>
      <Alert
        isVisible={alertVisible}
        {...connectionResponse}
        onClose={() => setAlertVisible(false)}
      />
      <GraphiQL
        fetcher={async (graphQLParams) => {
          const data = await fetch(serverUrl, {
            method: 'POST',
            headers: {
              Accept: 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(graphQLParams),
            credentials: 'same-origin',
          });
          return data.json().catch(() => errorMessage);
        }}
      />
      <QueryInputWindow value={serverUrl} onSubmit={onServerSubmit} />
    </>
  );
}

export default Home;
