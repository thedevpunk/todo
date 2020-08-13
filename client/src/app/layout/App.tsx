import React, { useState, useEffect } from 'react';
import './App.scss';
import { Dashboard } from '../../features/items/Dashboard';

function App() {
  const getInitialMode = () => {
    const mode = localStorage.getItem('darkMode');

    return (mode && JSON.parse(mode)) || false;
  }

  const [darkMode, setDarkMode] = useState(getInitialMode);

  useEffect(() => {
    localStorage.setItem('darkMode', JSON.stringify(darkMode));
  }, [darkMode])

  const handleSwitchMode = () => {
    setDarkMode(!darkMode);
  }

  return (
    <div className={`app${darkMode ? ' dark-mode' : ' light-mode'}`}>
      <header className="app-header">
        <div className="container">
          <div className="app-title">
            <h2>Todo</h2>
          </div>
          <div className="app-switch">
            <label className="switch">
              <input type="checkbox" onChange={handleSwitchMode} defaultChecked={darkMode} />
              <span className="slider round"></span>
            </label>
          </div>
        </div>
      </header>
      <main className="app-content">
        <div className="container">
          <Dashboard />
        </div>
      </main>
    </div>
  );
}

export default App;
