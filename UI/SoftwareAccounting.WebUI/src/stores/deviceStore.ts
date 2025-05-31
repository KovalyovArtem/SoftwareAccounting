import { create } from 'zustand';
import { getDevice, getInstalledSoftware } from '../services/deviceService';
import type { Device, Software } from '../services/deviceService';

interface DeviceStore {
  device: Device | null;
  software: Software[] | null;
  isLoading: boolean;
  isSoftwareLoading: boolean;
  fetchDevice: (id: string) => Promise<void>;
  fetchSoftware: (id: string) => Promise<void>;
}

export const useDeviceStore = create<DeviceStore>((set) => ({
  device: null,
  software: null,
  isLoading: false,
  isSoftwareLoading: false,

  fetchDevice: async (id: string) => {
    set({ isLoading: true });
    try {
      const data = await getDevice(id);
      set({ device: data });
    } catch (error) {
      console.error('Ошибка загрузки устройства:', error);
    } finally {
      set({ isLoading: false });
    }
  },

  fetchSoftware: async (id: string) => {
    set({ isSoftwareLoading: true });
    try {
      const data = await getInstalledSoftware(id);
      set({ software: data });
    } catch (error) {
      console.error('Ошибка загрузки ПО:', error);
    } finally {
      set({ isSoftwareLoading: false });
    }
  },
}));
