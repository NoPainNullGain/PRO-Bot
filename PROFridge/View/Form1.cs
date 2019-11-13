using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PROFridge.Annotations;
using PROFridge.Properties;
using PROFridge.View;
using PROFridge.ViewModel.HelperClasses;

namespace PROFridge
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        FormOverlay frm = new FormOverlay();

        public Form1()
        {
            InitializeComponent();

            coordinates = new Coordinates
            {
                Id = -9,
                CoordX = -9,
                CoordY = -9,
                CoordXLast = -9,
                CoordYLast = -9
            };

        }

        public bool startBot = false;

        private int abilityPP1;
        public int abilityPP2;
        public int abilityPP3;
        public int abilityPP4;
        public bool PPCheck = false;
        public bool needHeal = false;

        private string _status;
        public int pID;
        public bool openProc;

        private int _currentHealth;
        private int _currentMaxHealth;
        private int _enemyCurrentHealth;
        private int _enemyMaxHealth;
        private int _encounterPokeIndex;
        private int _farmSpecifPokeID;
        private float _xPos;
        private float _yPos;
        private int _PokeDollars;
        private int _isFight;

        public float SnapshotCurrentPositionX;
        public float SnapshotCurrentPositionY;
        public int coordinateID = 0;
        public string recordedPathFile = @"C:\Users\kjerg\Documents\stuff\PRO\CoordinatSaves\coordinates.txt";
        public bool FinishedRecording = true;
        public bool reversePath = true;



        public List<Coordinates> ReversedCoordList;
        public Coordinates coordinates;
        public List<Coordinates> coordListFromJson;

        public Mem m = new Mem();

        InputSimulator sim = new InputSimulator();

        public RamGecTools.KeyboardHook KeyboardHook = new RamGecTools.KeyboardHook();
        public Singleton singleton = Singleton.Instance;

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyboardHook.KeyDown += new RamGecTools.KeyboardHook.KeyboardHookCallback(KeyboardHook_KeyDown);
            KeyboardHook.Install();
            
            // Get Process ID
            int pID = m.getProcIDFromName("PROClient");

            // check
            openProc = false;

            if (pID > 0)
            {
                m.OpenProcess(pID);
                openProc = true;
            }


            OnTickMemoryRead();


            try
            {
                AbilityPP1 = Int32.Parse(txtbx_abilityPP1.Text);
            }
            catch (Exception exception)
            {
            }

            if (!chkbx_UseFishRod.Checked)
            {
                MoveFarming();
            }

            if (chkbx_UseFishRod.Checked)
            {
                Fishing();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        // Continuesly reading memory and updating the UI
        private async void OnTickMemoryRead()
        {
            if (openProc)
            {
                CurrentHealth = m.readInt("GameAssembly.dll+00E4FAB8,0xB8,0x0,0x1C8,0x10,0x28,0x148");
                txtbx_currentHealth.Text = CurrentHealth.ToString();

                EnemyCurrentHealth = m.readInt("GameAssembly.dll+00E4AD48,0x208,0xB40,0x18,0x138,0x50,0xA24");
                txtbx_enemyCurrentHealth.Text = EnemyCurrentHealth.ToString();

                IsFight = m.readInt("GameAssembly.dll+00E50690,0xB8,0x20,0x2E8,0x50,0x678");
                txtbx_fightState.Text = IsFight.ToString();

                EncounterPokeIndex = m.readInt("GameAssembly.dll+00E474B0,0x4B0,0x10,0xE0,0x50,0x10,0xA1c");
                txtbx_pokemonID.Text = EncounterPokeIndex.ToString();

                //PokeDollars = m.readInt("GameAssembly.dll+00A508B0,0xB8,0x48,0xB8,0x298,0x290");
                //txtbx_pokeDollar.Text = PokeDollars.ToString();

                XPos = Convert.ToInt32(Math.Ceiling(m.readFloat("UnityPlayer.dll+01641E38,0x180,0x58,0x128,0x38,0xB0")));
                txtbx_xPos.Text = XPos.ToString();

                
                YPos = Convert.ToInt32(Math.Ceiling(m.readFloat("UnityPlayer.dll+01641E38,0x180,0x58,0x128,0x38,0xB4")));
                txtbx_yPos.Text = YPos.ToString();

                txtbx_currentPP1.Text = AbilityPP1.ToString();

                await Task.Delay(100);

                OnTickMemoryRead();

            }
        }


        public void SnapshotCoords()
        {
            SnapshotCurrentPositionX = XPos;

            SnapshotCurrentPositionY = YPos;

        }


        public async void MoveFarming()
        {
            if (IsFight == 0 && startBot)
            {
                txtbx_status.Text = Status = "World";

                if (SnapshotCurrentPositionX < XPos + 1 && startBot)
                {
                    sim.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                    XPos--;
                    sim.Keyboard.Sleep(300);
                }

                if (SnapshotCurrentPositionX > XPos - 1 && startBot)
                {

                    sim.Keyboard.KeyPress(VirtualKeyCode.VK_D);
                    XPos++;
                    sim.Keyboard.Sleep(300);
                }

            }

            if (IsFight != 0 && EncounterPokeIndex != 0)
            {
                txtbx_status.Text = Status = "Pokemon Encountered: " + EnemyPokemon(EncounterPokeIndex);

                FightLogic();
            }



            await Task.Delay(50);
            MoveFarming();
        }

        public async void Fishing()
        {
            if (IsFight == 0)
            {
                txtbx_status.Text = Status = "World Fishing";


                sim.Keyboard.Sleep(500);

                sim.Keyboard.KeyPress(VirtualKeyCode.VK_6);

            }

            if (IsFight != 0 && EncounterPokeIndex != 0)
            {
                txtbx_status.Text = Status = "Pokemon Encountered: " + EnemyPokemon(EncounterPokeIndex);

                FightLogic();

            }



            await Task.Delay(500);
            Fishing();
        }


        // Fight logic
        public void FightLogic()
        {
            if (IsFight == 7 && startBot) // && AbilityPP1 > 0)
            {
                txtbx_status.Text = Status = "Lets Fight";








                // FARMING BOT LOGIC

                if (EnemyCurrentHealth > 1 && chkbx_farmSpecifPoke.Checked)
                {
                    if (EncounterPokeIndex == FarmSpecifPokeID)
                    {
                        txtbx_status.Text = "Fighting: " + EnemyPokemon(EncounterPokeIndex);

                        // Specific Poke to LOW

                        sim.Keyboard.Sleep(1000);

                        sim.Keyboard.KeyPress(VirtualKeyCode.VK_1);

                        sim.Keyboard.Sleep(1000);

                        sim.Keyboard.KeyPress(VirtualKeyCode.VK_1);

                        AbilityPP1--;

                    }
                    else if (EncounterPokeIndex != FarmSpecifPokeID)
                    {
                        txtbx_status.Text = "Found wrong Pokemon: " + EnemyPokemon(EncounterPokeIndex) + ", LEAVING!";

                        // Leave Logic
                        sim.Keyboard.Sleep(1000);

                        sim.Keyboard.KeyPress(VirtualKeyCode.VK_4);

                        sim.Keyboard.Sleep(1000);
                    }

                }
                else if (EnemyCurrentHealth == 1 && chkbx_farmSpecifPoke.Checked)
                {
                    txtbx_status.Text = "Catching Specific Poke: " + EnemyPokemon(EncounterPokeIndex);
                    // TODO
                    // Catch Mechanic
                }












                // LEVELING BOT LOGIC

                if (EnemyCurrentHealth > 0 && !chkbx_farmSpecifPoke.Checked)
                {
                    txtbx_status.Text = Status = "Fighting";

                    sim.Keyboard.Sleep(1000);

                    sim.Keyboard.KeyPress(VirtualKeyCode.VK_1);

                    sim.Keyboard.Sleep(1000);

                    sim.Keyboard.KeyPress(VirtualKeyCode.VK_1);

                    AbilityPP1--;
                }

            }

        }


        public void HealPokecenter()
        {
            //TODO
            LoadPath();

            MoveOnPath();

            // Interact();

            // reversePath = false;

            // MoveOnPath();
        }

        private void Interact()
        {
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            sim.Keyboard.TextEntry("Interacting!");
        }

        public async void MoveOnPath()
        {
            // TODO
            if (reversePath)
            {

                for (int i = 0; i < ReversedCoordList.Count; i++)
                {
                    if (i>0 && (ReversedCoordList[i].CoordX > ReversedCoordList[i - 1].CoordX + 3 || ReversedCoordList[i].CoordX < ReversedCoordList[i - 1].CoordX - 3 || ReversedCoordList[i].CoordY > ReversedCoordList[i - 1].CoordY + 3 || ReversedCoordList[i].CoordY < ReversedCoordList[i - 1].CoordY - 3))
                    {
                        if (ReversedCoordList[i].CoordX > ReversedCoordList[i - 1].CoordX + 3)
                        {
                            sim.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                        }

                        if (ReversedCoordList[i].CoordX < ReversedCoordList[i - 1].CoordX - 3)
                        {
                            sim.Keyboard.KeyDown(VirtualKeyCode.VK_D);
                        }

                        if (ReversedCoordList[i].CoordY > ReversedCoordList[i - 1].CoordY + 3)
                        {
                            sim.Keyboard.KeyPress(VirtualKeyCode.VK_W);
                        }

                        if (ReversedCoordList[i].CoordY < ReversedCoordList[i - 1].CoordY - 3)
                        {
                            sim.Keyboard.KeyPress(VirtualKeyCode.VK_S);
                        }

                        Thread.Sleep(1000);

                    }


                    else
                    {
                        while (XPos != ReversedCoordList[i].CoordX || YPos != ReversedCoordList[i].CoordY)
                        {


                            while (XPos > ReversedCoordList[i].CoordX)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                                await Task.Delay(50);
                            }

                            while (XPos < ReversedCoordList[i].CoordX)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_D);
                                await Task.Delay(50);
                            }

                            while (YPos > ReversedCoordList[i].CoordY)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_S);
                                await Task.Delay(50);
                            }

                            while (YPos < ReversedCoordList[i].CoordY)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_W);
                                await Task.Delay(50);
                            }
                        }
                    }

                }
            }
            else if (!reversePath)
            {
                for (int i = 0; i < coordListFromJson.Count; i++)
                {
                    if (i > 0 && (coordListFromJson[i].CoordX > coordListFromJson[i - 1].CoordX + 3 || coordListFromJson[i].CoordX < coordListFromJson[i - 1].CoordX - 3 || coordListFromJson[i].CoordY > coordListFromJson[i - 1].CoordY + 3 || coordListFromJson[i].CoordY < coordListFromJson[i - 1].CoordY - 3))
                    {
                        if (coordListFromJson[i].CoordX > coordListFromJson[i - 1].CoordX + 3)
                        {
                            sim.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                        }

                        if (coordListFromJson[i].CoordX < coordListFromJson[i - 1].CoordX - 3)
                        {
                            sim.Keyboard.KeyDown(VirtualKeyCode.VK_D);
                        }

                        if (coordListFromJson[i].CoordY > coordListFromJson[i - 1].CoordY + 3)
                        {
                            sim.Keyboard.KeyPress(VirtualKeyCode.VK_W);
                        }

                        if (coordListFromJson[i].CoordY < coordListFromJson[i - 1].CoordY - 3)
                        {
                            sim.Keyboard.KeyPress(VirtualKeyCode.VK_S);
                        }

                        Thread.Sleep(1000);

                    }


                    else
                    {
                        while (XPos != coordListFromJson[i].CoordX || YPos != coordListFromJson[i].CoordY)
                        {


                            while (XPos > coordListFromJson[i].CoordX)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                                await Task.Delay(50);
                            }

                            while (XPos < coordListFromJson[i].CoordX)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_D);
                                await Task.Delay(50);
                            }

                            while (YPos > coordListFromJson[i].CoordY)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_S);
                                await Task.Delay(50);
                            }

                            while (YPos < coordListFromJson[i].CoordY)
                            {
                                sim.Keyboard.KeyPress(VirtualKeyCode.VK_W);
                                await Task.Delay(50);
                            }
                        }
                    }

                }
            }

        }

        private void LoadPath()
        {
            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(recordedPathFile))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                coordListFromJson = JsonConvert.DeserializeObject<List<Coordinates>>(jsonFromFile);

                if (reversePath)
                {
                    ReversedCoordList = coordListFromJson;
                    ReversedCoordList.Reverse();
                }


            }
            catch (Exception e)
            {

            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            LoadPath();
        }



        private void button4_Click(object sender, EventArgs e)
        {

            frm.Show();
            HealPokecenter();
        }



        async void KeyboardHook_KeyDown(RamGecTools.KeyboardHook.VKeys key)
        {
            if (key.ToString() == "F5")
            {
                if (chkbx_farmSpecifPoke.Checked)
                {
                    try
                    {
                        FarmSpecifPokeID = Int32.Parse(txtbx_farmSpcifPoke.Text);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Please enter in a specific Pokemon ID");
                        startBot = false;
                    }

                }

                SnapshotCoords();
                startBot = true;
                txtbx_status.Text = "Go";

            }
            else if (key.ToString() == "F6")
            {
                startBot = false;
                txtbx_status.Text = "Stopped";
            }
            else if (key.ToString() == "KEY_W")
            {
                txtbx_status.Text = "Up";
                SnapshotCoords();
            }
            else if (key.ToString() == "KEY_S")
            {
                txtbx_status.Text = "Down";
                SnapshotCoords();
            }
            else if (key.ToString() == "KEY_A")
            {
                txtbx_status.Text = "Left";
                SnapshotCoords();
            }
            else if (key.ToString() == "KEY_D")
            {
                txtbx_status.Text = "Right";
                SnapshotCoords();
            }

            await Task.Delay(100);
        }


        public async void RecordPath()
        {


            FinishedRecording = false;
            SnapshotCoords();

            if (singleton.XYList.Count == 0)
            {
                coordinates = new Coordinates
                {
                    Id = ++coordinateID,
                    CoordX = XPos,
                    CoordY = YPos,
                    CoordXLast = XPos - 1,
                    CoordYLast = YPos + 1
                };

                singleton.XYList.Add(coordinates);
                Debug.WriteLine("Adding coords to empty list " + "X:" + coordinates.CoordX + " Y:" + coordinates.CoordY);


            }

            if (singleton.XYList.Last().CoordX != SnapshotCurrentPositionX || singleton.XYList.Last().CoordY != SnapshotCurrentPositionY)
            {
                coordinates = new Coordinates
                {
                    Id = ++coordinateID,
                    CoordX = XPos,
                    CoordY = YPos,
                    CoordXLast = XPos - 1,
                    CoordYLast = YPos + 1
                };

                singleton.XYList.Add(coordinates);
                Debug.WriteLine("Adding coords to list " + "X:" + coordinates.CoordX + " Y:" + coordinates.CoordY);


            }

            frm.Show();
            await Task.Delay(100);
            RecordPath();
        }


        public string EnemyPokemon(int id)
        {
            switch (id)
            {
                case 1:
                    return "";
                case 2:
                    return "";
                case 3:
                    return "";
                case 4:
                    return "";
                case 5:
                    return "";
                case 6:
                    return "";
                case 7:
                    return "";
                case 8:
                    return "";
                case 9:
                    return "";
                case 10:
                    return "";
                case 11:
                    return "";
                case 12:
                    return "";
                case 13:
                    return "";
                case 14:
                    return "";
                case 15:
                    return "";
                case 16:
                    return "";
                case 17:
                    return "";
                case 18:
                    return "";
                case 19:
                    return "Rattata";
                case 20:
                    return "";
                case 21:
                    return "Spearow";
                case 22:
                    return "";
                case 23:
                    return "Ekans";
                case 24:
                    return "Arbok";
                case 25:
                    return "";
                case 26:
                    return "";
                case 27:
                    return "";
                case 28:
                    return "";
                case 29:
                    return "";
                case 30:
                    return "";

                    // ALL Pokemons inserted
            }

            return id.ToString();
        }

        public int CurrentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }

        public int CurrentMaxHealth
        {
            get { return _currentMaxHealth; }
            set { _currentMaxHealth = value; }
        }

        public int EnemyCurrentHealth
        {
            get { return _enemyCurrentHealth; }
            set { _enemyCurrentHealth = value; }
        }

        public int EnemyMaxHealth
        {
            get { return _enemyMaxHealth; }
            set { _enemyMaxHealth = value; }
        }

        public int EncounterPokeIndex
        {
            get { return _encounterPokeIndex; }
            set { _encounterPokeIndex = value; }
        }

        public float XPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }

        public float YPos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }

        public int PokeDollars
        {
            get { return _PokeDollars; }
            set { _PokeDollars = value; }
        }

        public int IsFight
        {
            get { return _isFight; }
            set { _isFight = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int AbilityPP1
        {
            get { return abilityPP1; }
            set { abilityPP1 = value; }
        }

        public int FarmSpecifPokeID
        {
            get { return _farmSpecifPokeID; }
            set { _farmSpecifPokeID = value; }
        }



        #region OnPropChange

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            RecordPath();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FinishedRecording = true;

            if (FinishedRecording)
            {
                string result = JsonConvert.SerializeObject(singleton.XYList, Formatting.Indented);

                using (var writer = new StreamWriter(recordedPathFile))
                {
                    writer.Write(result);
                    Debug.WriteLine(result, "Writing coords to JSON");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
