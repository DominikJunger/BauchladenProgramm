﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BauchladenProgrammServer.Connector
{
    sealed class Syntax
    {
        //Primitiv Typen
        public static readonly String BOOLEAN = "(true|false)",
                                      INTEGER = @"-?(0|([1-9]\d{0,9}))",
                                      STRING = @"(?<=:).*",
                                      LONG = @"-?(0|([1-9]\d{0,18}))",
                                      CUT = @".*\r\n";

        // seperators 
        public static readonly String[] SEPERATORS = { "\r\n", "\0" };

        // Characters
        public static readonly Char SPACE_CHAR = (char)32,
                                  LINE_BREAK_CHAR = (char)10,
                                  TAB_CHAR = (char)9,
                                  ESCAPE_CHAR = (char)27,
                                  COLON_CHAR = ':',
                                  ENUM_CHAR = ',',
                                  DOT_CHAR = '.',
                                  UNDERSCORE_CHAR = '_'
                                  ;

        // Strings
        // -> Keys
        public static readonly String BEGIN = "begin",
                                   END = "end",
                                   PRODUCT_LIST= "prlist",
                                   STATUS="status",
                                   MEMBER="member",
                                   PRODUKT="pr"
                                   ;

        // -> Values 
        public static readonly String 
                                   //Status
                                   OKAY = "ok",
                                   UNKNOWN = "unknown",
                                   INVALID = "invalid",
                                   //Member
                                   FIRST_NAME="fName",
                                   LAST_NAME="lName",
                                   ID="id",
                                   BANK_BALANCE="bankB",

                                   //Produkt
                                   PRODUKT_NAME="produktN",
                                   PRODUKT_PRICE="produktP"
                                   ;


    }
}