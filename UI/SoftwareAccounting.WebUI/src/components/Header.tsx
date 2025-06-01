import { Link } from 'react-router-dom';
import { AppBar, Toolbar, Typography, Button } from '@mui/material';
import { useAuth } from '../hooks/useAuth';

export const Header = () => {
  const { isAuthenticated, logout, user } = useAuth();

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          <Link to="/" style={{ color: 'inherit', textDecoration: 'none' }}>
            Данные устройства
          </Link>
        </Typography>
        {isAuthenticated ? (
          <>
            <Typography sx={{ mr: 2 }}>{user?.username}</Typography>
            <Button color="inherit" onClick={logout}>Выйти</Button>
          </>
        ) : (
          <Button color="inherit" component={Link} to="/login">Войти</Button>
        )}
      </Toolbar>
    </AppBar>
  );
};