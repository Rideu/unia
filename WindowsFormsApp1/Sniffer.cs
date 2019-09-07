using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace UniaCore
{
    /*
    public class Sniffer
    {
        private byte byVersionAndHeaderLength; // Eight bits for version and header 
                                               // length 
        private byte byDifferentiatedServices; // Eight bits for differentiated 
                                               // services
        private ushort usTotalLength;          // Sixteen bits for total length 
        private ushort usIdentification;       // Sixteen bits for identification
        private ushort usFlagsAndOffset;       // Eight bits for flags and frag. 
                                               // offset 
        private byte byTTL;                    // Eight bits for TTL (Time To Live) 
        private byte byProtocol;               // Eight bits for the underlying 
                                               // protocol 
        private short sChecksum;               // Sixteen bits for checksum of the 
                                               //  header 
        private uint uiSourceIPAddress;        // Thirty two bit source IP Address 
        private uint uiDestinationIPAddress;   // Thirty two bit destination IP Address 

        //End IP Header fields   
        private byte byHeaderLength;             //Header length 
        private byte[] byIPData = new byte[4096]; //Data carried by the datagram
        public void IPHeader(byte[] byBuffer, int nReceived)
        {
            try
            {
                //Create MemoryStream out of the received bytes
                MemoryStream memoryStream = newMemoryStream(byBuffer, 0, nReceived);

                //Next we create a BinaryReader out of the MemoryStream
                BinaryReader binaryReader = newBinaryReader(memoryStream);

                //The first eight bits of the IP header contain the version and
                //header length so we read them
                byVersionAndHeaderLength = binaryReader.ReadByte();

                //The next eight bits contain the Differentiated services
                byDifferentiatedServices = binaryReader.ReadByte();

                //Next eight bits hold the total length of the datagram
                usTotalLength =
                         (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next sixteen have the identification bytes
                usIdentification =
                          (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next sixteen bits contain the flags and fragmentation offset
                usFlagsAndOffset =
                          (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next eight bits have the TTL value
                byTTL = binaryReader.ReadByte();

                //Next eight represent the protocol encapsulated in the datagram
                byProtocol = binaryReader.ReadByte();

                //Next sixteen bits contain the checksum of the header
                sChecksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next thirty two bits have the source IP address
                uiSourceIPAddress = (uint)(binaryReader.ReadInt32());

                //Next thirty two hold the destination IP address
                uiDestinationIPAddress = (uint)(binaryReader.ReadInt32());

                //Now we calculate the header length
                byHeaderLength = byVersionAndHeaderLength;

                //The last four bits of the version and header length field contain the
                //header length, we perform some simple binary arithmetic operations to
                //extract them
                byHeaderLength <<= 4;
                byHeaderLength >>= 4;

                //Multiply by four to get the exact header length
                byHeaderLength *= 4;

                //Copy the data carried by the datagram into another array so that
                //according to the protocol being carried in the IP datagram
                Array.Copy(byBuffer,
                           byHeaderLength, //start copying from the end of the header
                           byIPData, 0, usTotalLength - byHeaderLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MJsniff", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
    */
}
