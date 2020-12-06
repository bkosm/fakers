import React, { useState } from 'react';

import GraphiQL from 'graphiql';
import 'graphiql/graphiql.min.css';
import QueryInputWindow from '../Components/QueryInputWindow';

function Home() {
  const [serverUrl, setServerUrl] = useState('');

  return (
    <>
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
          return data.json().catch(() => data.text());
        }}
      />
      <QueryInputWindow
        value={serverUrl}
        onSubmit={(value) => setServerUrl(value)}
      />
    </>
  );
}

export default Home;
