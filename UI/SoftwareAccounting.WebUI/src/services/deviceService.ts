export interface Device {
  id: string;
  sotr: string;
  sotrFullName: string;
  synonym: string;
  macAddress: string;
  ipAddress: string;
  isActive: boolean;
  osName: string;
  osArchitecture: string;
}

export interface Software {
  id: string;
  programmName: string;
  programmVersion: string;
  programmDeveloper: string;
  programmLicense: string;
  programmInstalledDate: string;
  programmSize: string;
  programmInstallLocation: string;
  programmPublisher: string;
}

export const getDevice = async (deviceId: string): Promise<Device> => {
  const response = await fetch(`http://192.168.31.109:5080/Device/GetDevice?deviceId=${deviceId}`);

  if (!response.ok) {
    throw new Error('Ошибка при загрузке устройства');
  }

  return response.json();
};

export const getInstalledSoftware = async (deviceId: string): Promise<Software[]> => {
  const response = await fetch(`http://192.168.31.109:5080/Device/GetSoftwareInfo?deviceId=${deviceId}`);
  if (!response.ok) {
    throw new Error('Ошибка при получении установленного ПО');
  }
  return response.json();
};
