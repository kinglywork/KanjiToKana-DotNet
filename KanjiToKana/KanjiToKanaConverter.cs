using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiToKana
{
    public enum Mode
    {
        FullWidthKana = 0,
        HalfWidthKana = 1,
    }

    public static class KanjiToKanaConverter
    {
        public static string Convert(string source, Mode mode)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return source;
            }            

            GlobalInterface converter = new GlobalInterface();

            if (mode == Mode.HalfWidthKana)
            {
                return converter.GetConversion(
                    "MsIme.Japan", 
                    GlobalInterface.FELANG_REQUEST.FELANG_REQ_REV, 
                    GlobalInterface.FELANG_CMODE.FELANG_CMODE_KATAKANAOUT, 
                    source);
            }
            else if (mode == Mode.FullWidthKana)
            {
                string fullwidth = converter.GetConversion(
                    "MsIme.Japan",
                    GlobalInterface.FELANG_REQUEST.FELANG_REQ_REV,
                    GlobalInterface.FELANG_CMODE.FELANG_CMODE_KATAKANAOUT,
                    source);
                return converter.GetHalfWidthKana(fullwidth);
            }
            else
            {
                throw new InvalidOperationException("not support mode");
            }            
        }
    }
}
