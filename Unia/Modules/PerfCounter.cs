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
using static UniaCore.Helper;

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


        static float lmcps, rmcps;
        static float 
            cc, 
            newCpuValue, oldCpuValue, 
            newRamValue, oldRamValue;
        static int nbin, cbin, obin, nbout, cbout, obout;

        public async static void UpdatePerf()
        {
            await Task.Run(() =>
            {
                oldCpuValue = newCpuValue;
                newCpuValue = cpuCounter.NextValue();
                oldRamValue = newRamValue;
                newRamValue = ramCounter.NextValue();

                cc += newCpuValue;
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

        public static void DrawPerf()
        {

            var vc = (newCpuValue / 100) > 0.5f ? mm.labelCPUVh : mm.labelCPUVl;
            {
                mm.labelCPUVh.Text = mm.labelCPUVl.Text = "";
                vc.Text = string.Format(ci, "{0:0.0}", newCpuValue);

                mm.labelCPUVh.Height = (int)(138 * ((oldCpuValue + newCpuValue) / 2 / 100));
                mm.labelCPUVl.Height = 138 - (int)(138 * ((oldCpuValue + newCpuValue) / 2 / 100));
                mm.labelCPUVh.BackColor = LerpCol(red, green, 1 - newCpuValue / 100);
            }

            {
                mm.labelMIDVh.Text = mm.labelMIDVl.Text = "";
                vc = ((cc / sc) / 100) > 0.5f ? mm.labelMIDVh : mm.labelMIDVl;
                vc.Text = string.Format(ci, "{0:0.0}", (cc / sc));

                mm.labelMIDVh.Height = (int)(138 * ((cc / sc) / 100));
                mm.labelMIDVl.Height = 138 - (int)(138 * ((cc / sc) / 100));
                mm.labelMIDVh.BackColor = LerpCol(red, green, 1 - (cc / sc) / 100);
            }

            {
                mm.labelRAMVh.Text = mm.labelRAMVl.Text = "";
                vc = (newRamValue / 8192) < 0.5f ? mm.labelRAMVh : mm.labelRAMVl;
                vc.Text = string.Format(ci, "{0:0.0}G", ((8192 - newRamValue) / 1000));

                mm.labelRAMVh.Height = 138 - (int)(138 * (newRamValue / 8192));
                mm.labelRAMVl.Height = (int)(138 * (newRamValue / 8192));
                mm.labelRAMVh.BackColor = LerpCol(red, skyblue, 1 - (newRamValue / 8192));
            }
            if (sc > 2)
            {

                mm.labelINVh.Text = mm.labelINVl.Text = "";
                vc = (cbin / 1048576f) > 0.5f ? mm.labelINVh : mm.labelINVl;
                vc.Text = string.Format(ci, "{0:0.0}", (cbin / 1024));

                mm.labelINVh.Height = (int)(138 * (cbin / 1048576f));
                mm.labelINVl.Height = 138 - (int)(138 * (cbin / 1048576f));
                mm.labelINVh.BackColor = LerpCol(purple, skyblue, 1 - (cbin / 1048576f));

                mm.labelOUTVh.Text = mm.labelOUTVl.Text = "";
                vc = (cbout / 1048576f) > 0.5f ? mm.labelOUTVh : mm.labelOUTVl;
                vc.Text = string.Format(ci, "{0:0.0}", (cbout / 1024));

                mm.labelOUTVh.Height = (int)(138 * (cbout / 1048576f));
                mm.labelOUTVl.Height = 138 - (int)(138 * (cbout / 1048576f));
                mm.labelOUTVh.BackColor = LerpCol(purple, skyblue, 1 - (cbout / 1048576f));
            }
        }

    }
}