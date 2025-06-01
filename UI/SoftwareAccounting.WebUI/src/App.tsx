import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { useAuth } from './hooks/useAuth';
import DevicePage from './pages/DevicePage';
import { LoginPage } from './auth/LoginPage';
import { RegisterPage } from './auth/RegisterPage';
import { Header } from './components/Header';

function App() {
  const { isAuthenticated } = useAuth();

  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route path="/login" element={!isAuthenticated ? <LoginPage /> : <Navigate to="/" replace />} />
        <Route path="/register" element={!isAuthenticated ? <RegisterPage /> : <Navigate to="/login" replace />} />
        <Route 
          path="/device/:id" 
          element={
            isAuthenticated ? (
              <DevicePage />
            ) : (
              <Navigate 
                to="/login" 
                replace 
                state={{ 
                  from: window.location.pathname, // Сохраняем текущий путь
                  deviceId: window.location.pathname.split('/')[2] // Сохраняем ID устройства
                }} 
              />
            )
          } 
        />
        <Route path="/" element={<Navigate to={isAuthenticated ? "/device" : "/login"} replace />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;