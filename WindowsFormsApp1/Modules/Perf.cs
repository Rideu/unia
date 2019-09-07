using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.IO;
using UniaCore.Peripherals;

namespace UniaCore
{
    public partial class MainWindow
    {
        static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        static PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", string.Empty);
        static NetworkInterface netDevice = NetworkInterface.GetAllNetworkInterfaces().First();
        static IPv4InterfaceStatistics ndata;

        public void InitPerf()
        {

        }

        public async static void UpdatePerf()
        {

            await Task.Run(() =>
            {
                ocv = ncv;
                ncv = cpuCounter.NextValue();
                orv = nrv;
                nrv = ramCounter.NextValue();
                omtd = nspd = nmtd;
                //spd = nspd - ospd;
                nmtd = memReadFloat(moto_travelled, gpp);

                jmp = memReadInt(jumps_found, gpp);
                //if(nmtd <= 0)
                //{

                //}

                if (omtd > nmtd)
                {
                    Properties.Settings.Default.MotoDistance = totmtd;
                    Properties.Settings.Default.Save();
                    totmtd += omtd;
                    nullstats();
                }

                cc += ncv;
                sc++;
                //if (tc % 1000 == 0)
                if (mm.stopwatch.ElapsedMilliseconds > 1000)
                {
                    //spd = nspd - ospd;
                    //if (ospd != nspd)
                    //{

                    //}
                    //ospd = nspd;
                    tc += 1;
                    mm.stopwatch.Restart();
                }

                if (mm.speedwatch.ElapsedMilliseconds > 100)
                {
                    //oespd = ospd;
                    //var espd1 = spd;
                    spd = ((nspd - ospd) / (0.06f) + spd) / 3f;
                    ospd = nspd;
                    mm.speedwatch.Restart();
                }

                ndata = netDevice.GetIPv4Statistics();

                obin = nbin;
                nbin = (int)ndata.BytesReceived;
                obout = nbout;
                nbout = (int)ndata.BytesSent;

                cbin = nbin - obin;
                cbin = cbin < 0 ? 0 : cbin;
                cbout = nbout - obout;
                cbout = cbout < 0 ? 0 : cbout;
            }
            );
        }



    }
}