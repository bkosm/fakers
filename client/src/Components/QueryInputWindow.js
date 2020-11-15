import React, { useState } from 'react';

function QueryInputWindow(props) {
  const [input, setInput] = useState('');
  const onSubmit = () => props.onSubmit(input);

  return (
    <div className='windowInput'>
      <input
        className='connectButton'
        type='submit'
        value='Connect'
        onClick={onSubmit}
      />
      <textarea
        placeholder='GraphQL API server address'
        value={input}
        onChange={(e) => setInput(e.target.value)}
      />
    </div>
  );
}

export default QueryInputWindow;
