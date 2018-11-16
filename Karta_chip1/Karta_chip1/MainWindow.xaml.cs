using PCSC;
using PCSC.Exceptions;
using PCSC.Monitoring;
using PCSC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karta_chip1
{
    public partial class MainWindow : Window
    {

        private static SCardError err;
        private static SCardReader reader;
        private static System.IntPtr protocol;
        private static SCardContext hContext;

        public MainWindow()
        {
            InitializeComponent();
            try
            {

                connect(Textbox1);

                //GIVE PIN
                byte[] commandBytes = new byte[] { 0xA0, 0x20, 0x00, 0x01, 0x08, 0x31, 0x32, 0x33, 0x34, 0xFF, 0xFF, 0xFF, 0xFF };
                sendCommand(commandBytes, "VERIFY PIN", Textbox1);


                //SELECT TELECOM
                commandBytes = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 };
                //byte[] commandBytes = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 };
                sendCommand(commandBytes, "SELECT TELECOM", Textbox1);
                
                //GET RESPONSE
                commandBytes = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x16 };
                sendCommand(commandBytes, "GET RESPONSE",Textbox1);

                //SELECT SMS
                commandBytes = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C };
                sendCommand(commandBytes, "SELECT SMS", Textbox1);

                //GET RESPONSE
                commandBytes = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x0F };
                sendCommand(commandBytes, "GET RESPONSE", Textbox1);

                //READ RECORD                           nr
                //                                    rekordu
                commandBytes = new byte[] { 0xA0, 0xB2, 0x02, 0x04, 0xB0 };
                sendCommand(commandBytes, "READ RECORD", Textbox1);
                

                hContext.Release();
            }
            catch (PCSCException ex)
            {
                Textbox1.Text += $"Blad: {ex.Message} + ({ex.SCardError.ToString()})";
            }
            catch (Exception e)
            {
                Textbox1.Text += $"Nieznany blad";
            }
        }




        

        public static void connect(TextBox Textbox1)
        {
            hContext = new SCardContext();
            hContext.Establish(SCardScope.System);

            string[] readerList = hContext.GetReaders();
            Boolean noReaders = readerList.Length <= 0;
            if (noReaders)
            {
                throw new PCSCException(SCardError.NoReadersAvailable, "Blad czytnika");
            }

            Textbox1.Text += $"Nazwa czytnika + {readerList[0]}\n";

            reader = new SCardReader(hContext);

            err = reader.Connect(readerList[0],
                SCardShareMode.Shared,
                SCardProtocol.T0 | SCardProtocol.T1);
            checkError(err);

            switch (reader.ActiveProtocol)
            {
                case SCardProtocol.T0:
                    protocol = SCardPCI.T0;
                    break;
                case SCardProtocol.T1:
                    protocol = SCardPCI.T1;
                    break;
                default:
                    throw new PCSCException(SCardError.ProtocolMismatch, "nieobslugiwany protokol: " + reader.ActiveProtocol.ToString());
            }
        }

        public static void sendCommand(byte[] comand, String name, TextBox Textbox1)
        {
            byte[] recivedBytes = new byte[256];
            err = reader.Transmit(protocol, comand, ref recivedBytes);
            checkError(err);
            writeResponse(recivedBytes, name, Textbox1);
        }

        public static void writeResponse(byte[] recivedBytes, String responseCode, TextBox Textbox1)
        {
            Textbox1.Text += $"{responseCode}: ";
            for (int i = 0; i < recivedBytes.Length; i++)
                Textbox1.Text += $"{recivedBytes[i].ToString("X")} ";
            Textbox1.Text += $"\n";
        }

        static void checkError(SCardError err)
        {
            if (err != SCardError.Success)
            {
                throw new PCSCException(err, SCardHelper.StringifyError(err));
            }
        }
    }

}





