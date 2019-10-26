using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Media;
using System.Data.OleDb;
using QBD_2011.Database.ShootingInfoTableAdapters;
using QBD_2011.Database;

namespace QBD_2011
{
    public partial class MainForm : Form
    {
        delegate void threeBoolean(bool a, bool b, bool c);

        ShootingTableTableAdapter taShootingTable = new ShootingTableTableAdapter();
        List<Database.ShootingInfo.ShootingTableRow> lstShootingTable = new List<ShootingInfo.ShootingTableRow>();

        struct clientRect
        {
            public System.Drawing.Point location;
            public int width;
            public int height;
        };

        public SoundPlayer player;
        private clientRect restore;
        public VideoProcess vp;
        public SerialPortComm serialPort;
        private ShootPointStatus allShots;
        private bool fullscreen = false;
        private bool totalFullScreen = false;
        private bool isTimerChecked = true;
        private bool isCounterChecked = false;
        public int shootTime = 50;
        private Thread splashThread;
        //GraphForm graphForm;


        public MainForm()
        {
            InitializeComponent();
            this.FormClosing +=new FormClosingEventHandler(this.MainForm_FormClosingExit);
            oneButton.Visible = false;
            twoButton.Visible = false;
            threeButton.Visible = false;
            fourButton.Visible = false;
            fiveButton.Visible = false;
            sixButton.Visible = false;
            sevenButton.Visible = false;
            eightButton.Visible = false;
            nineButton.Visible = false;
            //For loading screen 
            this.Hide();
            vp = new VideoProcess();
            vp.connectCamere();
            vp.p.Visible = false;
            targetTimer.isRunning = false;
            splashThread = new Thread(new ThreadStart(Loading.ShowLoadingScreen));
            splashThread.IsBackground = true;
            

            Fullscreen(false);

            loadAllClasses();

            serialPort = new SerialPortComm(vp, mainTargetBox, mainTargetInfo, this, targetTimer);
            splashThread.Start();

            mainTargetBox.setTargetInfo(mainTargetInfo);
            showLoadingInfo();
            mainTargetInfo.setShotLabelInfo(0, 0);
            this.WindowState = FormWindowState.Maximized;
            SetMenuItem(0);
        }
        private void MainForm_FormClosingExit(object sender,FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to quit?", "Exit QBD-2011", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes) { Application.Exit(); }
        }
        public void SetMenuItem(int i)
        {
            //if (Login.loginAdmin == 0 || Login.loginOther == 0)
            if(i == 0)
            {
                this.defaultToolBar.Enabled = false;
                this.mainMenuStrip.Enabled = false;
                loginButton.Visible = true;
            }
            //else if (Login.loginAdmin == 1 || Login.loginOther == 1)
            else if(i == 1)
            {
                this.defaultToolBar.Enabled = true;
                this.mainMenuStrip.Enabled = true;
                loginButton.Visible = false;
            }
        }

        //--------------------------------------------------------------------------------------------
        //        Misc functions
        //--------------------------------------------------------------------------------------------

        private void showLoadingInfo()
        {
            Loading.UdpateStatusText("Loading ...");
            Thread.Sleep(1000);

            Loading.UdpateStatusText("Checking pointing device");
            Thread.Sleep(500);
            bool vc = vp.isConnected;
            if (vc == true)
            {
                //targetDeviceLabel.ForeColor = Color.Green;
                targetDeviceLabel.ForeColor = Color.Blue;
                targetDeviceLabel.BackColor = Color.Green;
            }
            else
            {
                targetDeviceLabel.BackColor = Color.Red;
                targetDeviceLabel.ForeColor = Color.White;
            }
            Loading.UdpateStatusText("Checking target device");
            Thread.Sleep(1000);
            bool pc = serialPort.isPortConnected;
            if (pc == true)
            {
                shootingDeviceLabel.BackColor = Color.Green;
                shootingDeviceLabel.ForeColor = Color.Blue;
            }
            else
            {
                shootingDeviceLabel.BackColor = Color.Red;
                shootingDeviceLabel.ForeColor = Color.White;
            }

            this.Show();
            Loading.CloseLoadingScreen();
            this.Activate();


            /*
            if (vc && pc)
            {
                this.Show();
                Loading.CloseLoadingScreen();
                this.Activate();
            }
            else
            {
                //this.Dispose();
                Application.Exit();
            }
             * */
            //Fullscreen(false);
        }

        private void loadAllClasses()
        {
            TargetBoxController.setTargetBox(mainTargetBox);
            allShots = ShootPointController.getController();
            //graphForm = new GraphForm(mainTargetBox);
            targetTimer.setMainForm(this);

            KeyPreview = true;

            targetTimer.countingComplete += new TargetTimer.eventDelegate(targetTimer_countingComplete);

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Normal;
        }

        void targetTimer_countingComplete()
        {
            //MessageBox.Show("hI");
            setControlToolButton(true, false, true);
        }


        private void Fullscreen(bool isTotalFullScreen)
        {
            if (fullscreen == false)
            {
                this.restore.location = this.Location;
                this.restore.width = this.Width;
                this.restore.height = this.Height;
                //this.TopMost = true;
                this.Location = new System.Drawing.Point(0, 0);
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                this.totalFullScreen = false;
                mainTargetBox.isFullScreen = false;
                if (isTotalFullScreen)
                {
                    this.mainMenuStrip.Hide();
                    this.defaultToolBar.Hide();
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.totalFullScreen = true;
                    mainTargetBox.isFullScreen = true;
                }
                else
                {
                    this.mainMenuStrip.Show();
                    this.defaultToolBar.Show();
                    this.totalFullScreen = false;
                }
            }
            else
            {
                this.TopMost = false;
                this.Location = this.restore.location;
                this.Width = this.restore.width;
                this.Height = this.restore.height;
                // these are the two variables you may wish to change, depending
                // on the design of your form (WindowState and FormBorderStyle)
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.totalFullScreen = false;
            }
        }


        public void setControlToolButton(bool isStart, bool isStop, bool isReset)
        {

            if (InvokeRequired)
            {
                BeginInvoke(new threeBoolean(setControlToolButton), new object[] { isStart, isStop, isReset });
                return;
            }
            startToolStripButton.Enabled = isStart;
            startToolStripMenuItem.Enabled = isStart;

            stopToolStripButton.Enabled = isStop;
            stopToolStripMenuItem.Enabled = isStop;

            resetToolStripButton.Enabled = isReset;
            resetToolStripMenuItem.Enabled = isReset;

        }

        //--------------------------------------------------------------------------------------------
        //        Handler functions
        //--------------------------------------------------------------------------------------------

        private void moreToolStripButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.incrementCircle();
        }

        private void lessToolStripButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.decrementCircle();
        }

        private void liveToolStripButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.livaView();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            vp.closeVideoSource();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //float distance = 0;
            if (e.KeyCode == Keys.S && ShootPointController.getController().isProjectLaser == false)
            {
                Mrg.Point p = new Mrg.Point();
                //MessageBox.Show("");
                player.Play();
                allShots = ShootPointController.getController();
                Color c;
                vp.getCurrentImageShotInfo(out p, out c);

                if (p.getX() != -1 && p.getY() != -1)
                {

                    allShots.shots.Add(new Mrg.Point(p.getX(), p.getY()));
                    allShots.incrementShot(true, true);

                }
                else
                {
                    allShots.incrementShot(false, true);
                }

                mainTargetBox.Invalidate();
                //mainTargetInfo.setShotLabelInfo(allShots.shotAffected, allShots.shotTaken);

                if (ShootPointController.getController().shotTaken == shootTime)
                {
                    if (MessageBox.Show("Do you want to save current shooting records?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GraphForm graphForm = new GraphForm(mainTargetBox);
                        graphForm.saveData = true;
                        graphForm.showTimerForm();
                        graphForm.showDistanceForm();
                        graphForm.showCircleForm();
                        graphForm.calculateAverage();
                        if (graphForm.doneSave)
                        {
                            MessageBox.Show("Data has been saved successfully.");
                        }
                    }
                    else
                    {
                        if (File.Exists(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName + "Log" + ".txt"))
                        {
                            File.Delete(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName + "Log" + ".txt");
                        }
                        if (File.Exists(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName+".txt"))
                        {
                            File.Delete(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName+".txt");
                        }
                    }
                    
                    setControlToolButton(true, true, true);

                    mainTargetBox.isCircleDrawn = true;
                    mainTargetBox.isDistanceDrawn = true;
                    targetTimer.hangTimer();
                }


                //time adding
                ShootPointController.getController().shotTime.Add(targetTimer.singleShotTime);
                //MessageBox.Show(targetTimer.singleShotTime.ToString());
                //MessageBox.Show(targetTimer.singleShotTime.ToString());
                targetTimer.singleShotTime = 0;



            }

            if (e.KeyCode == Keys.Escape)
            {
                if (totalFullScreen == true)
                {
                    Fullscreen(false);
                    totalFullScreen = false;
                }
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (totalFullScreen == false)
            {
                Fullscreen(true);
                totalFullScreen = true;
            }
            else
            {
                Fullscreen(false);
                totalFullScreen = false;
            }
        }

        private void timerToolStripButton_Click(object sender, EventArgs e)
        {
            if (isTimerChecked == true)
            {
                targetTimer.Show();
                isTimerChecked = false;
            }
            else
            {
                targetTimer.Hide();
                isTimerChecked = true;

            }
        }

        private void counterToolStripButton_Click(object sender, EventArgs e)
        {
            if (isCounterChecked == true)
            {
                mainTargetInfo.Show();
                isCounterChecked = false;
            }
            else
            {
                mainTargetInfo.Hide();
                isCounterChecked = true;

            }
        }

        private void zeroingToolStripButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.zeroing();
        }

        private void resetToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                vp.p.Close();
                vp.closeVideoSource();
                vp = new VideoProcess();
                vp.connectCamere();
                vp.p.Visible = false;
                if (vp.isConnected == true)
                {
                    //MessageBox.Show("Target device has been reconnected successfully.");
                    targetDeviceLabel.ForeColor = Color.Blue;
                    targetDeviceLabel.BackColor = Color.Green;
                }
                else
                {
                    targetDeviceLabel.ForeColor = Color.White;
                    targetDeviceLabel.BackColor = Color.Red;
                }
                serialPort.openPort();
                if (serialPort.isPortConnected == true)
                {
                    //MessageBox.Show("Shooting device has been reconnected.");
                    shootingDeviceLabel.ForeColor = Color.Blue;
                    shootingDeviceLabel.BackColor = Color.Green;
                }
                else
                {
                    shootingDeviceLabel.ForeColor = Color.White;
                    shootingDeviceLabel.BackColor = Color.Red;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error occured,Please restart the application.");
            }
        }

        private void distanceToolStripButton_Click(object sender, EventArgs e)
        {
            mainTargetBox.isDistanceDrawn = !mainTargetBox.isDistanceDrawn;
            mainTargetBox.Invalidate();

        }

        private void crcleToolStripButton_Click(object sender, EventArgs e)
        {
            mainTargetBox.isCircleDrawn = !mainTargetBox.isCircleDrawn;
            mainTargetBox.Invalidate();
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            string countData = "";
            if (Login.loginOther == 1)
            {
                try
                {
                    DatabaseIDU data = new DatabaseIDU();
                    countData = data.CountData(Login.TraineeId);
                    VideoProcess.fileNameEnd = Login.TraineeId + countData;
                }
                catch (Exception ex)
                {
                }

                if (File.Exists(Login.fileName + VideoProcess.fileNameEnd + "Log" + ".txt"))
                {
                    File.Delete(Login.fileName + VideoProcess.fileNameEnd + "Log" + ".txt");
                }
                if (File.Exists(Login.fileName + VideoProcess.fileNameEnd + ".txt"))
                {
                    File.Delete(Login.fileName + VideoProcess.fileNameEnd + ".txt");
                }
                ShootPointController.getController().resetPoint();
                targetTimer.isRunning = true;
                targetTimer.singleShotTime = 0;
                VideoProcess.getPoint = 1;
                VideoProcess.count = 1;
                //Starting counter
                startCounter();
                setControlToolButton(false, true, true);
                mainTargetInfo.setShotLabelInfo(0, 0);
            }
            else
            {
                MessageBox.Show("Please,Login as trainee");
            }


            //gbLogin.Visible = true;
            //dtLogin.Value = DateTime.Now;
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            setControlToolButton(true, true, true);

            gbLogin.Visible = false;

            targetTimer.stopTimer();
            targetTimer.Hide();
            VideoProcess.getPoint = 0;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShootPointController.getController().resetPoint();
            setControlToolButton(true, true, true);
            mainTargetBox.shotRadiusPoint.Clear();
            mainTargetBox.tempPoints.Clear();
            mainTargetInfo.setShotLabelInfo(0, 0);
        }

        private void distanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTargetBox.isDistanceDrawn = !mainTargetBox.isDistanceDrawn;
            mainTargetBox.Invalidate();
        }

        private void circleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainTargetBox.isCircleDrawn = !mainTargetBox.isCircleDrawn;
            mainTargetBox.Invalidate();
        }

        private void showTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTimerChecked == true)
            {
                targetTimer.Show();
                isTimerChecked = false;
            }
            else
            {
                targetTimer.Hide();
                isTimerChecked = true;

            }
        }

        private void showCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isCounterChecked == true)
            {
                mainTargetInfo.Show();
                isCounterChecked = false;
            }
            else
            {
                mainTargetInfo.Hide();
                isCounterChecked = true;
            }
        }

        private void shootSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = SettingsController.getShootSettingForm().ShowDialog();

            if (r == DialogResult.OK)
            {
                if (SettingsController.getShootSettingForm().shootBySradioButton.Checked == true)
                {
                    pointingDeviceMenuItem.Checked = false;
                    ShootPointController.getController().isProjectLaser = false;
                }
                else
                {
                    pointingDeviceMenuItem.Checked = true;
                    ShootPointController.getController().isProjectLaser = true;

                }

                shootTime = SettingsController.getShootSettingForm().shootTime;
            }


        }

        private void timeSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsController.getTimeSettingForm().ShowDialog();
            //this.TopMost = false;
            //t.TopMost = true;
        }

        private void pointingDeviceMenuItem_Click(object sender, EventArgs e)
        {
            if (pointingDeviceMenuItem.Checked == true)
            {
                ShootPointController.getController().isProjectLaser = false;
                pointingDeviceMenuItem.Checked = false;
                SettingsController.getShootSettingForm().shootBySradioButton.Checked = true;
                SettingsController.getShootSettingForm().shootByTrigerRadioButton.Checked = false;

            }
            else
            {
                ShootPointController.getController().isProjectLaser = true;
                pointingDeviceMenuItem.Checked = true;

                SettingsController.getShootSettingForm().shootBySradioButton.Checked = false;
                SettingsController.getShootSettingForm().shootByTrigerRadioButton.Checked = true;

            }
        }

        private void startCounter()
        {
            bool isCounter = SettingsController.getTimeSettingForm().isCounter;

            if (targetTimer.isRunning == true)
            {
                if (isCounter == false)
                {
                    targetTimer.startStopWatch();
                    targetTimer.Show();
                }
                else
                {
                    targetTimer.setTimer(SettingsController.getTimeSettingForm().getTimeInSeconds());
                    targetTimer.Show();
                }
            }
        }

        private void afterPerShotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (afterFinishToolStripMenuItem.Checked == true)
            {
                afterFinishToolStripMenuItem.Checked = false;
            }
            mainTargetBox.isCircleDrawn = true;
            mainTargetBox.isDistanceDrawn = true;
        }

        private void afterFinishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (afterPerShotToolStripMenuItem.Checked == true)
            {
                afterPerShotToolStripMenuItem.Checked = false;
            }
        }

        private void diatanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("sd");
            GraphForm graphForm = new GraphForm(mainTargetBox);
            graphForm.showTimerForm();
            graphForm.showDistanceForm();
            graphForm.showCircleForm();
            graphForm.calculateAverage();
            graphForm.tabControl.SelectTab(0);
            graphForm.Show();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphForm graphForm = new GraphForm(mainTargetBox);
            graphForm.showTimerForm();
            graphForm.showDistanceForm();
            graphForm.showCircleForm();
            graphForm.calculateAverage();
            graphForm.tabControl.SelectTab(1);
            graphForm.Show();




        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphForm graphForm = new GraphForm(mainTargetBox);
            graphForm.showTimerForm();
            graphForm.showDistanceForm();
            graphForm.showCircleForm();
            graphForm.calculateAverage();
            graphForm.tabControl.SelectTab(2);
            graphForm.Show();
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphForm graphForm = new GraphForm(mainTargetBox);
            graphForm.showTimerForm();
            graphForm.showCircleForm();
            graphForm.showDistanceForm();
            graphForm.calculateAverage();
            graphForm.tabControl.SelectTab(3);
            graphForm.Show();
        }

        private void mainTargetBox_Load(object sender, EventArgs e)
        {
            loadSoundFile();
        }


        private void loadSoundFile()
        {
            Assembly ass = this.GetType().Assembly;
            Stream audioStream = Properties.Resources.shot;
            player = new SoundPlayer(audioStream);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.loginOther == 1 || Login.loginAdmin == 1)
            {
                //Reseting all points
                ShootPointController.getController().resetPoint();
                targetTimer.isRunning = true;
                targetTimer.singleShotTime = 0;



                //Starting counter
                startCounter();
                setControlToolButton(false, true, true);
                mainTargetInfo.setShotLabelInfo(0, 0);
            }
            else
            {
                LoginForm form = new LoginForm(this);
                form.Visible = true;
            }
            
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setControlToolButton(true, true, true);

            targetTimer.stopTimer();
            targetTimer.Hide();
        }

        private void aboutQBD2011ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (vp.isConnected && serialPort.isPortConnected)
            {

            }
            else
            {
                //this.Hide();
                //splashThread.Abort();
                //MessageBox.Show("He");
                //this.Dispose();
                //mainTargetBox.DrawToBitmap();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            //printDialog.ShowDialog();
            //printForm.Form = this;
            //printForm.pr
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ColorRange range = new ColorRange(this);
            range.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (vp.showPreview == false)
            {
                vp.showPreview = true;
                vp.p.Show();
            }
            else
            {
                vp.showPreview = false;
                vp.p.Hide();
            }
        }

        private void btnLoginOk_Click(object sender, EventArgs e)
        {

            //Reseting all points
            ShootPointController.getController().resetPoint();
            targetTimer.isRunning = true;
            targetTimer.singleShotTime = 0;

            //
            string bano = txtBANo.Text;
            string name = txtName.Text;
            DateTime datetime = dtLogin.Value;
            gbLogin.Visible = false;

            
            //gf.fromMain(bano, name, datetime);

            //Starting counter
            startCounter();
            setControlToolButton(false, true, true);
            mainTargetInfo.setShotLabelInfo(0, 0);
        }

        private void btnLoginCancel_Click(object sender, EventArgs e)
        {
            gbLogin.Visible = false;
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.loginAdmin == 1)
            {
                DataRecords records = new DataRecords();
                records.Visible = true;
            }
            else
            {
                MessageBox.Show("Sorry,this portion is only for admin.");
            }
            //DataRecords dr = new DataRecords();
            //dr.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.loginAdmin == 1)
            {
                RegistrationForm form = new RegistrationForm();
                form.Visible = true;
            }
            else
            {
                MessageBox.Show("Sorry,This portion is only for admin.");
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            DataRecords record = new DataRecords();
            record.Visible = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            oneButton.Visible = true;
            twoButton.Visible = true;
            threeButton.Visible = true;
            fourButton.Visible = true;
            fiveButton.Visible = true;
            sixButton.Visible = true;
            sevenButton.Visible = true;
            eightButton.Visible = true;
            nineButton.Visible = true;
            TargetBoxController.SnapShooting();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375, 0, 206, 206);
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375 + 206, 0, 206, 206);
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375 + 206*2, 0, 206, 206);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375, 206, 206, 206);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375+206, 206, 206, 206);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375 + 206*2, 206, 206, 206);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375 , 206+206, 206, 206);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375+206, 206 + 206, 206, 206);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            TargetBoxController.SnapShooting();
            TargetBoxController.SelectRegion(375 + 206*2, 206 + 206, 206, 206);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(this);
            form.Visible = true;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.loginAdmin = 0;
            Login.loginOther = 0;
            Login.BaNo = "";
            Login.ShooterName = "";
            SetMenuItem(0);
            loginButton.Visible = true;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(this);
            form.Visible = true;
        }

        private void deleteRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.loginAdmin == 1)
            {
                DeleteRecords records = new DeleteRecords();
                records.Visible = true;
            }
            else
            {
                MessageBox.Show("Sorry,this portion is only for admin.");
            }

        }     
    }
}