using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;

namespace ModbusMultiClient
{
    public partial class Form1 : Form
    {

        ModbusClient ModClient = new ModbusClient();
        int[] vals;
        public Form1()
        {
            InitializeComponent();
            ModClient = new ModbusClient(txtPort.Text);
            ModClient.Baudrate = int.Parse(cboBaudrate.Text);
            if (cboParity.Text == "None")
            {
                ModClient.Parity = System.IO.Ports.Parity.None;
            }
            else if (cboParity.Text == "Even")
            {
                ModClient.Parity = System.IO.Ports.Parity.Even;
            }
            else if (cboParity.Text == "Odd")
            {
                ModClient.Parity = System.IO.Ports.Parity.Odd;
            }

            try
            {
                ModClient.Connect();
                timerPoll.Start();
                lblStatus.Text = "Connected";
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                grpRW.Enabled = true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error! " + ex.ToString();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
             ModClient = new ModbusClient(txtPort.Text);
             ModClient.Baudrate = int.Parse(cboBaudrate.Text);
             if (cboParity.Text == "None")
             {
                 ModClient.Parity = System.IO.Ports.Parity.None;
             } else if (cboParity.Text == "Even")
             {
                 ModClient.Parity = System.IO.Ports.Parity.Even;
             }
             else if (cboParity.Text == "Odd")
             {
                 ModClient.Parity = System.IO.Ports.Parity.Odd;
             }

             try
             {
                 ModClient.Connect();
                 timerPoll.Start();
                 lblStatus.Text = "Connected";
                 btnConnect.Enabled = false;
                 btnDisconnect.Enabled = true;
                 grpRW.Enabled = true;
             } catch (Exception ex)
             {
                 lblStatus.Text = "Error! " + ex.ToString();
             }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            ModClient.Disconnect();
            timerPoll.Stop();
            lblStatus.Text = "Disconnected";
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            grpRW.Enabled = false;
        }

        private void btnReadHolding_Click(object sender, EventArgs e)
        {

            
        }

        private void btnWriteHolding_Click(object sender, EventArgs e)
        {
            
            ModClient.WriteSingleRegister(int.Parse(txtReg.Text), int.Parse(TankBasıncı.Text));
        }

        private void btnReadAnalog_Click(object sender, EventArgs e)
        {
            int[] vals;
            vals = ModClient.ReadInputRegisters(int.Parse(txtReg.Text), 1);
            TankBasıncı.Text = vals[0].ToString();
        }

        private void btnReadCoil_Click(object sender, EventArgs e)
        {
            bool[] vals;
            vals = ModClient.ReadCoils(int.Parse(txtReg.Text), 1);
            TankBasıncı.Text = vals[0].ToString();
        }

        private void btnWriteCoil_Click(object sender, EventArgs e)
        {
            ModClient.WriteSingleCoil(int.Parse(txtReg.Text), bool.Parse(TankBasıncı.Text));
        }

        private void btnReadDigital_Click(object sender, EventArgs e)
        {
            bool[] vals;
            vals = ModClient.ReadDiscreteInputs(int.Parse(txtReg.Text), 1);
            TankBasıncı.Text = vals[0].ToString();
        }

        private void timerPoll_Tick(object sender, EventArgs e)
        {
            if(ModClient.Connected == true)
            {
                vals = ModClient.ReadHoldingRegisters(0, 47);
                ID.Text =           vals[0].ToString();
                Baud.Text =         vals[1].ToString();    
                TankBasıncı.Text =  vals[2].ToString();
                HatBasıncı.Text =   vals[3].ToString();
                StartBasıncı.Text = vals[4].ToString();
                StopBasıncı.Text =  vals[5].ToString();
                StartTime2.Text=    vals[6].ToString();
                StartTime3.Text =   vals[7].ToString();
                StartTime4.Text =   vals[8].ToString();
                StartTimeAlarm.Text = vals[9].ToString();
                StatPump.Text =     vals[10].ToString();


                Esyaslanma.Text = vals[11].ToString();
                EsyasDuty.Text = vals[12].ToString();
                SaatPompa1.Text = vals[13].ToString();
                DkikaPompa1.Text = vals[14].ToString();
                SaatPompa2.Text = vals[15].ToString();
                DkikaPompa2.Text = vals[16].ToString();
                SaatPompa3.Text = vals[17].ToString();
                DkikaPompa3.Text = vals[18].ToString();
                SaatPompa4.Text = vals[19].ToString();
                DkikaPompa4.Text = vals[20].ToString();
                StatP1.Text = vals[21].ToString();
                StatP2.Text = vals[22].ToString();
                StatP3.Text = vals[23].ToString();
                StatP4.Text = vals[24].ToString();
                DewPoint.Text = vals[34].ToString();
                DutyDryTime.Text = vals[35].ToString();
                DrayerGrup.Text = vals[36].ToString();
                StatDrayer1.Text = vals[37].ToString();
                StatDrayer2.Text = vals[38].ToString();
                StatDrayer3.Text = vals[39].ToString();
                StatDrayer4.Text = vals[40].ToString();
                PresureFault.Text = vals[41].ToString();
                TankPerıod.Text = vals[43].ToString();
                TankTahlıye.Text = vals[44].ToString();
                Dryerfault.Text = vals[46].ToString();
            }
        }
    }      
    }

