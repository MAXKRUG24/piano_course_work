using PianoEmulator.Classes;
using PianoEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace PianoEmulator.Forms
{
    public partial class Main : Form
    {
        // Системные переменные
        bool isClose = true;
        List<recorded> recordedList;

        // Ноты4
        MusicPlayerOld cSound = new MusicPlayerOld(@"Data\Sounds\c.wav");
        MusicPlayerOld cDiesSound = new MusicPlayerOld(@"Data\Sounds\c#.wav");
        MusicPlayerOld dSound = new MusicPlayerOld(@"Data\Sounds\d.wav");
        MusicPlayerOld dDiesSound = new MusicPlayerOld(@"Data\Sounds\d#.wav");
        MusicPlayerOld eSound = new MusicPlayerOld(@"Data\Sounds\e.wav");
        MusicPlayerOld fSound = new MusicPlayerOld(@"Data\Sounds\f.wav");
        MusicPlayerOld fDiesSound = new MusicPlayerOld(@"Data\Sounds\f#.wav");
        MusicPlayerOld gSound = new MusicPlayerOld(@"Data\Sounds\g.wav");
        MusicPlayerOld gDiesSound = new MusicPlayerOld(@"Data\Sounds\g#.wav");
        MusicPlayerOld aSound = new MusicPlayerOld(@"Data\Sounds\a.wav");
        MusicPlayerOld aDiesSound = new MusicPlayerOld(@"Data\Sounds\a#.wav");
        MusicPlayerOld bSound = new MusicPlayerOld(@"Data\Sounds\b.wav");
        MusicPlayerOld c2Sound = new MusicPlayerOld(@"Data\Sounds\c(a).wav");
        
        // Лист хранения экземпляров класса MusicPlayerOld
        List<MusicPlayerOld> soundsList = new List<MusicPlayerOld>();

        public Main()
        {
            InitializeComponent();
            // Включение обработки нажатия кнопок
            KeyPreview = true;
            // Загрузка композиций
            LoadCompositions();
            // Загрузка экземпляров класса MusicPlayerOld в лист
            soundsList.AddRange(new List<MusicPlayerOld>() {
                cSound, cDiesSound, dSound, dDiesSound, eSound,
                eSound, fSound, fDiesSound, gSound, gDiesSound,
                aSound, aDiesSound, bSound, c2Sound
            });
        }

        // Процедура запуска аудио файла
        public void LoadAsyncSound(MusicPlayerOld musicPlayerOld, string note, bool looping)
        {
            musicPlayerOld.StopPlaying();

            if (looping == true)
            {
                rtbHistory.Text += note + "(on) ";
            }
            else
            {
                rtbHistory.Text += note + " ";
            }

            musicPlayerOld.Play(looping);
        }

        // Загрузка списка композиций
        void LoadCompositions()
        {
            // Очищаем список от предыдущих строчек
            cbCompositions.Items.Clear();
            // Загрузка списка сохранённых композиций
            recordedList = Connector.Get<recorded>();

            if (recordedList != null)
            {
                foreach (var item in recordedList)
                {
                    cbCompositions.Items.Add(item.Name);
                }

                cbCompositions.SelectedIndex = 0;
            }
        }

        // Запуск нот

        private void btnDo_Click(object sender, EventArgs e) => LoadAsyncSound(cSound, "c", cbDo.Checked);

        private void btnDoDies_Click(object sender, EventArgs e) => LoadAsyncSound(cDiesSound, "c#", cbDoDies.Checked);

        private void btnRe_Click(object sender, EventArgs e) => LoadAsyncSound(dSound, "d", cbRe.Checked);

        private void btnReDies_Click(object sender, EventArgs e) => LoadAsyncSound(dDiesSound, "d#", cbReDies.Checked);

        private void btnMi_Click(object sender, EventArgs e) => LoadAsyncSound(eSound, "e", cbMi.Checked);

        private void btnFa_Click(object sender, EventArgs e) => LoadAsyncSound(fSound, "f", cbFa.Checked);

        private void btnFaDies_Click(object sender, EventArgs e) => LoadAsyncSound(fDiesSound, "f#", cbFaDies.Checked);

        private void btnSol_Click(object sender, EventArgs e) => LoadAsyncSound(gSound, "g", cbSol.Checked);

        private void btnSolDies_Click(object sender, EventArgs e) => LoadAsyncSound(gDiesSound, "g#", cbSolDies.Checked);

        private void btnLa_Click(object sender, EventArgs e) => LoadAsyncSound(aSound, "a", cbLa.Checked);

        private void btnLaDies_Click(object sender, EventArgs e) => LoadAsyncSound(aDiesSound, "a#", cbLaDies.Checked);

        private void btnSi_Click(object sender, EventArgs e) => LoadAsyncSound(bSound, "b", cbSi.Checked);

        private void btnDo2_Click(object sender, EventArgs e) => LoadAsyncSound(c2Sound, "c(a)", cbDo2.Checked);

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    LoadAsyncSound(cSound, "c", cbDo.Checked);
                    break;
                case Keys.W:
                    LoadAsyncSound(dSound, "d", cbRe.Checked);
                    break;
                case Keys.E:
                    LoadAsyncSound(eSound, "e", cbMi.Checked);
                    break;
                case Keys.R:
                    LoadAsyncSound(fSound, "f", cbFa.Checked);
                    break;
                case Keys.T:
                    LoadAsyncSound(gSound, "g", cbSol.Checked);
                    break;
                case Keys.Y:
                    LoadAsyncSound(aSound, "a", cbLa.Checked);
                    break;
                case Keys.U:
                    LoadAsyncSound(bSound, "b", cbSi.Checked);
                    break;
                case Keys.I:
                    LoadAsyncSound(c2Sound, "c(a)", cbDo2.Checked);
                    break;
                case Keys.NumPad1:
                    LoadAsyncSound(cDiesSound, "c#", cbDoDies.Checked);
                    break;
                case Keys.NumPad2:
                    LoadAsyncSound(dDiesSound, "d#", cbReDies.Checked);
                    break;
                case Keys.NumPad3:
                    LoadAsyncSound(fDiesSound, "f#", cbFaDies.Checked);
                    break;
                case Keys.NumPad4:
                    LoadAsyncSound(gDiesSound, "g#", cbSolDies.Checked);
                    break;
                case Keys.NumPad5:
                    LoadAsyncSound(aDiesSound, "a#", cbLaDies.Checked);
                    break;
                default:
                    break;
            }
        }

        // Очистка истории
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbHistory.Text = "";
            tbName.Text = "";
        }

        // Остановка зацикленных нот

        private void btnOffDo_Click(object sender, EventArgs e)
        {
            cSound.StopPlaying();
            cbDo.Checked = false;
            rtbHistory.Text += "c(off) ";
        }

        private void btnOffRe_Click(object sender, EventArgs e)
        {
            dSound.StopPlaying();
            cbRe.Checked = false;
            rtbHistory.Text += "d(off) ";
        }

        private void btnOffMi_Click(object sender, EventArgs e)
        {
            eSound.StopPlaying();
            cbMi.Checked = false;
            rtbHistory.Text += "e(off) ";
        }

        private void btnOffFa_Click(object sender, EventArgs e)
        {
            fSound.StopPlaying();
            cbFa.Checked = false;
            rtbHistory.Text += "f(off) ";
        }

        private void btnOffSol_Click(object sender, EventArgs e)
        {
            gSound.StopPlaying();
            cbSol.Checked = false;
            rtbHistory.Text += "g(off) ";
        }

        private void btnOffLa_Click(object sender, EventArgs e)
        {
            aSound.StopPlaying();
            cbLa.Checked = false;
            rtbHistory.Text += "a(off) ";
        }

        private void btnOffSi_Click(object sender, EventArgs e)
        {
            bSound.StopPlaying();
            cbSi.Checked = false;
            rtbHistory.Text += "b(off) ";
        }

        private void btnOffDo2_Click(object sender, EventArgs e)
        {
            c2Sound.StopPlaying();
            cbDo2.Checked = false;
            rtbHistory.Text += "c(a)(off) ";
        }

        private void btnOffDoDies_Click(object sender, EventArgs e)
        {
            cDiesSound.StopPlaying();
            cbDoDies.Checked = false;
            rtbHistory.Text += "c#(off) ";
        }

        private void btnOffReDies_Click(object sender, EventArgs e)
        {
            dDiesSound.StopPlaying();
            cbReDies.Checked = false;
            rtbHistory.Text += "d#(off) ";
        }

        private void btnOffFaDies_Click(object sender, EventArgs e)
        {
            fDiesSound.StopPlaying();
            cbFaDies.Checked = false;
            rtbHistory.Text += "f#(off) ";
        }

        private void btnOffSolDies_Click(object sender, EventArgs e)
        {
            gDiesSound.StopPlaying();
            cbSolDies.Checked = false;
            rtbHistory.Text += "g#(off) ";
        }

        private void btnOffLaDies_Click(object sender, EventArgs e)
        {
            aDiesSound.StopPlaying();
            cbLaDies.Checked = false;
            rtbHistory.Text += "a#(off) ";
        }
        /*
        private void btnOffALL_Click(object sender, EventArgs e)
        {
            
                // get rule settings
                SettingsHolder gaSettings = new SettingsHolder();
                gaSettings.GenMaxrun = (int)gensNUD.Value;
                ..gaAlgo = new GA(algoSettings);

                try
                {
                    currentPopulation = paretoAlgo.run();
                }
                catch (Exception e)
                {
                    MessageBox.Show("exc while trying run: " + e);
                }

                // iterate list and list in form
                popLB.Items.Clear();
                foreach (Chromosome c in currentPopulation)
                {
                    popLB.Items.Add(new KeyValuePair<String, int>(c.present(), id));
                }
            
        }
        */

        // Сохранить композицию
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbHistory.Text) || string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Все поля обязательны для заполнения!", "Сохранение");
            }
            else
            {
                if (Connector.Get<recorded>().Where(n => n.Name.Equals(tbName.Text)).FirstOrDefault() != null)
                {
                    MessageBox.Show("Композиция с таким названием уже есть! Выберите другое!", "Ошибка сохранения");
                }
                else
                {
                    if (Connector.Insert(new recorded() { Name = tbName.Text, Composition = rtbHistory.Text }) == false)
                    {
                        MessageBox.Show("Композицию не удалось сохранить. Ошибка!", "Ошибка сохранения");
                    }
                    else
                    {
                        LoadCompositions();
                    }
                }
            }
        }

        // Запусить композицию
        private void btnPlay_Click(object sender, EventArgs e)
        {
            List<string> notes = new List<string>();
            string composition = rtbHistory.Text;

            while (composition != "")
            {
                try
                {
                    // Добавляем ноту
                    notes.Add(@"Data\Sounds\" + composition.Substring(0, composition.IndexOf(" ")) + ".wav");
                    // Удаляем её из композиции
                    composition = composition.Remove(0, composition.IndexOf(" ")).TrimStart();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("В нотной последовательности допущены ошибки! Проверьте нотную последовательность и повторите попытку!\n" + exc.Message, "Ошибка");
                    return;
                }
            }

            // Запуск композиции
            foreach (var item in notes)
            {
                // Получаем значение зацикленности
                bool looping = item.IndexOf("on") != -1 ? true : false;

                try
                {
                    // Запускаем ноту
                    if (item.IndexOf("on") != -1)
                    {
                        // Обрезаем часть с вечным циклом
                        string name = item.Substring(0, item.IndexOf("(")) + ".wav";
                        // Запускаем
                        soundsList.Find(n => n.FileName.Equals(name)).Play(looping);
                    }
                    else if (item.IndexOf("off") != -1)
                    {
                        // Обрезаем часть с вечным циклом
                        string name = item.Substring(0, item.IndexOf("(")) + ".wav";
                        // Вырубаем
                        soundsList.Find(n => n.FileName.Equals(name)).StopPlaying();
                    }
                    else
                    {
                        soundsList.Find(n => n.FileName.Equals(item)).Play(looping);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("В нотной последовательности допущены ошибки! Проверьте нотную последовательность и повторите попытку!\n" + exc.Message, "Ошибка");
                    return;
                }                

                // Ставим задержку в 500 мс
                Thread.Sleep(500);
            }
        }

        // Остановить запись
        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var item in soundsList)
            {
                item.StopPlaying();
            }
        }

        // Выход на форму авторизации
        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClose = false;
            new Auth().Show();
            Close();
        }

        // Выход из приложения
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        // Обработка закрытия формы
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClose == true)
                Application.Exit();
        }

        // Выбор композиции
        private void cbCompositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbHistory.Text = recordedList.Where(n => n.Name.Equals(cbCompositions.Text)).FirstOrDefault().Composition;
            tbName.Text = cbCompositions.Text;
        }

        // Удалить текущую композицию
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выбранную композицию?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(cbCompositions.Text))
                {
                    MessageBox.Show("Нечего удалять!", "Ошибка");
                }
                else
                {
                    if (Connector.Delete(recordedList.Where(n => n.Name.Equals(cbCompositions.Text)).FirstOrDefault()) == false)
                    {
                        MessageBox.Show("Ошибка удаления выбранной композиции!", "Ошибка");
                    }
                    else
                    {
                        LoadCompositions();
                    }
                }
            }
        }

        // Обработка покидания поля ввода
        private void tbName_Leave(object sender, EventArgs e) => KeyPreview = true;

        // Работает в момент клика в поле ввода названия композиции
        private void tbName_Click(object sender, EventArgs e)
        {
            // При вводе названия композиции блокируем обработку клавиш
            KeyPreview = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void выбратьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "*.txt";
            openFileDialog1.Filter = "Text files|*.txt";

            string Compose;
            string ComposeName;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader F = new StreamReader(openFileDialog1.FileName);
                string file = F.ReadToEnd();
                string[] fileStrs = file.Split('\n');
                if (fileStrs.Length < 2)
                {
                    MessageBox.Show("Некорректное содержимое файла");
                    return;
                }
                ComposeName = fileStrs[0];
                Compose = fileStrs[1];
                if (string.IsNullOrEmpty(ComposeName) || string.IsNullOrEmpty(Compose))
                {
                    MessageBox.Show("Все поля обязательны для заполнения!", "Сохранение");
                }
                else
                {
                    if (Connector.Get<recorded>().Where(n => n.Name.Equals(ComposeName)).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Композиция с таким названием уже есть! Выберите другое!", "Ошибка сохранения");
                    }
                    else
                    {
                        if (Connector.Insert(new recorded() { Name = ComposeName, Composition = Compose }) == false)
                        {
                            MessageBox.Show("Композицию не удалось сохранить. Ошибка!", "Ошибка сохранения");
                        }
                        else
                        {
                            LoadCompositions();
                            rtbHistory.Text = recordedList.Where(n => n.Name.Equals(ComposeName)).FirstOrDefault().Composition;
                            tbName.Text = ComposeName;
                        }
                    }
                }

            }
            return;
        }
    }
}