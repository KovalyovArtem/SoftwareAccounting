import { useAuthStore } from '../stores/authStore';

export const useAuth = () => {
  const token = useAuthStore(state => state.token);
  const user = useAuthStore(state => state.user);
  const login = useAuthStore(state => state.login);
  const logout = useAuthStore(state => state.logout);
  const register = useAuthStore(state => state.register);

  return {
    token,
    user,
    isAuthenticated: !!token,
    login,
    logout,
    register
  };
};