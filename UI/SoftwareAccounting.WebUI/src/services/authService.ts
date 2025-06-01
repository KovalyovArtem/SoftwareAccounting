const API_BASE_URL = 'http://192.168.31.109:5080';

export const authService = {
  async register(username: string, password: string): Promise<void> {
    const response = await fetch(`${API_BASE_URL}/Auth/Register`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        UserName: username,
        Password: password
      })
    });

    if (!response.ok) {
      throw new Error(await response.text());
    }
  },

  async login(username: string, password: string): Promise<string> {
    const response = await fetch(`${API_BASE_URL}/Auth/Login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        UserName: username,
        Password: password
      }),
      credentials: 'include'
    });

    if (!response.ok) {
      throw new Error(await response.text());
    }

    return response.text();
  }
};