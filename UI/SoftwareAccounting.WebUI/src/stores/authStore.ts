import { create } from 'zustand';
import { persist } from 'zustand/middleware';
import { authService } from '../services/authService';

interface AuthState {
  token: string | null;
  user: { username: string } | null;
  login: (username: string, password: string) => Promise<void>;
  logout: () => void;
  register: (username: string, password: string) => Promise<void>;
}

export const useAuthStore = create<AuthState>()(
  persist(
    (set) => ({
      token: null,
      user: null,
      
      login: async (username, password) => {
        const token = await authService.login(username, password);
        set({ token, user: { username } });
      },
      
      logout: () => {
        set({ token: null, user: null });
      },
      
      register: async (username, password) => {
        await authService.register(username, password);
        const token = await authService.login(username, password);
        set({ token, user: { username } });
      }
    }),
    {
      name: 'auth-storage',
      partialize: (state) => ({ token: state.token, user: state.user })
    }
  )
);