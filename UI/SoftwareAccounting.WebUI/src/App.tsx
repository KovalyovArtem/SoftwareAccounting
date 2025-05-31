import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import DevicePage from './pages/DevicePage';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/device/:id" element={<DevicePage />} />
      </Routes>
    </Router>
  );
}

export default App;
