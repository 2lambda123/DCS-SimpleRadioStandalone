﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciribob.DCS.SimpleRadio.Standalone.Client.Network.DCS.Models;
using Ciribob.DCS.SimpleRadio.Standalone.Client.Singletons;

namespace Ciribob.DCS.SimpleRadio.Standalone.Client.Utils
{
    public static class TransponderHelper
    {

        public static DCSTransponder GetTransponder(bool onlyIfOverlayControls = false)
        {
            var dcsPlayerRadioInfo = ClientStateSingleton.Instance.DcsPlayerRadioInfo;

            if ((dcsPlayerRadioInfo != null) && dcsPlayerRadioInfo.IsCurrent() && dcsPlayerRadioInfo.iff !=null && dcsPlayerRadioInfo.iff.control != DCSTransponder.IFFControlMode.DISABLED)
            {
                if (onlyIfOverlayControls)
                {
                    if (dcsPlayerRadioInfo.iff.control == DCSTransponder.IFFControlMode.OVERLAY)
                    {
                        return dcsPlayerRadioInfo.iff;
                    }
                }
                else
                {
                    return dcsPlayerRadioInfo.iff;
                }
            }

            return null;
        }

        public static bool ToggleIdent()
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null && trans.status != DCSTransponder.IFFStatus.OFF)
            {
                if (trans.status == DCSTransponder.IFFStatus.NORMAL)
                {
                    trans.status = DCSTransponder.IFFStatus.IDENT;
                    return true;
                }
                else
                {
                    trans.status = DCSTransponder.IFFStatus.NORMAL;
                    return true;
                }
            }

            return false;
        }

        public static bool Mode4Toggle()
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null)
            {
                trans.mode4 = !trans.mode4;
            }

            return false;
        }

        public static bool SetMode3(int mode3)
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null)
            {

                if (mode3 < 0)
                {
                    trans.mode3 = -1;
                }
                else
                {
                    var numberStr = Math.Abs(mode3).ToString().ToCharArray();

                    for (int i = 0; i < numberStr.Length; i++)
                    {
                        if (int.Parse(numberStr[i].ToString()) > 7)
                        {
                            numberStr[i] = '7';
                        }
                    }

                    trans.mode3 = int.Parse(new string(numberStr));
                }

                return true;
            }

            return false;
        }

        public static bool SetMode1(int mode1)
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null)
            {

                if (mode1 < 0)
                {
                    trans.mode1 = -1;
                }
                else
                {
                    //first digit 0-7 inc
                    //second 0-3 inc

                    int first = mode1 / 10;

                    if (first > 7)
                    {
                        first = 7;
                    }

                    if (first < 0)
                    {
                        first = 0;
                    }

                    int second = mode1 % 10;

                    if (second > 3)
                    {
                        second = 3;
                    }

                    trans.mode1 = first * 10 + second;
                }
                
                return true;
            }

            return false;
        }

        public static bool TogglePower()
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null)
            {
                if (trans.status == DCSTransponder.IFFStatus.OFF)
                {
                    trans.status = DCSTransponder.IFFStatus.NORMAL;
                }
                else
                {
                    trans.status = DCSTransponder.IFFStatus.OFF;
                }

                return true;
            }

            return false;
        }

        public static bool SetPower(bool on)
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null)
            {
                if (on)
                {
                    trans.status = DCSTransponder.IFFStatus.NORMAL;
                }
                else
                {
                    trans.status = DCSTransponder.IFFStatus.OFF;
                }

                return true;
            }

            return false;
        }

        public static bool SetMode4(bool on)
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null)
            {
                trans.mode4 = on;
                return true;
            }

            return false;
        }

        public static bool SetIdent(bool on)
        {
            ClientStateSingleton.Instance.LastSent = 0;
            var trans = GetTransponder(true);

            if (trans != null && trans.status != DCSTransponder.IFFStatus.OFF)
            {
                if (on)
                {
                    trans.status = DCSTransponder.IFFStatus.IDENT;
                }
                else
                {
                    trans.status = DCSTransponder.IFFStatus.NORMAL;
                }

                return true;
            }

            return false;
        }
    }
}
