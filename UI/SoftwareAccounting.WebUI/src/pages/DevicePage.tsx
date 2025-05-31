import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Box,
  CircularProgress,
  Container,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
  IconButton,
  InputAdornment,
  Divider
} from '@mui/material';

import { TextField } from '@mui/material';
import ClearIcon from '@mui/icons-material/Clear';
import SearchIcon from '@mui/icons-material/Search';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useDeviceStore } from '../stores/deviceStore';

const DevicePage = () => {
  const { id } = useParams<{ id: string }>();
  const {
    device,
    software,
    fetchDevice,
    fetchSoftware,
    isLoading,
    isSoftwareLoading
  } = useDeviceStore();

  useEffect(() => {
    if (id) {
      fetchDevice(id);
    }
  }, [id]);

  const handleSoftwareLoad = async () => {
    if (!software && id) {
      await fetchSoftware(id);
    }
  };

  const [searchTerm, setSearchTerm] = useState('');

  const filteredSoftware = software?.filter((s) => {
    if (!searchTerm) return true;
    
    const searchLower = searchTerm.toLowerCase();
    return (
      (s.programmName?.toLowerCase().includes(searchLower)) ||
      (s.programmVersion?.toLowerCase().includes(searchLower)) ||
      (s.programmDeveloper?.toLowerCase().includes(searchLower)) ||
      (s.programmLicense?.toLowerCase().includes(searchLower)) ||
      (s.programmPublisher?.toLowerCase().includes(searchLower)) ||
      (s.programmInstallLocation?.toLowerCase().includes(searchLower))
    );
  });

  const handleClearSearch = () => {
    setSearchTerm('');
  };

  if (isLoading) return <CircularProgress />;
  if (!device) return <Typography>Устройство не найдено</Typography>;

  return (
    <Container maxWidth="lg" sx={{ mt: 4, color: 'white' }}>
      <Typography variant="h4" gutterBottom>
        Устройство на: {device.osName}
      </Typography>
      <Typography>IP-адрес: {device.ipAddress}</Typography>
      <Typography>Статус: {device.isActive ? 'Активно' : 'Не активно'}</Typography>
      <Typography>MAC-адрес: {device.macAddress}</Typography>
      <Typography>Архитектура системы: {device.osArchitecture}</Typography>
      <Typography>Ответственный: {device.sotrFullName}</Typography>
      <Typography>Синоним: {device.synonym}</Typography>

      <Accordion sx={{ mt: 4, bgcolor: 'background.paper' }} onChange={handleSoftwareLoad}>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography fontWeight={600}>Установленное ПО</Typography>
        </AccordionSummary>
        <AccordionDetails>
          {isSoftwareLoading ? (
            <Box sx={{ py: 3 }}> {}
              <CircularProgress />
            </Box>
          ) : software && software.length > 0 ? (
            <TableContainer
              component={Paper}
              sx={{
                maxHeight: 500,
                overflowX: 'auto',
              }}
            >
              <Box sx={{ display: 'flex', alignItems: 'center', mb: 2, p: 2, pb: 1 }}>
                <TextField
                  label="Поиск ПО"
                  variant="outlined"
                  size="small"
                  fullWidth
                  value={searchTerm}
                  onChange={(e) => setSearchTerm(e.target.value)}
                  InputProps={{
                    startAdornment: (
                      <InputAdornment position="start">
                        <SearchIcon />
                      </InputAdornment>
                    ),
                    endAdornment: searchTerm && (
                      <IconButton onClick={handleClearSearch} size="small">
                        <ClearIcon fontSize="small" />
                      </IconButton>
                    ),
                  }}
                />
                {searchTerm && (
                  <Typography variant="body2" sx={{ ml: 2, whiteSpace: 'nowrap' }}>
                    Найдено: {filteredSoftware?.length || 0}/{software.length}
                  </Typography>
                )}

                <Divider sx={{ my: 3 }} />
              </Box>

              <Table stickyHeader size="small">
                <TableHead>
                  <TableRow>
                    <TableCell>Название</TableCell>
                    <TableCell>Версия</TableCell>
                    <TableCell>Разработчик</TableCell>
                    <TableCell>Лицензия</TableCell>
                    <TableCell>Дата установки</TableCell>
                    <TableCell>Размер</TableCell>
                    <TableCell>Расположение</TableCell>
                    <TableCell>Издатель</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {filteredSoftware && filteredSoftware.length > 0 ? (
                    filteredSoftware.map((s, index) => (
                      <TableRow key={index}>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmName}</TableCell>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmVersion}</TableCell>
                        <TableCell>{s.programmDeveloper}</TableCell>
                        <TableCell
                          sx={{
                            whiteSpace: 'normal',
                            wordBreak: 'break-word'
                          }}
                        >
                          {s.programmLicense}
                        </TableCell>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmInstalledDate}</TableCell>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmSize}</TableCell>
                        <TableCell
                          sx={{
                            whiteSpace: 'normal',
                            wordBreak: 'break-word',
                            maxWidth: 250,
                          }}
                        >
                          {s.programmInstallLocation}
                        </TableCell>
                        <TableCell>{s.programmPublisher}</TableCell>
                      </TableRow>
                    ))
                  ) : (
                    <TableRow>
                      <TableCell colSpan={8} align="center">
                        {searchTerm ? 'Ничего не найдено' : 'Нет данных'}
                      </TableCell>
                    </TableRow>
                  )}
                </TableBody>
              </Table>
            </TableContainer>
          ) : (
            <Box sx={{ py: 2 }}> {}
              <Typography>ПО не найдено</Typography>
            </Box>
          )}
        </AccordionDetails>
      </Accordion>
    </Container>
  );
};

export default DevicePage;