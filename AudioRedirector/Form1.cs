using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AudioRedirector
{
    public partial class Form1 : Form
    {
        private List<MMDevice> audioDevices;
        private WasapiLoopbackCapture capture;
        private List<WasapiOut> outputs;
        private List<BufferedWaveProvider> providers;
        private bool isRedirecting;

        public Form1()
        {
            InitializeComponent();
            audioDevices = new List<MMDevice>();
            outputs = new List<WasapiOut>();
            providers = new List<BufferedWaveProvider>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void RefreshDeviceList()
        {
            try
            {
                listBoxDevices.Items.Clear();
                audioDevices.Clear();

                var enumerator = new MMDeviceEnumerator();
                var defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

                foreach (var device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                {
                    if (device.ID != defaultDevice.ID)
                    {
                        audioDevices.Add(device);
                        listBoxDevices.Items.Add(device.FriendlyName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении списка устройств: {ex.Message}");
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (listBoxDevices.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одно устройство");
                return;
            }

            try
            {
                // Получаем устройство по умолчанию для захвата звука
                var defaultDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

                // Инициализация захвата звука с конкретного устройства
                capture = new WasapiLoopbackCapture(defaultDevice);

                // Подготовка выходных устройств
                foreach (int index in listBoxDevices.SelectedIndices)
                {
                    var device = audioDevices[index];
                    // Проверяем, что выбранное устройство не является устройством по умолчанию
                    if (device.ID != defaultDevice.ID)
                    {
                        var output = new WasapiOut(device, AudioClientShareMode.Shared, true, 100);
                        outputs.Add(output);
                    }
                }

                if (outputs.Count == 0)
                {
                    MessageBox.Show("Нельзя выбрать только устройство по умолчанию");
                    return;
                }

                capture.DataAvailable += (s, a) =>
                {
                    // При первом получении данных инициализируем провайдеры
                    if (providers.Count == 0)
                    {
                        foreach (var output in outputs)
                        {
                            var provider = new BufferedWaveProvider(capture.WaveFormat);
                            providers.Add(provider);
                            output.Init(provider);
                            output.Play();
                        }
                    }

                    // Отправляем данные на все устройства
                    foreach (var provider in providers)
                    {
                        provider.AddSamples(a.Buffer, 0, a.BytesRecorded);
                    }
                };

                capture.RecordingStopped += (s, a) =>
                {
                    foreach (var output in outputs)
                    {
                        output.Stop();
                    }
                };

                // Запускаем захват звука
                capture.StartRecording();
                isRedirecting = true;

                // Обновляем UI
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                buttonRefresh.Enabled = false;
                groupBoxVolume.Enabled = true;

                // Настраиваем регуляторы громкости
                trackBarVolume1.Enabled = outputs.Count >= 1;
                trackBarVolume2.Enabled = outputs.Count >= 2;

                if (outputs.Count >= 1)
                {
                    var volume = (int)(audioDevices[listBoxDevices.SelectedIndices[0]].AudioEndpointVolume.MasterVolumeLevelScalar * 100);
                    trackBarVolume1.Value = volume;
                    labelVolume1.Text = $"Устройство 1: {volume}%";
                }

                if (outputs.Count >= 2)
                {
                    var volume = (int)(audioDevices[listBoxDevices.SelectedIndices[1]].AudioEndpointVolume.MasterVolumeLevelScalar * 100);
                    trackBarVolume2.Value = volume;
                    labelVolume2.Text = $"Устройство 2: {volume}%";
                }

                labelStatus.Text = $"Подключено устройств: {outputs.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении: {ex.Message}");
                StopRedirecting();
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            StopRedirecting();
        }

        private void StopRedirecting()
        {
            try
            {
                if (capture != null)
                {
                    capture.StopRecording();
                    capture.Dispose();
                    capture = null;
                }

                foreach (var output in outputs)
                {
                    output.Stop();
                    output.Dispose();
                }

                foreach (var provider in providers)
                {
                    provider.ClearBuffer();
                }

                outputs.Clear();
                providers.Clear();
                isRedirecting = false;

                // Обновляем UI
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                buttonRefresh.Enabled = true;
                groupBoxVolume.Enabled = false;
                labelStatus.Text = "Отключено";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отключении: {ex.Message}");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void trackBarVolume1_Scroll(object sender, EventArgs e)
        {
            if (outputs.Count >= 1 && listBoxDevices.SelectedIndices.Count >= 1)
            {
                try
                {
                    var device = audioDevices[listBoxDevices.SelectedIndices[0]];
                    device.AudioEndpointVolume.MasterVolumeLevelScalar = trackBarVolume1.Value / 100f;
                    labelVolume1.Text = $"Устройство 1: {trackBarVolume1.Value}%";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при изменении громкости: {ex.Message}");
                }
            }
        }

        private void trackBarVolume2_Scroll(object sender, EventArgs e)
        {
            if (outputs.Count >= 2 && listBoxDevices.SelectedIndices.Count >= 2)
            {
                try
                {
                    var device = audioDevices[listBoxDevices.SelectedIndices[1]];
                    device.AudioEndpointVolume.MasterVolumeLevelScalar = trackBarVolume2.Value / 100f;
                    labelVolume2.Text = $"Устройство 2: {trackBarVolume2.Value}%";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при изменении громкости: {ex.Message}");
                }
            }
        }

        private void listBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDevices.SelectedIndices.Count > 2)
            {
                listBoxDevices.SelectedIndices.Remove(listBoxDevices.SelectedIndices[0]);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (isRedirecting)
            {
                StopRedirecting();
            }
        }
    }
}