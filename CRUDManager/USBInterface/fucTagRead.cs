using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_D2xx;

namespace CRUDManager
{
    public partial class MainWindow : Window
    {
        isD2xx mDevice = new isD2xx();
        IntPtr ftHandle = IntPtr.Zero;

        bool connectionStatus = false;

        //
        byte[] writeBuffer = new byte[1024];
        byte[] readBuffer = new byte[1024];
        ushort readLength = 0, writeLength = 0;

        String getTag_Number = "";
        String getTag_View = "";


        public void initDevice()
        {
            connectTagReader();
        }

        public void connectTagReader()
        {
            if (mDevice.OpenSerialNumber(ref ftHandle, getTagReaderSerial(), 115200) == isD2xx.IS_STATUS.IS_OK)
            {
                labFtdiConnectState.Text = "Connect";
                connectionStatus = true;
            }
            else
            {
                ftHandle = IntPtr.Zero;
                labFtdiConnectState.Text = "Not Connected";
                connectionStatus = false;
            }
        }

        public byte[] getTagReaderSerial()
        {
            String serialString = "";
            byte[] serialBuffer = new byte[64];
            short serialLength = 0;

            try
            {
                if (mDevice.GetSerialNumberExt(0, serialBuffer, ref serialLength) == isD2xx.IS_STATUS.IS_OK)
                {
                    serialString = Encoding.Default.GetString(serialBuffer);

                    Console.WriteLine("getTagReaderSerial : Success = " + serialString);
                }
                else if(mDevice.GetSerialNumberExt(0, serialBuffer, ref serialLength) == isD2xx.IS_STATUS.IS_INVALID_HANDLE)
                {
                    Console.WriteLine("getTagReaderSerial : Fail ");
                }
                else
                {
                    MessageBox.Show("리더기를 확인 할 수 없습니다.\n리더기를 확인해주세요.", "리더기 오류");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR getTagReaderSerial : " + e);
            }

            return serialBuffer;
        }

        private void cmdFtdiSerialRead_Click(object sender, EventArgs e)
        {
            byte[] serialBuffer = new byte[64];
            short serialLength = 0;
            Console.WriteLine("USB cmdFtdiSerialRead_Click MSG : " + mDevice.GetSerialNumberExt(0, serialBuffer, ref serialLength));
            if (mDevice.GetSerialNumberExt(0, serialBuffer, ref serialLength) == isD2xx.IS_STATUS.IS_OK)
            {
                editFtdiSerial.Text = Encoding.Default.GetString(serialBuffer);
            }
            else
            {
                MessageBox.Show("리더기를 확인 할 수 없습니다.\n리더기를 확인해주세요.", "리더기 오류");
                editFtdiSerial.Text = "";
                return;
            }
        }

        private void cmdFtdiUsbOpen_Click(object sender, EventArgs e)
        {
            if (editFtdiSerial.Text.Length == 0)
            {
                labFtdiConnectState.Text = "Serial 입력 하세요.";
                return;
            }
            byte[] serialBuffer = Encoding.UTF8.GetBytes(editFtdiSerial.Text);

            if (mDevice.OpenSerialNumber(ref ftHandle, serialBuffer, 115200) == isD2xx.IS_STATUS.IS_OK)
            {
                labFtdiConnectState.Text = "Connected";
            }
            else
            {
                ftHandle = IntPtr.Zero;
                labFtdiConnectState.Text = "Not Connected";
                editFtdiSerial.Text = "";
                editMifareUid.Text = "";
            }
        }

        private void cmdFtdiUsbClose_Click(object sender, EventArgs e)
        {
            if (ftHandle != IntPtr.Zero)
            {
                mDevice.Close(ftHandle);
                ftHandle = IntPtr.Zero;
            }
            labFtdiConnectState.Text = "Not Connected";
            editFtdiSerial.Text = "";
            editMifareUid.Text = "";
        }

        private void cmdMifareUid_Click(object sender, EventArgs e)
        {

            if (mDevice.WriteReadCommand(ftHandle, 0, 0x24 + isD2xx.BUZZER_ON, writeLength, writeBuffer, ref readLength, readBuffer) == isD2xx.IS_STATUS.IS_FAILED_TO_WRITE_DEVICE)
            {
                ftHandle = IntPtr.Zero;
                connectTagReader();
                editMifareUid.Text = "";
            }
            else if (mDevice.WriteReadCommand(ftHandle, 0, 0x24 + isD2xx.BUZZER_ON, writeLength, writeBuffer, ref readLength, readBuffer) == isD2xx.IS_STATUS.IS_OK)
            {
                String tagIdOrigin = ByteToString(readBuffer, readLength);
                getTag_Number = String.Format("{0}{1}{2}{3}", tagIdOrigin.Substring(0, 2), tagIdOrigin.Substring(2, 2), tagIdOrigin.Substring(4, 2), tagIdOrigin.Substring(6, 2));
                getTag_View = String.Format("{0}:{1}:{2}:{3}", tagIdOrigin.Substring(0, 2), tagIdOrigin.Substring(2, 2), tagIdOrigin.Substring(4, 2), tagIdOrigin.Substring(6, 2));
                editMifareUid.Text = getTag_View;
            }
            else 
            {
                editMifareUid.Text = "";
            }
        }

        public string ByteToString(byte[] strByte, int length)
        {
            string str = "";

            for (int i = 0; i < length; i++)
            {
                str += System.String.Format("{0:X2}", strByte[i]);
            }
            return str;
        }
        public byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }
    }
}
