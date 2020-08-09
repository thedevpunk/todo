import React from 'react';
import './App.scss';
import { Dashboard } from '../../features/items/Dashboard';

function App() {
  return (
    <div className="app">
      <header className="app-header">
        <h2>Todo</h2>
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
