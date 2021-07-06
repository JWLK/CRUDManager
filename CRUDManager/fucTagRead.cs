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
        delegate void DelegateChains();

        isD2xx mDevice = new isD2xx();
        IntPtr ftHandle = IntPtr.Zero;
        //
        byte[] writeBuffer = new byte[1024];
        byte[] readBuffer = new byte[1024];
        ushort readLength = 0, writeLength = 0;
        private void cmdFtdiSerialRead_Click(object sender, EventArgs e)
        {
            byte[] serialBuffer = new byte[64];
            short serialLength = 0;

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
                labFtdiConnectState.Text = "Connect";
            }
            else
            {
                ftHandle = IntPtr.Zero;
                labFtdiConnectState.Text = "DisConnect";
            }
        }

        private void cmdFtdiUsbClose_Click(object sender, EventArgs e)
        {
            if (ftHandle != IntPtr.Zero)
            {
                mDevice.Close(ftHandle);
                ftHandle = IntPtr.Zero;
            }
            labFtdiConnectState.Text = "DisConnect";
        }
        private void cmdMifareUid_Click(object sender, EventArgs e)
        {
            byte[] serialBuffer = new byte[64];
            short serialLength = 0;

            //Get Reader ID
            if (mDevice.GetSerialNumberExt(0, serialBuffer, ref serialLength) == isD2xx.IS_STATUS.IS_OK)
            {
                editFtdiSerial.Text = Encoding.Default.GetString(serialBuffer);
                serialBuffer = Encoding.UTF8.GetBytes(editFtdiSerial.Text);
            }
            else
            {
                MessageBox.Show("리더기를 확인 할 수 없습니다.\n리더기를 확인해주세요.", "리더기 오류");
                editFtdiSerial.Text = "";
                return;
            }

            //Get Reader Connection
            if (mDevice.OpenSerialNumber(ref ftHandle, serialBuffer, 115200) == isD2xx.IS_STATUS.IS_OK)
            {
                labFtdiConnectState.Text = "Connect";
            }
            else
            {
                ftHandle = IntPtr.Zero;
                labFtdiConnectState.Text = "DisConnect";
                return;
            }

            //Get Tag Serial Number
            if (mDevice.WriteReadCommand(ftHandle, 0, 0x24 + isD2xx.BUZZER_ON, writeLength, writeBuffer, ref readLength, readBuffer) == isD2xx.IS_STATUS.IS_OK)
            {
                String tagIdOrigin = ByteToString(readBuffer, readLength);
                editMifareUid.Text = String.Format("{0}:{1}:{2}:{3}", tagIdOrigin.Substring(0, 2), tagIdOrigin.Substring(2, 2), tagIdOrigin.Substring(4, 2), tagIdOrigin.Substring(6, 2));
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
