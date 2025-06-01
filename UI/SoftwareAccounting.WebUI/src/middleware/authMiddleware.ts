import { useAuthStore } from '../stores/authStore';

export const authMiddleware = async () => {
  const { token, refreshToken, logout } = useAuthStore.getState();
  
  if (!token) {
    return { shouldProceed: false, redirect: '/login' };
  }
  
  try {
    const response = await fetch('/api/auth/validate', {
      headers: { Authorization: `Bearer ${token}` }
    });
    
    if (!response.ok) throw new Error('Invalid token');
    
    return { shouldProceed: true };
  } catch (error) {
    try {
      await refreshToken();
      return { shouldProceed: true };
    } catch (refreshError) {
      logout();
      return { shouldProceed: false, redirect: '/login' };
    }
  }
};