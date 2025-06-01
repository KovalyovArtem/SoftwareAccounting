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

  const [searchTerm, setSearchTerm] = useState('');

  // Загрузка данных устройства
  useEffect(() => {
    if (id) {
      fetchDevice(id);
    }
  }, [id, fetchDevice]);

  const handleSoftwareLoad = async () => {
    if (!software && id) {
      await fetchSoftware(id);
    }
  };

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

  if (!id) {
    return (
      <Container sx={{ mt: 4 }}>
        <Typography variant="h6">ID устройства не указан</Typography>
      </Container>
    );
  }

  if (isLoading) {
    return (
      <Container sx={{ display: 'flex', justifyContent: 'center', mt: 4 }}>
        <CircularProgress />
      </Container>
    );
  }

  if (!device) {
    return (
      <Container sx={{ mt: 4 }}>
        <Typography variant="h6">Устройство не найдено</Typography>
      </Container>
    );
  }

  return (
    <Container
      maxWidth="lg"
      sx={{
        mt: 4,
        color: (theme) =>
          theme.palette.mode === 'dark' ? theme.palette.text.primary : 'black',
      }}
    >      
      <Box component="section"sx={{
          mb: 2,
          p: 2,
          borderRadius: 2,
          backgroundColor: 'background.paper',
          boxShadow: 1,
          display: 'flex',
          flexDirection: 'column',
          gap: 1,
          wordBreak: 'break-word',
        }}>
        <Typography variant="h4" gutterBottom>
          Устройство на: {device.osName}
        </Typography>
        <Typography>IP-адрес: {device.ipAddress}</Typography>
        <Typography>Статус: {device.isActive ? 'Активно' : 'Не активно'}</Typography>
        <Typography>MAC-адрес: {device.macAddress}</Typography>
        <Typography>Архитектура системы: {device.osArchitecture}</Typography>
        <Typography>Ответственный: {device.sotrFullName}</Typography>
        <Typography>Синоним: {device.synonym}</Typography>
      </Box>

      <Accordion sx={{ mt: 4, bgcolor: 'background.paper' }} onChange={handleSoftwareLoad}>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography fontWeight={600}>Установленное ПО</Typography>
        </AccordionSummary>
        <AccordionDetails>
          {isSoftwareLoading ? (
            <Box sx={{ py: 3, display: 'flex', justifyContent: 'center' }}>
              <CircularProgress />
            </Box>
          ) : software && software.length > 0 ? (
            <>
              <Box sx={{ display: 'flex', alignItems: 'center', mb: 2, p: 2 }}>
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
              </Box>

              <TableContainer component={Paper} sx={{ maxHeight: 500, overflowX: 'auto' }}>
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
                    {filteredSoftware?.map((s, index) => (
                      <TableRow key={index}>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmName}</TableCell>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmVersion}</TableCell>
                        <TableCell>{s.programmDeveloper}</TableCell>
                        <TableCell sx={{ whiteSpace: 'normal', wordBreak: 'break-word' }}>
                          {s.programmLicense}
                        </TableCell>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmInstalledDate}</TableCell>
                        <TableCell sx={{ whiteSpace: 'nowrap' }}>{s.programmSize}</TableCell>
                        <TableCell sx={{ whiteSpace: 'normal', wordBreak: 'break-word', maxWidth: 250 }}>
                          {s.programmInstallLocation}
                        </TableCell>
                        <TableCell>{s.programmPublisher}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </>
          ) : (
            <Box sx={{ py: 2, textAlign: 'center' }}>
              <Typography>ПО не найдено</Typography>
            </Box>
          )}
        </AccordionDetails>
      </Accordion>
    </Container>
  );
};

export default DevicePage;