using System;
using System.Collections.Generic;

using System.Runtime.InteropServices;
using System.Text;

namespace IS_D2xx
{
    class isD2xx
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);

        //
        // 
        public const int BUZZER_ON = 0x80;
        //
        public const byte CM1_COMMON = 0x00;
        public const byte CM1_ISO14443AB = 0x01;
        public const byte CM1_ISO15693 = 0x03;
        public const byte CM1_MIFARE = 0x02;
        public const byte CM1_MIFARE_ULTRALIGHT = 0x05;
        public const byte CM1_MIFARE_PLUS = 0x07;
        public const byte CM1_ISO7816 = 0x0A;
        public const byte CM1_CRYPT = 0x10;

        // common cm2
        public const int CMD2_COMMON_UNIQUE_ID = 0x0F;
        public const int CMD2_COMMON_VERSION = 0x10;
        public const int CMD2_COMMON_BAUD_CHANGE = 0x12;
        public const int CMD2_COMMON_SAK_TYPE = 0x14;
        public const int CMD2_COMMON_RFON = 0x20;
        public const int CMD2_COMMON_RFOFF = 0x21;
        public const int CMD2_COMMON_ALL_UID_READ = 0x23;
        public const int CMD2_COMMON_ISO14443A_UID_READ = 0x24;
        public const int CMD2_COMMON_ISO14443B_UID_READ = 0x25;
        public const int CMD2_COMMON_FELICA_UID_READ = 0x26;
        public const int CMD2_COMMON_ISO15693_UID_READ = 0x27;
        public const int CMD2_COMMON_T_MONEY_SERIAL_NUMBER_READ = 0x30;
        public const int CMD2_COMMON_CASHBEE_SERIAL_NUMBER_READ = 0x31;
        public const int CMD2_COMMON_KCASH_SERIAL_NUMBER_READ = 0x32;
        public const int CMD2_COMMON_ALL_CASH_SERIAL_NUMBER_READ = 0x33;

        // ISO15693
        public const byte CM2_ISO15693_ACTIVE = 0x20;
        public const byte CM2_ISO15693_SINGLE_BLOCK_READ = 0x21;
        public const byte CM2_ISO15693_MULTIPLE_BLOCK_READ = 0x22;
        public const byte CM2_ISO15693_SINGLE_BLOCK_WRITE = 0x23;
        public const byte CM2_ISO15693_MULTIPLE_BLOCK_WRITE = 0x24;
        public const byte CM2_ISO15693_STAYQUIET = 0x25;
        public const byte CM2_ISO15693_SELECT = 0x26;
        public const byte CM2_ISO15693_RESETTOREADY = 0x27;
        public const byte CM2_ISO15693_BLOCK_LOOK = 0x28;
        public const byte CM2_ISO15693_WRITE_AFI = 0x29;
        public const byte CM2_ISO15693_LOCK_AFI = 0x2A;
        public const byte CM2_ISO15693_WRITE_DSFID = 0x2B;
        public const byte CM2_ISO15693_LOCK_DSFID = 0x2C;
        public const byte CM2_ISO15693_GETSYSTEMINFORMATION = 0x2D;
        public const byte CM2_ISO15693_GETMULTIPLEBLOCKSECURITYSTATUS = 0x2E;

        //ISO15693 & SLIX 2
        public const byte CM2_ISO15693_ICODE_GET_RANDOM_NUMBER = 0x30;
        public const byte CM2_ISO15693_ICODE_SET_PASSWD = 0x31;
        public const byte CM2_ISO15693_ICODE_WRITE_PASSWD = 0x32;
        public const byte CM2_ISO15693_ICODE_LOCK_PASSWD = 0x33;
        public const byte CM2_ISO15693_ICODE_PROTECT_PAGE = 0x34;
        public const byte CM2_ISO15693_ICODE_LOCK_PROTECT_PAGE = 0x35;
        public const byte CM2_ISO15693_ICODE_PROTECT_BLOCK_STATE = 0x38;
        public const byte CM2_ISO15693_ICODE_DESTROY = 0x36;
        public const byte CM2_ISO15693_ICODE_ENABLE_PRIVACY = 0x37;
        public const byte CM2_ISO15693_ICODE_AUTO_SET_PASSWD = 0x39;
        public const byte CM2_ISO15693_ICODE_INVENTORY_READ = 0x40;
        public const byte CM2_ISO15693_ICODE_FASET_INVENTORY_READ = 0x41;
        public const byte CM2_ISO15693_ICODE_SET_EAS = 0x42;
        public const byte CM2_ISO15693_ICODE_RESET_EAS = 0x43;
        public const byte CM2_ISO15693_ICODE_PROTEC_EAS = 0x44;
        public const byte CM2_ISO15693_ICODE_LOCK_EAS = 0x45;
        public const byte CM2_ISO15693_ICODE_EAS_ALRAM = 0x46;
        public const byte CM2_ISO15693_ICODE_WRITE_EAS_ID = 0x47;
        public const byte CM2_ISO15693_ICODE_READ_EPC = 0x48;
        public const byte CM2_ISO15693_ICODE_GET_NXP_SYSTEMINFORMATION = 0x49;
        public const byte CM2_ISO15693_ICODE_STAY_QUIET_PERSISTENT = 0x4A;
        public const byte CM2_ISO15693_ICODE_READ_SIGNATURE = 0x4B;
        public const byte CM2_ISO15693_ICODE_64BIT_PASSWORD_SET = 0x50;
        public const byte CM2_ISO15693_ICODE_16BIT_COUNTER_READ = 0x51;
        public const byte CM2_ISO15693_ICODE_16BIT_COUNTER_INCREMENT = 0x52;
        public const byte CM2_ISO15693_ICODE_16BIT_COUNTER_PROTECT_SET = 0x53;
        public const byte CM2_ISO15693_ICODE_16BIT_COUNTER_PROTECT_CLREAR = 0x54;

        //Crypt Calculator
        public const byte CM2_RANDOM_SEED = 0x30;
        public const byte CM2_RANDOM_CREATE = 0x31;
        public const byte CM2_AES128_KEY_SAVE = 0x35;
        public const byte CM2_AES128_IV_SAVE = 0x36;
        public const byte CM2_AES128_DECRYPT = 0x37;
        public const byte CM2_AES128_ENCRYPT = 0x38;
        public const byte CM2_3DES_KEY_SAVE = 0x39;
        public const byte CM2_3DES_IV_SAVE = 0x3A;
        public const byte CM2_3DES_DECRYPT = 0x3B;
        public const byte CM2_3DES_ENCRYPT = 0x3C;
        public const byte CM2_CRYPT_KEY_IV_SAVE = 0x40;
        public const byte CM2_CRYPT_COMMAND_CONVERT = 0x42;
        public const byte CM2_CRYPT_COMMAND_EXE = 0x43;

        // ISO14443A/B
        public const byte CM2_ISO14443A_ACTIVE = 0x20;
        public const byte CM2_ISO14443_4A_106_ACTIVE = 0x21;
        public const byte CM2_ISO14443_3A_4A_ACTIVE = 0x22;
        public const byte CM2_ISO14443B_ACTIVE = 0x23;
        public const byte CM2_ISO14443AB_ACTIVE = 0x24;
        public const byte CM2_ISO14443A_HALT = 0x2A;
        public const byte CM2_ISO14443B_HALT = 0x2B;
        public const byte CM2_ISO14443P4_DATA_EXCHANGE = 0x30;

        //Mifare Ultralight
        public const byte CM2_MIFARE_ULTRALIGHT_ACTIVE = 0x20;
        public const byte CM2_ULTRALIGHT_AUTH = 0x21;
        public const byte CM2_ULTRALIGHT_READ = 0x22;
        public const byte CM2__ULTRALIGHT_WRITE = 0x23;
        public const byte CM2_ULTRALIGHT_PASSWD_CHANGE = 0x24;
        public const byte CM2__ULTRALIGHT_OTP_READ = 0x25;
        public const byte CM2__ULTRALIGHT_OTP_WRITE = 0x26;
        public const byte CM2__ULTRALIGHT_COUNT_READ = 0x27;
        public const byte CM2__ULTRALIGHT_COUNT_INC_1 = 0x28;
        public const byte CM2__ULTRALIGHT_COUNT_INC_ADD = 0x29;
        public const byte CM2__ULTRALIGHT_LOCK_BYTE0_WRITE = 0x2A;
        public const byte CM2__ULTRALIGHT_LOCK_BYTE2_WRITE = 0x2B;
        public const byte CM2__ULTRALIGHT_PASSWORD_WRITE = 0x2C;
        public const byte CM2__ULTRALIGHT_AUTH0_AUTH1_READ = 0x2D;
        public const byte CM2__ULTRALIGHT_AUTH0_WRITE = 0x2E;
        public const byte CM2__ULTRALIGHT_AUTH1_WRITE = 0x2F;
        public const byte CM2_ULTRALIGHT_AUTH_32BIT = 0x30;

        //NTAG 
        public const byte CM2_NTAG_COUNTER_READ = 0x31;
        public const byte CM2_NTAG_GET_VERSION = 0x32;
        public const byte CM2_NTAG_READ_SIGNAL_ECC = 0x33;
        public const byte CM2_NTAG_FAST_READ = 0x34;
        public const byte CM2_NTAG_AUTH0_WRITE = 0x35;
        public const byte CM2_NTAG_ACCESS_WRITE = 0x36;
        public const byte CM2_NTAG_AUTH0_ACCESS_READ = 0x37;
        public const byte CM2_NTAG_COUNTER_ENABLE_WRITE = 0x38;
        public const byte CM2_NTAG_COUNTER_PWD_WRITE = 0x39;
        public const byte CM2_NTAG_COUNTER_STATE_READ = 0x3A;
        public const byte CM2_NTAG_PASSWD_CHANGE = 0x3B;
        public const byte CM2__ULTRALIGHT_COMPATILITY_WRITE = 0x3C;

        //Mifare Plus
        public const byte CM2_MIFARE_PLUS_SL3_ACTIVE = 0x20;
        public const byte CM2_MIFARE_PLUS_SL3_BLOCK_READ = 0x21;
        public const byte CM2_MIFARE_PLUS_SL3_BLOCK_WRITE = 0x22;
        public const byte CM2_MIFARE_PLUS_SL3_READ_VALUE = 0x23;
        public const byte CM2_MIFARE_PLUS_SL3_WRITE_VALUE = 0x24;
        public const byte CM2_MIFARE_PLUS_SL3_INC = 0x25;
        public const byte CM2_MIFARE_PLUS_SL3_DEC = 0x26;
        public const byte CM2_MIFARE_PLUS_SL3_TRAN = 0x27;
        public const byte CM2_MIFARE_PLUS_SL3_RESOTE = 0x28;
        public const byte CM2_MIFARE_PLUS_SL3_INC_TRAN = 0x29;
        public const byte CM2_MIFARE_PLUS_SL3_DEC_TRAN = 0x2A;
        public const byte CM2_MIFARE_PLUS_SL3_AUTH = 0x2B;
        public const byte CM2_MIFARE_PLUS_SL3_KEY_CHANGE = 0x2C;

        //Mifare Classic
        public const byte CM2_MIFARE_ACTIVEL = 0x20;
        public const byte CM2_MIFARE_AUTH = 0x21;
        public const byte CM2_MIFARE_BLOCK_READ = 0x22;
        public const byte CM2_MIFARE_SECTOR_READ = 0x23;
        public const byte CM2_MIFARE_BLOCK_WRITE = 0x24;
        public const byte CM2_MIFARE_SECTOR_WRITE = 0x25;
        public const byte CM2_MIFARE_PURSE_CREATE = 0x26;
        public const byte CM2_MIFARE_PURSE_READ = 0x27;
        public const byte CM2_MIFARE_INC = 0x28;
        public const byte CM2_MIFARE_DEC = 0x29;
        public const byte CM2_MIFARE_TRANSFER = 0x2A;
        public const byte CM2_MIFARE_RESTORE = 0x2B;
        public const byte CM2_MIFARE_INC_TRAN = 0x2C;
        public const byte CM2_MIFARE_DEC_TRAN = 0x2D;
        public const byte CM2_MIFARE_RESTORE_TRAN = 0x2E;


        // ISO7816
        public const byte CM2_USIM_ACTIVE = 0x20;
        public const byte CM2_USIM_DEACTIVE = 0x21;
        public const byte CM2_USIM_TPDU_COMMAND = 0x22;


        public enum IS_STATUS
        {
            IS_OK = 0,
            IS_INVALID_HANDLE,
            IS_DEVICE_NOT_FOUND,
            IS_DEVICE_NOT_OPENED,
            IS_IO_ERROR,
            IS_INSUFFICIENT_RESOURCES,
            IS_INVALID_PARAMETER,
            IS_INVALID_BAUD_RATE,

            IS_DEVICE_NOT_OPENED_FOR_ERASE,
            IS_DEVICE_NOT_OPENED_FOR_WRITE,
            IS_FAILED_TO_WRITE_DEVICE,
            IS_EEPROM_READ_FAILED,
            IS_EEPROM_WRITE_FAILED,
            IS_EEPROM_ERASE_FAILED,
            IS_EEPROM_NOT_PRESENT,
            IS_EEPROM_NOT_PROGRAMMED,
            IS_INVALID_ARGS,
            IS_NOT_SUPPORTED,
            IS_OTHER_ERROR,
            IS_DEVICE_LIST_NOT_READY,
            IS_TIME_OUT,
            IS_NO_TAG,
            IS_UNABLE_TO_LOAD_LIBRARY,
        };
        IntPtr hFTD2XXDLL = IntPtr.Zero;
        //
        IntPtr pis_GetDeviceNumber = IntPtr.Zero;
        IntPtr pis_SetTimeOut = IntPtr.Zero;
        IntPtr pis_GetTimeOut = IntPtr.Zero;
        IntPtr pis_OpenSerialNumber = IntPtr.Zero;
        IntPtr pis_OpenDescription = IntPtr.Zero;
        IntPtr pis_OpenDeviceNumber = IntPtr.Zero;
        IntPtr pis_Close = IntPtr.Zero;
        IntPtr pis_GetSerialNumberCExt = IntPtr.Zero;
        IntPtr pis_GetDescriptionCExt = IntPtr.Zero;
        IntPtr pis_SetSerialNumber = IntPtr.Zero;
        IntPtr pis_GetCOMPort_NoConnect = IntPtr.Zero;
        IntPtr pis_GetCOMPort = IntPtr.Zero;

        IntPtr pis_WriteCommand = IntPtr.Zero;
        IntPtr pis_ReadExCommand = IntPtr.Zero;
        IntPtr pis_ReadCommand = IntPtr.Zero;
        IntPtr pis_WriteReadCommand = IntPtr.Zero;


        public isD2xx()
        {
            // If FTD2XX.DLL is NOT loaded already, load it
            if (hFTD2XXDLL == IntPtr.Zero)
            {
                // Load our FTD2XX.DLL library
                hFTD2XXDLL = LoadLibrary(@"IS_D2XX.DLL");
                if (hFTD2XXDLL == IntPtr.Zero)
                {
                    //Error

                }
            }

            // If we have succesfully loaded the library, get the function pointers set up
            if (hFTD2XXDLL != IntPtr.Zero)
            {
                FindFunctionPointers();
            }
            else
            {
                // Failed to load our DLL - alert the user

            }
        }

        ~isD2xx()
        {
            // FreeLibrary here - we should only do this if we are completely finished
            FreeLibrary(hFTD2XXDLL);
            hFTD2XXDLL = IntPtr.Zero;
        }

        private void FindFunctionPointers()
        {
            // Set up our function pointers for use through our exported methods
            //
            pis_GetDeviceNumber = GetProcAddress(hFTD2XXDLL, "is_GetDeviceNumber");
            pis_SetTimeOut = GetProcAddress(hFTD2XXDLL, "is_SetTimeOut");
            pis_GetTimeOut = GetProcAddress(hFTD2XXDLL, "is_GetTimeOut");
            pis_OpenSerialNumber = GetProcAddress(hFTD2XXDLL, "is_OpenSerialNumber");
            pis_OpenDescription = GetProcAddress(hFTD2XXDLL, "is_OpenDescription");
            pis_OpenDeviceNumber = GetProcAddress(hFTD2XXDLL, "is_OpenDeviceNumber");
            pis_Close = GetProcAddress(hFTD2XXDLL, "is_Close");
            pis_GetSerialNumberCExt = GetProcAddress(hFTD2XXDLL, "is_GetSerialNumberCExt");
            pis_GetDescriptionCExt = GetProcAddress(hFTD2XXDLL, "is_GetDescriptionCExt");
            pis_SetSerialNumber = GetProcAddress(hFTD2XXDLL, "is_SetSerialNumber");
            pis_GetCOMPort_NoConnect = GetProcAddress(hFTD2XXDLL, "is_GetCOMPort_NoConnect");
            pis_GetCOMPort = GetProcAddress(hFTD2XXDLL, "is_GetCOMPort");
            pis_WriteCommand = GetProcAddress(hFTD2XXDLL, "is_WriteCommand");
            pis_ReadExCommand = GetProcAddress(hFTD2XXDLL, "is_ReadExCommand");
            pis_ReadCommand = GetProcAddress(hFTD2XXDLL, "is_ReadCommand");
            pis_WriteReadCommand = GetProcAddress(hFTD2XXDLL, "is_WriteReadCommand");
        }
        
        //
        public IS_STATUS GetDeviceNumber(ref short DeviceNumber)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_GetDeviceNumber != IntPtr.Zero)
            {
                tis_GetDeviceNumber is_GetDeviceNumber = (tis_GetDeviceNumber)Marshal.GetDelegateForFunctionPointer(pis_GetDeviceNumber, typeof(tis_GetDeviceNumber));
                ftStatus = (IS_STATUS)is_GetDeviceNumber(ref DeviceNumber);
            }
            return ftStatus;
        }

        public IS_STATUS SetTimeOut(IntPtr ftHandle, UInt32 readTimeOut_milliseconds, UInt32 writeTimeOut_milliseconds)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_SetTimeOut != IntPtr.Zero)
            {
                tis_SetTimeOut is_SetTimeOut = (tis_SetTimeOut)Marshal.GetDelegateForFunctionPointer(pis_SetTimeOut, typeof(tis_SetTimeOut));
                ftStatus = (IS_STATUS)is_SetTimeOut(ftHandle, readTimeOut_milliseconds, writeTimeOut_milliseconds);
            }
            return ftStatus;
        }


        public IS_STATUS GetTimeOut(IntPtr ftHandle, ref UInt32 readTimeOut_milliseconds, ref UInt32 writeTimeOut_milliseconds)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_GetTimeOut != IntPtr.Zero)
            {
                tis_GetTimeOut is_GetTimeOut = (tis_GetTimeOut)Marshal.GetDelegateForFunctionPointer(pis_GetTimeOut, typeof(tis_GetTimeOut));
                ftStatus = (IS_STATUS)is_GetTimeOut(ftHandle, ref readTimeOut_milliseconds, ref writeTimeOut_milliseconds);
            }
            return ftStatus;
        }

        public IS_STATUS OpenSerialNumber(ref IntPtr ftHandle, byte[] SerialNumberReadBuffer, long BaudRate)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_OpenSerialNumber != IntPtr.Zero)
            {
                tis_OpenSerialNumber is_OpenSerialNumber = (tis_OpenSerialNumber)Marshal.GetDelegateForFunctionPointer(pis_OpenSerialNumber, typeof(tis_OpenSerialNumber));
                ftStatus = (IS_STATUS)is_OpenSerialNumber(ref ftHandle, SerialNumberReadBuffer, BaudRate);
            }
            return ftStatus;
        }

        public IS_STATUS OpenDescription(ref IntPtr ftHandle, byte[] DescriptionReadBuffer, long BaudRate)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_OpenDescription != IntPtr.Zero)
            {
                tis_OpenDescription is_OpenDescription = (tis_OpenDescription)Marshal.GetDelegateForFunctionPointer(pis_OpenDescription, typeof(tis_OpenDescription));
                ftStatus = (IS_STATUS)is_OpenDescription(ref ftHandle, DescriptionReadBuffer, BaudRate);
            }
            return ftStatus;
        }

        public IS_STATUS OpenDeviceNumber(long deviceNumber, ref IntPtr ftHandle)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_OpenDeviceNumber != IntPtr.Zero)
            {
                tis_OpenDeviceNumber is_OpenDeviceNumber = (tis_OpenDeviceNumber)Marshal.GetDelegateForFunctionPointer(pis_OpenDeviceNumber, typeof(tis_OpenDeviceNumber));
                ftHandle = is_OpenDeviceNumber(deviceNumber);
            }

            if (ftStatus != 0)
                ftStatus = IS_STATUS.IS_OK;
            return ftStatus;
        }

        public IS_STATUS Close(IntPtr ftHandle)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_IO_ERROR;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_Close != IntPtr.Zero)
            {
                tis_Close is_Close = (tis_Close)Marshal.GetDelegateForFunctionPointer(pis_Close, typeof(tis_Close));
                ftStatus = (IS_STATUS)is_Close(ftHandle);
            }
            return ftStatus;
        }

        public IS_STATUS GetDescriptionExt(long deviceNumber, byte[] DescriptionReadBuffer, ref short DescriptionLength)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            IntPtr ftHandle = IntPtr.Zero;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            if(OpenDeviceNumber(deviceNumber, ref ftHandle) == IS_STATUS.IS_OK)
            {
                ftStatus = GetDescriptionCExt(ftHandle, DescriptionReadBuffer, ref DescriptionLength);
            }
	    Close(ftHandle);
            return ftStatus;
        }


        public IS_STATUS GetSerialNumberExt(long deviceNumber, byte[] SerialNumberReadBuffer, ref short SerialLength)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            IntPtr ftHandle = IntPtr.Zero;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            if (OpenDeviceNumber(deviceNumber, ref ftHandle) == IS_STATUS.IS_OK)
            {
                ftStatus = GetSerialNumberCExt(ftHandle, SerialNumberReadBuffer, ref SerialLength);
            }
	    Close(ftHandle);
            return ftStatus;
        }
        public IS_STATUS GetSerialNumberCExt(IntPtr ftHandle, byte[] SerialNumberReadBuffer, ref short SerialLength)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_GetSerialNumberCExt != IntPtr.Zero)
            {
                tis_GetSerialNumberCExt is_GetSerialNumberCExt = (tis_GetSerialNumberCExt)Marshal.GetDelegateForFunctionPointer(pis_GetSerialNumberCExt, typeof(tis_GetSerialNumberCExt));
                ftStatus = (IS_STATUS)is_GetSerialNumberCExt(ftHandle, SerialNumberReadBuffer, ref SerialLength);
            }
            return ftStatus;
        }



        public IS_STATUS GetDescriptionCExt(IntPtr ftHandle, byte[] DescriptionReadBuffer, ref short DescriptionLength)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_GetDescriptionCExt != IntPtr.Zero)
            {
                tis_GetDescriptionCExt is_GetDescriptionCExt = (tis_GetDescriptionCExt)Marshal.GetDelegateForFunctionPointer(pis_GetDescriptionCExt, typeof(tis_GetDescriptionCExt));
                ftStatus = (IS_STATUS)is_GetDescriptionCExt(ftHandle, DescriptionReadBuffer, ref DescriptionLength);
            }
            return ftStatus;
        }

        

        public IS_STATUS GetCOMPort_NoConnect(long DeviceNumber, ref long comPor)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_GetCOMPort_NoConnect != IntPtr.Zero)
            {
                tis_GetCOMPort_NoConnect is_GetCOMPort_NoConnect = (tis_GetCOMPort_NoConnect)Marshal.GetDelegateForFunctionPointer(pis_GetCOMPort_NoConnect, typeof(tis_GetCOMPort_NoConnect));
                ftStatus = (IS_STATUS)is_GetCOMPort_NoConnect(DeviceNumber, ref comPor);
            }
	    
            return ftStatus;
        }

        public IS_STATUS GetCOMPort(IntPtr ftHandle, ref long comPor)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_GetCOMPort != IntPtr.Zero)
            {
                tis_GetCOMPort is_GetCOMPort = (tis_GetCOMPort)Marshal.GetDelegateForFunctionPointer(pis_GetCOMPort, typeof(tis_GetCOMPort));
                ftStatus = (IS_STATUS)is_GetCOMPort(ftHandle, ref comPor);
            }
            return ftStatus;
        }

        public IS_STATUS WriteCommand(IntPtr ftHandle, byte cmd1, byte cmd2, UInt16 writeLength, byte[] writeData)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_WriteCommand != IntPtr.Zero)
            {
                tis_WriteCommand is_WriteCommand = (tis_WriteCommand)Marshal.GetDelegateForFunctionPointer(pis_WriteCommand, typeof(tis_WriteCommand));
                ftStatus = (IS_STATUS)is_WriteCommand(ftHandle, cmd1, cmd2, writeLength, writeData);
            }
            return ftStatus;
        }

        public IS_STATUS ReadExCommand(IntPtr ftHandle, ref byte cmd1, ref byte cmd2, ref UInt16 length, byte[] readData)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_ReadExCommand != IntPtr.Zero)
            {
                tis_ReadExCommand is_ReadExCommand = (tis_ReadExCommand)Marshal.GetDelegateForFunctionPointer(pis_ReadExCommand, typeof(tis_ReadExCommand));
                ftStatus = (IS_STATUS)is_ReadExCommand(ftHandle, ref cmd1, ref cmd2, ref length, readData);
            }
            return ftStatus;
        }

        public IS_STATUS ReadCommand(IntPtr ftHandle, ref UInt16 length, byte[] readData)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_ReadCommand != IntPtr.Zero)
            {
                tis_ReadCommand is_ReadCommand = (tis_ReadCommand)Marshal.GetDelegateForFunctionPointer(pis_ReadCommand, typeof(tis_ReadCommand));
                ftStatus = (IS_STATUS)is_ReadCommand(ftHandle, ref length, readData);
            }
            return ftStatus;
        }

        public IS_STATUS WriteReadCommand(IntPtr ftHandle, byte cmd1, byte cmd2, UInt16 writeLength, byte[] writeData, ref UInt16 length, byte[] readData)
        {
            IS_STATUS ftStatus = IS_STATUS.IS_UNABLE_TO_LOAD_LIBRARY;
            if (hFTD2XXDLL == IntPtr.Zero)
                return ftStatus;

            // Check for our required function pointers being set up
            if (pis_WriteReadCommand != IntPtr.Zero)
            {
                tis_WriteReadCommand is_WriteReadCommand = (tis_WriteReadCommand)Marshal.GetDelegateForFunctionPointer(pis_WriteReadCommand, typeof(tis_WriteReadCommand));
                ftStatus = (IS_STATUS)is_WriteReadCommand(ftHandle, cmd1, cmd2, writeLength, writeData, ref length, readData);
            }
            return ftStatus;
        }


        //
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_GetDeviceNumber(ref short DeviceNumber);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_SetTimeOut(IntPtr ftHandle, UInt32 readTimeOut_milliseconds, UInt32 writeTimeOut_milliseconds);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_GetTimeOut(IntPtr ftHandle, ref UInt32 readTimeOut_milliseconds, ref UInt32 writeTimeOut_milliseconds);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_OpenSerialNumber(ref IntPtr ftHandle, byte[] SerialNumberReadBuffer, long BaudRate);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_OpenDescription(ref IntPtr ftHandle, byte[] DescriptionReadBuffer, long BaudRate);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr tis_OpenDeviceNumber(long deviceNumber);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_Close(IntPtr ftHandle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_GetSerialNumberCExt(IntPtr ftHandle, byte[] SerialNumberReadBuffer, ref short SerialLength);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_GetDescriptionCExt(IntPtr ftHandle, byte[] DescriptionReadBuffer, ref short SerialLength);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_SetSerialNumber(long DeviceNumber, byte[] SerialNumberReadBuffer);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_GetCOMPort_NoConnect(long DeviceNumber, ref long comPor);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_GetCOMPort(IntPtr ftHandle, ref long comPor);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_WriteCommand(IntPtr ftHandle, byte cmd1, byte cmd2, UInt16 writeLength, byte[] writeData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_ReadExCommand(IntPtr ftHandle, ref byte cmd1, ref byte cmd2, ref UInt16 length, byte[] readData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_ReadCommand(IntPtr ftHandle, ref UInt16 length, byte[] readData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int tis_WriteReadCommand(IntPtr ftHandle, byte cmd1, byte cmd2, UInt16 writeLength, byte[] writeData, ref UInt16 length, byte[] readData);

    }
}
